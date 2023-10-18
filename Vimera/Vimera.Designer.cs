namespace Vimera
{
    partial class Vimera
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Vimera));
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.HashCompareBtn = new System.Windows.Forms.Button();
            this.TextHashBtn = new System.Windows.Forms.Button();
            this.FileHashBtn = new System.Windows.Forms.Button();
            this.FileHashTimer = new System.Windows.Forms.Label();
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.HeaderImage = new System.Windows.Forms.PictureBox();
            this.HeaderText = new System.Windows.Forms.Label();
            this.HeaderMenu = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.themeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lightThemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darkThemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.turkishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frenchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.initialViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gitHubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainContent = new System.Windows.Forms.TabControl();
            this.FileHash = new System.Windows.Forms.TabPage();
            this.FileHash_TLP = new System.Windows.Forms.TableLayoutPanel();
            this.FileHashPanel = new System.Windows.Forms.Panel();
            this.FileHashLoadBG_Panel = new System.Windows.Forms.Panel();
            this.FileHashLoadFE_Panel = new System.Windows.Forms.Panel();
            this.FileHashDGV = new System.Windows.Forms.DataGridView();
            this.FileHashExportHashsBtn = new System.Windows.Forms.Button();
            this.FileHashCompareBtn = new System.Windows.Forms.Button();
            this.FileHashCompareTextBox = new System.Windows.Forms.TextBox();
            this.FileHashUpperHashMode = new System.Windows.Forms.CheckBox();
            this.FileHashSelectFileBtn = new System.Windows.Forms.Button();
            this.FileHashSelectFilePathTextBox = new System.Windows.Forms.TextBox();
            this.FileHashAlgorithmSelect = new System.Windows.Forms.ComboBox();
            this.FileHashStartBtn = new System.Windows.Forms.Button();
            this.TextHash = new System.Windows.Forms.TabPage();
            this.TextHash_TLP = new System.Windows.Forms.TableLayoutPanel();
            this.TextHashPanel = new System.Windows.Forms.Panel();
            this.TextHashTLP = new System.Windows.Forms.TableLayoutPanel();
            this.TextHashResultCopyBtn = new System.Windows.Forms.Button();
            this.TextHashTLP_Panel2 = new System.Windows.Forms.Panel();
            this.TextHashAlgorithmSelect = new System.Windows.Forms.ComboBox();
            this.TextHashL1 = new System.Windows.Forms.Label();
            this.TextHashOriginalTextBox = new System.Windows.Forms.TextBox();
            this.TextHashTLP_Panel3 = new System.Windows.Forms.Panel();
            this.TextHashSaltingTextBox = new System.Windows.Forms.TextBox();
            this.TextHashL2 = new System.Windows.Forms.Label();
            this.TextHashSaltingLocateMode = new System.Windows.Forms.ComboBox();
            this.TextHashSaltingMode = new System.Windows.Forms.CheckBox();
            this.TextHashTLP_Panel4 = new System.Windows.Forms.Panel();
            this.TextHashL3 = new System.Windows.Forms.Label();
            this.TextHashResultTextBox = new System.Windows.Forms.TextBox();
            this.HashCompare = new System.Windows.Forms.TabPage();
            this.HashCompare_TLP = new System.Windows.Forms.TableLayoutPanel();
            this.HashComparePanel = new System.Windows.Forms.Panel();
            this.HashCompareTLP = new System.Windows.Forms.TableLayoutPanel();
            this.HashCompareTopPanel = new System.Windows.Forms.Panel();
            this.FirstHashValueLabel = new System.Windows.Forms.Label();
            this.FirstHashValueTextBox = new System.Windows.Forms.TextBox();
            this.HashCompareResultLabel = new System.Windows.Forms.Label();
            this.HashCompareBottomPanel = new System.Windows.Forms.Panel();
            this.SecondHashValueLabel = new System.Windows.Forms.Label();
            this.SecondHashValueTextBox = new System.Windows.Forms.TextBox();
            this.FileHash_BG_Worker = new System.ComponentModel.BackgroundWorker();
            this.LeftPanel.SuspendLayout();
            this.HeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderImage)).BeginInit();
            this.HeaderMenu.SuspendLayout();
            this.MainContent.SuspendLayout();
            this.FileHash.SuspendLayout();
            this.FileHash_TLP.SuspendLayout();
            this.FileHashPanel.SuspendLayout();
            this.FileHashLoadBG_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FileHashDGV)).BeginInit();
            this.TextHash.SuspendLayout();
            this.TextHash_TLP.SuspendLayout();
            this.TextHashPanel.SuspendLayout();
            this.TextHashTLP.SuspendLayout();
            this.TextHashTLP_Panel2.SuspendLayout();
            this.TextHashTLP_Panel3.SuspendLayout();
            this.TextHashTLP_Panel4.SuspendLayout();
            this.HashCompare.SuspendLayout();
            this.HashCompare_TLP.SuspendLayout();
            this.HashComparePanel.SuspendLayout();
            this.HashCompareTLP.SuspendLayout();
            this.HashCompareTopPanel.SuspendLayout();
            this.HashCompareBottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LeftPanel
            // 
            this.LeftPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.LeftPanel.Controls.Add(this.HashCompareBtn);
            this.LeftPanel.Controls.Add(this.TextHashBtn);
            this.LeftPanel.Controls.Add(this.FileHashBtn);
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(200, 591);
            this.LeftPanel.TabIndex = 0;
            // 
            // HashCompareBtn
            // 
            this.HashCompareBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.HashCompareBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.HashCompareBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HashCompareBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.HashCompareBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.HashCompareBtn.FlatAppearance.BorderSize = 0;
            this.HashCompareBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.HashCompareBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.HashCompareBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HashCompareBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.HashCompareBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.HashCompareBtn.Image = global::Vimera.Properties.Resources.hash_compare;
            this.HashCompareBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.HashCompareBtn.Location = new System.Drawing.Point(0, 92);
            this.HashCompareBtn.Name = "HashCompareBtn";
            this.HashCompareBtn.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.HashCompareBtn.Size = new System.Drawing.Size(200, 46);
            this.HashCompareBtn.TabIndex = 3;
            this.HashCompareBtn.Text = " Karma Karşılaştırma";
            this.HashCompareBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.HashCompareBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.HashCompareBtn.UseVisualStyleBackColor = false;
            this.HashCompareBtn.Click += new System.EventHandler(this.HashCompareBtn_Click);
            // 
            // TextHashBtn
            // 
            this.TextHashBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.TextHashBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.TextHashBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TextHashBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.TextHashBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.TextHashBtn.FlatAppearance.BorderSize = 0;
            this.TextHashBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.TextHashBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.TextHashBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TextHashBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.TextHashBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.TextHashBtn.Image = global::Vimera.Properties.Resources.text_hash;
            this.TextHashBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TextHashBtn.Location = new System.Drawing.Point(0, 46);
            this.TextHashBtn.Name = "TextHashBtn";
            this.TextHashBtn.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.TextHashBtn.Size = new System.Drawing.Size(200, 46);
            this.TextHashBtn.TabIndex = 2;
            this.TextHashBtn.Text = " Metin Ham Değeri";
            this.TextHashBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TextHashBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.TextHashBtn.UseVisualStyleBackColor = false;
            this.TextHashBtn.Click += new System.EventHandler(this.TextHashBtn_Click);
            // 
            // FileHashBtn
            // 
            this.FileHashBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.FileHashBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.FileHashBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FileHashBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.FileHashBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.FileHashBtn.FlatAppearance.BorderSize = 0;
            this.FileHashBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.FileHashBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.FileHashBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FileHashBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.FileHashBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.FileHashBtn.Image = global::Vimera.Properties.Resources.file_hash;
            this.FileHashBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FileHashBtn.Location = new System.Drawing.Point(0, 0);
            this.FileHashBtn.Name = "FileHashBtn";
            this.FileHashBtn.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.FileHashBtn.Size = new System.Drawing.Size(200, 46);
            this.FileHashBtn.TabIndex = 1;
            this.FileHashBtn.Text = " Dosya Ham Değeri";
            this.FileHashBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FileHashBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.FileHashBtn.UseVisualStyleBackColor = false;
            this.FileHashBtn.Click += new System.EventHandler(this.FileHashBtn_Click);
            // 
            // FileHashTimer
            // 
            this.FileHashTimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.FileHashTimer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.FileHashTimer.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.FileHashTimer.Location = new System.Drawing.Point(7, 454);
            this.FileHashTimer.Name = "FileHashTimer";
            this.FileHashTimer.Size = new System.Drawing.Size(100, 25);
            this.FileHashTimer.TabIndex = 4;
            this.FileHashTimer.Text = "--:--:--";
            this.FileHashTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.FileHashTimer.Visible = false;
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.HeaderPanel.Controls.Add(this.HeaderImage);
            this.HeaderPanel.Controls.Add(this.HeaderText);
            this.HeaderPanel.Controls.Add(this.HeaderMenu);
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderPanel.Location = new System.Drawing.Point(200, 0);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(784, 46);
            this.HeaderPanel.TabIndex = 1;
            // 
            // HeaderImage
            // 
            this.HeaderImage.BackColor = System.Drawing.Color.Transparent;
            this.HeaderImage.BackgroundImage = global::Vimera.Properties.Resources.file_hash;
            this.HeaderImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.HeaderImage.Location = new System.Drawing.Point(8, 9);
            this.HeaderImage.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.HeaderImage.Name = "HeaderImage";
            this.HeaderImage.Size = new System.Drawing.Size(28, 28);
            this.HeaderImage.TabIndex = 6;
            this.HeaderImage.TabStop = false;
            // 
            // HeaderText
            // 
            this.HeaderText.AutoSize = true;
            this.HeaderText.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.HeaderText.Location = new System.Drawing.Point(40, 13);
            this.HeaderText.Name = "HeaderText";
            this.HeaderText.Size = new System.Drawing.Size(160, 21);
            this.HeaderText.TabIndex = 5;
            this.HeaderText.Text = "DOSYA HAM DEĞERİ";
            // 
            // HeaderMenu
            // 
            this.HeaderMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.HeaderMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.HeaderMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.gitHubToolStripMenuItem});
            this.HeaderMenu.Location = new System.Drawing.Point(618, 11);
            this.HeaderMenu.Name = "HeaderMenu";
            this.HeaderMenu.Size = new System.Drawing.Size(158, 24);
            this.HeaderMenu.TabIndex = 7;
            this.HeaderMenu.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.themeToolStripMenuItem,
            this.languageToolStripMenuItem,
            this.initialViewToolStripMenuItem});
            this.settingsToolStripMenuItem.Image = global::Vimera.Properties.Resources.top_settings;
            this.settingsToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // themeToolStripMenuItem
            // 
            this.themeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lightThemeToolStripMenuItem,
            this.darkThemeToolStripMenuItem});
            this.themeToolStripMenuItem.Image = global::Vimera.Properties.Resources.top_theme;
            this.themeToolStripMenuItem.Name = "themeToolStripMenuItem";
            this.themeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.themeToolStripMenuItem.Text = "Theme";
            // 
            // lightThemeToolStripMenuItem
            // 
            this.lightThemeToolStripMenuItem.Name = "lightThemeToolStripMenuItem";
            this.lightThemeToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.lightThemeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.lightThemeToolStripMenuItem.Text = "Light Theme";
            this.lightThemeToolStripMenuItem.Click += new System.EventHandler(this.lightThemeToolStripMenuItem_Click);
            // 
            // darkThemeToolStripMenuItem
            // 
            this.darkThemeToolStripMenuItem.Name = "darkThemeToolStripMenuItem";
            this.darkThemeToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.darkThemeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.darkThemeToolStripMenuItem.Text = "Dark Theme";
            this.darkThemeToolStripMenuItem.Click += new System.EventHandler(this.darkThemeToolStripMenuItem_Click);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.frenchToolStripMenuItem,
            this.turkishToolStripMenuItem});
            this.languageToolStripMenuItem.Image = global::Vimera.Properties.Resources.top_language;
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.languageToolStripMenuItem.Text = "Language";
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.englishToolStripMenuItem.Text = "English";
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // turkishToolStripMenuItem
            // 
            this.turkishToolStripMenuItem.Name = "turkishToolStripMenuItem";
            this.turkishToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.turkishToolStripMenuItem.Text = "Turkish";
            this.turkishToolStripMenuItem.Click += new System.EventHandler(this.turkishToolStripMenuItem_Click);
            // 
            // frenchToolStripMenuItem
            // 
            this.frenchToolStripMenuItem.Name = "frenchToolStripMenuItem";
            this.frenchToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.frenchToolStripMenuItem.Text = "French";
            this.frenchToolStripMenuItem.Click += new System.EventHandler(this.frenchToolStripMenuItem_Click);
            // 
            // initialViewToolStripMenuItem
            // 
            this.initialViewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.windowedToolStripMenuItem,
            this.fullScreenToolStripMenuItem});
            this.initialViewToolStripMenuItem.Image = global::Vimera.Properties.Resources.top_launch;
            this.initialViewToolStripMenuItem.Name = "initialViewToolStripMenuItem";
            this.initialViewToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.initialViewToolStripMenuItem.Text = "Initial View";
            // 
            // windowedToolStripMenuItem
            // 
            this.windowedToolStripMenuItem.Name = "windowedToolStripMenuItem";
            this.windowedToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.windowedToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.windowedToolStripMenuItem.Text = "Windowed";
            this.windowedToolStripMenuItem.Click += new System.EventHandler(this.windowedToolStripMenuItem_Click);
            // 
            // fullScreenToolStripMenuItem
            // 
            this.fullScreenToolStripMenuItem.Name = "fullScreenToolStripMenuItem";
            this.fullScreenToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.fullScreenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.fullScreenToolStripMenuItem.Text = "Full Screen";
            this.fullScreenToolStripMenuItem.Click += new System.EventHandler(this.fullScreenToolStripMenuItem_Click);
            // 
            // gitHubToolStripMenuItem
            // 
            this.gitHubToolStripMenuItem.Image = global::Vimera.Properties.Resources.top_github;
            this.gitHubToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.gitHubToolStripMenuItem.Name = "gitHubToolStripMenuItem";
            this.gitHubToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.gitHubToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.gitHubToolStripMenuItem.Text = "GitHub";
            this.gitHubToolStripMenuItem.Click += new System.EventHandler(this.gitHubToolStripMenuItem_Click);
            // 
            // MainContent
            // 
            this.MainContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainContent.Controls.Add(this.FileHash);
            this.MainContent.Controls.Add(this.TextHash);
            this.MainContent.Controls.Add(this.HashCompare);
            this.MainContent.Location = new System.Drawing.Point(195, 23);
            this.MainContent.Name = "MainContent";
            this.MainContent.SelectedIndex = 0;
            this.MainContent.Size = new System.Drawing.Size(794, 573);
            this.MainContent.TabIndex = 0;
            this.MainContent.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.MainContent_Selecting);
            // 
            // FileHash
            // 
            this.FileHash.Controls.Add(this.FileHash_TLP);
            this.FileHash.Location = new System.Drawing.Point(4, 22);
            this.FileHash.Name = "FileHash";
            this.FileHash.Padding = new System.Windows.Forms.Padding(3);
            this.FileHash.Size = new System.Drawing.Size(786, 547);
            this.FileHash.TabIndex = 0;
            this.FileHash.Text = "FileHash";
            this.FileHash.UseVisualStyleBackColor = true;
            // 
            // FileHash_TLP
            // 
            this.FileHash_TLP.ColumnCount = 1;
            this.FileHash_TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.FileHash_TLP.Controls.Add(this.FileHashPanel, 0, 0);
            this.FileHash_TLP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileHash_TLP.Location = new System.Drawing.Point(3, 3);
            this.FileHash_TLP.Name = "FileHash_TLP";
            this.FileHash_TLP.Padding = new System.Windows.Forms.Padding(4);
            this.FileHash_TLP.RowCount = 1;
            this.FileHash_TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FileHash_TLP.Size = new System.Drawing.Size(780, 541);
            this.FileHash_TLP.TabIndex = 1;
            // 
            // FileHashPanel
            // 
            this.FileHashPanel.AllowDrop = true;
            this.FileHashPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileHashPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.FileHashPanel.Controls.Add(this.FileHashLoadBG_Panel);
            this.FileHashPanel.Controls.Add(this.FileHashDGV);
            this.FileHashPanel.Controls.Add(this.FileHashTimer);
            this.FileHashPanel.Controls.Add(this.FileHashExportHashsBtn);
            this.FileHashPanel.Controls.Add(this.FileHashCompareBtn);
            this.FileHashPanel.Controls.Add(this.FileHashCompareTextBox);
            this.FileHashPanel.Controls.Add(this.FileHashUpperHashMode);
            this.FileHashPanel.Controls.Add(this.FileHashSelectFileBtn);
            this.FileHashPanel.Controls.Add(this.FileHashSelectFilePathTextBox);
            this.FileHashPanel.Controls.Add(this.FileHashAlgorithmSelect);
            this.FileHashPanel.Controls.Add(this.FileHashStartBtn);
            this.FileHashPanel.Location = new System.Drawing.Point(7, 7);
            this.FileHashPanel.Name = "FileHashPanel";
            this.FileHashPanel.Size = new System.Drawing.Size(767, 527);
            this.FileHashPanel.TabIndex = 0;
            this.FileHashPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.FileHashPanel_DragDrop);
            this.FileHashPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.FileHashPanel_DragEnter);
            // 
            // FileHashLoadBG_Panel
            // 
            this.FileHashLoadBG_Panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileHashLoadBG_Panel.Controls.Add(this.FileHashLoadFE_Panel);
            this.FileHashLoadBG_Panel.Location = new System.Drawing.Point(8, 47);
            this.FileHashLoadBG_Panel.Name = "FileHashLoadBG_Panel";
            this.FileHashLoadBG_Panel.Size = new System.Drawing.Size(750, 5);
            this.FileHashLoadBG_Panel.TabIndex = 13;
            this.FileHashLoadBG_Panel.Visible = false;
            // 
            // FileHashLoadFE_Panel
            // 
            this.FileHashLoadFE_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(57)))), ((int)(((byte)(211)))));
            this.FileHashLoadFE_Panel.Dock = System.Windows.Forms.DockStyle.Left;
            this.FileHashLoadFE_Panel.Location = new System.Drawing.Point(0, 0);
            this.FileHashLoadFE_Panel.Name = "FileHashLoadFE_Panel";
            this.FileHashLoadFE_Panel.Size = new System.Drawing.Size(137, 5);
            this.FileHashLoadFE_Panel.TabIndex = 0;
            // 
            // FileHashDGV
            // 
            this.FileHashDGV.AllowUserToAddRows = false;
            this.FileHashDGV.AllowUserToDeleteRows = false;
            this.FileHashDGV.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.FileHashDGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.FileHashDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileHashDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.FileHashDGV.BackgroundColor = System.Drawing.Color.White;
            this.FileHashDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FileHashDGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(45)))), ((int)(((byte)(163)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(45)))), ((int)(((byte)(163)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.FileHashDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.FileHashDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FileHashDGV.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(45)))), ((int)(((byte)(163)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.FileHashDGV.DefaultCellStyle = dataGridViewCellStyle3;
            this.FileHashDGV.EnableHeadersVisualStyles = false;
            this.FileHashDGV.GridColor = System.Drawing.Color.Gray;
            this.FileHashDGV.Location = new System.Drawing.Point(7, 52);
            this.FileHashDGV.MultiSelect = false;
            this.FileHashDGV.Name = "FileHashDGV";
            this.FileHashDGV.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(45)))), ((int)(((byte)(163)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.FileHashDGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.FileHashDGV.RowHeadersVisible = false;
            this.FileHashDGV.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.FileHashDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.FileHashDGV.Size = new System.Drawing.Size(752, 355);
            this.FileHashDGV.TabIndex = 4;
            this.FileHashDGV.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FileHashDGV_CellDoubleClick);
            // 
            // FileHashExportHashsBtn
            // 
            this.FileHashExportHashsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.FileHashExportHashsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(45)))), ((int)(((byte)(163)))));
            this.FileHashExportHashsBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.FileHashExportHashsBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FileHashExportHashsBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(45)))), ((int)(((byte)(163)))));
            this.FileHashExportHashsBtn.FlatAppearance.BorderSize = 0;
            this.FileHashExportHashsBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(57)))), ((int)(((byte)(211)))));
            this.FileHashExportHashsBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(57)))), ((int)(((byte)(211)))));
            this.FileHashExportHashsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FileHashExportHashsBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.FileHashExportHashsBtn.ForeColor = System.Drawing.Color.White;
            this.FileHashExportHashsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FileHashExportHashsBtn.Location = new System.Drawing.Point(633, 423);
            this.FileHashExportHashsBtn.Name = "FileHashExportHashsBtn";
            this.FileHashExportHashsBtn.Size = new System.Drawing.Size(126, 25);
            this.FileHashExportHashsBtn.TabIndex = 14;
            this.FileHashExportHashsBtn.Text = "DIŞA AKTAR";
            this.FileHashExportHashsBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.FileHashExportHashsBtn.UseVisualStyleBackColor = false;
            this.FileHashExportHashsBtn.Visible = false;
            this.FileHashExportHashsBtn.Click += new System.EventHandler(this.FileHashExportHashsBtn_Click);
            // 
            // FileHashCompareBtn
            // 
            this.FileHashCompareBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.FileHashCompareBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(45)))), ((int)(((byte)(163)))));
            this.FileHashCompareBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.FileHashCompareBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FileHashCompareBtn.Enabled = false;
            this.FileHashCompareBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(45)))), ((int)(((byte)(163)))));
            this.FileHashCompareBtn.FlatAppearance.BorderSize = 0;
            this.FileHashCompareBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(57)))), ((int)(((byte)(211)))));
            this.FileHashCompareBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(57)))), ((int)(((byte)(211)))));
            this.FileHashCompareBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FileHashCompareBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.FileHashCompareBtn.ForeColor = System.Drawing.Color.White;
            this.FileHashCompareBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FileHashCompareBtn.Location = new System.Drawing.Point(633, 454);
            this.FileHashCompareBtn.Name = "FileHashCompareBtn";
            this.FileHashCompareBtn.Size = new System.Drawing.Size(126, 25);
            this.FileHashCompareBtn.TabIndex = 7;
            this.FileHashCompareBtn.Text = "SINA";
            this.FileHashCompareBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.FileHashCompareBtn.UseVisualStyleBackColor = false;
            this.FileHashCompareBtn.Visible = false;
            this.FileHashCompareBtn.Click += new System.EventHandler(this.FileHashCompareBtn_Click);
            // 
            // FileHashCompareTextBox
            // 
            this.FileHashCompareTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileHashCompareTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.FileHashCompareTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FileHashCompareTextBox.Enabled = false;
            this.FileHashCompareTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.FileHashCompareTextBox.ForeColor = System.Drawing.Color.Black;
            this.FileHashCompareTextBox.Location = new System.Drawing.Point(113, 454);
            this.FileHashCompareTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.FileHashCompareTextBox.MaxLength = 256;
            this.FileHashCompareTextBox.Name = "FileHashCompareTextBox";
            this.FileHashCompareTextBox.Size = new System.Drawing.Size(515, 25);
            this.FileHashCompareTextBox.TabIndex = 6;
            this.FileHashCompareTextBox.Visible = false;
            this.FileHashCompareTextBox.TextChanged += new System.EventHandler(this.FileHashCompareTextBox_TextChanged);
            // 
            // FileHashUpperHashMode
            // 
            this.FileHashUpperHashMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.FileHashUpperHashMode.AutoSize = true;
            this.FileHashUpperHashMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FileHashUpperHashMode.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.FileHashUpperHashMode.Location = new System.Drawing.Point(7, 426);
            this.FileHashUpperHashMode.Name = "FileHashUpperHashMode";
            this.FileHashUpperHashMode.Size = new System.Drawing.Size(154, 19);
            this.FileHashUpperHashMode.TabIndex = 5;
            this.FileHashUpperHashMode.Text = "Büyük harf karma modu";
            this.FileHashUpperHashMode.UseVisualStyleBackColor = true;
            this.FileHashUpperHashMode.Visible = false;
            this.FileHashUpperHashMode.CheckedChanged += new System.EventHandler(this.FileHashUpperHashMode_CheckedChanged);
            // 
            // FileHashSelectFileBtn
            // 
            this.FileHashSelectFileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FileHashSelectFileBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(45)))), ((int)(((byte)(163)))));
            this.FileHashSelectFileBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.FileHashSelectFileBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FileHashSelectFileBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(45)))), ((int)(((byte)(163)))));
            this.FileHashSelectFileBtn.FlatAppearance.BorderSize = 0;
            this.FileHashSelectFileBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(57)))), ((int)(((byte)(211)))));
            this.FileHashSelectFileBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(57)))), ((int)(((byte)(211)))));
            this.FileHashSelectFileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FileHashSelectFileBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.FileHashSelectFileBtn.ForeColor = System.Drawing.Color.White;
            this.FileHashSelectFileBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FileHashSelectFileBtn.Location = new System.Drawing.Point(633, 9);
            this.FileHashSelectFileBtn.Name = "FileHashSelectFileBtn";
            this.FileHashSelectFileBtn.Size = new System.Drawing.Size(126, 25);
            this.FileHashSelectFileBtn.TabIndex = 3;
            this.FileHashSelectFileBtn.Text = "SEÇ";
            this.FileHashSelectFileBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.FileHashSelectFileBtn.UseVisualStyleBackColor = false;
            this.FileHashSelectFileBtn.Click += new System.EventHandler(this.FileHashSelectFileBtn_Click);
            // 
            // FileHashSelectFilePathTextBox
            // 
            this.FileHashSelectFilePathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileHashSelectFilePathTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.FileHashSelectFilePathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FileHashSelectFilePathTextBox.Enabled = false;
            this.FileHashSelectFilePathTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.FileHashSelectFilePathTextBox.ForeColor = System.Drawing.Color.Black;
            this.FileHashSelectFilePathTextBox.Location = new System.Drawing.Point(113, 9);
            this.FileHashSelectFilePathTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.FileHashSelectFilePathTextBox.MaxLength = 256;
            this.FileHashSelectFilePathTextBox.Name = "FileHashSelectFilePathTextBox";
            this.FileHashSelectFilePathTextBox.Size = new System.Drawing.Size(517, 25);
            this.FileHashSelectFilePathTextBox.TabIndex = 2;
            // 
            // FileHashAlgorithmSelect
            // 
            this.FileHashAlgorithmSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(45)))), ((int)(((byte)(163)))));
            this.FileHashAlgorithmSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FileHashAlgorithmSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FileHashAlgorithmSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FileHashAlgorithmSelect.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.FileHashAlgorithmSelect.ForeColor = System.Drawing.Color.White;
            this.FileHashAlgorithmSelect.FormattingEnabled = true;
            this.FileHashAlgorithmSelect.Location = new System.Drawing.Point(7, 9);
            this.FileHashAlgorithmSelect.Margin = new System.Windows.Forms.Padding(3, 3, 3, 25);
            this.FileHashAlgorithmSelect.Name = "FileHashAlgorithmSelect";
            this.FileHashAlgorithmSelect.Size = new System.Drawing.Size(100, 25);
            this.FileHashAlgorithmSelect.TabIndex = 0;
            this.FileHashAlgorithmSelect.SelectedIndexChanged += new System.EventHandler(this.FileHashAlgorithmSelect_SelectedIndexChanged);
            // 
            // FileHashStartBtn
            // 
            this.FileHashStartBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(45)))), ((int)(((byte)(163)))));
            this.FileHashStartBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.FileHashStartBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FileHashStartBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FileHashStartBtn.Enabled = false;
            this.FileHashStartBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(45)))), ((int)(((byte)(163)))));
            this.FileHashStartBtn.FlatAppearance.BorderSize = 0;
            this.FileHashStartBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(57)))), ((int)(((byte)(211)))));
            this.FileHashStartBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(57)))), ((int)(((byte)(211)))));
            this.FileHashStartBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FileHashStartBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.FileHashStartBtn.ForeColor = System.Drawing.Color.White;
            this.FileHashStartBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FileHashStartBtn.Location = new System.Drawing.Point(0, 487);
            this.FileHashStartBtn.Name = "FileHashStartBtn";
            this.FileHashStartBtn.Size = new System.Drawing.Size(767, 40);
            this.FileHashStartBtn.TabIndex = 8;
            this.FileHashStartBtn.Text = "BAŞLAT";
            this.FileHashStartBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.FileHashStartBtn.UseVisualStyleBackColor = false;
            this.FileHashStartBtn.Click += new System.EventHandler(this.FileHashStartBtn_Click);
            // 
            // TextHash
            // 
            this.TextHash.Controls.Add(this.TextHash_TLP);
            this.TextHash.Location = new System.Drawing.Point(4, 22);
            this.TextHash.Name = "TextHash";
            this.TextHash.Padding = new System.Windows.Forms.Padding(3);
            this.TextHash.Size = new System.Drawing.Size(786, 547);
            this.TextHash.TabIndex = 1;
            this.TextHash.Text = "TextHash";
            this.TextHash.UseVisualStyleBackColor = true;
            // 
            // TextHash_TLP
            // 
            this.TextHash_TLP.ColumnCount = 1;
            this.TextHash_TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TextHash_TLP.Controls.Add(this.TextHashPanel, 0, 0);
            this.TextHash_TLP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextHash_TLP.Location = new System.Drawing.Point(3, 3);
            this.TextHash_TLP.Name = "TextHash_TLP";
            this.TextHash_TLP.Padding = new System.Windows.Forms.Padding(4);
            this.TextHash_TLP.RowCount = 1;
            this.TextHash_TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TextHash_TLP.Size = new System.Drawing.Size(780, 541);
            this.TextHash_TLP.TabIndex = 1;
            // 
            // TextHashPanel
            // 
            this.TextHashPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.TextHashPanel.Controls.Add(this.TextHashTLP);
            this.TextHashPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextHashPanel.Location = new System.Drawing.Point(7, 7);
            this.TextHashPanel.Name = "TextHashPanel";
            this.TextHashPanel.Size = new System.Drawing.Size(767, 527);
            this.TextHashPanel.TabIndex = 0;
            // 
            // TextHashTLP
            // 
            this.TextHashTLP.BackColor = System.Drawing.Color.Transparent;
            this.TextHashTLP.ColumnCount = 1;
            this.TextHashTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TextHashTLP.Controls.Add(this.TextHashResultCopyBtn, 0, 3);
            this.TextHashTLP.Controls.Add(this.TextHashTLP_Panel2, 0, 0);
            this.TextHashTLP.Controls.Add(this.TextHashTLP_Panel3, 0, 1);
            this.TextHashTLP.Controls.Add(this.TextHashTLP_Panel4, 0, 2);
            this.TextHashTLP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextHashTLP.Location = new System.Drawing.Point(0, 0);
            this.TextHashTLP.Name = "TextHashTLP";
            this.TextHashTLP.RowCount = 4;
            this.TextHashTLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TextHashTLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.TextHashTLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TextHashTLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.TextHashTLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TextHashTLP.Size = new System.Drawing.Size(767, 527);
            this.TextHashTLP.TabIndex = 10;
            // 
            // TextHashResultCopyBtn
            // 
            this.TextHashResultCopyBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(45)))), ((int)(((byte)(163)))));
            this.TextHashResultCopyBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.TextHashResultCopyBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TextHashResultCopyBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextHashResultCopyBtn.Enabled = false;
            this.TextHashResultCopyBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(45)))), ((int)(((byte)(163)))));
            this.TextHashResultCopyBtn.FlatAppearance.BorderSize = 0;
            this.TextHashResultCopyBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(57)))), ((int)(((byte)(211)))));
            this.TextHashResultCopyBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(57)))), ((int)(((byte)(211)))));
            this.TextHashResultCopyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TextHashResultCopyBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.TextHashResultCopyBtn.ForeColor = System.Drawing.Color.White;
            this.TextHashResultCopyBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TextHashResultCopyBtn.Location = new System.Drawing.Point(3, 489);
            this.TextHashResultCopyBtn.Name = "TextHashResultCopyBtn";
            this.TextHashResultCopyBtn.Size = new System.Drawing.Size(761, 35);
            this.TextHashResultCopyBtn.TabIndex = 9;
            this.TextHashResultCopyBtn.Text = "KOPYALA";
            this.TextHashResultCopyBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.TextHashResultCopyBtn.UseVisualStyleBackColor = false;
            this.TextHashResultCopyBtn.Click += new System.EventHandler(this.TextHashResultCopyBtn_Click);
            // 
            // TextHashTLP_Panel2
            // 
            this.TextHashTLP_Panel2.BackColor = System.Drawing.Color.Transparent;
            this.TextHashTLP_Panel2.Controls.Add(this.TextHashAlgorithmSelect);
            this.TextHashTLP_Panel2.Controls.Add(this.TextHashL1);
            this.TextHashTLP_Panel2.Controls.Add(this.TextHashOriginalTextBox);
            this.TextHashTLP_Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextHashTLP_Panel2.Location = new System.Drawing.Point(3, 3);
            this.TextHashTLP_Panel2.Name = "TextHashTLP_Panel2";
            this.TextHashTLP_Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.TextHashTLP_Panel2.Size = new System.Drawing.Size(761, 192);
            this.TextHashTLP_Panel2.TabIndex = 11;
            // 
            // TextHashAlgorithmSelect
            // 
            this.TextHashAlgorithmSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(45)))), ((int)(((byte)(163)))));
            this.TextHashAlgorithmSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TextHashAlgorithmSelect.Dock = System.Windows.Forms.DockStyle.Right;
            this.TextHashAlgorithmSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TextHashAlgorithmSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TextHashAlgorithmSelect.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.TextHashAlgorithmSelect.ForeColor = System.Drawing.Color.White;
            this.TextHashAlgorithmSelect.FormattingEnabled = true;
            this.TextHashAlgorithmSelect.Location = new System.Drawing.Point(656, 5);
            this.TextHashAlgorithmSelect.Name = "TextHashAlgorithmSelect";
            this.TextHashAlgorithmSelect.Size = new System.Drawing.Size(100, 25);
            this.TextHashAlgorithmSelect.TabIndex = 0;
            this.TextHashAlgorithmSelect.SelectedIndexChanged += new System.EventHandler(this.TextHashAlgorithmSelect_SelectedIndexChanged);
            // 
            // TextHashL1
            // 
            this.TextHashL1.AutoSize = true;
            this.TextHashL1.BackColor = System.Drawing.Color.Transparent;
            this.TextHashL1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.TextHashL1.ForeColor = System.Drawing.Color.Black;
            this.TextHashL1.Location = new System.Drawing.Point(5, 12);
            this.TextHashL1.Name = "TextHashL1";
            this.TextHashL1.Size = new System.Drawing.Size(150, 19);
            this.TextHashL1.TabIndex = 1;
            this.TextHashL1.Text = "Orijinal Değeri Giriniz:";
            this.TextHashL1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TextHashOriginalTextBox
            // 
            this.TextHashOriginalTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextHashOriginalTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TextHashOriginalTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextHashOriginalTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.TextHashOriginalTextBox.ForeColor = System.Drawing.Color.Black;
            this.TextHashOriginalTextBox.Location = new System.Drawing.Point(8, 36);
            this.TextHashOriginalTextBox.Margin = new System.Windows.Forms.Padding(3, 5, 0, 5);
            this.TextHashOriginalTextBox.MaxLength = 512;
            this.TextHashOriginalTextBox.Multiline = true;
            this.TextHashOriginalTextBox.Name = "TextHashOriginalTextBox";
            this.TextHashOriginalTextBox.Size = new System.Drawing.Size(748, 146);
            this.TextHashOriginalTextBox.TabIndex = 2;
            this.TextHashOriginalTextBox.TextChanged += new System.EventHandler(this.TextHashOriginalTextBox_TextChanged);
            // 
            // TextHashTLP_Panel3
            // 
            this.TextHashTLP_Panel3.BackColor = System.Drawing.Color.Transparent;
            this.TextHashTLP_Panel3.Controls.Add(this.TextHashSaltingTextBox);
            this.TextHashTLP_Panel3.Controls.Add(this.TextHashL2);
            this.TextHashTLP_Panel3.Controls.Add(this.TextHashSaltingLocateMode);
            this.TextHashTLP_Panel3.Controls.Add(this.TextHashSaltingMode);
            this.TextHashTLP_Panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextHashTLP_Panel3.Location = new System.Drawing.Point(3, 201);
            this.TextHashTLP_Panel3.Name = "TextHashTLP_Panel3";
            this.TextHashTLP_Panel3.Padding = new System.Windows.Forms.Padding(5);
            this.TextHashTLP_Panel3.Size = new System.Drawing.Size(761, 84);
            this.TextHashTLP_Panel3.TabIndex = 12;
            // 
            // TextHashSaltingTextBox
            // 
            this.TextHashSaltingTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextHashSaltingTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TextHashSaltingTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextHashSaltingTextBox.Enabled = false;
            this.TextHashSaltingTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.TextHashSaltingTextBox.ForeColor = System.Drawing.Color.Black;
            this.TextHashSaltingTextBox.Location = new System.Drawing.Point(9, 29);
            this.TextHashSaltingTextBox.Margin = new System.Windows.Forms.Padding(3, 5, 0, 5);
            this.TextHashSaltingTextBox.MaxLength = 32;
            this.TextHashSaltingTextBox.Name = "TextHashSaltingTextBox";
            this.TextHashSaltingTextBox.Size = new System.Drawing.Size(540, 25);
            this.TextHashSaltingTextBox.TabIndex = 5;
            this.TextHashSaltingTextBox.TextChanged += new System.EventHandler(this.TextHashSaltingTextBox_TextChanged);
            // 
            // TextHashL2
            // 
            this.TextHashL2.AutoSize = true;
            this.TextHashL2.BackColor = System.Drawing.Color.Transparent;
            this.TextHashL2.Dock = System.Windows.Forms.DockStyle.Top;
            this.TextHashL2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.TextHashL2.Location = new System.Drawing.Point(5, 5);
            this.TextHashL2.Name = "TextHashL2";
            this.TextHashL2.Size = new System.Drawing.Size(155, 19);
            this.TextHashL2.TabIndex = 3;
            this.TextHashL2.Text = "Tuzlama Değeri Giriniz:";
            this.TextHashL2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TextHashSaltingLocateMode
            // 
            this.TextHashSaltingLocateMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TextHashSaltingLocateMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(45)))), ((int)(((byte)(163)))));
            this.TextHashSaltingLocateMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TextHashSaltingLocateMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TextHashSaltingLocateMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TextHashSaltingLocateMode.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.TextHashSaltingLocateMode.ForeColor = System.Drawing.Color.White;
            this.TextHashSaltingLocateMode.FormattingEnabled = true;
            this.TextHashSaltingLocateMode.Location = new System.Drawing.Point(552, 29);
            this.TextHashSaltingLocateMode.Margin = new System.Windows.Forms.Padding(3, 3, 3, 25);
            this.TextHashSaltingLocateMode.Name = "TextHashSaltingLocateMode";
            this.TextHashSaltingLocateMode.Size = new System.Drawing.Size(175, 25);
            this.TextHashSaltingLocateMode.TabIndex = 6;
            this.TextHashSaltingLocateMode.Visible = false;
            this.TextHashSaltingLocateMode.SelectedIndexChanged += new System.EventHandler(this.TextHashSaltingLocateMode_SelectedIndexChanged);
            // 
            // TextHashSaltingMode
            // 
            this.TextHashSaltingMode.AutoSize = true;
            this.TextHashSaltingMode.BackColor = System.Drawing.Color.Transparent;
            this.TextHashSaltingMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TextHashSaltingMode.Enabled = false;
            this.TextHashSaltingMode.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.TextHashSaltingMode.Location = new System.Drawing.Point(9, 62);
            this.TextHashSaltingMode.Name = "TextHashSaltingMode";
            this.TextHashSaltingMode.Size = new System.Drawing.Size(106, 19);
            this.TextHashSaltingMode.TabIndex = 4;
            this.TextHashSaltingMode.Text = "Tuzlama Modu";
            this.TextHashSaltingMode.UseVisualStyleBackColor = false;
            this.TextHashSaltingMode.CheckedChanged += new System.EventHandler(this.TextHashSaltingMode_CheckedChanged);
            // 
            // TextHashTLP_Panel4
            // 
            this.TextHashTLP_Panel4.BackColor = System.Drawing.Color.Transparent;
            this.TextHashTLP_Panel4.Controls.Add(this.TextHashL3);
            this.TextHashTLP_Panel4.Controls.Add(this.TextHashResultTextBox);
            this.TextHashTLP_Panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextHashTLP_Panel4.Location = new System.Drawing.Point(3, 291);
            this.TextHashTLP_Panel4.Name = "TextHashTLP_Panel4";
            this.TextHashTLP_Panel4.Padding = new System.Windows.Forms.Padding(5);
            this.TextHashTLP_Panel4.Size = new System.Drawing.Size(761, 192);
            this.TextHashTLP_Panel4.TabIndex = 13;
            // 
            // TextHashL3
            // 
            this.TextHashL3.AutoSize = true;
            this.TextHashL3.BackColor = System.Drawing.Color.Transparent;
            this.TextHashL3.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.TextHashL3.Location = new System.Drawing.Point(5, 14);
            this.TextHashL3.Name = "TextHashL3";
            this.TextHashL3.Size = new System.Drawing.Size(172, 19);
            this.TextHashL3.TabIndex = 7;
            this.TextHashL3.Text = "Oluşturulan Karma Değer:";
            this.TextHashL3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TextHashResultTextBox
            // 
            this.TextHashResultTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextHashResultTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TextHashResultTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextHashResultTextBox.Enabled = false;
            this.TextHashResultTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.TextHashResultTextBox.ForeColor = System.Drawing.Color.Black;
            this.TextHashResultTextBox.Location = new System.Drawing.Point(8, 38);
            this.TextHashResultTextBox.Margin = new System.Windows.Forms.Padding(3, 5, 0, 3);
            this.TextHashResultTextBox.MaxLength = 256;
            this.TextHashResultTextBox.Multiline = true;
            this.TextHashResultTextBox.Name = "TextHashResultTextBox";
            this.TextHashResultTextBox.Size = new System.Drawing.Size(748, 146);
            this.TextHashResultTextBox.TabIndex = 8;
            // 
            // HashCompare
            // 
            this.HashCompare.Controls.Add(this.HashCompare_TLP);
            this.HashCompare.Location = new System.Drawing.Point(4, 22);
            this.HashCompare.Name = "HashCompare";
            this.HashCompare.Size = new System.Drawing.Size(786, 547);
            this.HashCompare.TabIndex = 2;
            this.HashCompare.Text = "HashCompare";
            this.HashCompare.UseVisualStyleBackColor = true;
            // 
            // HashCompare_TLP
            // 
            this.HashCompare_TLP.ColumnCount = 1;
            this.HashCompare_TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.HashCompare_TLP.Controls.Add(this.HashComparePanel, 0, 0);
            this.HashCompare_TLP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HashCompare_TLP.Location = new System.Drawing.Point(0, 0);
            this.HashCompare_TLP.Name = "HashCompare_TLP";
            this.HashCompare_TLP.Padding = new System.Windows.Forms.Padding(7);
            this.HashCompare_TLP.RowCount = 1;
            this.HashCompare_TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.HashCompare_TLP.Size = new System.Drawing.Size(786, 547);
            this.HashCompare_TLP.TabIndex = 2;
            // 
            // HashComparePanel
            // 
            this.HashComparePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.HashComparePanel.Controls.Add(this.HashCompareTLP);
            this.HashComparePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HashComparePanel.Location = new System.Drawing.Point(10, 10);
            this.HashComparePanel.Name = "HashComparePanel";
            this.HashComparePanel.Size = new System.Drawing.Size(767, 527);
            this.HashComparePanel.TabIndex = 1;
            // 
            // HashCompareTLP
            // 
            this.HashCompareTLP.BackColor = System.Drawing.Color.Transparent;
            this.HashCompareTLP.ColumnCount = 1;
            this.HashCompareTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.HashCompareTLP.Controls.Add(this.HashCompareTopPanel, 0, 0);
            this.HashCompareTLP.Controls.Add(this.HashCompareResultLabel, 0, 2);
            this.HashCompareTLP.Controls.Add(this.HashCompareBottomPanel, 0, 1);
            this.HashCompareTLP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HashCompareTLP.Location = new System.Drawing.Point(0, 0);
            this.HashCompareTLP.Name = "HashCompareTLP";
            this.HashCompareTLP.RowCount = 3;
            this.HashCompareTLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.HashCompareTLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.HashCompareTLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.HashCompareTLP.Size = new System.Drawing.Size(767, 527);
            this.HashCompareTLP.TabIndex = 8;
            // 
            // HashCompareTopPanel
            // 
            this.HashCompareTopPanel.BackColor = System.Drawing.Color.Transparent;
            this.HashCompareTopPanel.Controls.Add(this.FirstHashValueLabel);
            this.HashCompareTopPanel.Controls.Add(this.FirstHashValueTextBox);
            this.HashCompareTopPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HashCompareTopPanel.Location = new System.Drawing.Point(3, 3);
            this.HashCompareTopPanel.Name = "HashCompareTopPanel";
            this.HashCompareTopPanel.Padding = new System.Windows.Forms.Padding(5);
            this.HashCompareTopPanel.Size = new System.Drawing.Size(761, 237);
            this.HashCompareTopPanel.TabIndex = 0;
            // 
            // FirstHashValueLabel
            // 
            this.FirstHashValueLabel.AutoSize = true;
            this.FirstHashValueLabel.BackColor = System.Drawing.Color.Transparent;
            this.FirstHashValueLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.FirstHashValueLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.FirstHashValueLabel.ForeColor = System.Drawing.Color.Black;
            this.FirstHashValueLabel.Location = new System.Drawing.Point(5, 5);
            this.FirstHashValueLabel.Name = "FirstHashValueLabel";
            this.FirstHashValueLabel.Size = new System.Drawing.Size(187, 19);
            this.FirstHashValueLabel.TabIndex = 3;
            this.FirstHashValueLabel.Text = "Birinci Karma Değeri Giriniz:";
            this.FirstHashValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FirstHashValueTextBox
            // 
            this.FirstHashValueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FirstHashValueTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.FirstHashValueTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FirstHashValueTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.FirstHashValueTextBox.ForeColor = System.Drawing.Color.Black;
            this.FirstHashValueTextBox.Location = new System.Drawing.Point(8, 29);
            this.FirstHashValueTextBox.Margin = new System.Windows.Forms.Padding(3, 5, 0, 5);
            this.FirstHashValueTextBox.MaxLength = 512;
            this.FirstHashValueTextBox.Multiline = true;
            this.FirstHashValueTextBox.Name = "FirstHashValueTextBox";
            this.FirstHashValueTextBox.Size = new System.Drawing.Size(748, 198);
            this.FirstHashValueTextBox.TabIndex = 4;
            this.FirstHashValueTextBox.TextChanged += new System.EventHandler(this.FirstHashValueTextBox_TextChanged);
            // 
            // HashCompareResultLabel
            // 
            this.HashCompareResultLabel.BackColor = System.Drawing.Color.Transparent;
            this.HashCompareResultLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HashCompareResultLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.HashCompareResultLabel.ForeColor = System.Drawing.Color.Black;
            this.HashCompareResultLabel.Location = new System.Drawing.Point(3, 486);
            this.HashCompareResultLabel.Name = "HashCompareResultLabel";
            this.HashCompareResultLabel.Size = new System.Drawing.Size(761, 41);
            this.HashCompareResultLabel.TabIndex = 7;
            this.HashCompareResultLabel.Text = "HASH SONUCU";
            this.HashCompareResultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.HashCompareResultLabel.Visible = false;
            // 
            // HashCompareBottomPanel
            // 
            this.HashCompareBottomPanel.BackColor = System.Drawing.Color.Transparent;
            this.HashCompareBottomPanel.Controls.Add(this.SecondHashValueLabel);
            this.HashCompareBottomPanel.Controls.Add(this.SecondHashValueTextBox);
            this.HashCompareBottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HashCompareBottomPanel.Location = new System.Drawing.Point(3, 246);
            this.HashCompareBottomPanel.Name = "HashCompareBottomPanel";
            this.HashCompareBottomPanel.Padding = new System.Windows.Forms.Padding(5);
            this.HashCompareBottomPanel.Size = new System.Drawing.Size(761, 237);
            this.HashCompareBottomPanel.TabIndex = 1;
            // 
            // SecondHashValueLabel
            // 
            this.SecondHashValueLabel.AutoSize = true;
            this.SecondHashValueLabel.BackColor = System.Drawing.Color.Transparent;
            this.SecondHashValueLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.SecondHashValueLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.SecondHashValueLabel.ForeColor = System.Drawing.Color.Black;
            this.SecondHashValueLabel.Location = new System.Drawing.Point(5, 5);
            this.SecondHashValueLabel.Name = "SecondHashValueLabel";
            this.SecondHashValueLabel.Size = new System.Drawing.Size(181, 19);
            this.SecondHashValueLabel.TabIndex = 5;
            this.SecondHashValueLabel.Text = "İkinci Karma Değeri Giriniz:";
            this.SecondHashValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SecondHashValueTextBox
            // 
            this.SecondHashValueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SecondHashValueTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.SecondHashValueTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SecondHashValueTextBox.Enabled = false;
            this.SecondHashValueTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.SecondHashValueTextBox.ForeColor = System.Drawing.Color.Black;
            this.SecondHashValueTextBox.Location = new System.Drawing.Point(8, 29);
            this.SecondHashValueTextBox.Margin = new System.Windows.Forms.Padding(3, 5, 0, 5);
            this.SecondHashValueTextBox.MaxLength = 512;
            this.SecondHashValueTextBox.Multiline = true;
            this.SecondHashValueTextBox.Name = "SecondHashValueTextBox";
            this.SecondHashValueTextBox.Size = new System.Drawing.Size(748, 198);
            this.SecondHashValueTextBox.TabIndex = 6;
            this.SecondHashValueTextBox.TextChanged += new System.EventHandler(this.SecondHashValueTextBox_TextChanged);
            // 
            // FileHash_BG_Worker
            // 
            this.FileHash_BG_Worker.WorkerReportsProgress = true;
            this.FileHash_BG_Worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.FileHash_BG_Worker_DoWork);
            this.FileHash_BG_Worker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.FileHash_BG_Worker_ProgressChanged);
            this.FileHash_BG_Worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.FileHash_BG_Worker_RunWorkerCompleted);
            // 
            // Vimera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(984, 591);
            this.Controls.Add(this.HeaderPanel);
            this.Controls.Add(this.LeftPanel);
            this.Controls.Add(this.MainContent);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.HeaderMenu;
            this.MinimumSize = new System.Drawing.Size(1000, 630);
            this.Name = "Vimera";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vimera";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Vimera_FormClosing);
            this.Load += new System.EventHandler(this.Vimera_Load);
            this.LeftPanel.ResumeLayout(false);
            this.HeaderPanel.ResumeLayout(false);
            this.HeaderPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderImage)).EndInit();
            this.HeaderMenu.ResumeLayout(false);
            this.HeaderMenu.PerformLayout();
            this.MainContent.ResumeLayout(false);
            this.FileHash.ResumeLayout(false);
            this.FileHash_TLP.ResumeLayout(false);
            this.FileHashPanel.ResumeLayout(false);
            this.FileHashPanel.PerformLayout();
            this.FileHashLoadBG_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FileHashDGV)).EndInit();
            this.TextHash.ResumeLayout(false);
            this.TextHash_TLP.ResumeLayout(false);
            this.TextHashPanel.ResumeLayout(false);
            this.TextHashTLP.ResumeLayout(false);
            this.TextHashTLP_Panel2.ResumeLayout(false);
            this.TextHashTLP_Panel2.PerformLayout();
            this.TextHashTLP_Panel3.ResumeLayout(false);
            this.TextHashTLP_Panel3.PerformLayout();
            this.TextHashTLP_Panel4.ResumeLayout(false);
            this.TextHashTLP_Panel4.PerformLayout();
            this.HashCompare.ResumeLayout(false);
            this.HashCompare_TLP.ResumeLayout(false);
            this.HashComparePanel.ResumeLayout(false);
            this.HashCompareTLP.ResumeLayout(false);
            this.HashCompareTopPanel.ResumeLayout(false);
            this.HashCompareTopPanel.PerformLayout();
            this.HashCompareBottomPanel.ResumeLayout(false);
            this.HashCompareBottomPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel LeftPanel;
        private System.Windows.Forms.Panel HeaderPanel;
        private System.Windows.Forms.Button HashCompareBtn;
        private System.Windows.Forms.Button TextHashBtn;
        private System.Windows.Forms.Button FileHashBtn;
        private System.Windows.Forms.PictureBox HeaderImage;
        private System.Windows.Forms.Label HeaderText;
        private System.Windows.Forms.MenuStrip HeaderMenu;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem themeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lightThemeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem darkThemeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem turkishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem initialViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullScreenToolStripMenuItem;
        private System.Windows.Forms.TabControl MainContent;
        private System.Windows.Forms.TabPage FileHash;
        private System.Windows.Forms.TabPage TextHash;
        private System.Windows.Forms.TabPage HashCompare;
        private System.Windows.Forms.Panel FileHashPanel;
        private System.Windows.Forms.Panel TextHashPanel;
        private System.Windows.Forms.Panel HashComparePanel;
        private System.Windows.Forms.Button FileHashStartBtn;
        internal System.Windows.Forms.ComboBox FileHashAlgorithmSelect;
        internal System.Windows.Forms.TextBox FileHashSelectFilePathTextBox;
        private System.Windows.Forms.Button FileHashSelectFileBtn;
        private System.Windows.Forms.DataGridView FileHashDGV;
        private System.Windows.Forms.CheckBox FileHashUpperHashMode;
        private System.Windows.Forms.Button FileHashCompareBtn;
        internal System.Windows.Forms.TextBox FileHashCompareTextBox;
        private System.ComponentModel.BackgroundWorker FileHash_BG_Worker;
        private System.Windows.Forms.Panel FileHashLoadBG_Panel;
        private System.Windows.Forms.Panel FileHashLoadFE_Panel;
        private System.Windows.Forms.Button FileHashExportHashsBtn;
        private System.Windows.Forms.Label FileHashTimer;
        internal System.Windows.Forms.ComboBox TextHashAlgorithmSelect;
        internal System.Windows.Forms.TextBox TextHashOriginalTextBox;
        internal System.Windows.Forms.TextBox TextHashResultTextBox;
        private System.Windows.Forms.Button TextHashResultCopyBtn;
        internal System.Windows.Forms.TextBox TextHashSaltingTextBox;
        private System.Windows.Forms.CheckBox TextHashSaltingMode;
        private System.Windows.Forms.Label TextHashL2;
        private System.Windows.Forms.Label TextHashL1;
        private System.Windows.Forms.Label TextHashL3;
        internal System.Windows.Forms.ComboBox TextHashSaltingLocateMode;
        private System.Windows.Forms.Label FirstHashValueLabel;
        internal System.Windows.Forms.TextBox FirstHashValueTextBox;
        private System.Windows.Forms.Label SecondHashValueLabel;
        internal System.Windows.Forms.TextBox SecondHashValueTextBox;
        private System.Windows.Forms.Label HashCompareResultLabel;
        private System.Windows.Forms.TableLayoutPanel HashCompareTLP;
        private System.Windows.Forms.Panel HashCompareTopPanel;
        private System.Windows.Forms.Panel HashCompareBottomPanel;
        private System.Windows.Forms.TableLayoutPanel TextHashTLP;
        private System.Windows.Forms.Panel TextHashTLP_Panel2;
        private System.Windows.Forms.Panel TextHashTLP_Panel3;
        private System.Windows.Forms.Panel TextHashTLP_Panel4;
        private System.Windows.Forms.TableLayoutPanel FileHash_TLP;
        private System.Windows.Forms.TableLayoutPanel TextHash_TLP;
        private System.Windows.Forms.TableLayoutPanel HashCompare_TLP;
        private System.Windows.Forms.ToolStripMenuItem gitHubToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem frenchToolStripMenuItem;
    }
}

