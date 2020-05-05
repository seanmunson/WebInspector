namespace WindowsFormsApplication2
{
    partial class Form1
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
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.lstObjects = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbMissing = new System.Windows.Forms.Label();
            this.lstMissing = new System.Windows.Forms.ListBox();
            this.lstDepends = new System.Windows.Forms.ListBox();
            this.lstSupports = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdFindTextinFiles = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.txtElementNameToFind = new System.Windows.Forms.TextBox();
            this.txtTextToFind = new System.Windows.Forms.TextBox();
            this.btnFindText = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblSortOb = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearchText = new System.Windows.Forms.TextBox();
            this.cmdFindText = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.wordWrapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtAddressBar = new System.Windows.Forms.TextBox();
            this.txtSleuthFileNameList = new System.Windows.Forms.TextBox();
            this.cmdSleuth = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cmdWordCount = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFromRootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToSQLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findCommonDependenciesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstFiles
            // 
            this.lstFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.Location = new System.Drawing.Point(12, 89);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(516, 433);
            this.lstFiles.TabIndex = 4;
            this.lstFiles.SelectedIndexChanged += new System.EventHandler(this.lstFiles_SelectedIndexChanged);
            this.lstFiles.DoubleClick += new System.EventHandler(this.lst_DoubleClick);
            this.lstFiles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstObjects_KeyDown);
            // 
            // lstObjects
            // 
            this.lstObjects.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lstObjects.FormattingEnabled = true;
            this.lstObjects.Location = new System.Drawing.Point(12, 545);
            this.lstObjects.Name = "lstObjects";
            this.lstObjects.Size = new System.Drawing.Size(315, 199);
            this.lstObjects.TabIndex = 6;
            this.lstObjects.SelectedIndexChanged += new System.EventHandler(this.lstObjects_SelectedIndexChanged_1);
            this.lstObjects.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstObjects_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "File components";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 529);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "COM / Object Components";
            // 
            // lbMissing
            // 
            this.lbMissing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbMissing.AutoSize = true;
            this.lbMissing.Location = new System.Drawing.Point(343, 529);
            this.lbMissing.Name = "lbMissing";
            this.lbMissing.Size = new System.Drawing.Size(114, 13);
            this.lbMissing.TabIndex = 10;
            this.lbMissing.Text = "Missing/Unknown files";
            // 
            // lstMissing
            // 
            this.lstMissing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lstMissing.FormattingEnabled = true;
            this.lstMissing.Location = new System.Drawing.Point(343, 545);
            this.lstMissing.Name = "lstMissing";
            this.lstMissing.Size = new System.Drawing.Size(283, 199);
            this.lstMissing.TabIndex = 9;
            this.lstMissing.SelectedIndexChanged += new System.EventHandler(this.lstFiles_SelectedIndexChanged);
            this.lstMissing.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstObjects_KeyDown);
            // 
            // lstDepends
            // 
            this.lstDepends.FormattingEnabled = true;
            this.lstDepends.Location = new System.Drawing.Point(537, 348);
            this.lstDepends.Name = "lstDepends";
            this.lstDepends.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstDepends.Size = new System.Drawing.Size(89, 173);
            this.lstDepends.TabIndex = 11;
            this.lstDepends.SelectedIndexChanged += new System.EventHandler(this.lstDepends_SelectedIndexChanged);
            this.lstDepends.DoubleClick += new System.EventHandler(this.lstDepends_DoubleClick);
            this.lstDepends.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstObjects_KeyDown);
            // 
            // lstSupports
            // 
            this.lstSupports.FormattingEnabled = true;
            this.lstSupports.Location = new System.Drawing.Point(537, 91);
            this.lstSupports.Name = "lstSupports";
            this.lstSupports.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstSupports.Size = new System.Drawing.Size(89, 238);
            this.lstSupports.TabIndex = 12;
            this.lstSupports.SelectedIndexChanged += new System.EventHandler(this.lstSupports_SelectedIndexChanged);
            this.lstSupports.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstObjects_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(534, 332);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Depends on ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(534, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Supports";
            // 
            // cmdFindTextinFiles
            // 
            this.cmdFindTextinFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdFindTextinFiles.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdFindTextinFiles.HideSelection = false;
            this.cmdFindTextinFiles.Location = new System.Drawing.Point(632, 89);
            this.cmdFindTextinFiles.Multiline = true;
            this.cmdFindTextinFiles.Name = "cmdFindTextinFiles";
            this.cmdFindTextinFiles.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.cmdFindTextinFiles.Size = new System.Drawing.Size(608, 655);
            this.cmdFindTextinFiles.TabIndex = 18;
            this.cmdFindTextinFiles.WordWrap = false;
            this.cmdFindTextinFiles.TextChanged += new System.EventHandler(this.cmdFindTextinFiles_TextChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1230, 61);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(22, 23);
            this.button3.TabIndex = 19;
            this.button3.Text = "☓";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtElementNameToFind
            // 
            this.txtElementNameToFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtElementNameToFind.Location = new System.Drawing.Point(102, 64);
            this.txtElementNameToFind.Name = "txtElementNameToFind";
            this.txtElementNameToFind.Size = new System.Drawing.Size(200, 22);
            this.txtElementNameToFind.TabIndex = 20;
            this.txtElementNameToFind.Text = "*.css";
            // 
            // txtTextToFind
            // 
            this.txtTextToFind.Location = new System.Drawing.Point(969, 35);
            this.txtTextToFind.Name = "txtTextToFind";
            this.txtTextToFind.Size = new System.Drawing.Size(197, 20);
            this.txtTextToFind.TabIndex = 22;
            // 
            // btnFindText
            // 
            this.btnFindText.Location = new System.Drawing.Point(1172, 31);
            this.btnFindText.Name = "btnFindText";
            this.btnFindText.Size = new System.Drawing.Size(46, 28);
            this.btnFindText.TabIndex = 21;
            this.btnFindText.Text = "Find";
            this.btnFindText.UseVisualStyleBackColor = true;
            this.btnFindText.Click += new System.EventHandler(this.btnFindText_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBack.Location = new System.Drawing.Point(632, 63);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(26, 25);
            this.btnBack.TabIndex = 23;
            this.btnBack.Text = "⇦";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblSortOb
            // 
            this.lblSortOb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSortOb.AutoSize = true;
            this.lblSortOb.Location = new System.Drawing.Point(308, 529);
            this.lblSortOb.Name = "lblSortOb";
            this.lblSortOb.Size = new System.Drawing.Size(19, 13);
            this.lblSortOb.TabIndex = 24;
            this.lblSortOb.Text = "☐";
            this.lblSortOb.Click += new System.EventHandler(this.lblSortOb_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(308, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "☐";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtSearchText
            // 
            this.txtSearchText.Location = new System.Drawing.Point(632, 34);
            this.txtSearchText.Name = "txtSearchText";
            this.txtSearchText.Size = new System.Drawing.Size(166, 20);
            this.txtSearchText.TabIndex = 26;
            // 
            // cmdFindText
            // 
            this.cmdFindText.Location = new System.Drawing.Point(804, 30);
            this.cmdFindText.Name = "cmdFindText";
            this.cmdFindText.Size = new System.Drawing.Size(59, 28);
            this.cmdFindText.TabIndex = 27;
            this.cmdFindText.Text = "Find Text";
            this.cmdFindText.UseVisualStyleBackColor = true;
            this.cmdFindText.Click += new System.EventHandler(this.cmdFindText_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripDropDownButton1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 759);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1252, 22);
            this.statusStrip1.TabIndex = 28;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wordWrapToolStripMenuItem});
            this.toolStripDropDownButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(13, 20);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // wordWrapToolStripMenuItem
            // 
            this.wordWrapToolStripMenuItem.Name = "wordWrapToolStripMenuItem";
            this.wordWrapToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.wordWrapToolStripMenuItem.Text = "Word Wrap";
            this.wordWrapToolStripMenuItem.Click += new System.EventHandler(this.wordWrapToolStripMenuItem_Click);
            // 
            // txtAddressBar
            // 
            this.txtAddressBar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtAddressBar.Location = new System.Drawing.Point(664, 64);
            this.txtAddressBar.Name = "txtAddressBar";
            this.txtAddressBar.ReadOnly = true;
            this.txtAddressBar.Size = new System.Drawing.Size(560, 20);
            this.txtAddressBar.TabIndex = 29;
            // 
            // txtSleuthFileNameList
            // 
            this.txtSleuthFileNameList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSleuthFileNameList.Location = new System.Drawing.Point(64, 35);
            this.txtSleuthFileNameList.Name = "txtSleuthFileNameList";
            this.txtSleuthFileNameList.Size = new System.Drawing.Size(414, 22);
            this.txtSleuthFileNameList.TabIndex = 31;
            // 
            // cmdSleuth
            // 
            this.cmdSleuth.Location = new System.Drawing.Point(484, 32);
            this.cmdSleuth.Name = "cmdSleuth";
            this.cmdSleuth.Size = new System.Drawing.Size(59, 28);
            this.cmdSleuth.TabIndex = 30;
            this.cmdSleuth.Text = "Sleuth";
            this.cmdSleuth.UseVisualStyleBackColor = true;
            this.cmdSleuth.Click += new System.EventHandler(this.cmdSleuth_Click);
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(12, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(46, 25);
            this.button1.TabIndex = 32;
            this.button1.Text = "Copy";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // cmdWordCount
            // 
            this.cmdWordCount.Location = new System.Drawing.Point(869, 30);
            this.cmdWordCount.Name = "cmdWordCount";
            this.cmdWordCount.Size = new System.Drawing.Size(89, 28);
            this.cmdWordCount.TabIndex = 33;
            this.cmdWordCount.Text = "Wordcount";
            this.cmdWordCount.UseVisualStyleBackColor = true;
            this.cmdWordCount.Click += new System.EventHandler(this.cmdWordCount_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1252, 24);
            this.menuStrip1.TabIndex = 34;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadFromRootToolStripMenuItem,
            this.connectToSQLToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "&File";
            // 
            // loadFromRootToolStripMenuItem
            // 
            this.loadFromRootToolStripMenuItem.Name = "loadFromRootToolStripMenuItem";
            this.loadFromRootToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.loadFromRootToolStripMenuItem.Text = "Load From Root";
            this.loadFromRootToolStripMenuItem.Click += new System.EventHandler(this.MnuClick);
            // 
            // connectToSQLToolStripMenuItem
            // 
            this.connectToSQLToolStripMenuItem.Name = "connectToSQLToolStripMenuItem";
            this.connectToSQLToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.connectToSQLToolStripMenuItem.Text = "Connect to SQL";
            this.connectToSQLToolStripMenuItem.Click += new System.EventHandler(this.connectToSQLToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(156, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findTextToolStripMenuItem,
            this.toolStripMenuItem3,
            this.preferencesToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // findTextToolStripMenuItem
            // 
            this.findTextToolStripMenuItem.Name = "findTextToolStripMenuItem";
            this.findTextToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.findTextToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.findTextToolStripMenuItem.Text = "&Find Text";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(159, 6);
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findCommonDependenciesToolStripMenuItem,
            this.statisticsToolStripMenuItem,
            this.graphViewToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // findCommonDependenciesToolStripMenuItem
            // 
            this.findCommonDependenciesToolStripMenuItem.Name = "findCommonDependenciesToolStripMenuItem";
            this.findCommonDependenciesToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.findCommonDependenciesToolStripMenuItem.Text = "Find Common Dependencies";
            // 
            // statisticsToolStripMenuItem
            // 
            this.statisticsToolStripMenuItem.Name = "statisticsToolStripMenuItem";
            this.statisticsToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.statisticsToolStripMenuItem.Text = "Statistics";
            // 
            // graphViewToolStripMenuItem
            // 
            this.graphViewToolStripMenuItem.Name = "graphViewToolStripMenuItem";
            this.graphViewToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.graphViewToolStripMenuItem.Text = "Graph View";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1252, 781);
            this.Controls.Add(this.cmdWordCount);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtSleuthFileNameList);
            this.Controls.Add(this.cmdSleuth);
            this.Controls.Add(this.txtAddressBar);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.cmdFindText);
            this.Controls.Add(this.txtSearchText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSortOb);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtTextToFind);
            this.Controls.Add(this.btnFindText);
            this.Controls.Add(this.txtElementNameToFind);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.cmdFindTextinFiles);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lstSupports);
            this.Controls.Add(this.lstDepends);
            this.Controls.Add(this.lbMissing);
            this.Controls.Add(this.lstMissing);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstObjects);
            this.Controls.Add(this.lstFiles);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form1";
            this.Text = "Web Inspector";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstFiles;
        private System.Windows.Forms.ListBox lstObjects;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbMissing;
        private System.Windows.Forms.ListBox lstMissing;
        private System.Windows.Forms.ListBox lstDepends;
        private System.Windows.Forms.ListBox lstSupports;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox cmdFindTextinFiles;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtElementNameToFind;
        private System.Windows.Forms.TextBox txtTextToFind;
        private System.Windows.Forms.Button btnFindText;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblSortOb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearchText;
        private System.Windows.Forms.Button cmdFindText;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TextBox txtAddressBar;
        private System.Windows.Forms.TextBox txtSleuthFileNameList;
        private System.Windows.Forms.Button cmdSleuth;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button cmdWordCount;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem wordWrapToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loadFromRootToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findCommonDependenciesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statisticsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToSQLToolStripMenuItem;
    }
}

