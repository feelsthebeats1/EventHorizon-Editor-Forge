using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Windows.Forms;
using DatabaseMigration;
using EditorDatabase;
using EditorDatabase.DataModel;
using EditorDatabase.Enums;
using EditorDatabase.Model;
using EditorDatabase.Serializable;
using EditorDatabase.Storage;
using Newtonsoft.Json;

namespace GameDatabase
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            fileToolStripMenuItem.DropDownItems.Add("Convert satellite lists", null, ConvertSatelliteLists_Click);
        }

        private void MainWindow_Load(object sender, EventArgs eventArgs)
        {
            var args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
                OpenDatabase(args[1]);
            else
                OpenDatabase(Directory.GetCurrentDirectory());
        }

        private void OpenDatabase(string path)
        {
            try
            {
                DatabaseTreeView.Nodes.Clear();
                var storage = new DatabaseStorage(path);
                storage.LoadDatabaseVersion();
                var result = storage.Version.Compare(Database.VersionMajor, Database.VersionMinor);
                if (result > 0)
                    throw new InvalidOperationException($"Database version in not supported - {storage.Version}. Must be {Database.VersionMajor}.{Database.VersionMinor} or less.");
                if (result < 0)
                {
                    var dialogResult = MessageBox.Show($"Database version is outdated - {storage.Version}. Do you want to upgrade it to {Database.VersionMajor}.{Database.VersionMinor}?",
                        "Warning", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                        _database = UpgradeDatabase(storage, path);
                }
                else
                {
                    _database = new Database(storage);
                }

                BuildFilesTree(path, DatabaseTreeView.Nodes);
                _lastDatabasePath = path;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " " + e.StackTrace);
            }
        }

        private static Database UpgradeDatabase(IDataStorage storage, string path)
        {
            Console.WriteLine("Upgrading Database ...");
            var database = Database.MigrateFrom(storage);
            database.Save(new DatabaseStorage(path));
            Console.WriteLine($"Database upgraded - {database.DatabaseSettings.DatabaseVersion}.{database.DatabaseSettings.DatabaseVersionMinor}");
            return database;
        }

        // A mod upgraded by an earlier 1.8 build still holds exclusion lists. Move them onto the
        // Satellite records. Read the folder directly: BlackMarketSettings.json stops the load.
        private void ConvertSatelliteLists_Click(object sender, EventArgs e)
        {
            using var dialog = new FolderBrowserDialog
            {
                Description = "Select the mod folder that still holds BlackMarketSettings.json or an ExcludedSatellites field.",
            };
            if (dialog.ShowDialog() != DialogResult.OK) return;

            MessageBox.Show(SatelliteListConverter.Convert(dialog.SelectedPath));
        }

        private void BuildFilesTree(string path, TreeNodeCollection nodeCollection)
        {
            try
            {
                foreach (var directory in Directory.EnumerateDirectories(path))
                {
                    var name = directory.Substring(directory.LastIndexOf("\\", StringComparison.OrdinalIgnoreCase) + 1);
                    var node = nodeCollection.Add(directory, name);
                    BuildFilesTree(directory, node.Nodes);
                }

                foreach (var file in Directory.EnumerateFiles(path, "*.json", SearchOption.TopDirectoryOnly))
                    nodeCollection.Add(file, Helpers.FileName(file));
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
        }

        private void DatabaseTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ShowItemInfo(e.Node.Name);
        }

        private void ShowItemInfo(string path)
        {
            try
            {
                ItemTypeText.Text = @"-";
                _selectedItem = new SerializableItem();
                EditButton.Enabled = false;

                if (Directory.Exists(path))
                {
                    ItemTypeText.Text = @"Directory";
                    structDataView1.Data = GetDirectoryInfo(path);
                    return;
                }

                var data = File.ReadAllText(path);
                var name = Helpers.FileName(path);
                var item = JsonConvert.DeserializeObject<SerializableItem>(data);
                item.FileName = name;
                if ((ItemType)item.ItemType == ItemType.Undefined)
                    return;

                ItemTypeText.Text = ((ItemType)item.ItemType).ToString();
                _selectedItem = item;

                structDataView1.Database = _database;
                structDataView1.Data = GetItem();

                EditButton.Enabled = true;
            }
            catch (Exception)
            {
                //MessageBox.Show(e.Message);
            }
        }

        private struct DirectoryInfoData
        {
            public NumericValue<int> FilesCount;
            public ItemType ItemTypes;
			public NumericValue<int> FirstItemId;
			public NumericValue<int> LastItemId;
            public NumericValue<int> FirstUnusedId;
        }

        private DirectoryInfoData GetDirectoryInfo(string path)
        {
            DirectoryInfoData data = new DirectoryInfoData
            {
                FilesCount = new NumericValue<int>(0, 0, int.MaxValue),
                ItemTypes = ItemType.Undefined,
				FirstItemId = new NumericValue<int>(0, 0, int.MaxValue),
				LastItemId = new NumericValue<int>(0, 0, int.MaxValue),
                FirstUnusedId = new NumericValue<int>(0, 0, int.MaxValue),
            };

            try
            {
                var ids = new SortedSet<int>();
                foreach (var file in Directory.EnumerateFiles(path, "*.json", SearchOption.TopDirectoryOnly))
                {
                    var text = File.ReadAllText(file);
                    var item = JsonConvert.DeserializeObject<SerializableItem>(text);

                    data.FilesCount.Value++;

                    if (item.ItemType == ItemType.Undefined)
                        continue;

                    ids.Add(item.Id);

                    if (data.ItemTypes == ItemType.Undefined)
                        data.ItemTypes = item.ItemType;
                }

				if (ids.Count == 0)
				{
					data.FilesCount.Value = 0;
					data.FirstItemId.Value = 0;
					data.LastItemId.Value = 0;
					data.FirstUnusedId.Value = 1;
				}
				else
				{
					var lastId = ids.First();
					data.FirstItemId.Value = lastId;
					data.LastItemId.Value = ids.Last();
					data.FirstUnusedId.Value = data.LastItemId.Value + 1;
					data.FilesCount.Value = ids.Count;

					foreach (var id in ids.Skip(1))
					{
						if (id - lastId > 1)
						{
							data.FirstUnusedId.Value = lastId + 1;
							break;
						}
						lastId = id;
					}
				}
			}
			catch (Exception)
            {
            }

            return data;
        }

        private void DatabaseTreeView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EditButton_Click(sender, e);
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            var item = GetItem();
            if (item == null)
                return;

            switch (_selectedItem.ItemType)
            {
                case ItemType.Component:
                    new ComponentEditorDialog(_database, (Component)item).ShowDialog();
                    break;
                case ItemType.Satellite:
                case ItemType.Ship:
                    new ShipEditorDialog(_database, item, _selectedItem.FileName).ShowDialog();
                    break;
                default:
                    new EditorDialog(_database, item, _selectedItem.FileName).ShowDialog();
                    break;
            }
        }

        private object GetItem()
        {
            return _database.GetItem(_selectedItem.ItemType, _selectedItem.Id);
        }

        private void loadMenuItem_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                OpenDatabase(folderBrowserDialog1.SelectedPath);
            }
        }

        private void saveAsMenuItem_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                if (!ConfirmZeroIdRecords()) return;
                _database.Save(new DatabaseStorage(folderBrowserDialog1.SelectedPath));
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_lastDatabasePath)) return;
            if (!ConfirmZeroIdRecords()) return;
            _database.Save(new DatabaseStorage(_lastDatabasePath));
        }

        // A record with id 0 loses its id line on save: the writer drops every field equal to the
        // default, and 0 is that default. Ask once per session per record instead of failing quietly.
        private readonly HashSet<string> _zeroIdWarned = new();

        private bool ConfirmZeroIdRecords()
        {
            var offenders = _database.GetAllItems()
                .Select(item => item.GetType().GetField("Id")?.GetValue(item) as IItemId)
                .Where(id => id != null && id.Value == 0)
                .Select(id => id.ItemType.Name + "  " + id.Name)
                .Distinct()
                .OrderBy(item => item)
                .ToList();

            var fresh = offenders.Where(item => _zeroIdWarned.Add(item)).ToList();
            if (fresh.Count == 0) return true;

            var message = "These records have id 0. Saving drops their id line:\n\n" +
                string.Join("\n", fresh) + "\n\nUse a positive id instead. Save anyway?";
            return MessageBox.Show(message, "Record id 0", MessageBoxButtons.YesNo) == DialogResult.Yes;
        }

        private void createModMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_lastDatabasePath))
                return;

            try
            {
                if (!ModBuilder.TryReadSignature(_lastDatabasePath, out var name, out var guid))
                {
                    var dialog = new NameForm();
                    if (dialog.ShowDialog() != DialogResult.OK || string.IsNullOrWhiteSpace(dialog.Name))
                        return;

                    name = dialog.Name;
                    guid = Guid.NewGuid().ToString();

                    File.WriteAllText(Path.Combine(_lastDatabasePath, ModBuilder.SignatureFileName), name + '\n' + guid );
                }

                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                if (!ConfirmZeroIdRecords()) return;

                _database.Save(new DatabaseStorage(_lastDatabasePath));
                var builder = ModBuilder.Create(_lastDatabasePath, 
                    _database.DatabaseSettings.DatabaseVersion.Value, 
                    _database.DatabaseSettings.DatabaseVersionMinor.Value);

                builder.Build((FileStream)saveFileDialog.OpenFile());
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private SerializableItem _selectedItem;
        private Database _database;
        private string _lastDatabasePath;
    }
}
