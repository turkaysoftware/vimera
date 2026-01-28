namespace Vimera
{
    partial class VimeraMain
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
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.HashCompareBtn = new System.Windows.Forms.Button();
            this.TextHashBtn = new System.Windows.Forms.Button();
            this.FileHashBtn = new System.Windows.Forms.Button();
            this.FileHashTimer = new System.Windows.Forms.Label();
            this.HeaderInPanel = new System.Windows.Forms.Panel();
            this.HeaderImage = new System.Windows.Forms.PictureBox();
            this.HeaderText = new System.Windows.Forms.Label();
            this.HeaderMenu = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.themeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lightThemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darkThemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemThemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arabicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chineseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frenchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.germanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hindiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.italianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.japaneseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.koreanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.polishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.portugueseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.russianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spanishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.turkishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dutchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tSWizardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.donateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainContent = new System.Windows.Forms.TabControl();
            this.FileHash = new System.Windows.Forms.TabPage();
            this.FileHashPanel = new System.Windows.Forms.Panel();
            this.FileHashDGV = new System.Windows.Forms.DataGridView();
            this.FileHashSizer = new System.Windows.Forms.Label();
            this.FileHashStopBtn = new Vimera.TSCustomButton();
            this.FileHashLoadBG_Panel = new System.Windows.Forms.Panel();
            this.FileHashLoadFE_Panel = new System.Windows.Forms.Panel();
            this.FileHashExportHashsBtn = new Vimera.TSCustomButton();
            this.FileHashCompareBtn = new Vimera.TSCustomButton();
            this.FileHashCompareTextBox = new System.Windows.Forms.TextBox();
            this.FileHashUpperHashMode = new System.Windows.Forms.CheckBox();
            this.FileHashSelectFileBtn = new Vimera.TSCustomButton();
            this.FileHashAlgorithmSelect = new Vimera.TSCustomComboBox();
            this.FileHashStartBtn = new Vimera.TSCustomButton();
            this.TextHash = new System.Windows.Forms.TabPage();
            this.TextHashPanel = new System.Windows.Forms.Panel();
            this.TextHashResultCopyBtn = new Vimera.TSCustomButton();
            this.TextHashL3 = new System.Windows.Forms.Label();
            this.TextHashResultTextBox = new System.Windows.Forms.TextBox();
            this.TextHashSaltingTextBox = new System.Windows.Forms.TextBox();
            this.TextHashL2 = new System.Windows.Forms.Label();
            this.TextHashAlgorithmSelect = new Vimera.TSCustomComboBox();
            this.TextHashSaltingLocateMode = new Vimera.TSCustomComboBox();
            this.TextHashSaltingMode = new System.Windows.Forms.CheckBox();
            this.TextHashL1 = new System.Windows.Forms.Label();
            this.TextHashOriginalTextBox = new System.Windows.Forms.TextBox();
            this.HashCompare = new System.Windows.Forms.TabPage();
            this.HashComparePanel = new System.Windows.Forms.Panel();
            this.HashCompareResult = new Vimera.TSCustomButton();
            this.SecondHashValueLabel = new System.Windows.Forms.Label();
            this.SecondHashValueTextBox = new System.Windows.Forms.TextBox();
            this.FirstHashValueLabel = new System.Windows.Forms.Label();
            this.FirstHashValueTextBox = new System.Windows.Forms.TextBox();
            this.FileHash_BG_Worker = new System.ComponentModel.BackgroundWorker();
            this.HeaderPanel = new System.Windows.Forms.TableLayoutPanel();
            this.LeftPanel.SuspendLayout();
            this.HeaderInPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderImage)).BeginInit();
            this.HeaderMenu.SuspendLayout();
            this.MainContent.SuspendLayout();
            this.FileHash.SuspendLayout();
            this.FileHashPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FileHashDGV)).BeginInit();
            this.FileHashLoadBG_Panel.SuspendLayout();
            this.TextHash.SuspendLayout();
            this.TextHashPanel.SuspendLayout();
            this.HashCompare.SuspendLayout();
            this.HashComparePanel.SuspendLayout();
            this.HeaderPanel.SuspendLayout();
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
            this.LeftPanel.Size = new System.Drawing.Size(225, 601);
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
            this.HashCompareBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.HashCompareBtn.Location = new System.Drawing.Point(0, 84);
            this.HashCompareBtn.Name = "HashCompareBtn";
            this.HashCompareBtn.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.HashCompareBtn.Size = new System.Drawing.Size(225, 42);
            this.HashCompareBtn.TabIndex = 2;
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
            this.TextHashBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TextHashBtn.Location = new System.Drawing.Point(0, 42);
            this.TextHashBtn.Name = "TextHashBtn";
            this.TextHashBtn.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.TextHashBtn.Size = new System.Drawing.Size(225, 42);
            this.TextHashBtn.TabIndex = 1;
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
            this.FileHashBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FileHashBtn.Location = new System.Drawing.Point(0, 0);
            this.FileHashBtn.Name = "FileHashBtn";
            this.FileHashBtn.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.FileHashBtn.Size = new System.Drawing.Size(225, 42);
            this.FileHashBtn.TabIndex = 0;
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
            this.FileHashTimer.Location = new System.Drawing.Point(91, 475);
            this.FileHashTimer.Margin = new System.Windows.Forms.Padding(3);
            this.FileHashTimer.Name = "FileHashTimer";
            this.FileHashTimer.Size = new System.Drawing.Size(100, 25);
            this.FileHashTimer.TabIndex = 7;
            this.FileHashTimer.Text = "--:--:--";
            this.FileHashTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.FileHashTimer.Visible = false;
            // 
            // HeaderInPanel
            // 
            this.HeaderInPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.HeaderInPanel.Controls.Add(this.HeaderImage);
            this.HeaderInPanel.Controls.Add(this.HeaderText);
            this.HeaderInPanel.Controls.Add(this.HeaderMenu);
            this.HeaderInPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HeaderInPanel.Location = new System.Drawing.Point(3, 0);
            this.HeaderInPanel.Margin = new System.Windows.Forms.Padding(0);
            this.HeaderInPanel.Name = "HeaderInPanel";
            this.HeaderInPanel.Size = new System.Drawing.Size(780, 42);
            this.HeaderInPanel.TabIndex = 0;
            // 
            // HeaderImage
            // 
            this.HeaderImage.BackColor = System.Drawing.Color.Transparent;
            this.HeaderImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.HeaderImage.Location = new System.Drawing.Point(7, 8);
            this.HeaderImage.Name = "HeaderImage";
            this.HeaderImage.Size = new System.Drawing.Size(27, 27);
            this.HeaderImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.HeaderImage.TabIndex = 8;
            this.HeaderImage.TabStop = false;
            // 
            // HeaderText
            // 
            this.HeaderText.AutoSize = true;
            this.HeaderText.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.HeaderText.Location = new System.Drawing.Point(38, 11);
            this.HeaderText.Name = "HeaderText";
            this.HeaderText.Size = new System.Drawing.Size(160, 21);
            this.HeaderText.TabIndex = 0;
            this.HeaderText.Text = "DOSYA HAM DEĞERİ";
            // 
            // HeaderMenu
            // 
            this.HeaderMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.HeaderMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.HeaderMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.tSWizardToolStripMenuItem,
            this.donateToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.HeaderMenu.Location = new System.Drawing.Point(524, 9);
            this.HeaderMenu.Name = "HeaderMenu";
            this.HeaderMenu.Size = new System.Drawing.Size(246, 24);
            this.HeaderMenu.TabIndex = 1;
            this.HeaderMenu.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.themeToolStripMenuItem,
            this.languageToolStripMenuItem,
            this.startupToolStripMenuItem,
            this.checkForUpdateToolStripMenuItem});
            this.settingsToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // themeToolStripMenuItem
            // 
            this.themeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lightThemeToolStripMenuItem,
            this.darkThemeToolStripMenuItem,
            this.systemThemeToolStripMenuItem});
            this.themeToolStripMenuItem.Name = "themeToolStripMenuItem";
            this.themeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.themeToolStripMenuItem.Text = "Theme";
            // 
            // lightThemeToolStripMenuItem
            // 
            this.lightThemeToolStripMenuItem.Name = "lightThemeToolStripMenuItem";
            this.lightThemeToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.lightThemeToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.lightThemeToolStripMenuItem.Text = "Light Theme";
            this.lightThemeToolStripMenuItem.Click += new System.EventHandler(this.LightThemeToolStripMenuItem_Click);
            // 
            // darkThemeToolStripMenuItem
            // 
            this.darkThemeToolStripMenuItem.Name = "darkThemeToolStripMenuItem";
            this.darkThemeToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.darkThemeToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.darkThemeToolStripMenuItem.Text = "Dark Theme";
            this.darkThemeToolStripMenuItem.Click += new System.EventHandler(this.DarkThemeToolStripMenuItem_Click);
            // 
            // systemThemeToolStripMenuItem
            // 
            this.systemThemeToolStripMenuItem.Name = "systemThemeToolStripMenuItem";
            this.systemThemeToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.systemThemeToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.systemThemeToolStripMenuItem.Text = "System Theme";
            this.systemThemeToolStripMenuItem.Click += new System.EventHandler(this.SystemThemeToolStripMenuItem_Click);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arabicToolStripMenuItem,
            this.chineseToolStripMenuItem,
            this.englishToolStripMenuItem,
            this.dutchToolStripMenuItem,
            this.frenchToolStripMenuItem,
            this.germanToolStripMenuItem,
            this.hindiToolStripMenuItem,
            this.italianToolStripMenuItem,
            this.japaneseToolStripMenuItem,
            this.koreanToolStripMenuItem,
            this.polishToolStripMenuItem,
            this.portugueseToolStripMenuItem,
            this.russianToolStripMenuItem,
            this.spanishToolStripMenuItem,
            this.turkishToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.languageToolStripMenuItem.Text = "Language";
            // 
            // arabicToolStripMenuItem
            // 
            this.arabicToolStripMenuItem.Name = "arabicToolStripMenuItem";
            this.arabicToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.arabicToolStripMenuItem.Text = "Arabic";
            // 
            // chineseToolStripMenuItem
            // 
            this.chineseToolStripMenuItem.Name = "chineseToolStripMenuItem";
            this.chineseToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.chineseToolStripMenuItem.Text = "Chinese";
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.englishToolStripMenuItem.Text = "English";
            // 
            // frenchToolStripMenuItem
            // 
            this.frenchToolStripMenuItem.Name = "frenchToolStripMenuItem";
            this.frenchToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.frenchToolStripMenuItem.Text = "French";
            // 
            // germanToolStripMenuItem
            // 
            this.germanToolStripMenuItem.Name = "germanToolStripMenuItem";
            this.germanToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.germanToolStripMenuItem.Text = "German";
            // 
            // hindiToolStripMenuItem
            // 
            this.hindiToolStripMenuItem.Name = "hindiToolStripMenuItem";
            this.hindiToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.hindiToolStripMenuItem.Text = "Hindi";
            // 
            // italianToolStripMenuItem
            // 
            this.italianToolStripMenuItem.Name = "italianToolStripMenuItem";
            this.italianToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.italianToolStripMenuItem.Text = "Italian";
            // 
            // japaneseToolStripMenuItem
            // 
            this.japaneseToolStripMenuItem.Name = "japaneseToolStripMenuItem";
            this.japaneseToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.japaneseToolStripMenuItem.Text = "Japanese";
            // 
            // koreanToolStripMenuItem
            // 
            this.koreanToolStripMenuItem.Name = "koreanToolStripMenuItem";
            this.koreanToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.koreanToolStripMenuItem.Text = "Korean";
            // 
            // polishToolStripMenuItem
            // 
            this.polishToolStripMenuItem.Name = "polishToolStripMenuItem";
            this.polishToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.polishToolStripMenuItem.Text = "Polish";
            // 
            // portugueseToolStripMenuItem
            // 
            this.portugueseToolStripMenuItem.Name = "portugueseToolStripMenuItem";
            this.portugueseToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.portugueseToolStripMenuItem.Text = "Portuguese";
            // 
            // russianToolStripMenuItem
            // 
            this.russianToolStripMenuItem.Name = "russianToolStripMenuItem";
            this.russianToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.russianToolStripMenuItem.Text = "Russian";
            // 
            // spanishToolStripMenuItem
            // 
            this.spanishToolStripMenuItem.Name = "spanishToolStripMenuItem";
            this.spanishToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.spanishToolStripMenuItem.Text = "Spanish";
            // 
            // turkishToolStripMenuItem
            // 
            this.turkishToolStripMenuItem.Name = "turkishToolStripMenuItem";
            this.turkishToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.turkishToolStripMenuItem.Text = "Turkish";
            // 
            // dutchToolStripMenuItem
            // 
            this.dutchToolStripMenuItem.Name = "dutchToolStripMenuItem";
            this.dutchToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.dutchToolStripMenuItem.Text = "Dutch";
            // 
            // startupToolStripMenuItem
            // 
            this.startupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.windowedToolStripMenuItem,
            this.fullScreenToolStripMenuItem});
            this.startupToolStripMenuItem.Name = "startupToolStripMenuItem";
            this.startupToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.startupToolStripMenuItem.Text = "Startup";
            // 
            // windowedToolStripMenuItem
            // 
            this.windowedToolStripMenuItem.Name = "windowedToolStripMenuItem";
            this.windowedToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.windowedToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.windowedToolStripMenuItem.Text = "Windowed";
            this.windowedToolStripMenuItem.Click += new System.EventHandler(this.WindowedToolStripMenuItem_Click);
            // 
            // fullScreenToolStripMenuItem
            // 
            this.fullScreenToolStripMenuItem.Name = "fullScreenToolStripMenuItem";
            this.fullScreenToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.fullScreenToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.fullScreenToolStripMenuItem.Text = "Full Screen";
            this.fullScreenToolStripMenuItem.Click += new System.EventHandler(this.FullScreenToolStripMenuItem_Click);
            // 
            // checkForUpdateToolStripMenuItem
            // 
            this.checkForUpdateToolStripMenuItem.Name = "checkForUpdateToolStripMenuItem";
            this.checkForUpdateToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F11;
            this.checkForUpdateToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.checkForUpdateToolStripMenuItem.Text = "Check Update";
            this.checkForUpdateToolStripMenuItem.Click += new System.EventHandler(this.CheckForUpdateToolStripMenuItem_Click);
            // 
            // tSWizardToolStripMenuItem
            // 
            this.tSWizardToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tSWizardToolStripMenuItem.Name = "tSWizardToolStripMenuItem";
            this.tSWizardToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.tSWizardToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.tSWizardToolStripMenuItem.Text = "TSWizard";
            this.tSWizardToolStripMenuItem.Click += new System.EventHandler(this.TSWizardToolStripMenuItem_Click);
            // 
            // donateToolStripMenuItem
            // 
            this.donateToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.donateToolStripMenuItem.Name = "donateToolStripMenuItem";
            this.donateToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.D)));
            this.donateToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.donateToolStripMenuItem.Text = "Donate";
            this.donateToolStripMenuItem.Click += new System.EventHandler(this.DonateToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // MainContent
            // 
            this.MainContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainContent.Controls.Add(this.FileHash);
            this.MainContent.Controls.Add(this.TextHash);
            this.MainContent.Controls.Add(this.HashCompare);
            this.MainContent.Location = new System.Drawing.Point(218, 17);
            this.MainContent.Name = "MainContent";
            this.MainContent.SelectedIndex = 0;
            this.MainContent.Size = new System.Drawing.Size(797, 591);
            this.MainContent.TabIndex = 2;
            this.MainContent.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.MainContent_Selecting);
            // 
            // FileHash
            // 
            this.FileHash.Controls.Add(this.FileHashPanel);
            this.FileHash.Location = new System.Drawing.Point(4, 22);
            this.FileHash.Name = "FileHash";
            this.FileHash.Padding = new System.Windows.Forms.Padding(6);
            this.FileHash.Size = new System.Drawing.Size(789, 565);
            this.FileHash.TabIndex = 0;
            this.FileHash.Text = "FileHash";
            this.FileHash.UseVisualStyleBackColor = true;
            // 
            // FileHashPanel
            // 
            this.FileHashPanel.AllowDrop = true;
            this.FileHashPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.FileHashPanel.Controls.Add(this.FileHashDGV);
            this.FileHashPanel.Controls.Add(this.FileHashSizer);
            this.FileHashPanel.Controls.Add(this.FileHashStopBtn);
            this.FileHashPanel.Controls.Add(this.FileHashLoadBG_Panel);
            this.FileHashPanel.Controls.Add(this.FileHashTimer);
            this.FileHashPanel.Controls.Add(this.FileHashExportHashsBtn);
            this.FileHashPanel.Controls.Add(this.FileHashCompareBtn);
            this.FileHashPanel.Controls.Add(this.FileHashCompareTextBox);
            this.FileHashPanel.Controls.Add(this.FileHashUpperHashMode);
            this.FileHashPanel.Controls.Add(this.FileHashSelectFileBtn);
            this.FileHashPanel.Controls.Add(this.FileHashAlgorithmSelect);
            this.FileHashPanel.Controls.Add(this.FileHashStartBtn);
            this.FileHashPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileHashPanel.Location = new System.Drawing.Point(6, 6);
            this.FileHashPanel.Name = "FileHashPanel";
            this.FileHashPanel.Padding = new System.Windows.Forms.Padding(5);
            this.FileHashPanel.Size = new System.Drawing.Size(777, 553);
            this.FileHashPanel.TabIndex = 0;
            this.FileHashPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.FileHashPanel_DragDrop);
            this.FileHashPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.FileHashPanel_DragEnter);
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
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SlateBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SlateBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.FileHashDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.FileHashDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FileHashDGV.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SlateBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.FileHashDGV.DefaultCellStyle = dataGridViewCellStyle3;
            this.FileHashDGV.EnableHeadersVisualStyles = false;
            this.FileHashDGV.GridColor = System.Drawing.Color.Gray;
            this.FileHashDGV.Location = new System.Drawing.Point(8, 52);
            this.FileHashDGV.MultiSelect = false;
            this.FileHashDGV.Name = "FileHashDGV";
            this.FileHashDGV.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SlateBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.FileHashDGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.FileHashDGV.RowHeadersVisible = false;
            this.FileHashDGV.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.FileHashDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.FileHashDGV.Size = new System.Drawing.Size(761, 417);
            this.FileHashDGV.TabIndex = 5;
            this.FileHashDGV.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FileHashDGV_CellDoubleClick);
            // 
            // FileHashSizer
            // 
            this.FileHashSizer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.FileHashSizer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.FileHashSizer.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.FileHashSizer.Location = new System.Drawing.Point(7, 475);
            this.FileHashSizer.Margin = new System.Windows.Forms.Padding(3);
            this.FileHashSizer.Name = "FileHashSizer";
            this.FileHashSizer.Size = new System.Drawing.Size(78, 25);
            this.FileHashSizer.TabIndex = 6;
            this.FileHashSizer.Text = "00,00 XX";
            this.FileHashSizer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.FileHashSizer.Visible = false;
            // 
            // FileHashStopBtn
            // 
            this.FileHashStopBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.FileHashStopBtn.BackColor = System.Drawing.Color.SlateBlue;
            this.FileHashStopBtn.BackgroundColor = System.Drawing.Color.SlateBlue;
            this.FileHashStopBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.FileHashStopBtn.BorderColor = System.Drawing.Color.SlateBlue;
            this.FileHashStopBtn.BorderRadius = 5;
            this.FileHashStopBtn.BorderSize = 0;
            this.FileHashStopBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FileHashStopBtn.Enabled = false;
            this.FileHashStopBtn.FlatAppearance.BorderSize = 0;
            this.FileHashStopBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FileHashStopBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.FileHashStopBtn.ForeColor = System.Drawing.Color.White;
            this.FileHashStopBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.FileHashStopBtn.Location = new System.Drawing.Point(544, 506);
            this.FileHashStopBtn.Margin = new System.Windows.Forms.Padding(1, 3, 3, 3);
            this.FileHashStopBtn.Name = "FileHashStopBtn";
            this.FileHashStopBtn.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.FileHashStopBtn.Size = new System.Drawing.Size(225, 39);
            this.FileHashStopBtn.TabIndex = 11;
            this.FileHashStopBtn.Text = "DURDUR";
            this.FileHashStopBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FileHashStopBtn.TextColor = System.Drawing.Color.White;
            this.FileHashStopBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.FileHashStopBtn.UseVisualStyleBackColor = false;
            this.FileHashStopBtn.Click += new System.EventHandler(this.FileHashStopBtn_Click);
            // 
            // FileHashLoadBG_Panel
            // 
            this.FileHashLoadBG_Panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileHashLoadBG_Panel.Controls.Add(this.FileHashLoadFE_Panel);
            this.FileHashLoadBG_Panel.Location = new System.Drawing.Point(8, 47);
            this.FileHashLoadBG_Panel.Name = "FileHashLoadBG_Panel";
            this.FileHashLoadBG_Panel.Size = new System.Drawing.Size(761, 5);
            this.FileHashLoadBG_Panel.TabIndex = 4;
            this.FileHashLoadBG_Panel.Visible = false;
            // 
            // FileHashLoadFE_Panel
            // 
            this.FileHashLoadFE_Panel.BackColor = System.Drawing.Color.SlateBlue;
            this.FileHashLoadFE_Panel.Dock = System.Windows.Forms.DockStyle.Left;
            this.FileHashLoadFE_Panel.Location = new System.Drawing.Point(0, 0);
            this.FileHashLoadFE_Panel.Name = "FileHashLoadFE_Panel";
            this.FileHashLoadFE_Panel.Size = new System.Drawing.Size(137, 5);
            this.FileHashLoadFE_Panel.TabIndex = 0;
            // 
            // FileHashExportHashsBtn
            // 
            this.FileHashExportHashsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FileHashExportHashsBtn.BackColor = System.Drawing.Color.SlateBlue;
            this.FileHashExportHashsBtn.BackgroundColor = System.Drawing.Color.SlateBlue;
            this.FileHashExportHashsBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.FileHashExportHashsBtn.BorderColor = System.Drawing.Color.SlateBlue;
            this.FileHashExportHashsBtn.BorderRadius = 5;
            this.FileHashExportHashsBtn.BorderSize = 0;
            this.FileHashExportHashsBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FileHashExportHashsBtn.FlatAppearance.BorderSize = 0;
            this.FileHashExportHashsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FileHashExportHashsBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.FileHashExportHashsBtn.ForeColor = System.Drawing.Color.White;
            this.FileHashExportHashsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.FileHashExportHashsBtn.Location = new System.Drawing.Point(418, 8);
            this.FileHashExportHashsBtn.Name = "FileHashExportHashsBtn";
            this.FileHashExportHashsBtn.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.FileHashExportHashsBtn.Size = new System.Drawing.Size(185, 27);
            this.FileHashExportHashsBtn.TabIndex = 2;
            this.FileHashExportHashsBtn.Text = "DIŞA AKTAR";
            this.FileHashExportHashsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FileHashExportHashsBtn.TextColor = System.Drawing.Color.White;
            this.FileHashExportHashsBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.FileHashExportHashsBtn.UseVisualStyleBackColor = false;
            this.FileHashExportHashsBtn.Visible = false;
            this.FileHashExportHashsBtn.Click += new System.EventHandler(this.FileHashExportHashsBtn_Click);
            // 
            // FileHashCompareBtn
            // 
            this.FileHashCompareBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.FileHashCompareBtn.BackColor = System.Drawing.Color.SlateBlue;
            this.FileHashCompareBtn.BackgroundColor = System.Drawing.Color.SlateBlue;
            this.FileHashCompareBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.FileHashCompareBtn.BorderColor = System.Drawing.Color.SlateBlue;
            this.FileHashCompareBtn.BorderRadius = 5;
            this.FileHashCompareBtn.BorderSize = 0;
            this.FileHashCompareBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FileHashCompareBtn.Enabled = false;
            this.FileHashCompareBtn.FlatAppearance.BorderSize = 0;
            this.FileHashCompareBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FileHashCompareBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.FileHashCompareBtn.ForeColor = System.Drawing.Color.White;
            this.FileHashCompareBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.FileHashCompareBtn.Location = new System.Drawing.Point(609, 474);
            this.FileHashCompareBtn.Name = "FileHashCompareBtn";
            this.FileHashCompareBtn.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.FileHashCompareBtn.Size = new System.Drawing.Size(160, 27);
            this.FileHashCompareBtn.TabIndex = 9;
            this.FileHashCompareBtn.Text = "SINA";
            this.FileHashCompareBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FileHashCompareBtn.TextColor = System.Drawing.Color.White;
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
            this.FileHashCompareTextBox.Location = new System.Drawing.Point(197, 475);
            this.FileHashCompareTextBox.MaxLength = 256;
            this.FileHashCompareTextBox.Name = "FileHashCompareTextBox";
            this.FileHashCompareTextBox.Size = new System.Drawing.Size(406, 25);
            this.FileHashCompareTextBox.TabIndex = 8;
            this.FileHashCompareTextBox.Visible = false;
            this.FileHashCompareTextBox.TextChanged += new System.EventHandler(this.FileHashCompareTextBox_TextChanged);
            // 
            // FileHashUpperHashMode
            // 
            this.FileHashUpperHashMode.AutoSize = true;
            this.FileHashUpperHashMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FileHashUpperHashMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FileHashUpperHashMode.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.FileHashUpperHashMode.Location = new System.Drawing.Point(114, 9);
            this.FileHashUpperHashMode.Name = "FileHashUpperHashMode";
            this.FileHashUpperHashMode.Padding = new System.Windows.Forms.Padding(7, 3, 5, 3);
            this.FileHashUpperHashMode.Size = new System.Drawing.Size(166, 25);
            this.FileHashUpperHashMode.TabIndex = 1;
            this.FileHashUpperHashMode.Text = "Büyük harf karma modu";
            this.FileHashUpperHashMode.UseVisualStyleBackColor = false;
            this.FileHashUpperHashMode.Visible = false;
            this.FileHashUpperHashMode.CheckedChanged += new System.EventHandler(this.FileHashUpperHashMode_CheckedChanged);
            // 
            // FileHashSelectFileBtn
            // 
            this.FileHashSelectFileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FileHashSelectFileBtn.BackColor = System.Drawing.Color.SlateBlue;
            this.FileHashSelectFileBtn.BackgroundColor = System.Drawing.Color.SlateBlue;
            this.FileHashSelectFileBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.FileHashSelectFileBtn.BorderColor = System.Drawing.Color.SlateBlue;
            this.FileHashSelectFileBtn.BorderRadius = 5;
            this.FileHashSelectFileBtn.BorderSize = 0;
            this.FileHashSelectFileBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FileHashSelectFileBtn.FlatAppearance.BorderSize = 0;
            this.FileHashSelectFileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FileHashSelectFileBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.FileHashSelectFileBtn.ForeColor = System.Drawing.Color.White;
            this.FileHashSelectFileBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.FileHashSelectFileBtn.Location = new System.Drawing.Point(609, 8);
            this.FileHashSelectFileBtn.Name = "FileHashSelectFileBtn";
            this.FileHashSelectFileBtn.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.FileHashSelectFileBtn.Size = new System.Drawing.Size(160, 27);
            this.FileHashSelectFileBtn.TabIndex = 3;
            this.FileHashSelectFileBtn.Text = "SEÇ";
            this.FileHashSelectFileBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FileHashSelectFileBtn.TextColor = System.Drawing.Color.White;
            this.FileHashSelectFileBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.FileHashSelectFileBtn.UseVisualStyleBackColor = false;
            this.FileHashSelectFileBtn.Click += new System.EventHandler(this.FileHashSelectFileBtn_Click);
            // 
            // FileHashAlgorithmSelect
            // 
            this.FileHashAlgorithmSelect.ArrowColor = System.Drawing.Color.White;
            this.FileHashAlgorithmSelect.BackColor = System.Drawing.Color.SlateBlue;
            this.FileHashAlgorithmSelect.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.FileHashAlgorithmSelect.ButtonColor = System.Drawing.Color.SlateBlue;
            this.FileHashAlgorithmSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FileHashAlgorithmSelect.DisabledArrowColor = System.Drawing.SystemColors.GrayText;
            this.FileHashAlgorithmSelect.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.FileHashAlgorithmSelect.DisabledButtonColor = System.Drawing.SystemColors.ControlDark;
            this.FileHashAlgorithmSelect.DisabledForeColor = System.Drawing.SystemColors.GrayText;
            this.FileHashAlgorithmSelect.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.FileHashAlgorithmSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FileHashAlgorithmSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FileHashAlgorithmSelect.FocusedBorderColor = System.Drawing.Color.DodgerBlue;
            this.FileHashAlgorithmSelect.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.FileHashAlgorithmSelect.ForeColor = System.Drawing.Color.White;
            this.FileHashAlgorithmSelect.FormattingEnabled = true;
            this.FileHashAlgorithmSelect.HoverBackColor = System.Drawing.SystemColors.Window;
            this.FileHashAlgorithmSelect.HoverButtonColor = System.Drawing.SystemColors.ControlDark;
            this.FileHashAlgorithmSelect.Location = new System.Drawing.Point(8, 8);
            this.FileHashAlgorithmSelect.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.FileHashAlgorithmSelect.Name = "FileHashAlgorithmSelect";
            this.FileHashAlgorithmSelect.Size = new System.Drawing.Size(100, 26);
            this.FileHashAlgorithmSelect.TabIndex = 0;
            this.FileHashAlgorithmSelect.SelectedIndexChanged += new System.EventHandler(this.FileHashAlgorithmSelect_SelectedIndexChanged);
            // 
            // FileHashStartBtn
            // 
            this.FileHashStartBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileHashStartBtn.BackColor = System.Drawing.Color.SlateBlue;
            this.FileHashStartBtn.BackgroundColor = System.Drawing.Color.SlateBlue;
            this.FileHashStartBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.FileHashStartBtn.BorderColor = System.Drawing.Color.SlateBlue;
            this.FileHashStartBtn.BorderRadius = 5;
            this.FileHashStartBtn.BorderSize = 0;
            this.FileHashStartBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FileHashStartBtn.Enabled = false;
            this.FileHashStartBtn.FlatAppearance.BorderSize = 0;
            this.FileHashStartBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FileHashStartBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.FileHashStartBtn.ForeColor = System.Drawing.Color.White;
            this.FileHashStartBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.FileHashStartBtn.Location = new System.Drawing.Point(7, 506);
            this.FileHashStartBtn.Margin = new System.Windows.Forms.Padding(3, 3, 1, 3);
            this.FileHashStartBtn.Name = "FileHashStartBtn";
            this.FileHashStartBtn.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.FileHashStartBtn.Size = new System.Drawing.Size(535, 39);
            this.FileHashStartBtn.TabIndex = 10;
            this.FileHashStartBtn.Text = "BAŞLAT";
            this.FileHashStartBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FileHashStartBtn.TextColor = System.Drawing.Color.White;
            this.FileHashStartBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.FileHashStartBtn.UseVisualStyleBackColor = false;
            this.FileHashStartBtn.Click += new System.EventHandler(this.FileHashStartBtn_Click);
            // 
            // TextHash
            // 
            this.TextHash.Controls.Add(this.TextHashPanel);
            this.TextHash.Location = new System.Drawing.Point(4, 22);
            this.TextHash.Name = "TextHash";
            this.TextHash.Padding = new System.Windows.Forms.Padding(6);
            this.TextHash.Size = new System.Drawing.Size(789, 565);
            this.TextHash.TabIndex = 1;
            this.TextHash.Text = "TextHash";
            this.TextHash.UseVisualStyleBackColor = true;
            // 
            // TextHashPanel
            // 
            this.TextHashPanel.AllowDrop = true;
            this.TextHashPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.TextHashPanel.Controls.Add(this.TextHashResultCopyBtn);
            this.TextHashPanel.Controls.Add(this.TextHashL3);
            this.TextHashPanel.Controls.Add(this.TextHashResultTextBox);
            this.TextHashPanel.Controls.Add(this.TextHashSaltingTextBox);
            this.TextHashPanel.Controls.Add(this.TextHashL2);
            this.TextHashPanel.Controls.Add(this.TextHashAlgorithmSelect);
            this.TextHashPanel.Controls.Add(this.TextHashSaltingLocateMode);
            this.TextHashPanel.Controls.Add(this.TextHashSaltingMode);
            this.TextHashPanel.Controls.Add(this.TextHashL1);
            this.TextHashPanel.Controls.Add(this.TextHashOriginalTextBox);
            this.TextHashPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextHashPanel.Location = new System.Drawing.Point(6, 6);
            this.TextHashPanel.Name = "TextHashPanel";
            this.TextHashPanel.Padding = new System.Windows.Forms.Padding(5);
            this.TextHashPanel.Size = new System.Drawing.Size(777, 553);
            this.TextHashPanel.TabIndex = 0;
            this.TextHashPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextHashPanel_DragDrop);
            this.TextHashPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextHashPanel_DragEnter);
            // 
            // TextHashResultCopyBtn
            // 
            this.TextHashResultCopyBtn.BackColor = System.Drawing.Color.SlateBlue;
            this.TextHashResultCopyBtn.BackgroundColor = System.Drawing.Color.SlateBlue;
            this.TextHashResultCopyBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.TextHashResultCopyBtn.BorderColor = System.Drawing.Color.SlateBlue;
            this.TextHashResultCopyBtn.BorderRadius = 5;
            this.TextHashResultCopyBtn.BorderSize = 0;
            this.TextHashResultCopyBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TextHashResultCopyBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TextHashResultCopyBtn.Enabled = false;
            this.TextHashResultCopyBtn.FlatAppearance.BorderSize = 0;
            this.TextHashResultCopyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TextHashResultCopyBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.TextHashResultCopyBtn.ForeColor = System.Drawing.Color.White;
            this.TextHashResultCopyBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.TextHashResultCopyBtn.Location = new System.Drawing.Point(5, 509);
            this.TextHashResultCopyBtn.Margin = new System.Windows.Forms.Padding(7, 0, 8, 8);
            this.TextHashResultCopyBtn.Name = "TextHashResultCopyBtn";
            this.TextHashResultCopyBtn.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.TextHashResultCopyBtn.Size = new System.Drawing.Size(767, 39);
            this.TextHashResultCopyBtn.TabIndex = 9;
            this.TextHashResultCopyBtn.Text = "KOPYALA";
            this.TextHashResultCopyBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TextHashResultCopyBtn.TextColor = System.Drawing.Color.White;
            this.TextHashResultCopyBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.TextHashResultCopyBtn.UseVisualStyleBackColor = false;
            this.TextHashResultCopyBtn.Click += new System.EventHandler(this.TextHashResultCopyBtn_Click);
            // 
            // TextHashL3
            // 
            this.TextHashL3.AutoSize = true;
            this.TextHashL3.BackColor = System.Drawing.Color.Transparent;
            this.TextHashL3.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.TextHashL3.Location = new System.Drawing.Point(4, 313);
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
            this.TextHashResultTextBox.Location = new System.Drawing.Point(7, 337);
            this.TextHashResultTextBox.Margin = new System.Windows.Forms.Padding(3, 5, 0, 15);
            this.TextHashResultTextBox.MaxLength = 256;
            this.TextHashResultTextBox.Multiline = true;
            this.TextHashResultTextBox.Name = "TextHashResultTextBox";
            this.TextHashResultTextBox.Size = new System.Drawing.Size(762, 160);
            this.TextHashResultTextBox.TabIndex = 8;
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
            this.TextHashSaltingTextBox.Location = new System.Drawing.Point(8, 246);
            this.TextHashSaltingTextBox.Margin = new System.Windows.Forms.Padding(3, 5, 5, 5);
            this.TextHashSaltingTextBox.MaxLength = 32;
            this.TextHashSaltingTextBox.Name = "TextHashSaltingTextBox";
            this.TextHashSaltingTextBox.Size = new System.Drawing.Size(520, 25);
            this.TextHashSaltingTextBox.TabIndex = 4;
            this.TextHashSaltingTextBox.TextChanged += new System.EventHandler(this.TextHashSaltingTextBox_TextChanged);
            // 
            // TextHashL2
            // 
            this.TextHashL2.AutoSize = true;
            this.TextHashL2.BackColor = System.Drawing.Color.Transparent;
            this.TextHashL2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.TextHashL2.Location = new System.Drawing.Point(4, 222);
            this.TextHashL2.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.TextHashL2.Name = "TextHashL2";
            this.TextHashL2.Size = new System.Drawing.Size(155, 19);
            this.TextHashL2.TabIndex = 3;
            this.TextHashL2.Text = "Tuzlama Değeri Giriniz:";
            this.TextHashL2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TextHashAlgorithmSelect
            // 
            this.TextHashAlgorithmSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TextHashAlgorithmSelect.ArrowColor = System.Drawing.Color.White;
            this.TextHashAlgorithmSelect.BackColor = System.Drawing.Color.SlateBlue;
            this.TextHashAlgorithmSelect.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.TextHashAlgorithmSelect.ButtonColor = System.Drawing.Color.SlateBlue;
            this.TextHashAlgorithmSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TextHashAlgorithmSelect.DisabledArrowColor = System.Drawing.SystemColors.GrayText;
            this.TextHashAlgorithmSelect.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.TextHashAlgorithmSelect.DisabledButtonColor = System.Drawing.SystemColors.ControlDark;
            this.TextHashAlgorithmSelect.DisabledForeColor = System.Drawing.SystemColors.GrayText;
            this.TextHashAlgorithmSelect.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.TextHashAlgorithmSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TextHashAlgorithmSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TextHashAlgorithmSelect.FocusedBorderColor = System.Drawing.Color.DodgerBlue;
            this.TextHashAlgorithmSelect.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.TextHashAlgorithmSelect.ForeColor = System.Drawing.Color.White;
            this.TextHashAlgorithmSelect.FormattingEnabled = true;
            this.TextHashAlgorithmSelect.HoverBackColor = System.Drawing.SystemColors.Window;
            this.TextHashAlgorithmSelect.HoverButtonColor = System.Drawing.SystemColors.ControlDark;
            this.TextHashAlgorithmSelect.Location = new System.Drawing.Point(644, 8);
            this.TextHashAlgorithmSelect.Name = "TextHashAlgorithmSelect";
            this.TextHashAlgorithmSelect.Size = new System.Drawing.Size(125, 26);
            this.TextHashAlgorithmSelect.TabIndex = 1;
            this.TextHashAlgorithmSelect.SelectedIndexChanged += new System.EventHandler(this.TextHashAlgorithmSelect_SelectedIndexChanged);
            // 
            // TextHashSaltingLocateMode
            // 
            this.TextHashSaltingLocateMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TextHashSaltingLocateMode.ArrowColor = System.Drawing.Color.White;
            this.TextHashSaltingLocateMode.BackColor = System.Drawing.Color.SlateBlue;
            this.TextHashSaltingLocateMode.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.TextHashSaltingLocateMode.ButtonColor = System.Drawing.Color.SlateBlue;
            this.TextHashSaltingLocateMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TextHashSaltingLocateMode.DisabledArrowColor = System.Drawing.SystemColors.GrayText;
            this.TextHashSaltingLocateMode.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.TextHashSaltingLocateMode.DisabledButtonColor = System.Drawing.SystemColors.ControlDark;
            this.TextHashSaltingLocateMode.DisabledForeColor = System.Drawing.SystemColors.GrayText;
            this.TextHashSaltingLocateMode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.TextHashSaltingLocateMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TextHashSaltingLocateMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TextHashSaltingLocateMode.FocusedBorderColor = System.Drawing.Color.DodgerBlue;
            this.TextHashSaltingLocateMode.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.TextHashSaltingLocateMode.ForeColor = System.Drawing.Color.White;
            this.TextHashSaltingLocateMode.FormattingEnabled = true;
            this.TextHashSaltingLocateMode.HoverBackColor = System.Drawing.SystemColors.Window;
            this.TextHashSaltingLocateMode.HoverButtonColor = System.Drawing.SystemColors.ControlDark;
            this.TextHashSaltingLocateMode.Location = new System.Drawing.Point(536, 245);
            this.TextHashSaltingLocateMode.Margin = new System.Windows.Forms.Padding(3, 3, 3, 25);
            this.TextHashSaltingLocateMode.Name = "TextHashSaltingLocateMode";
            this.TextHashSaltingLocateMode.Size = new System.Drawing.Size(233, 26);
            this.TextHashSaltingLocateMode.TabIndex = 5;
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
            this.TextHashSaltingMode.Location = new System.Drawing.Point(8, 279);
            this.TextHashSaltingMode.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.TextHashSaltingMode.Name = "TextHashSaltingMode";
            this.TextHashSaltingMode.Size = new System.Drawing.Size(106, 19);
            this.TextHashSaltingMode.TabIndex = 6;
            this.TextHashSaltingMode.Text = "Tuzlama Modu";
            this.TextHashSaltingMode.UseVisualStyleBackColor = false;
            this.TextHashSaltingMode.CheckedChanged += new System.EventHandler(this.TextHashSaltingMode_CheckedChanged);
            // 
            // TextHashL1
            // 
            this.TextHashL1.AutoSize = true;
            this.TextHashL1.BackColor = System.Drawing.Color.Transparent;
            this.TextHashL1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.TextHashL1.ForeColor = System.Drawing.Color.Black;
            this.TextHashL1.Location = new System.Drawing.Point(4, 12);
            this.TextHashL1.Margin = new System.Windows.Forms.Padding(3);
            this.TextHashL1.Name = "TextHashL1";
            this.TextHashL1.Size = new System.Drawing.Size(150, 19);
            this.TextHashL1.TabIndex = 0;
            this.TextHashL1.Text = "Orijinal Değeri Giriniz:";
            this.TextHashL1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TextHashOriginalTextBox
            // 
            this.TextHashOriginalTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextHashOriginalTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TextHashOriginalTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextHashOriginalTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.TextHashOriginalTextBox.ForeColor = System.Drawing.Color.Black;
            this.TextHashOriginalTextBox.Location = new System.Drawing.Point(8, 42);
            this.TextHashOriginalTextBox.Margin = new System.Windows.Forms.Padding(3, 5, 0, 15);
            this.TextHashOriginalTextBox.MaxLength = 0;
            this.TextHashOriginalTextBox.Multiline = true;
            this.TextHashOriginalTextBox.Name = "TextHashOriginalTextBox";
            this.TextHashOriginalTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TextHashOriginalTextBox.Size = new System.Drawing.Size(761, 168);
            this.TextHashOriginalTextBox.TabIndex = 2;
            this.TextHashOriginalTextBox.TextChanged += new System.EventHandler(this.TextHashOriginalTextBox_TextChanged);
            // 
            // HashCompare
            // 
            this.HashCompare.Controls.Add(this.HashComparePanel);
            this.HashCompare.Location = new System.Drawing.Point(4, 22);
            this.HashCompare.Name = "HashCompare";
            this.HashCompare.Padding = new System.Windows.Forms.Padding(6);
            this.HashCompare.Size = new System.Drawing.Size(789, 565);
            this.HashCompare.TabIndex = 2;
            this.HashCompare.Text = "HashCompare";
            this.HashCompare.UseVisualStyleBackColor = true;
            // 
            // HashComparePanel
            // 
            this.HashComparePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.HashComparePanel.Controls.Add(this.HashCompareResult);
            this.HashComparePanel.Controls.Add(this.SecondHashValueLabel);
            this.HashComparePanel.Controls.Add(this.SecondHashValueTextBox);
            this.HashComparePanel.Controls.Add(this.FirstHashValueLabel);
            this.HashComparePanel.Controls.Add(this.FirstHashValueTextBox);
            this.HashComparePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HashComparePanel.Location = new System.Drawing.Point(6, 6);
            this.HashComparePanel.Name = "HashComparePanel";
            this.HashComparePanel.Padding = new System.Windows.Forms.Padding(5);
            this.HashComparePanel.Size = new System.Drawing.Size(777, 553);
            this.HashComparePanel.TabIndex = 0;
            // 
            // HashCompareResult
            // 
            this.HashCompareResult.BackColor = System.Drawing.Color.SlateBlue;
            this.HashCompareResult.BackgroundColor = System.Drawing.Color.SlateBlue;
            this.HashCompareResult.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.HashCompareResult.BorderColor = System.Drawing.Color.SlateBlue;
            this.HashCompareResult.BorderRadius = 5;
            this.HashCompareResult.BorderSize = 0;
            this.HashCompareResult.Cursor = System.Windows.Forms.Cursors.Default;
            this.HashCompareResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.HashCompareResult.FlatAppearance.BorderSize = 0;
            this.HashCompareResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HashCompareResult.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.HashCompareResult.ForeColor = System.Drawing.Color.White;
            this.HashCompareResult.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.HashCompareResult.Location = new System.Drawing.Point(5, 509);
            this.HashCompareResult.Margin = new System.Windows.Forms.Padding(7, 0, 8, 8);
            this.HashCompareResult.Name = "HashCompareResult";
            this.HashCompareResult.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.HashCompareResult.Size = new System.Drawing.Size(767, 39);
            this.HashCompareResult.TabIndex = 4;
            this.HashCompareResult.Text = "KOPYALA";
            this.HashCompareResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.HashCompareResult.TextColor = System.Drawing.Color.White;
            this.HashCompareResult.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.HashCompareResult.UseVisualStyleBackColor = false;
            this.HashCompareResult.Visible = false;
            // 
            // SecondHashValueLabel
            // 
            this.SecondHashValueLabel.AutoSize = true;
            this.SecondHashValueLabel.BackColor = System.Drawing.Color.Transparent;
            this.SecondHashValueLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.SecondHashValueLabel.ForeColor = System.Drawing.Color.Black;
            this.SecondHashValueLabel.Location = new System.Drawing.Point(4, 237);
            this.SecondHashValueLabel.Name = "SecondHashValueLabel";
            this.SecondHashValueLabel.Size = new System.Drawing.Size(181, 19);
            this.SecondHashValueLabel.TabIndex = 2;
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
            this.SecondHashValueTextBox.Location = new System.Drawing.Point(8, 261);
            this.SecondHashValueTextBox.Margin = new System.Windows.Forms.Padding(3, 5, 0, 15);
            this.SecondHashValueTextBox.MaxLength = 512;
            this.SecondHashValueTextBox.Multiline = true;
            this.SecondHashValueTextBox.Name = "SecondHashValueTextBox";
            this.SecondHashValueTextBox.Size = new System.Drawing.Size(761, 168);
            this.SecondHashValueTextBox.TabIndex = 3;
            this.SecondHashValueTextBox.TextChanged += new System.EventHandler(this.SecondHashValueTextBox_TextChanged);
            // 
            // FirstHashValueLabel
            // 
            this.FirstHashValueLabel.AutoSize = true;
            this.FirstHashValueLabel.BackColor = System.Drawing.Color.Transparent;
            this.FirstHashValueLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.FirstHashValueLabel.ForeColor = System.Drawing.Color.Black;
            this.FirstHashValueLabel.Location = new System.Drawing.Point(4, 12);
            this.FirstHashValueLabel.Margin = new System.Windows.Forms.Padding(3);
            this.FirstHashValueLabel.Name = "FirstHashValueLabel";
            this.FirstHashValueLabel.Size = new System.Drawing.Size(187, 19);
            this.FirstHashValueLabel.TabIndex = 0;
            this.FirstHashValueLabel.Text = "Birinci Karma Değeri Giriniz:";
            this.FirstHashValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FirstHashValueTextBox
            // 
            this.FirstHashValueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FirstHashValueTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.FirstHashValueTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FirstHashValueTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.FirstHashValueTextBox.ForeColor = System.Drawing.Color.Black;
            this.FirstHashValueTextBox.Location = new System.Drawing.Point(8, 42);
            this.FirstHashValueTextBox.Margin = new System.Windows.Forms.Padding(3, 5, 0, 30);
            this.FirstHashValueTextBox.MaxLength = 512;
            this.FirstHashValueTextBox.Multiline = true;
            this.FirstHashValueTextBox.Name = "FirstHashValueTextBox";
            this.FirstHashValueTextBox.Size = new System.Drawing.Size(761, 168);
            this.FirstHashValueTextBox.TabIndex = 1;
            this.FirstHashValueTextBox.TextChanged += new System.EventHandler(this.FirstHashValueTextBox_TextChanged);
            // 
            // FileHash_BG_Worker
            // 
            this.FileHash_BG_Worker.WorkerReportsProgress = true;
            this.FileHash_BG_Worker.WorkerSupportsCancellation = true;
            this.FileHash_BG_Worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.FileHash_BG_Worker_DoWork);
            this.FileHash_BG_Worker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.FileHash_BG_Worker_ProgressChanged);
            this.FileHash_BG_Worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.FileHash_BG_Worker_RunWorkerCompleted);
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.BackColor = System.Drawing.Color.Transparent;
            this.HeaderPanel.ColumnCount = 1;
            this.HeaderPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.HeaderPanel.Controls.Add(this.HeaderInPanel, 0, 0);
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderPanel.Location = new System.Drawing.Point(225, 0);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.HeaderPanel.RowCount = 1;
            this.HeaderPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.HeaderPanel.Size = new System.Drawing.Size(783, 42);
            this.HeaderPanel.TabIndex = 1;
            // 
            // VimeraMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1008, 601);
            this.Controls.Add(this.HeaderPanel);
            this.Controls.Add(this.LeftPanel);
            this.Controls.Add(this.MainContent);
            this.DoubleBuffered = true;
            this.Icon = global::Vimera.Properties.Resources.VimeraLogo;
            this.MinimumSize = new System.Drawing.Size(1024, 640);
            this.Name = "VimeraMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vimera";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Vimera_FormClosing);
            this.Load += new System.EventHandler(this.Vimera_Load);
            this.LeftPanel.ResumeLayout(false);
            this.HeaderInPanel.ResumeLayout(false);
            this.HeaderInPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderImage)).EndInit();
            this.HeaderMenu.ResumeLayout(false);
            this.HeaderMenu.PerformLayout();
            this.MainContent.ResumeLayout(false);
            this.FileHash.ResumeLayout(false);
            this.FileHashPanel.ResumeLayout(false);
            this.FileHashPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FileHashDGV)).EndInit();
            this.FileHashLoadBG_Panel.ResumeLayout(false);
            this.TextHash.ResumeLayout(false);
            this.TextHashPanel.ResumeLayout(false);
            this.TextHashPanel.PerformLayout();
            this.HashCompare.ResumeLayout(false);
            this.HashComparePanel.ResumeLayout(false);
            this.HashComparePanel.PerformLayout();
            this.HeaderPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel LeftPanel;
        private System.Windows.Forms.Panel HeaderInPanel;
        private System.Windows.Forms.Button HashCompareBtn;
        private System.Windows.Forms.Button TextHashBtn;
        private System.Windows.Forms.Button FileHashBtn;
        private System.Windows.Forms.Label HeaderText;
        private System.Windows.Forms.TabControl MainContent;
        private System.Windows.Forms.TabPage FileHash;
        private System.Windows.Forms.TabPage TextHash;
        private System.Windows.Forms.TabPage HashCompare;
        private System.Windows.Forms.Panel FileHashPanel;
        private System.Windows.Forms.Panel TextHashPanel;
        private System.Windows.Forms.Panel HashComparePanel;
        private TSCustomButton FileHashStartBtn;
        internal TSCustomComboBox FileHashAlgorithmSelect;
        private TSCustomButton FileHashSelectFileBtn;
        private System.Windows.Forms.DataGridView FileHashDGV;
        private System.Windows.Forms.CheckBox FileHashUpperHashMode;
        private TSCustomButton FileHashCompareBtn;
        internal System.Windows.Forms.TextBox FileHashCompareTextBox;
        private System.ComponentModel.BackgroundWorker FileHash_BG_Worker;
        private System.Windows.Forms.Panel FileHashLoadBG_Panel;
        private System.Windows.Forms.Panel FileHashLoadFE_Panel;
        private TSCustomButton FileHashExportHashsBtn;
        private System.Windows.Forms.Label FileHashTimer;
        internal TSCustomComboBox TextHashAlgorithmSelect;
        internal System.Windows.Forms.TextBox TextHashOriginalTextBox;
        internal System.Windows.Forms.TextBox TextHashResultTextBox;
        private TSCustomButton TextHashResultCopyBtn;
        internal System.Windows.Forms.TextBox TextHashSaltingTextBox;
        private System.Windows.Forms.CheckBox TextHashSaltingMode;
        private System.Windows.Forms.Label TextHashL2;
        private System.Windows.Forms.Label TextHashL1;
        private System.Windows.Forms.Label TextHashL3;
        internal TSCustomComboBox TextHashSaltingLocateMode;
        private System.Windows.Forms.Label FirstHashValueLabel;
        internal System.Windows.Forms.TextBox FirstHashValueTextBox;
        private System.Windows.Forms.Label SecondHashValueLabel;
        internal System.Windows.Forms.TextBox SecondHashValueTextBox;
        private System.Windows.Forms.TableLayoutPanel HeaderPanel;
        private System.Windows.Forms.PictureBox HeaderImage;
        private System.Windows.Forms.MenuStrip HeaderMenu;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem turkishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem themeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lightThemeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem darkThemeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullScreenToolStripMenuItem;
        private TSCustomButton FileHashStopBtn;
        private System.Windows.Forms.Label FileHashSizer;
        private System.Windows.Forms.ToolStripMenuItem tSWizardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem donateToolStripMenuItem;
        private TSCustomButton HashCompareResult;
        private System.Windows.Forms.ToolStripMenuItem systemThemeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chineseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem japaneseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem koreanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arabicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem frenchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem germanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hindiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem italianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem polishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem portugueseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem russianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spanishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dutchToolStripMenuItem;
    }
}

