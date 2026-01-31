using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EditorDatabase;
using EditorDatabase.Model;

namespace GameDatabase.Controls
{
    public partial class StructDataView : UserControl
    {
        [Description("Data"), Category("Data")]
        public object Data
        {
            get { return _data; }
            set
            {
                _data = value;
                BuildLayout();
            }
        }

        [Description("Database"), Category("Data")]
        public Database Database
        {
            get { return _database; }
            set { _database = value; }
        }

        public StructDataView()
        {
            InitializeComponent();
        }

        private void Cleanup()
        {
            tableLayoutPanel.Controls.Clear();
            tableLayoutPanel.RowStyles.Clear();
        }

        private void BuildLayout()
        {
            Cleanup();

            if (_data == null)
                return;

            var type = _data.GetType();
            var fields = type.GetFields().Where(f => f.IsPublic && !f.IsStatic).ToDictionary(field => field.Name);

            var rowCount = fields.Count;
            tableLayoutPanel.Controls.Clear();
            tableLayoutPanel.RowCount = rowCount + 1;

            tableLayoutPanel.SuspendLayout();
            for (var i = 0; i <= tableLayoutPanel.RowCount; ++i)
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            var rowId = 0;
            foreach (var item in fields)
            {
                var value = item.Value.GetValue(_data);
                if (null != CreateControl(value, rowId))
                {
                    CreateLabel(item.Key, 0, rowId);
                    rowId++;
                }
            }

            tableLayoutPanel.ResumeLayout();
        }

        private object CreateControl(object value, int rowId)
        {
            if (value == null)
                return null;

            var valueType = value.GetType();
            if (valueType.IsEnum)
            {
                //if ((int)value == default(int))
                //    return null;

                return CreateLabel(value.ToString(), 1, rowId);
            }

            if (valueType == typeof(NumericValue<int>))
            {
                var numeric = (NumericValue<int>)value;

                //if (numeric.Value == 0)
                //    return null;

                return CreateLabel(numeric.Value.ToString(), 1, rowId);
            }

            if (valueType == typeof(NumericValue<float>))
            {
                var numeric = (NumericValue<float>)value;

                //if (Math.Abs(numeric.Value) < float.Epsilon)
                //    return null;

                return CreateLabel(numeric.Value.ToString(), 1, rowId);
            }

            if (valueType == typeof(bool))
                return CreateLabel(value.ToString(), 1, rowId);

            if (valueType == typeof (Color))
                return CreateLabel(Helpers.ColorToString((Color)value), 1, rowId);

            if (valueType == typeof (Layout))
                return null; //CreateLayout((Layout)value, 1, rowId);

            if (valueType.IsArray)
            {
                var array = (object[]) value;

                //if (array.Length == 0)
                //    return null;

                return CreateLabel(string.Join("\n", array), 1, rowId);
            }

            if (valueType == typeof (Vector2))
                return CreateLabel(value.ToString(), 1, rowId);

            if (value is IItemId)
            {
                var itemid = (IItemId)value;

                //if (itemid.IsNull)
                //    return null;

                return CreateLabel(value.ToString(), 1, rowId);
            }
            
            if (valueType.IsClass)
            {
                return CreateStructView(value, 1, rowId);
            }
            return null;
        }

        private Label CreateLabel(string text, int column, int row)
        {
            var label = new Label()
            {
                Text = text,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left,
                BorderStyle = BorderStyle.None,
                Dock = DockStyle.Fill,
                AutoSize = true,
            };

            tableLayoutPanel.Controls.Add(label, column, row);
            return label;
        }

        private object _data;
        private Database _database;
        
        private Control CreateStructView(object data, int column, int row)
        {
            var view = new StructDataView
            {
                Dock = DockStyle.Fill,
                AutoSize = true,
                Database = _database,
                Data = new DataAdapter(data),
            };

            tableLayoutPanel.Controls.Add(view, column, row);
            return view;
        }    
    }
}
