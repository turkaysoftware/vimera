using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;
using Microsoft.Win32;
using System.Threading;
using System.Reflection;
using System.Diagnostics;
using System.Windows.Forms;
using System.Globalization;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Cryptography;
using static Vimera.VimeraModules;

namespace Vimera {
    public partial class Vimera : Form {
        public Vimera(){ InitializeComponent(); CheckForIllegalCrossThreadCalls = false; }
        // GLOBAL VARIABLES
        public static string lang, lang_path;
        public static int theme;
        // ======================================================================================================
        // VARIABLES
        int menu_btns = 1, menu_rp = 1, initial_status;
        // FILE HASH
        // ======================================================================================================
        int file_hash_algorithm_mode, file_hash_process_end, file_hash_preloader = 0;
        string file_last_hash_algorithm;
        bool file_hash_timer_mode;
        // TEXT HASH
        // ======================================================================================================
        int text_hash_salt_mode;
        // HASH COMPARE
        // ======================================================================================================
        int hash_compare_status;
        // GITHUB WEBSITE & GITHUB LINK
        // ======================================================================================================
        public static readonly string github_link = "https://github.com/roines45";
        // ======================================================================================================
        // COLOR MODES / Index Mode | 0 = Dark - 1 = Light - 2 = Nord 
        List<Color> btn_colors_active = new List<Color>(){ Color.WhiteSmoke, Color.FromArgb(31, 31, 31), Color.FromArgb(46, 52, 64) };
        List<Color> btn_colors_deactive = new List<Color>(){ Color.FromArgb(235, 235, 235), Color.FromArgb(24, 24, 24), Color.FromArgb(36, 41, 51) };
        public static List<Color> ui_colors = new List<Color>();
        static List<Color> header_colors = new List<Color>();
        // ======================================================================================================
        // HEADER SETTINGS
        private class HeaderMenuColors : ToolStripProfessionalRenderer {
            public HeaderMenuColors() : base(new HeaderColors()){ }
            protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e){ e.ArrowColor = header_colors[1]; base.OnRenderArrow(e); }
        }
        private class HeaderColors : ProfessionalColorTable {
            public override Color MenuItemSelected { get { return header_colors[0]; } }
            public override Color ToolStripDropDownBackground { get { return header_colors[0]; } }
            public override Color ImageMarginGradientBegin { get { return header_colors[0]; } }
            public override Color ImageMarginGradientEnd { get { return header_colors[0]; } }
            public override Color ImageMarginGradientMiddle { get { return header_colors[0]; } }
            public override Color MenuItemSelectedGradientBegin { get { return header_colors[0]; } }
            public override Color MenuItemSelectedGradientEnd { get { return header_colors[0]; } }
            public override Color MenuItemPressedGradientBegin { get { return header_colors[0]; } }
            public override Color MenuItemPressedGradientMiddle { get { return header_colors[0]; } }
            public override Color MenuItemPressedGradientEnd { get { return header_colors[0]; } }
            public override Color MenuItemBorder { get { return header_colors[0]; } }
            public override Color CheckBackground { get { return header_colors[0]; } }
            public override Color ButtonSelectedBorder { get { return header_colors[0]; } }
            public override Color CheckSelectedBackground { get { return header_colors[0]; } }
            public override Color CheckPressedBackground { get { return header_colors[0]; } }
            public override Color MenuBorder { get { return header_colors[0]; } }
            public override Color SeparatorLight { get { return header_colors[1]; } }
            public override Color SeparatorDark { get { return header_colors[1]; } }
        }
        // ======================================================================================================
        // VIMERA PRELOADER
        /*
            -- THEME --      |  -- LANGUAGE --   |   -- INITIAL MODE --
            0 = Dark Theme   |  Moved to         |   0 = Normal Windowed
            1 = Light Theme  |  VimeraModules.cs |   1 = FullScreen Mode
            2 = Nord Theme
        */
        private void vimera_preloader(){
            try{
                string ui_lang = CultureInfo.InstalledUICulture.TwoLetterISOLanguageName.Trim();
                // CHECK VIMERA LANG FOLDER
                if (Directory.Exists(vimera_lf)){
                    // CHECK LANG FILES
                    int get_langs_file = Directory.GetFiles(vimera_lf, "*.ini", SearchOption.AllDirectories).Length;
                    if (get_langs_file >= v_langs_count){
                        // CHECK SETTINGS
                        try{
                            if (File.Exists(vimera_sf)){
                                GetVimeraSetting();
                            }else{
                                // DETECT SYSTEM THEME
                                VimeraSettingsSave vimera_settings_save = new VimeraSettingsSave(vimera_sf);
                                string get_system_theme = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", "SystemUsesLightTheme", "").ToString().Trim();
                                vimera_settings_save.VimeraWriteSettings("VimeraSettings", "ThemeStatus", get_system_theme);
                                // DETECT SYSTEM LANG
                                vimera_settings_save.VimeraWriteSettings("VimeraSettings", "LanguageStatus", ui_lang);
                                // SET INITIAL MODE
                                vimera_settings_save.VimeraWriteSettings("VimeraSettings", "InitialStatus", "0");
                                GetVimeraSetting();
                            }
                        }catch (Exception){ }
                    }else{
                        preloader_message(1, ui_lang);      // 1 = No lang file 
                    }
                }else{
                    preloader_message(2, ui_lang);          // 2 = No G_langs folder 
                }
            }catch (Exception){ }
        }
        // ======================================================================================================
        // VIMERA PRELOADER MESSAGE
        private void preloader_message(int pre_mod, string pre_lang){
            try{
                switch (pre_mod){
                    case 1:
                        switch (pre_lang){
                            case "tr":
                                MessageBox.Show($"Dil dosyaları eksik veya bulunamadı.\n{Application.ProductName} kapatılıyor.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            default:
                                MessageBox.Show($"Language files missing or not found.\n{Application.ProductName} is shutting down.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                        }
                        break;
                    case 2:
                        switch (pre_lang){
                            case "tr":
                                MessageBox.Show($"V_langs klasörü bulunamadı.\n{Application.ProductName} kapatılıyor.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            default:
                                MessageBox.Show($"V_langs folder not found.\n{Application.ProductName} is shutting down.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                        }
                        break;
                }
                vimera_exit();
            }catch (Exception){ }
        }
        // ======================================================================================================
        // VIMERA LOAD LANGS SETTINGS
        private void GetVimeraSetting(){
            // THEME - LANG - VIEW MODE PRELOADER
            VimeraSettingsSave vimera_read_settings = new VimeraSettingsSave(vimera_sf);
            string theme_mode = vimera_read_settings.VimeraReadSettings("VimeraSettings", "ThemeStatus");
            switch (theme_mode){
                case "0":
                    color_mode(0);
                    darkThemeToolStripMenuItem.Checked = true;
                    break;
                case "2":
                    color_mode(2);
                    nordThemeToolStripMenuItem.Checked = true;
                    break;
                default:
                    color_mode(1);
                    lightThemeToolStripMenuItem.Checked = true;
                    break;
            }
            string lang_mode = vimera_read_settings.VimeraReadSettings("VimeraSettings", "LanguageStatus");
            switch (lang_mode){
                case "en":
                    lang_engine("en");
                    englishToolStripMenuItem.Checked = true;
                    break;
                case "tr":
                    lang_engine("tr");
                    turkishToolStripMenuItem.Checked = true;
                    break;
                default:
                    lang_engine("en");
                    englishToolStripMenuItem.Checked = true;
                    break;
            }
            string initial_mode = vimera_read_settings.VimeraReadSettings("VimeraSettings", "InitialStatus");
            switch (initial_mode){
                case "0":
                    initial_status = 0;
                    windowedToolStripMenuItem.Checked = true;
                    //WindowState = FormWindowState.Normal;
                    break;
                case "1":
                    initial_status = 1;
                    fullScreenToolStripMenuItem.Checked = true;
                    WindowState = FormWindowState.Maximized;
                    break;
                default:
                    initial_status = 0;
                    windowedToolStripMenuItem.Checked = true;
                    //WindowState = FormWindowState.Normal;
                    break;
            }
            // DGV AND TAB CONTROL DOUBLE BUFFERS
            typeof(TabControl).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, MainContent, new object[]{ true });
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, FileHashDGV, new object[]{ true });
            // TLP DOUBLE BUFFERS
            typeof(TableLayoutPanel).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, FileHash_TLP, new object[]{ true });
            typeof(TableLayoutPanel).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, TextHash_TLP, new object[]{ true });
            typeof(TableLayoutPanel).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, HashCompare_TLP, new object[]{ true });
            // TLP TEXT HASH AND HASH COMPARE DOUBLE BUFFERS
            typeof(TableLayoutPanel).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, TextHashTLP, new object[]{ true });
            typeof(TableLayoutPanel).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, HashCompareTLP, new object[]{ true });
            // ARROWS KEYS PRELOADER SET
            MainContent.SelectedTab = TextHash;
            MainContent.SelectedTab = FileHash;
        }
        // VIMERA LOAD
        private void Vimera_Load(object sender, EventArgs e){
            Text = Application.ProductName + " " + Application.ProductVersion.Substring(0, 4);
            HeaderMenu.Cursor = Cursors.Hand;
            vimera_pre_selected_values();
            vimera_preloader();
        }
        // VIMERA PRE SELECTED VALUES SET FUNCTION
        // ======================================================================================================
        private void vimera_pre_selected_values(){
            try{
                VimeraGetLangs v_lang = new VimeraGetLangs(lang_path);
                // BUTTONS DPI AWARE SETTINGS
                int btn_dpi_height = FileHashSelectFilePathTextBox.Height;
                FileHashSelectFileBtn.Height = btn_dpi_height;
                FileHashExportHashsBtn.Height = btn_dpi_height;
                FileHashCompareBtn.Height = btn_dpi_height;
                // HASH ALGORITHM
                string[] hash_algorithm = { Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("FileHashTool", "fht_binary").Trim())), "MD5", "SHA-1", "SHA-256", "SHA-384", "SHA-512" };
                // FILE HASH PRELOAD
                // ======================================================================================================
                for (int i = 1; i <= hash_algorithm.Length - 1; i++){
                    FileHashAlgorithmSelect.Items.Add(hash_algorithm[i]);
                }
                FileHashAlgorithmSelect.SelectedIndex = 0;
                // DVG
                FileHashDGV.Columns.Add("FP", Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("FileHashTool", "fht_file_path").Trim())));
                FileHashDGV.Columns.Add("FS", Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("FileHashTool", "fht_file_size").Trim())));
                FileHashDGV.Columns.Add("HV", Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("FileHashTool", "fht_hash_value").Trim())));
                FileHashDGV.Columns.Add("CP", Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("FileHashTool", "fht_copy").Trim())));
                FileHashDGV.Columns[0].Width = 185;
                FileHashDGV.Columns[1].Width = 115;
                FileHashDGV.Columns[3].Width = 115;
                FileHashDGV.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                foreach (DataGridViewColumn OSD_Column in FileHashDGV.Columns){
                    OSD_Column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                FileHashDGV.ClearSelection();
                // TEXT HASH PRELOAD
                // ======================================================================================================
                for (int i = 0; i <= hash_algorithm.Length - 1; i++){
                    TextHashAlgorithmSelect.Items.Add(hash_algorithm[i]);
                }
                TextHashAlgorithmSelect.SelectedIndex = 0;
                for (int i = 0; i <= 1; i++){
                    TextHashSaltingLocateMode.Items.Add(i);
                }
                TextHashSaltingLocateMode.SelectedIndex = 0;
            }catch (Exception){ }
        }
        // ======================================================================================================
        // FILE HASH
        // ======================================================================================================
        // FILE HASH HASH ALGORITHM SELECT CHANGED INDEX
        // ======================================================================================================
        private void FileHashAlgorithmSelect_SelectedIndexChanged(object sender, EventArgs e){
            file_hash_algorithm_mode = FileHashAlgorithmSelect.SelectedIndex;
            if (file_hash_preloader == 1){
               FileHashStartBtn.Enabled = true;
            }
        }
        // FILE HASH DRAG ENTER FUNCTION
        // ======================================================================================================
        private void FileHashPanel_DragEnter(object sender, DragEventArgs e){
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false)){
                e.Effect = DragDropEffects.All;
            }
        }
        // FILE HASH DRAG AND DROP PROCESS
        // ======================================================================================================
        private void FileHashPanel_DragDrop(object sender, DragEventArgs e){
            if (e.Data.GetDataPresent(DataFormats.FileDrop)){
                try{
                    var data_path = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
                    if (Directory.Exists(data_path)){
                        // Folder
                        file_select_clear_function();
                        string[] file_list = Directory.GetFiles(data_path, "*.*", SearchOption.AllDirectories);
                        foreach (string files in file_list){
                            file_select_process_function(files);
                        }
                        FileHashDGV.ClearSelection();
                    }else{
                        // File
                        string[] select_file = (string[])e.Data.GetData(DataFormats.FileDrop, true);
                        file_select_clear_function();
                        for (int i = 0; i <= select_file.Length - 1; i++){
                            file_select_process_function(select_file[i]);
                        }
                        FileHashDGV.ClearSelection();
                    }
                }catch (Exception){ }
            }
        }
        // FILE HASH SELECT FILE BTN
        // ======================================================================================================
        private void FileHashSelectFileBtn_Click(object sender, EventArgs e){
            try{
                VimeraGetLangs v_lang = new VimeraGetLangs(lang_path);
                using (var select_file = new OpenFileDialog()){
                    select_file.Filter = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("FileHashTool", "fht_all_files").Trim())) + " (*.*)|*.*";
                    select_file.InitialDirectory = @"C:\Users\" + SystemInformation.UserName + @"\Desktop\";
                    select_file.Title = Application.ProductName + " - " + Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("FileHashTool", "fht_file_select_notification").Trim()));
                    select_file.Multiselect = true;
                    if (select_file.ShowDialog() == DialogResult.OK){
                        file_select_clear_function();
                        foreach (String files in select_file.FileNames){
                            file_select_process_function(files);
                        }
                        FileHashDGV.ClearSelection();
                    }
                }
            }catch (Exception){ }
        }
        // FILE HASH FILE SELECT PROCESS FUNCTION
        // ======================================================================================================
        private void file_select_process_function(string get_file){
            VimeraGetLangs v_lang = new VimeraGetLangs(lang_path);
            double file_size = new FileInfo(get_file).Length; // Byte
            if (file_size > 1024){
                if ((file_size / 1024) > 1024){
                    if ((file_size / 1024 / 1024) > 1024){
                        if ((file_size / 1024 / 1024 / 1024) > 1024){
                            // TB
                            FileHashDGV.Rows.Add(get_file, string.Format("{0:0.0 TB}", file_size / 1024 / 1024 / 1024 / 1024));
                        }else{
                            // GB
                            FileHashDGV.Rows.Add(get_file, string.Format("{0:0.0 GB}", file_size / 1024 / 1024 / 1024));
                        }
                    }else{
                        // MB
                        FileHashDGV.Rows.Add(get_file, string.Format("{0:0.00 MB}", file_size / 1024 / 1024));
                    }
                }else{
                    // KB
                    FileHashDGV.Rows.Add(get_file, string.Format("{0:0.0 KB}", file_size / 1024));
                }
            }else{
                // Byte
                FileHashDGV.Rows.Add(get_file, string.Format("{0:0} " + Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("FileHashTool", "fht_byte").Trim())), file_size));
            }
            FileHashSelectFilePathTextBox.Text = FileHashDGV.Rows[0].Cells[0].Value.ToString();
        }
        // FILE HASH FILE SELECT CLEAR FUNCTION
        // ======================================================================================================
        private void file_select_clear_function(){
            FileHashDGV.Rows.Clear();
            FileHashStartBtn.Enabled = true;
            FileHashCompareTextBox.Visible = false;
            FileHashCompareTextBox.Enabled = false;
            FileHashCompareTextBox.Text = string.Empty;
            FileHashCompareBtn.Visible = false;
            FileHashCompareBtn.Enabled = false;
            FileHashUpperHashMode.Visible = false;
            FileHashUpperHashMode.Checked = false;
            FileHashExportHashsBtn.Visible = false;
            FileHashTimer.Visible = false;
            file_hash_process_end = 0;
        }
        // FILE HASH ASYNC ALGORITHM
        // ======================================================================================================
        private void FileHash_BG_Worker_DoWork(object sender, DoWorkEventArgs e){
            file_last_hash_algorithm = FileHashAlgorithmSelect.SelectedItem.ToString();
            VimeraGetLangs v_lang = new VimeraGetLangs(lang_path);
            file_hash_timer_mode = true;
            Task fileh_hash_timer = new Task(file_hash_timer);
            fileh_hash_timer.Start();
            // GLOBAL BUFFER SIZE
            int buffer_size = 64 * 1024; // 64 KB
            //Console.WriteLine(buffer_size.ToString());
            // GLOBAL BUFFER SIZE
            for (int i = 0; i <= FileHashDGV.Rows.Count - 1; i++){
                try{
                    string file_path = FileHashDGV.Rows[i].Cells[0].Value.ToString();
                    byte[] buffer;
                    int bytes_read;
                    long size;
                    long total_bytes_read = 0;
                    // FILE HASH TEXT BOX SET FILE PATH
                    FileHashSelectFilePathTextBox.Text = file_path;
                    using (Stream file = File.OpenRead(file_path)){
                        size = file.Length;
                        switch (file_hash_algorithm_mode){
                            case 0:
                                using (HashAlgorithm hasher = MD5.Create()){
                                    do{
                                        buffer = new byte[buffer_size];
                                        bytes_read = file.Read(buffer, 0, buffer.Length);
                                        total_bytes_read += bytes_read;
                                        hasher.TransformBlock(buffer, 0, bytes_read, null, 0);
                                        FileHash_BG_Worker.ReportProgress((int)((double)total_bytes_read / size * 100));
                                    } while (bytes_read != 0);
                                    hasher.TransformFinalBlock(buffer, 0, 0);
                                    FileHashDGV.Rows[i].Cells[2].Value = HashStringRotate(hasher.Hash);
                                    FileHashDGV.Rows[i].Cells[3].Value = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("FileHashTool", "fht_copy").Trim()));
                                }
                                break;
                            case 1:
                                using (HashAlgorithm hasher = SHA1.Create()){
                                    do{
                                        buffer = new byte[buffer_size];
                                        bytes_read = file.Read(buffer, 0, buffer.Length);
                                        total_bytes_read += bytes_read;
                                        hasher.TransformBlock(buffer, 0, bytes_read, null, 0);
                                        FileHash_BG_Worker.ReportProgress((int)((double)total_bytes_read / size * 100));
                                    } while (bytes_read != 0);
                                    hasher.TransformFinalBlock(buffer, 0, 0);
                                    FileHashDGV.Rows[i].Cells[2].Value = HashStringRotate(hasher.Hash);
                                    FileHashDGV.Rows[i].Cells[3].Value = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("FileHashTool", "fht_copy").Trim()));
                                }
                                break;
                            case 2:
                                using (HashAlgorithm hasher = SHA256.Create()){
                                    do{
                                        buffer = new byte[buffer_size];
                                        bytes_read = file.Read(buffer, 0, buffer.Length);
                                        total_bytes_read += bytes_read;
                                        hasher.TransformBlock(buffer, 0, bytes_read, null, 0);
                                        FileHash_BG_Worker.ReportProgress((int)((double)total_bytes_read / size * 100));
                                    } while (bytes_read != 0);
                                    hasher.TransformFinalBlock(buffer, 0, 0);
                                    FileHashDGV.Rows[i].Cells[2].Value = HashStringRotate(hasher.Hash);
                                    FileHashDGV.Rows[i].Cells[3].Value = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("FileHashTool", "fht_copy").Trim()));
                                }
                                break;
                            case 3:
                                using (HashAlgorithm hasher = SHA384.Create()){
                                    do{
                                        buffer = new byte[buffer_size];
                                        bytes_read = file.Read(buffer, 0, buffer.Length);
                                        total_bytes_read += bytes_read;
                                        hasher.TransformBlock(buffer, 0, bytes_read, null, 0);
                                        FileHash_BG_Worker.ReportProgress((int)((double)total_bytes_read / size * 100));
                                    } while (bytes_read != 0);
                                    hasher.TransformFinalBlock(buffer, 0, 0);
                                    FileHashDGV.Rows[i].Cells[2].Value = HashStringRotate(hasher.Hash);
                                    FileHashDGV.Rows[i].Cells[3].Value = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("FileHashTool", "fht_copy").Trim()));
                                }
                                break;
                            case 4:
                                using (HashAlgorithm hasher = SHA512.Create()){
                                    do{
                                        buffer = new byte[buffer_size];
                                        bytes_read = file.Read(buffer, 0, buffer.Length);
                                        total_bytes_read += bytes_read;
                                        hasher.TransformBlock(buffer, 0, bytes_read, null, 0);
                                        FileHash_BG_Worker.ReportProgress((int)((double)total_bytes_read / size * 100));
                                    } while (bytes_read != 0);
                                    hasher.TransformFinalBlock(buffer, 0, 0);
                                    FileHashDGV.Rows[i].Cells[2].Value = HashStringRotate(hasher.Hash);
                                    FileHashDGV.Rows[i].Cells[3].Value = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("FileHashTool", "fht_copy").Trim()));
                                }
                                break;
                        }
                    }
                }catch (Exception){ }
            }
        }
        // FILE HASH PROCESS CHANGED
        // ======================================================================================================
        private void FileHash_BG_Worker_ProgressChanged(object sender, ProgressChangedEventArgs e){
            Text = Application.ProductName + " " + Application.ProductVersion.Substring(0, 4) + " - " + "%" + e.ProgressPercentage;
            FileHashLoadFE_Panel.Width = e.ProgressPercentage * FileHashLoadBG_Panel.Width / 100;
        }
        // FILE HASH PROCESS RUNWORKER COMPLETED
        // ======================================================================================================
        private void FileHash_BG_Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e){
            VimeraGetLangs v_lang = new VimeraGetLangs(lang_path);
            Text = Application.ProductName + " " + Application.ProductVersion.Substring(0, 4);
            file_hash_enabled_ui();
            MessageBox.Show(Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("FileHashTool", "fht_hash_success").Trim())), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        // FILE HASH STRING GENERATE
        // ======================================================================================================
        private static string HashStringRotate(byte[] hash_bytes){
            StringBuilder hash = new StringBuilder(256);
            foreach (byte be in hash_bytes){
                hash.Append(be.ToString("X2").ToLower());
            }
            return hash.ToString();
        }
        // FILE HASH START BTN
        // ======================================================================================================
        private void FileHashStartBtn_Click(object sender, EventArgs e){
            try{
                FileHash_BG_Worker.RunWorkerAsync();
                file_hash_disabled_ui();
            }catch (Exception){ }
        }
        // FILE HASH DISABLED UI
        // ======================================================================================================
        private void file_hash_disabled_ui(){
            FileHashLoadBG_Panel.Visible = true;
            FileHashTimer.Visible = true;
            FileHashAlgorithmSelect.Enabled = false;
            FileHashSelectFileBtn.Enabled = false;
            FileHashStartBtn.Enabled = false;
            FileHashDGV.ClearSelection();
            FileHashPanel.AllowDrop = false;
        }
        // FILE HASH ENABLED UI
        // ======================================================================================================
        private void file_hash_enabled_ui(){
            file_hash_timer_mode = false;
            FileHashAlgorithmSelect.Enabled = true;
            FileHashSelectFilePathTextBox.Text = string.Empty;
            FileHashSelectFileBtn.Enabled = true;
            FileHashUpperHashMode.Visible = true;
            FileHashExportHashsBtn.Visible = true;
            FileHashLoadBG_Panel.Visible = false;
            FileHashCompareTextBox.Visible = true;
            FileHashCompareTextBox.Enabled = true;
            FileHashCompareBtn.Visible = true;
            FileHashPanel.AllowDrop = true;
            // NULL VALUE CHANGE
            try{
                if (FileHashDGV.Rows.Count > 0){
                    VimeraGetLangs v_lang = new VimeraGetLangs(lang_path);
                    for (int i = 0; i <= FileHashDGV.Rows.Count - 1; i++){
                        if (FileHashDGV.Rows[i].Cells[2].Value == null || (string)FileHashDGV.Rows[i].Cells[2].Value == "" || (string)FileHashDGV.Rows[i].Cells[2].Value == string.Empty){
                            FileHashDGV.Rows[i].Cells[2].Value = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("FileHashTool", "fht_unreadable").Trim()));
                        }
                        if (FileHashDGV.Rows[i].Cells[3].Value == null || (string)FileHashDGV.Rows[i].Cells[3].Value == "" || (string)FileHashDGV.Rows[i].Cells[3].Value == string.Empty){
                            FileHashDGV.Rows[i].Cells[3].Value = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("FileHashTool", "fht_copy").Trim()));
                        }
                    }
                }
            }catch (Exception){ }
            if (WindowState == FormWindowState.Minimized){
                WindowState = FormWindowState.Normal;
            }
            file_hash_process_end = 1;
            file_hash_preloader = 1;
        }
        // FILE HASH VALUE UPPER & LOWER CASE FUNCTION
        // ======================================================================================================
        private void FileHashUpperHashMode_CheckedChanged(object sender, EventArgs e){
            if (FileHashUpperHashMode.Checked == true){
                for (int i = 0; i<= FileHashDGV.Rows.Count - 1; i++){
                    string select_hash = FileHashDGV.Rows[i].Cells[2].Value.ToString().ToUpper();
                    FileHashDGV.Rows[i].Cells[2].Value = select_hash;
                }
            }else if (FileHashUpperHashMode.Checked == false){
                for (int i = 0; i <= FileHashDGV.Rows.Count - 1; i++){
                    string select_hash = FileHashDGV.Rows[i].Cells[2].Value.ToString().ToLower();
                    FileHashDGV.Rows[i].Cells[2].Value = select_hash;
                }
            }
        }
        // FILE HASH DGV CELL CLICK COPY HASH
        // ======================================================================================================
        private void FileHashDGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e){
            try{
                if (file_hash_process_end == 1){
                    VimeraGetLangs v_lang = new VimeraGetLangs(lang_path);
                    if (Clipboard.GetText() != FileHashDGV.Rows[e.RowIndex].Cells[2].Value.ToString()){
                        Clipboard.SetText(FileHashDGV.Rows[e.RowIndex].Cells[2].Value.ToString());
                        //FileHashDGV.ClearSelection();
                        MessageBox.Show(Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("FileHashTool", "fht_hash_value_copy_success").Trim())), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }catch (Exception){ }
        }
        // FILE HASH COMPARE BTN ENABLED CHECK MODE
        // ======================================================================================================
        private void FileHashCompareTextBox_TextChanged(object sender, EventArgs e){
            if (FileHashCompareTextBox.Text != "" || FileHashCompareTextBox.Text != string.Empty){
                FileHashCompareBtn.Enabled = true;
            }else{
                FileHashCompareBtn.Enabled = false;
            }
        }
        // FILE HASH COMPARE
        // ======================================================================================================
        private void FileHashCompareBtn_Click(object sender, EventArgs e){
            try{
                VimeraGetLangs v_lang = new VimeraGetLangs(lang_path);
                if (FileHashDGV.SelectedRows.Count > 0){
                    string generate_hash_value = FileHashDGV.Rows[FileHashDGV.CurrentCell.RowIndex].Cells[2].Value.ToString().ToLower();
                    string original_value = FileHashCompareTextBox.Text.Trim().ToLower();
                    if (original_value == generate_hash_value){
                        MessageBox.Show(Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("FileHashTool", "fht_hash_match").Trim())), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }else{
                        MessageBox.Show(Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("FileHashTool", "fht_hash_not_match").Trim())), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    FileHashDGV.ClearSelection();
                }else{
                    MessageBox.Show(Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("FileHashTool", "fht_hash_select_notification").Trim())), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }catch (Exception){ }
        }
        // FILE HASH TIMER
        // ======================================================================================================
        private void file_hash_timer(){
            int fh_second = 0;
            int fh_minute = 0;
            int fh_hour = 0;
            try{
                do{
                    fh_second++;
                    if (fh_second == 60){
                        fh_second = 0;
                        fh_minute++;
                    }
                    if (fh_minute == 60){
                        fh_minute = 0;
                        fh_hour++;
                    }
                    FileHashTimer.Text = string.Format("{0}:{1}:{2}", fh_hour, fh_minute, fh_second);
                    Thread.Sleep(1000);
                } while (file_hash_timer_mode);
            }catch (Exception){ }
        }
        // FILE HASH EXPORT HASH DATA
        // ======================================================================================================
        List<string> PrintEngineList = new List<string>();
        private void FileHashExportHashsBtn_Click(object sender, EventArgs e){
            try{
                VimeraGetLangs v_lang = new VimeraGetLangs(lang_path);
                PrintEngineList.Add($"<{new string('-', 13)} {string.Format(Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("FileHashPrintEngine", "fhpe_title").Trim())), Application.ProductName)} {new string('-', 13)}>");
                PrintEngineList.Add($"{Environment.NewLine}{new string('-', 75)}{Environment.NewLine}");
                for (int i = 0; i <= FileHashDGV.Rows.Count - 1; i++){
                    PrintEngineList.Add(Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("FileHashPrintEngine", "fhpe_file_name").Trim())) + " " + Path.GetFileName(FileHashDGV.Rows[i].Cells[0].Value.ToString()));
                    PrintEngineList.Add(Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("FileHashPrintEngine", "fhpe_file_path").Trim())) + " " + FileHashDGV.Rows[i].Cells[0].Value.ToString());
                    PrintEngineList.Add(Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("FileHashPrintEngine", "fhpe_file_size").Trim())) + " " + FileHashDGV.Rows[i].Cells[1].Value.ToString());
                    PrintEngineList.Add(file_last_hash_algorithm + " " + Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("FileHashPrintEngine", "fhpe_hash_value").Trim())) + " " + FileHashDGV.Rows[i].Cells[2].Value.ToString() + "\n\n" + new string('-', 75) + Environment.NewLine);
                }
                PrintEngineList.Add(string.Format(Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("FileHashPrintEngine", "fhpe_version").Trim())), Application.ProductName, Application.ProductVersion.Substring(0, 4)));
                PrintEngineList.Add($"(C) {DateTime.Now.Year} {Application.CompanyName}.");
                PrintEngineList.Add(Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("FileHashPrintEngine", "fhpe_processing_time").Trim())) + " " + DateTime.Now.ToString("dd.MM.yyyy - H:mm:ss"));
                PrintEngineList.Add(Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("FileHashPrintEngine", "fhpe_github").Trim())) + " " + github_link);
                SaveFileDialog save_engine = new SaveFileDialog{
                    InitialDirectory = @"C:\Users\" + SystemInformation.UserName + @"\Desktop\",
                    Title = string.Format(Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("FileHashPrintEngine", "fhpe_save_directory_notification").Trim())), Application.ProductName),
                    DefaultExt = "txt",
                    FileName = string.Format(Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("FileHashPrintEngine", "fhpe_save_file_name").Trim())), Application.ProductName),
                    Filter = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("FileHashPrintEngine", "fhpe_document_txt").Trim())) + " (*.txt)|*.txt"
                };
                if (save_engine.ShowDialog() == DialogResult.OK){
                    String[] text_engine = new String[PrintEngineList.Count];
                    PrintEngineList.CopyTo(text_engine, 0);
                    File.WriteAllLines(save_engine.FileName, text_engine);
                    DialogResult vimera_print_engine_query = MessageBox.Show(string.Format(Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("FileHashPrintEngine", "fhpe_save_hash_report_success_notification").Trim())), Application.ProductName, save_engine.FileName, "\n\n"), Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (vimera_print_engine_query == DialogResult.Yes){ Process.Start(save_engine.FileName); }
                    PrintEngineList.Clear(); save_engine.Dispose();
                }else{
                    PrintEngineList.Clear(); save_engine.Dispose();
                }
            }catch (Exception){ }
        }
        // ======================================================================================================
        // FILE HASH
        // ======================================================================================================
        // ======================================================================================================
        // TEXT HASH
        // ======================================================================================================
        // TEXT HASH ALGORITHM SELECT INDEX CHANGED
        // ======================================================================================================
        private void TextHashAlgorithmSelect_SelectedIndexChanged(object sender, EventArgs e){
            if (TextHashOriginalTextBox.Text != "" || TextHashOriginalTextBox.Text != string.Empty){
                text_hash_engine(TextHashAlgorithmSelect.SelectedIndex, text_hash_salt_mode, TextHashSaltingLocateMode.SelectedIndex, TextHashOriginalTextBox.Text);
            }
        }
        // TEXT HASH ORIGINAL TEXTBOX TEXT CHANGED
        // ======================================================================================================
        private void TextHashOriginalTextBox_TextChanged(object sender, EventArgs e){
            if (TextHashOriginalTextBox.Text != "" || TextHashOriginalTextBox.Text != string.Empty){
                TextHashSaltingMode.Enabled = true;
                TextHashResultCopyBtn.Enabled = true;
                text_hash_engine(TextHashAlgorithmSelect.SelectedIndex, text_hash_salt_mode, TextHashSaltingLocateMode.SelectedIndex, TextHashOriginalTextBox.Text);
            }else{
                TextHashSaltingMode.Enabled = false;
                TextHashSaltingMode.Checked = false;
                TextHashResultCopyBtn.Enabled = false;
                TextHashResultTextBox.Text = string.Empty;
            }
        }
        // TEXT HASH SALTING TEXTBOX TEXT CHANGED
        // ======================================================================================================
        private void TextHashSaltingTextBox_TextChanged(object sender, EventArgs e){
            text_hash_engine(TextHashAlgorithmSelect.SelectedIndex, text_hash_salt_mode, TextHashSaltingLocateMode.SelectedIndex, TextHashOriginalTextBox.Text);
        }
        // TEXT HASH SALTING LOCATE MODE INDEX CHANGED
        // ======================================================================================================
        private void TextHashSaltingLocateMode_SelectedIndexChanged(object sender, EventArgs e){
            text_hash_engine(TextHashAlgorithmSelect.SelectedIndex, text_hash_salt_mode, TextHashSaltingLocateMode.SelectedIndex, TextHashOriginalTextBox.Text);
        }
        // TEXT HASH SALTING MODE CHECKED CHANGED
        // ======================================================================================================
        private void TextHashSaltingMode_CheckedChanged(object sender, EventArgs e){
            if (TextHashSaltingMode.Checked == true){
                TextHashSaltingTextBox.Enabled = true;
                TextHashSaltingLocateMode.Visible = true;
                text_hash_salt_mode = 1;
            }else if (TextHashSaltingMode.Checked == false){
                TextHashSaltingTextBox.Enabled = false;
                TextHashSaltingLocateMode.Visible = false;
                text_hash_salt_mode = 0;
            }
            text_hash_engine(TextHashAlgorithmSelect.SelectedIndex, text_hash_salt_mode, TextHashSaltingLocateMode.SelectedIndex, TextHashOriginalTextBox.Text);
        }
        // TEXT HASH ENGINE
        // ======================================================================================================
        private void text_hash_engine(int hash_mode, int salt_mode, int salt_locate_mode, string original_text){
            try{
                // CHECK SALT MODE
                switch (salt_mode) {
                    case 1:
                        // CHECK SALT LOCATE MODE
                        switch (salt_locate_mode){
                            case 0:
                                original_text = TextHashSaltingTextBox.Text + original_text;
                            break;
                            case 1:
                                original_text += TextHashSaltingTextBox.Text;
                            break;
                        }
                    break;
                }
                // CHECK HASH MODE
                switch (hash_mode){
                    case 0:
                        // Binary
                        TextHashResultTextBox.Text = ToBinary(ConvertToByteArray(original_text, Encoding.UTF8));
                        break;
                    case 1:
                        // MD5
                        using (MD5 md5 = MD5.Create()) {
                            byte[] inputBytes = Encoding.UTF8.GetBytes(original_text);
                            byte[] hashBytes = md5.ComputeHash(inputBytes);
                            TextHashResultTextBox.Text = HashStringRotate(hashBytes);
                        }
                        break;
                    case 2:
                        // SHA-1
                        using (SHA1 sha1 = SHA1.Create()){
                            byte[] inputBytes = Encoding.UTF8.GetBytes(original_text);
                            byte[] hashBytes = sha1.ComputeHash(inputBytes);
                            TextHashResultTextBox.Text = HashStringRotate(hashBytes);
                        }
                        break;
                    case 3:
                        // SHA-256
                        using (SHA256 sha256 = SHA256.Create()){
                            byte[] inputBytes = Encoding.UTF8.GetBytes(original_text);
                            byte[] hashBytes = sha256.ComputeHash(inputBytes);
                            TextHashResultTextBox.Text = HashStringRotate(hashBytes);
                        }
                        break;
                    case 4:
                        // SHA-384
                        using (SHA384 sha384 = SHA384.Create()){
                            byte[] inputBytes = Encoding.UTF8.GetBytes(original_text);
                            byte[] hashBytes = sha384.ComputeHash(inputBytes);
                            TextHashResultTextBox.Text = HashStringRotate(hashBytes);
                        }
                        break;
                    case 5:
                        // SHA-512
                        using (SHA512 sha512 = SHA512.Create()){
                            byte[] inputBytes = Encoding.UTF8.GetBytes(original_text);
                            byte[] hashBytes = sha512.ComputeHash(inputBytes);
                            TextHashResultTextBox.Text = HashStringRotate(hashBytes);
                        }
                        break;
                }
            }catch (Exception){ }
        }
        // BINARY CONVERTER
        // ======================================================================================================
        public static byte[] ConvertToByteArray(string original_text, Encoding encode_mode){
            return encode_mode.GetBytes(original_text);
        }
        public static String ToBinary(Byte[] hash_data){
            return string.Join(" ", hash_data.Select(hash_byte => Convert.ToString(hash_byte, 2).PadLeft(8, '0')));
        }
        // COPY TEXT HASH RESULT
        // ======================================================================================================
        private void TextHashResultCopyBtn_Click(object sender, EventArgs e){
            try{
                VimeraGetLangs v_lang = new VimeraGetLangs(lang_path);
                if (Clipboard.GetText() != TextHashResultTextBox.Text){
                    Clipboard.SetText(TextHashResultTextBox.Text);
                    MessageBox.Show(Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("TextHashTool", "tht_hash_copy_notiftication").Trim())), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }catch (Exception){ }
        }
        // ======================================================================================================
        // TEXT HASH
        // ======================================================================================================
        // ======================================================================================================
        // HASH COMPARE
        // ======================================================================================================
        // HASH COMPARE FIRST HASH VALUE TEXT CHANGED
        // ======================================================================================================
        private void FirstHashValueTextBox_TextChanged(object sender, EventArgs e){
            if (FirstHashValueTextBox.Text != "" || FirstHashValueTextBox.Text != string.Empty){
                SecondHashValueTextBox.Enabled = true;
                if (SecondHashValueTextBox.Text != "" || SecondHashValueTextBox.Text != string.Empty){
                    hash_compare_engine();
                }
            }else{
                SecondHashValueTextBox.Enabled = false;
                HashCompareResultLabel.Visible = false;
            }
        }
        // HASH COMPARE SECOND HASH VALUE TEXT CHANGED
        // ======================================================================================================
        private void SecondHashValueTextBox_TextChanged(object sender, EventArgs e){
            if (FirstHashValueTextBox.Text != "" || FirstHashValueTextBox.Text != string.Empty){
                if (SecondHashValueTextBox.Text != "" || SecondHashValueTextBox.Text != string.Empty){
                    hash_compare_engine();
                }else{
                    HashCompareResultLabel.Visible = false;
                }
            }
        }
        // HASH COMPARE ENGINE
        // ======================================================================================================
        private void hash_compare_engine(){
            try{
                VimeraGetLangs v_lang = new VimeraGetLangs(lang_path);
                HashCompareResultLabel.Visible = true;
                string hash_1 = FirstHashValueTextBox.Text.Trim().ToLower();
                string hash_2 = SecondHashValueTextBox.Text.Trim().ToLower();
                if (hash_1 == hash_2){
                    hash_compare_status = 0;
                    HashCompareResultLabel.BackColor = Color.FromArgb(18, 119, 69);
                    HashCompareResultLabel.ForeColor = Color.WhiteSmoke;
                    HashCompareResultLabel.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("HashCompareTool", "hct_values_match").Trim()));
                }else{
                    hash_compare_status = 1;
                    HashCompareResultLabel.BackColor = Color.FromArgb(156, 37, 77);
                    HashCompareResultLabel.ForeColor = Color.WhiteSmoke;
                    HashCompareResultLabel.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("HashCompareTool", "hct_values_not_match").Trim()));
                }
            }catch (Exception){ }
        }
        // ROTATE BTNS
        // ======================================================================================================
        private Button active_btn;
        private void active_page(object btn_target){
            disabled_page();
            if (btn_target != null){
                if (active_btn != (Button)btn_target){
                    active_btn = (Button)btn_target;
                    if (theme == 1){ active_btn.BackColor = btn_colors_active[0]; }
                    else if (theme == 0){ active_btn.BackColor = btn_colors_active[1]; }
                    else if (theme == 2){ active_btn.BackColor = btn_colors_active[2]; }
                    active_btn.Cursor = Cursors.Default;
                }
            }
        }
        private void disabled_page(){
            foreach (Control disabled_btn in LeftPanel.Controls){
                if (theme == 1){ disabled_btn.BackColor = btn_colors_deactive[0]; }
                else if (theme == 0){ disabled_btn.BackColor = btn_colors_deactive[1]; }
                else if (theme == 2){ disabled_btn.BackColor = btn_colors_deactive[2]; }
                disabled_btn.Cursor = Cursors.Hand;
            }
        }
        private void FileHashBtn_Click(object sender, EventArgs e){
            left_menu_preloader(1, sender);
        }
        private void TextHashBtn_Click(object sender, EventArgs e){
            left_menu_preloader(2, sender);
        }
        private void HashCompareBtn_Click(object sender, EventArgs e){
            left_menu_preloader(3, sender);
        }
        // VIMERA DYNAMIC ARROW KEYS ROTATE
        private void MainContent_Selecting(object sender, TabControlCancelEventArgs e){
            try{
                switch (MainContent.SelectedIndex){
                    case 0:
                        if (!e.TabPage.Enabled){ e.Cancel = true; }else{ FileHashBtn.PerformClick(); }
                        break;
                    case 1:
                        if (!e.TabPage.Enabled){ e.Cancel = true; }else{ TextHashBtn.PerformClick(); }
                        break;
                    case 2:
                        if (!e.TabPage.Enabled){ e.Cancel = true; }else{ HashCompareBtn.PerformClick(); }
                        break;
                }
            }catch (Exception){ }
        }
        // VIMERA DYNAMIC LEFT MENU PRELOADER
        private void left_menu_preloader(int target_menu, object sender){
            try{
                VimeraGetLangs g_lang = new VimeraGetLangs(lang_path);
                switch (target_menu){
                    case 1:
                        if (menu_btns != 1){
                            MainContent.SelectedTab = FileHash;
                            menu_btns = 1;
                            menu_rp = 1;
                            if (!btn_colors_active.Contains(FileHashBtn.BackColor)){ active_page(sender); }
                            HeaderText.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(g_lang.VimeraReadLangs("Header", "header_file_hash").Trim()));
                        }
                        break;
                    case 2:
                        if (menu_btns != 2){
                            MainContent.SelectedTab = TextHash;
                            menu_btns = 2;
                            menu_rp = 2;
                            if (!btn_colors_active.Contains(TextHashBtn.BackColor)){ active_page(sender); }
                            HeaderText.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(g_lang.VimeraReadLangs("Header", "header_text_hash").Trim()));
                        }
                        break;
                    case 3:
                        if (menu_btns != 3){
                            MainContent.SelectedTab = HashCompare;
                            menu_btns = 3;
                            menu_rp = 3;
                            if (!btn_colors_active.Contains(HashCompareBtn.BackColor)){ active_page(sender); }
                            HeaderText.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(g_lang.VimeraReadLangs("Header", "header_hash_compare").Trim()));
                        }
                        break;
                }
                header_image_reloader(menu_btns);
            }catch (Exception){ }
        }
        // LANG MODE
        // ======================================================================================================
        private ToolStripMenuItem selected_lang;
        private void select_lang_active(object target_lang){
            select_lang_deactive();
            if (target_lang != null){
                if (selected_lang != (ToolStripMenuItem)target_lang){
                    selected_lang = (ToolStripMenuItem)target_lang;
                    selected_lang.Checked = true;
                }
            }
        }
        private void select_lang_deactive(){
            foreach (ToolStripMenuItem disabled_lang in languageToolStripMenuItem.DropDownItems){
                disabled_lang.Checked = false;
            }
        }
        private void englishToolStripMenuItem_Click(object sender, EventArgs e){
            if (lang != "en"){ lang_preload("en"); select_lang_active(sender); }
        }
        private void turkishToolStripMenuItem_Click(object sender, EventArgs e){
            if (lang != "tr"){ lang_preload("tr"); select_lang_active(sender); }
        }
        private void lang_preload(string lang_type){
            lang_engine(lang_type);
            try{
                VimeraSettingsSave vimera_setting_save = new VimeraSettingsSave(vimera_sf);
                vimera_setting_save.VimeraWriteSettings("VimeraSettings", "LanguageStatus", lang_type);
            }catch (Exception){ }
        }
        private void lang_engine(string lang_type){
            try{
                switch (lang_type){
                    case "en":
                        lang = "en";
                        lang_path = vimera_lang_en;
                        break;
                    case "tr":
                        lang = "tr";
                        lang_path = vimera_lang_tr;
                        break;
                }
                // GLOBAL ENGINE
                VimeraGetLangs v_lang = new VimeraGetLangs(lang_path);
                if (menu_rp == 1){
                    HeaderText.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("Header", "header_file_hash").Trim()));
                }else if (menu_rp == 2){
                    HeaderText.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("Header", "header_text_hash").Trim()));
                }else if (menu_rp == 3){
                    HeaderText.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("Header", "header_hash_compare").Trim()));
                }
                // SETTINGS
                settingsToolStripMenuItem.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("HeaderMenu", "header_menu_settings").Trim()));
                // THEMES
                themeToolStripMenuItem.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("HeaderMenu", "header_menu_theme").Trim()));
                lightThemeToolStripMenuItem.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("HeaderThemes", "theme_light").Trim()));
                darkThemeToolStripMenuItem.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("HeaderThemes", "theme_dark").Trim()));
                nordThemeToolStripMenuItem.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("HeaderThemes", "theme_nord").Trim()));
                // LANGS
                languageToolStripMenuItem.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("HeaderMenu", "header_menu_language").Trim()));
                englishToolStripMenuItem.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("HeaderLangs", "lang_en").Trim()));
                turkishToolStripMenuItem.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("HeaderLangs", "lang_tr").Trim()));
                // INITIAL VIEW
                initialViewToolStripMenuItem.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("HeaderMenu", "header_menu_start").Trim()));
                windowedToolStripMenuItem.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("HeaderViewMode", "header_viev_mode_windowed").Trim()));
                fullScreenToolStripMenuItem.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("HeaderViewMode", "header_viev_mode_full_screen").Trim()));
                // GITHUB
                helpToolStripMenuItem.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("HeaderMenu", "header_menu_help").Trim()));
                aboutToolStripMenuItem.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("HeaderHelp", "header_help_about").Trim()));
                gitHubToolStripMenuItem.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("HeaderHelp", "header_help_github").Trim()));
                // MENU
                FileHashBtn.Text = " " + " " + Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("LeftMenu", "left_file_hash").Trim()));
                TextHashBtn.Text = " " + " " + Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("LeftMenu", "left_text_hash").Trim()));
                HashCompareBtn.Text = " " + " " + Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("LeftMenu", "left_hash_compare").Trim()));
                // FILE HASH
                FileHashSelectFileBtn.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("FileHashTool", "fht_select").Trim()));
                FileHashDGV.Columns[0].HeaderText = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("FileHashTool", "fht_file_path").Trim()));
                FileHashDGV.Columns[1].HeaderText = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("FileHashTool", "fht_file_size").Trim()));
                FileHashDGV.Columns[2].HeaderText = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("FileHashTool", "fht_hash_value").Trim()));
                FileHashDGV.Columns[3].HeaderText = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("FileHashTool", "fht_copy").Trim()));
                FileHashUpperHashMode.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("FileHashTool", "fht_hash_uppercase").Trim()));
                FileHashExportHashsBtn.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("FileHashTool", "fht_export_hashs").Trim()));
                FileHashCompareBtn.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("FileHashTool", "fht_compare").Trim()));
                FileHashStartBtn.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("FileHashTool", "fht_start").Trim()));
                // FILE HASH REPLACE
                try{
                    if (FileHashDGV.Rows.Count > 0){
                        for (int i = 0; i<= FileHashDGV.Rows.Count - 1; i++){
                            if ((string)FileHashDGV.Rows[i].Cells[3].Value == "Copy" || (string)FileHashDGV.Rows[i].Cells[3].Value == "Kopyala"){
                                FileHashDGV.Rows[i].Cells[3].Value = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("FileHashTool", "fht_copy").Trim()));
                            }
                            if (Convert.ToString(FileHashDGV.Rows[i].Cells[1].Value).Contains("Byte")){
                                FileHashDGV.Rows[i].Cells[1].Value = FileHashDGV.Rows[i].Cells[1].Value.ToString().Replace("Byte", Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("FileHashTool", "fht_byte").Trim())));
                            }else if (Convert.ToString(FileHashDGV.Rows[i].Cells[1].Value).Contains("Bayt")){
                                FileHashDGV.Rows[i].Cells[1].Value = FileHashDGV.Rows[i].Cells[1].Value.ToString().Replace("Bayt", Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("FileHashTool", "fht_byte").Trim())));
                            }
                        }
                    }
                }catch (Exception){ }
                // TEXT HASH
                TextHashAlgorithmSelect.Items[0] = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("TextHashTool", "tht_binary").Trim()));
                TextHashL1.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("TextHashTool", "tht_original_value_input").Trim()));
                TextHashL2.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("TextHashTool", "tht_salting_value_input").Trim()));
                TextHashL3.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("TextHashTool", "tht_creating_hash_value").Trim()));
                TextHashSaltingMode.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("TextHashTool", "tht_salting_mode").Trim()));
                TextHashSaltingLocateMode.Items[0] = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("TextHashTool", "tht_add_at_the_beginning").Trim()));
                TextHashSaltingLocateMode.Items[1] = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("TextHashTool", "tht_add_to_end").Trim()));
                TextHashResultCopyBtn.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("TextHashTool", "tht_copy").Trim()));
                // HASH COMPARE
                FirstHashValueLabel.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("HashCompareTool", "hct_first_hash_value_input").Trim()));
                SecondHashValueLabel.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("HashCompareTool", "hct_secondary_hash_value_input").Trim()));
                if (hash_compare_status == 0){
                    HashCompareResultLabel.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("HashCompareTool", "hct_values_match").Trim()));
                }else if (hash_compare_status == 1){
                    HashCompareResultLabel.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("HashCompareTool", "hct_values_not_match").Trim()));
                }
                // OTHER PAGE DYNAMIC UI
                vimera_other_page_preloader();
            }catch (Exception){ }
        }
        // THEME MODE
        // ======================================================================================================
        private ToolStripMenuItem selected_theme;
        private void select_theme_active(object target_theme){
            select_theme_deactive();
            if (target_theme != null){
                if (selected_theme != (ToolStripMenuItem)target_theme){
                    selected_theme = (ToolStripMenuItem)target_theme;
                    selected_theme.Checked = true;
                }
            }
        }
        private void select_theme_deactive(){
            foreach (ToolStripMenuItem disabled_theme in themeToolStripMenuItem.DropDownItems){
                disabled_theme.Checked = false;
            }
        }
        private void lightThemeToolStripMenuItem_Click(object sender, EventArgs e){
            if (theme != 1){ color_mode(1); select_theme_active(sender); }
        }
        private void darkThemeToolStripMenuItem_Click(object sender, EventArgs e){
            if (theme != 0){ color_mode(0); select_theme_active(sender); }
        }
        private void nordThemeToolStripMenuItem_Click(object sender, EventArgs e){
            if (theme != 2){ color_mode(2); select_theme_active(sender); }
        }
        private void color_mode(int ts){
            theme = ts;
            if (theme == 1){
                // TITLEBAR CHANGE 
                try { if (DwmSetWindowAttribute(Handle, 20, new[]{ 1 }, 4) != 1){ DwmSetWindowAttribute(Handle, 20, new[]{ 0 }, 4); } }catch (Exception){ }
                // CLEAR PRELOAD ITEMS
                if (ui_colors.Count > 0){ ui_colors.Clear(); }
                if (header_colors.Count > 1){ header_colors.Clear(); }
                // HEADER MENU COLOR MODE
                header_colors.Add(Color.FromArgb(222, 222, 222));
                header_colors.Add(Color.FromArgb(31, 31, 31));
                // HEADER AND TOOLTIP COLOR MODE
                ui_colors.Add(Color.FromArgb(32, 32, 32));          // 0
                ui_colors.Add(Color.FromArgb(235, 235, 235));       // 1
                // LEFT MENU COLOR MODE
                ui_colors.Add(Color.FromArgb(235, 235, 235));       // 2
                ui_colors.Add(Color.WhiteSmoke);                    // 3
                ui_colors.Add(Color.FromArgb(32, 32, 32));          // 4
                // CONTENT BG COLOR MODE
                ui_colors.Add(Color.WhiteSmoke);                    // 5
                // UI COLOR MODES
                ui_colors.Add(Color.FromArgb(235, 235, 235));       // 6
                ui_colors.Add(Color.White);                         // 7
                ui_colors.Add(Color.FromArgb(32, 32, 32));          // 8
                ui_colors.Add(Color.FromArgb(217, 217, 217));       // 9
                ui_colors.Add(Color.FromArgb(235, 235, 235));       // 10
                ui_colors.Add(Color.FromArgb(105, 81, 147));        // 11
                ui_colors.Add(Color.WhiteSmoke);                    // 12
                ui_colors.Add(Color.WhiteSmoke);                    // 13
                ui_colors.Add(Color.FromArgb(32, 32, 32));          // 14
                // THEME LOGOS
                FileHashBtn.Image = Properties.Resources.light_left_menu_file_hash;
                TextHashBtn.Image = Properties.Resources.light_left_menu_text_hash;
                HashCompareBtn.Image = Properties.Resources.light_left_menu_hash_compare;
                // SETTINGS
                settingsToolStripMenuItem.Image = Properties.Resources.light_top_menu_settings;
                themeToolStripMenuItem.Image = Properties.Resources.light_top_menu_theme;
                languageToolStripMenuItem.Image = Properties.Resources.light_top_menu_language;
                initialViewToolStripMenuItem.Image = Properties.Resources.light_top_menu_start;
                // HELP
                helpToolStripMenuItem.Image = Properties.Resources.light_top_menu_help;
                aboutToolStripMenuItem.Image = Properties.Resources.light_top_menu_about;
                gitHubToolStripMenuItem.Image = Properties.Resources.light_top_menu_github;
            }else if (theme == 0){
                // TITLEBAR CHANGE
                try { if (DwmSetWindowAttribute(Handle, 19, new[]{ 1 }, 4) != 0){ DwmSetWindowAttribute(Handle, 20, new[]{ 1 }, 4); } }catch (Exception){ }
                // CLEAR PRELOAD ITEMS
                if (ui_colors.Count > 0){ ui_colors.Clear(); }
                if (header_colors.Count > 1){ header_colors.Clear(); }
                // HEADER MENU COLOR MODE
                header_colors.Add(Color.FromArgb(31, 31, 31));
                header_colors.Add(Color.FromArgb(222, 222, 222));
                // HEADER AND TOOLTIP COLOR MODE
                ui_colors.Add(Color.WhiteSmoke);                    // 0
                ui_colors.Add(Color.FromArgb(24, 24, 24));          // 1
                // LEFT MENU COLOR MODE
                ui_colors.Add(Color.FromArgb(24, 24, 24));          // 2
                ui_colors.Add(Color.FromArgb(31, 31, 31));          // 3
                ui_colors.Add(Color.WhiteSmoke);                    // 4
                // CONTENT BG COLOR MODE
                ui_colors.Add(Color.FromArgb(31, 31, 31));          // 5
                // UI COLOR MODES
                ui_colors.Add(Color.FromArgb(24, 24, 24));          // 6
                ui_colors.Add(Color.FromArgb(31, 31, 31));          // 7
                ui_colors.Add(Color.WhiteSmoke);                    // 8
                ui_colors.Add(Color.FromArgb(50, 50, 50));          // 9
                ui_colors.Add(Color.FromArgb(24, 24, 24));          // 10
                ui_colors.Add(Color.FromArgb(48, 98, 88));          // 11
                ui_colors.Add(Color.WhiteSmoke);                    // 12
                ui_colors.Add(Color.FromArgb(31, 31, 31));          // 13
                ui_colors.Add(Color.WhiteSmoke);                    // 14
                // THEME LOGOS
                FileHashBtn.Image = Properties.Resources.dark_left_menu_file_hash;
                TextHashBtn.Image = Properties.Resources.dark_left_menu_text_hash;
                HashCompareBtn.Image = Properties.Resources.dark_left_menu_hash_compare;
                // SETTINGS
                settingsToolStripMenuItem.Image = Properties.Resources.dark_top_menu_settings;
                themeToolStripMenuItem.Image = Properties.Resources.dark_top_menu_theme;
                languageToolStripMenuItem.Image = Properties.Resources.dark_top_menu_language;
                initialViewToolStripMenuItem.Image = Properties.Resources.dark_top_menu_start;
                // HELP
                helpToolStripMenuItem.Image = Properties.Resources.dark_top_menu_help;
                aboutToolStripMenuItem.Image = Properties.Resources.dark_top_menu_about;
                gitHubToolStripMenuItem.Image = Properties.Resources.dark_top_menu_github;
            }else if (theme == 2){
                // TITLEBAR CHANGE
                try { if (DwmSetWindowAttribute(Handle, 19, new[]{ 1 }, 4) != 0){ DwmSetWindowAttribute(Handle, 20, new[] { 1 }, 4); } }catch (Exception){ }
                // CLEAR PRELOAD ITEMS
                if (ui_colors.Count > 0){ ui_colors.Clear(); }
                if (header_colors.Count > 1){ header_colors.Clear(); }
                // HEADER MENU COLOR MODE
                header_colors.Add(Color.FromArgb(46, 52, 64));
                header_colors.Add(Color.FromArgb(222, 222, 222));
                // HEADER AND TOOLTIP COLOR MODE
                ui_colors.Add(Color.WhiteSmoke);                    // 0
                ui_colors.Add(Color.FromArgb(36, 41, 51));          // 1
                // LEFT MENU COLOR MODE
                ui_colors.Add(Color.FromArgb(36, 41, 51));          // 2
                ui_colors.Add(Color.FromArgb(46, 52, 64));          // 3
                ui_colors.Add(Color.WhiteSmoke);                    // 4
                // CONTENT BG COLOR MODE
                ui_colors.Add(Color.FromArgb(46, 52, 64));          // 5
                // UI COLOR MODES
                ui_colors.Add(Color.FromArgb(36, 41, 51));          // 6
                ui_colors.Add(Color.FromArgb(46, 52, 64));          // 7
                ui_colors.Add(Color.WhiteSmoke);                    // 8
                ui_colors.Add(Color.FromArgb(59, 66, 82));          // 9
                ui_colors.Add(Color.FromArgb(36, 41, 51));          // 10
                ui_colors.Add(Color.FromArgb(88, 119, 157));        // 11
                ui_colors.Add(Color.WhiteSmoke);                    // 12
                ui_colors.Add(Color.FromArgb(46, 52, 64));          // 13
                ui_colors.Add(Color.WhiteSmoke);                    // 14
                // THEME LOGOS
                FileHashBtn.Image = Properties.Resources.nord_left_menu_file_hash;
                TextHashBtn.Image = Properties.Resources.nord_left_menu_text_hash;
                HashCompareBtn.Image = Properties.Resources.nord_left_menu_hash_compare;
                // SETTINGS
                settingsToolStripMenuItem.Image = Properties.Resources.nord_top_menu_settings;
                themeToolStripMenuItem.Image = Properties.Resources.nord_top_menu_theme;
                languageToolStripMenuItem.Image = Properties.Resources.nord_top_menu_language;
                initialViewToolStripMenuItem.Image = Properties.Resources.nord_top_menu_start;
                // HELP
                helpToolStripMenuItem.Image = Properties.Resources.nord_top_menu_help;
                aboutToolStripMenuItem.Image = Properties.Resources.nord_top_menu_about;
                gitHubToolStripMenuItem.Image = Properties.Resources.nord_top_menu_github;
            }
            // SAVE THEME
            try{
                VimeraSettingsSave vimera_setting_save = new VimeraSettingsSave(vimera_sf);
                vimera_setting_save.VimeraWriteSettings("VimeraSettings", "ThemeStatus", Convert.ToString(ts));
            }catch (Exception){ }
            theme_engine();
            // OTHER PAGE DYNAMIC UI
            vimera_other_page_preloader();
        }
        private void vimera_other_page_preloader(){
            // VIMERA ABOUT
            try{
                VimeraAbout vimera_about = new VimeraAbout();
                string vimera_about_name = "vimera_about";
                vimera_about.Name = vimera_about_name;
                if (Application.OpenForms[vimera_about_name] != null){
                    vimera_about = (VimeraAbout)Application.OpenForms[vimera_about_name];
                    vimera_about.about_preloader();
                }
            }catch (Exception) { }
        }
        private void theme_engine(){
            try{
                header_image_reloader(menu_btns);
                HeaderMenu.Renderer = new HeaderMenuColors();
                // HEADER PANEL
                HeaderPanel.BackColor = ui_colors[1];
                // HEADER PANEL TEXT
                HeaderText.ForeColor = ui_colors[0];
                // HEADER MENU
                HeaderMenu.ForeColor = ui_colors[0];
                HeaderMenu.BackColor = ui_colors[1];
                // HEADER MENU CONTENT
                // SETTINGS
                settingsToolStripMenuItem.ForeColor = ui_colors[0];
                settingsToolStripMenuItem.BackColor = ui_colors[1];
                // THEMES
                themeToolStripMenuItem.BackColor = ui_colors[1];
                themeToolStripMenuItem.ForeColor = ui_colors[0];
                lightThemeToolStripMenuItem.BackColor = ui_colors[1];
                lightThemeToolStripMenuItem.ForeColor = ui_colors[0];
                darkThemeToolStripMenuItem.BackColor = ui_colors[1];
                darkThemeToolStripMenuItem.ForeColor = ui_colors[0];
                nordThemeToolStripMenuItem.BackColor = ui_colors[1];
                nordThemeToolStripMenuItem.ForeColor = ui_colors[0];
                // LANGS
                languageToolStripMenuItem.BackColor = ui_colors[1];
                languageToolStripMenuItem.ForeColor = ui_colors[0];
                englishToolStripMenuItem.BackColor = ui_colors[1];
                englishToolStripMenuItem.ForeColor = ui_colors[0];
                turkishToolStripMenuItem.BackColor = ui_colors[1];
                turkishToolStripMenuItem.ForeColor = ui_colors[0];
                // INITIAL VIEW
                initialViewToolStripMenuItem.BackColor = ui_colors[1];
                initialViewToolStripMenuItem.ForeColor = ui_colors[0];
                windowedToolStripMenuItem.BackColor = ui_colors[1];
                windowedToolStripMenuItem.ForeColor = ui_colors[0];
                fullScreenToolStripMenuItem.BackColor = ui_colors[1];
                fullScreenToolStripMenuItem.ForeColor = ui_colors[0];
                // HELP
                helpToolStripMenuItem.BackColor = ui_colors[1];
                helpToolStripMenuItem.ForeColor = ui_colors[0];
                aboutToolStripMenuItem.BackColor = ui_colors[1];
                aboutToolStripMenuItem.ForeColor = ui_colors[0];
                gitHubToolStripMenuItem.BackColor = ui_colors[1];
                gitHubToolStripMenuItem.ForeColor = ui_colors[0];
                // LEFT MENU
                LeftPanel.BackColor = ui_colors[2];
                FileHashBtn.BackColor = ui_colors[2];
                TextHashBtn.BackColor = ui_colors[2];
                HashCompareBtn.BackColor = ui_colors[2];
                // LEFT MENU BORDER
                FileHashBtn.FlatAppearance.BorderColor = ui_colors[2];
                TextHashBtn.FlatAppearance.BorderColor = ui_colors[2];
                HashCompareBtn.FlatAppearance.BorderColor = ui_colors[2];
                // LEFT MENU MOUSE HOVER
                FileHashBtn.FlatAppearance.MouseOverBackColor = ui_colors[3];
                TextHashBtn.FlatAppearance.MouseOverBackColor = ui_colors[3];
                HashCompareBtn.FlatAppearance.MouseOverBackColor = ui_colors[3];
                // LEFT MENU MOUSE DOWN
                FileHashBtn.FlatAppearance.MouseDownBackColor = ui_colors[3];
                TextHashBtn.FlatAppearance.MouseDownBackColor = ui_colors[3];
                HashCompareBtn.FlatAppearance.MouseDownBackColor = ui_colors[3];
                // LEFT MENU BUTTON TEXT COLOR
                FileHashBtn.ForeColor = ui_colors[4];
                TextHashBtn.ForeColor = ui_colors[4];
                HashCompareBtn.ForeColor = ui_colors[4];
                // CONTENT BG
                BackColor = ui_colors[5];
                FileHash.BackColor = ui_colors[5];
                TextHash.BackColor = ui_colors[5];
                HashCompare.BackColor = ui_colors[5];
                // FILE HASH
                FileHashPanel.BackColor = ui_colors[6];
                FileHashAlgorithmSelect.BackColor = ui_colors[11];
                FileHashSelectFileBtn.BackColor = ui_colors[11];
                FileHashLoadFE_Panel.BackColor = ui_colors[11];
                FileHashDGV.BackgroundColor = ui_colors[7];
                FileHashDGV.GridColor = ui_colors[9];
                FileHashDGV.DefaultCellStyle.BackColor = ui_colors[7];
                FileHashDGV.DefaultCellStyle.ForeColor = ui_colors[8];
                FileHashDGV.AlternatingRowsDefaultCellStyle.BackColor = ui_colors[10];
                FileHashDGV.ColumnHeadersDefaultCellStyle.BackColor = ui_colors[11];
                FileHashDGV.ColumnHeadersDefaultCellStyle.SelectionBackColor = ui_colors[11];
                FileHashDGV.ColumnHeadersDefaultCellStyle.ForeColor = ui_colors[12];
                FileHashDGV.DefaultCellStyle.SelectionBackColor = ui_colors[11];
                FileHashDGV.DefaultCellStyle.SelectionForeColor = ui_colors[12];
                FileHashExportHashsBtn.BackColor = ui_colors[11];
                FileHashCompareBtn.BackColor = ui_colors[11];
                FileHashStartBtn.BackColor = ui_colors[11];
                FileHashSelectFilePathTextBox.BackColor = ui_colors[13];
                FileHashSelectFilePathTextBox.ForeColor = ui_colors[14];
                FileHashUpperHashMode.ForeColor = ui_colors[14];
                FileHashTimer.BackColor = ui_colors[3];
                FileHashTimer.ForeColor = ui_colors[4];
                FileHashCompareTextBox.BackColor = ui_colors[13];
                FileHashCompareTextBox.ForeColor = ui_colors[14];
                // TEXT HASH
                TextHashPanel.BackColor = ui_colors[6];
                TextHashAlgorithmSelect.BackColor = ui_colors[11];
                TextHashL1.ForeColor = ui_colors[4];
                TextHashL2.ForeColor = ui_colors[4];
                TextHashL3.ForeColor = ui_colors[4];
                TextHashOriginalTextBox.BackColor = ui_colors[13];
                TextHashOriginalTextBox.ForeColor = ui_colors[14];
                TextHashSaltingMode.ForeColor = ui_colors[14];
                TextHashSaltingTextBox.BackColor = ui_colors[13];
                TextHashSaltingTextBox.ForeColor = ui_colors[14];
                TextHashSaltingLocateMode.BackColor = ui_colors[11];
                TextHashResultTextBox.BackColor = ui_colors[13];
                TextHashResultTextBox.ForeColor = ui_colors[14];
                TextHashResultCopyBtn.BackColor = ui_colors[11];
                // HASH COMPARE
                HashComparePanel.BackColor = ui_colors[6];
                FirstHashValueLabel.ForeColor = ui_colors[4];
                FirstHashValueTextBox.BackColor = ui_colors[13];
                FirstHashValueTextBox.ForeColor = ui_colors[14];
                SecondHashValueLabel.ForeColor = ui_colors[4];
                SecondHashValueTextBox.BackColor = ui_colors[13];
                SecondHashValueTextBox.ForeColor = ui_colors[14];
                // ROTATE MENU
                if (menu_btns == 1){
                    FileHashBtn.BackColor = ui_colors[5];
                }else if (menu_btns == 2){
                    TextHashBtn.BackColor = ui_colors[5];
                }else if (menu_btns == 3){
                    HashCompareBtn.BackColor = ui_colors[5];
                }
            }catch (Exception){ }
        }
        private void header_image_reloader(int hi_value){
            try{
                if (theme == 1){
                    switch (hi_value){
                        case 1:
                            HeaderImage.BackgroundImage = Properties.Resources.light_left_menu_file_hash;
                            break;
                        case 2:
                            HeaderImage.BackgroundImage = Properties.Resources.light_left_menu_text_hash;
                            break;
                        case 3:
                            HeaderImage.BackgroundImage = Properties.Resources.light_left_menu_hash_compare;
                            break;
                    }
                }else if (theme == 0){
                    switch (hi_value){
                        case 1:
                            HeaderImage.BackgroundImage = Properties.Resources.dark_left_menu_file_hash;
                            break;
                        case 2:
                            HeaderImage.BackgroundImage = Properties.Resources.dark_left_menu_text_hash;
                            break;
                        case 3:
                            HeaderImage.BackgroundImage = Properties.Resources.dark_left_menu_hash_compare;
                            break;
                    }
                } else if (theme == 2){
                    switch (hi_value){
                        case 1:
                            HeaderImage.BackgroundImage = Properties.Resources.nord_left_menu_file_hash;
                            break;
                        case 2:
                            HeaderImage.BackgroundImage = Properties.Resources.nord_left_menu_text_hash;
                            break;
                        case 3:
                            HeaderImage.BackgroundImage = Properties.Resources.nord_left_menu_hash_compare;
                            break;
                    }
                }
            }catch (Exception){ }
        }
        // INITIAL SETINGS
        // ======================================================================================================
        private ToolStripMenuItem selected_initial_mode;
        private void select_initial_mode_active(object target_initial_mode){
            select_initial_mode_deactive();
            if (target_initial_mode != null){
                if (selected_initial_mode != (ToolStripMenuItem)target_initial_mode){
                    selected_initial_mode = (ToolStripMenuItem)target_initial_mode;
                    selected_initial_mode.Checked = true;
                }
            }
        }
        private void select_initial_mode_deactive(){
            foreach (ToolStripMenuItem disabled_initial in initialViewToolStripMenuItem.DropDownItems){
                disabled_initial.Checked = false;
            }
        }
        private void windowedToolStripMenuItem_Click(object sender, EventArgs e){
            if (initial_status != 0){ initial_status = 0; initial_mode_settings("0"); select_initial_mode_active(sender); }
        }
        private void fullScreenToolStripMenuItem_Click(object sender, EventArgs e){
            if (initial_status != 1){ initial_status = 1; initial_mode_settings("1"); select_initial_mode_active(sender); }
        }
        private void initial_mode_settings(string get_inital_value){
            try{
                VimeraSettingsSave vimera_setting_save = new VimeraSettingsSave(vimera_sf);
                vimera_setting_save.VimeraWriteSettings("VimeraSettings", "InitialStatus", get_inital_value);
            }catch (Exception){ }
        }
        // ======================================================================================================
        // VIMERA ABOUT
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e){
            try{
                VimeraGetLangs v_lang = new VimeraGetLangs(lang_path);
                VimeraAbout vimera_about = new VimeraAbout();
                string vimera_about_name = "vimera_about";
                vimera_about.Name = vimera_about_name;
                if (Application.OpenForms[vimera_about_name] == null){
                    vimera_about.Show();
                }else{
                    if (Application.OpenForms[vimera_about_name].WindowState == FormWindowState.Minimized){
                        Application.OpenForms[vimera_about_name].WindowState = FormWindowState.Normal;
                    }
                    Application.OpenForms[vimera_about_name].Activate();
                    MessageBox.Show(string.Format(Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("HeaderHelp", "header_help_info_notification").Trim())), Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("HeaderHelp", "header_help_about").Trim()))), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }catch (Exception){ }
        }
        // ======================================================================================================
        // ROINES45 GITHUB
        private void gitHubToolStripMenuItem_Click(object sender, EventArgs e){
            try{
                Process.Start(github_link);
            }catch (Exception){ }
        }
        // VIMERA EXIT
        // ======================================================================================================
        private void vimera_exit(){ Application.Exit(); }
        private void Vimera_FormClosing(object sender, FormClosingEventArgs e){ vimera_exit(); }
    }
}