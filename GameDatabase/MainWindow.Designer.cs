using GameDatabase.Controls;

namespace GameDatabase
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DatabaseEditor.Properties.Settings settings1 = new DatabaseEditor.Properties.Settings();
            DatabaseTreeView = new TreeView();
            splitContainer = new SplitContainer();
            structDataView1 = new StructDataView();
            EditButton = new Button();
            ItemTypeText = new Label();
            ItemTypeLabel = new Label();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            loadMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsMenuItem = new ToolStripMenuItem();
            createModMenuItem = new ToolStripMenuItem();
            folderBrowserDialog1 = new FolderBrowserDialog();
            saveFileDialog = new SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // DatabaseTreeView
            // 
            DatabaseTreeView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DatabaseTreeView.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DatabaseTreeView.Location = new Point(6, 3);
            DatabaseTreeView.Margin = new Padding(4, 5, 4, 5);
            DatabaseTreeView.Name = "DatabaseTreeView";
            DatabaseTreeView.Size = new Size(383, 568);
            DatabaseTreeView.TabIndex = 0;
            DatabaseTreeView.AfterSelect += DatabaseTreeView_AfterSelect;
            DatabaseTreeView.MouseDoubleClick += DatabaseTreeView_MouseDoubleClick;
            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Location = new Point(0, 24);
            splitContainer.Margin = new Padding(4, 5, 4, 5);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(DatabaseTreeView);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(structDataView1);
            splitContainer.Panel2.Controls.Add(EditButton);
            splitContainer.Panel2.Controls.Add(ItemTypeText);
            splitContainer.Panel2.Controls.Add(ItemTypeLabel);
            splitContainer.Size = new Size(800, 576);
            splitContainer.SplitterDistance = 393;
            splitContainer.SplitterWidth = 6;
            splitContainer.TabIndex = 1;
            // 
            // structDataView1
            // 
            structDataView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            structDataView1.BackColor = Color.WhiteSmoke;
            structDataView1.BorderStyle = BorderStyle.FixedSingle;
            structDataView1.Data = null;
            structDataView1.Database = null;
            structDataView1.ForeColor = Color.DimGray;
            structDataView1.Location = new Point(8, 41);
            structDataView1.Margin = new Padding(4, 5, 4, 5);
            structDataView1.Name = "structDataView1";
            structDataView1.Size = new Size(379, 483);
            structDataView1.TabIndex = 5;
            // 
            // EditButton
            // 
            EditButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            EditButton.Enabled = false;
            EditButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EditButton.Location = new Point(8, 534);
            EditButton.Margin = new Padding(4, 5, 4, 5);
            EditButton.Name = "EditButton";
            EditButton.Size = new Size(112, 35);
            EditButton.TabIndex = 4;
            EditButton.TabStop = false;
            EditButton.Text = "Edit";
            EditButton.UseVisualStyleBackColor = true;
            EditButton.Click += EditButton_Click;
            // 
            // ItemTypeText
            // 
            ItemTypeText.AutoSize = true;
            ItemTypeText.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ItemTypeText.Location = new Point(90, 3);
            ItemTypeText.Margin = new Padding(4, 0, 4, 0);
            ItemTypeText.Name = "ItemTypeText";
            ItemTypeText.Size = new Size(14, 20);
            ItemTypeText.TabIndex = 3;
            ItemTypeText.Text = "-";
            // 
            // ItemTypeLabel
            // 
            ItemTypeLabel.AutoSize = true;
            ItemTypeLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ItemTypeLabel.Location = new Point(3, 3);
            ItemTypeLabel.Margin = new Padding(4, 0, 4, 0);
            ItemTypeLabel.Name = "ItemTypeLabel";
            ItemTypeLabel.Size = new Size(79, 20);
            ItemTypeLabel.TabIndex = 2;
            ItemTypeLabel.Text = "Item type:";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadMenuItem, saveToolStripMenuItem, saveAsMenuItem, createModMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // loadMenuItem
            // 
            loadMenuItem.Name = "loadMenuItem";
            loadMenuItem.Size = new Size(145, 22);
            loadMenuItem.Text = "Load";
            loadMenuItem.Click += loadMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(145, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // saveAsMenuItem
            // 
            saveAsMenuItem.Name = "saveAsMenuItem";
            saveAsMenuItem.Size = new Size(145, 22);
            saveAsMenuItem.Text = "Save As...";
            saveAsMenuItem.Click += saveAsMenuItem_Click;
            // 
            // createModMenuItem
            // 
            createModMenuItem.Name = "createModMenuItem";
            createModMenuItem.Size = new Size(145, 22);
            createModMenuItem.Text = "Create Mod...";
            createModMenuItem.Click += createModMenuItem_Click;
            // 
            // saveFileDialog
            // 
            saveFileDialog.AddExtension = false;
            saveFileDialog.FileName = "mod";
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 600);
            Controls.Add(splitContainer);
            Controls.Add(menuStrip1);
            settings1.EditorPosition = new Point(100, 100);
            settings1.EditorSize = new Size(400, 400);
            settings1.MainPosition = new Point(100, 100);
            settings1.MainSize = new Size(800, 600);
            settings1.SettingsKey = "";
            settings1.ShipEditorHorizontalSplitter = 272;
            settings1.ShipEditorPosition = new Point(100, 100);
            settings1.ShipEditorSize = new Size(800, 600);
            settings1.ShipEditorVerticalSplitter = 364;
            DataBindings.Add(new Binding("Location", settings1, "MainPosition", true, DataSourceUpdateMode.OnPropertyChanged));
            DataBindings.Add(new Binding("ClientSize", settings1, "MainSize", true, DataSourceUpdateMode.OnPropertyChanged));
            Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Location = new Point(100, 100);
            Margin = new Padding(4, 5, 4, 5);
            Name = "MainWindow";
            Text = "Game database";
            Load += MainWindow_Load;
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView DatabaseTreeView;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Label ItemTypeText;
        private System.Windows.Forms.Label ItemTypeLabel;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private Controls.StructDataView structDataView1;
        private System.Windows.Forms.ToolStripMenuItem createModMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

