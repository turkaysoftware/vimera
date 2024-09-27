using System;
using System.IO;
using System.Net;
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
using System.Net.NetworkInformation;
//
using static Vimera.TSModules;

namespace Vimera {
    public partial class Vimera : Form { 
        public Vimera(){ InitializeComponent(); CheckForIllegalCrossThreadCalls = false; }
        // GLOBAL VARIABLES
        public static string lang, lang_path;
        public static int theme, ts_version_mode = 0;
        // ======================================================================================================
        // VARIABLES
        int menu_btns = 1, menu_rp = 1, initial_status;
        // FILE HASH
        // ======================================================================================================
        int file_hash_algorithm_mode, file_hash_process_end, file_hash_preloader = 0;
        bool file_hash_timer_mode;
        string file_hash_current_mode;
        // TEXT HASH
        // ======================================================================================================
        int text_hash_salt_mode;
        // HASH COMPARE
        // ======================================================================================================
        int hash_compare_status;
        // GITHUB WEBSITE & GITHUB LINK
        // ======================================================================================================
        // MEDIA LINK SYSTEM
        static TS_VersionEngine TS_SoftwareVersion = new TS_VersionEngine();
        TS_LinkSystem TS_LinkSystem = new TS_LinkSystem();
        // ======================================================================================================
        // COLOR MODES / Index Mode | 0 = Dark - 1 = Light
        List<Color> btn_colors_active = new List<Color>(){ Color.Transparent };
        static List<Color> header_colors = new List<Color>(){ Color.Transparent, Color.Transparent };
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
            -- THEME --      |  -- LANGUAGE --      |   -- INITIAL MODE --
            0 = Dark Theme   |  Moved to            |   0 = Normal Windowed
            1 = Light Theme  |  TSModules.cs        |   1 = FullScreen Mode
        */
        private void software_preloader(){
            try{
                //
                bool alt_lang_available = false;
                bool en_lang_available = false;
                //
                // CHECK OS NAME
                string ui_lang = CultureInfo.InstalledUICulture.TwoLetterISOLanguageName.Trim();
                // CHECK VIMERA LANG FOLDER
                if (Directory.Exists(vimera_lf)){
                    // CHECK LANG FILES
                    int get_langs_file = Directory.GetFiles(vimera_lf, "*.ini").Length;
                    if (get_langs_file > 0){
                        // CHECK SETTINGS
                        try{
                            // CHECK LANG FILES
                            if (!File.Exists(vimera_lang_en)){ englishToolStripMenuItem.Enabled = false; }else{ en_lang_available = true; }
                            if (!File.Exists(vimera_lang_tr)){ turkishToolStripMenuItem.Enabled = false; }else{ alt_lang_available = true; }
                            //
                            if (en_lang_available == true){
                                // CHECK TR LANG
                                if (File.Exists(ts_sf)){
                                    GetSettingSetting(alt_lang_available);
                                }else{
                                    // DETECT SYSTEM THEME
                                    TSSettingsSave software_settings_save = new TSSettingsSave(ts_sf);
                                    string get_system_theme = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", "SystemUsesLightTheme", "").ToString().Trim();
                                    software_settings_save.TSWriteSettings(ts_settings_container, "ThemeStatus", get_system_theme);
                                    // DETECT SYSTEM LANG / BYPASS LANGUAGE
                                    if (alt_lang_available){
                                        if (ui_lang != "" && ui_lang != string.Empty){
                                            software_settings_save.TSWriteSettings(ts_settings_container, "LanguageStatus", ui_lang);
                                        }else{
                                            software_settings_save.TSWriteSettings(ts_settings_container, "LanguageStatus", "en");
                                        }
                                        GetSettingSetting(true);
                                    }else{
                                        software_settings_save.TSWriteSettings(ts_settings_container, "LanguageStatus", "en");
                                        GetSettingSetting(false);
                                    }
                                    // SET INITIAL MODE
                                    software_settings_save.TSWriteSettings(ts_settings_container, "InitialStatus", "0");
                                }
                            }else{
                                software_prelaoder_alert(0);
                            }
                        }catch (Exception){ }
                    }else{
                        software_prelaoder_alert(1);
                    }
                }else{
                    software_prelaoder_alert(2);
                }
            }catch (Exception){ }
        }
        // ======================================================================================================
        // PRELOAD ALERT
        private void software_prelaoder_alert(int pre_mode){
            DialogResult open_last_release = DialogResult.OK;
            if (pre_mode == 0){
                open_last_release = MessageBox.Show($"English language (English.ini) is a compulsory language. The English.ini file seems to be missing.\n\nWould you like to view and download the latest version of {Application.ProductName} again?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            }else if (pre_mode == 1){
                open_last_release = MessageBox.Show($"No language file found.\nThere seems to be a problem with the language files.\n\nWould you like to view and download the latest version of {Application.ProductName} again?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            }else if (pre_mode == 2){
                open_last_release = MessageBox.Show($"v_langs folder not found.\nThe folder seems to be missing.\n\nWould you like to view and download the latest version of {Application.ProductName} again?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            }
            if (open_last_release == DialogResult.Yes){
                Process.Start(TS_LinkSystem.github_link_lr);
            }
            software_exit();
        }
        // ======================================================================================================
        // VIMERA LOAD LANGS SETTINGS
        private void GetSettingSetting(bool _lang_wrapper){
            // THEME - LANG - VIEW MODE PRELOADER
            TSSettingsSave software_read_settings = new TSSettingsSave(ts_sf);
            string theme_mode = software_read_settings.TSReadSettings(ts_settings_container, "ThemeStatus");
            switch (theme_mode){
                case "0":
                    theme_engine(0);
                    darkThemeToolStripMenuItem.Checked = true;
                    break;
                default:
                    theme_engine(1);
                    lightThemeToolStripMenuItem.Checked = true;
                    break;
            }
            string lang_mode = software_read_settings.TSReadSettings(ts_settings_container, "LanguageStatus");
            if (_lang_wrapper){
                switch (lang_mode){
                    case "en":
                        lang_engine(vimera_lang_en, "en");
                        englishToolStripMenuItem.Checked = true;
                        break;
                    case "tr":
                        lang_engine(vimera_lang_tr, "tr");
                        turkishToolStripMenuItem.Checked = true;
                        break;
                    default:
                        lang_engine(vimera_lang_en, "en");
                        englishToolStripMenuItem.Checked = true;
                        break;
                }
            }else{
                lang_engine(vimera_lang_en, "en");
                englishToolStripMenuItem.Checked = true;
            }
            string initial_mode = software_read_settings.TSReadSettings(ts_settings_container, "InitialStatus");
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
        TS_VersionEngine TS_SofwareVersion = new TS_VersionEngine();
        // VIMERA LOAD
        // ====================================================================================================== 
        private void Vimera_Load(object sender, EventArgs e){ 
            Text = TS_SofwareVersion.TS_SofwareVersion(0, ts_version_mode);
            HeaderMenu.Cursor = Cursors.Hand;
            software_pre_selected_values();
            software_preloader();
            //
            Task softwareUpdateCheck = Task.Run(() => software_update_check(0));
        }
        // VIMERA PRE SELECTED VALUES SET FUNCTION
        // ======================================================================================================
        private void software_pre_selected_values(){
            try{
                TSGetLangs software_lang = new TSGetLangs(lang_path);
                // BUTTONS DPI AWARE SETTINGS
                int btn_dpi_height = FileHashSelectFilePathTextBox.Height;
                FileHashSelectFileBtn.Height = btn_dpi_height;
                FileHashExportHashsBtn.Height = btn_dpi_height;
                FileHashCompareBtn.Height = btn_dpi_height;
                // HASH ALGORITHM
                string[] hash_algorithm_file = { "MD5", "SHA-1", "SHA-256", "SHA-384", "SHA-512" };
                string[] hash_algorithm_text = { Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("FileHashTool", "fht_binary").Trim())), "Base64", "RIPEMD-160", "MD5", "SHA-1", "SHA-256", "SHA-384", "SHA-512" };
                // FILE HASH PRELOAD
                // ======================================================================================================
                for (int i = 0; i <= hash_algorithm_file.Length - 1; i++){
                    FileHashAlgorithmSelect.Items.Add(hash_algorithm_file[i]);
                }
                FileHashAlgorithmSelect.SelectedIndex = 0;
                // DVG
                FileHashDGV.Columns.Add("FP", Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("FileHashTool", "fht_file_path").Trim())));
                FileHashDGV.Columns.Add("FS", Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("FileHashTool", "fht_file_size").Trim())));
                FileHashDGV.Columns.Add("HV", Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("FileHashTool", "fht_hash_value").Trim())));
                FileHashDGV.Columns[0].Width = 225;
                FileHashDGV.Columns[1].Width = 140;
                foreach (DataGridViewColumn OSD_Column in FileHashDGV.Columns){
                    OSD_Column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                FileHashDGV.ClearSelection();
                // TEXT HASH PRELOAD
                // ======================================================================================================
                for (int i = 0; i <= hash_algorithm_text.Length - 1; i++){
                    TextHashAlgorithmSelect.Items.Add(hash_algorithm_text[i]);
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
                TSGetLangs software_lang = new TSGetLangs(lang_path);
                using (var select_file = new OpenFileDialog()){
                    select_file.Filter = Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("FileHashTool", "fht_all_files").Trim())) + " (*.*)|*.*";
                    select_file.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    select_file.Title = Application.ProductName + " - " + Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("FileHashTool", "fht_file_select_notification").Trim()));
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
            TSGetLangs software_lang = new TSGetLangs(lang_path);
            double file_size = new FileInfo(get_file).Length; // Byte
            FileHashDGV.Rows.Add(get_file, TS_FormatSize(file_size));
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
        private int FileHashTotalFiles;
        private List<int> FileProgressList;
        private void FileHash_BG_Worker_DoWork(object sender, DoWorkEventArgs e){
            TSGetLangs software_lang = new TSGetLangs(lang_path);
            file_hash_timer_mode = true;
            Task file_hash_timers = new Task(file_hash_timer);
            file_hash_timers.Start();
            //
            int buffer_size = 128 * 1024; // 128 KB
            //
            FileHashTotalFiles = FileHashDGV.Rows.Count;
            FileProgressList = new List<int>(new int[FileHashTotalFiles]);
            //
            object lockObject = new object();
            int processedFiles = 0;
            //
            Parallel.ForEach(FileHashDGV.Rows.Cast<DataGridViewRow>().Select((row, index) => new { row, index }), item =>{
                try{
                    string file_path = item.row.Cells[0].Value.ToString();
                    byte[] buffer = new byte[buffer_size];
                    long total_bytes_read = 0;
                    //
                    FileHashSelectFilePathTextBox.Invoke((Action)(() => FileHashSelectFilePathTextBox.Text = file_path));
                    //
                    using (Stream file = File.OpenRead(file_path)){
                        long size = file.Length;
                        HashAlgorithm hasher = GetHashAlgorithm(file_hash_algorithm_mode);
                        if (hasher != null){
                            int bytes_read;
                            do{
                                bytes_read = file.Read(buffer, 0, buffer_size);
                                total_bytes_read += bytes_read;
                                hasher.TransformBlock(buffer, 0, bytes_read, null, 0);
                                //
                                int progressPercentage = (int)((double)total_bytes_read / size * 100);
                                lock (lockObject){
                                    FileProgressList[item.index] = progressPercentage;
                                }
                            } while (bytes_read > 0);
                            hasher.TransformFinalBlock(buffer, 0, 0);
                            item.row.Cells[2].Value = HashStringRotate(hasher.Hash);
                        }
                    }
                    // Increase the number of processed files as each file is processed
                    lock (lockObject){
                        processedFiles++;
                        int overallProgress = (int)((double)processedFiles / FileHashTotalFiles * 100);
                        FileHash_BG_Worker.ReportProgress(overallProgress);
                    }
                }catch (Exception){ }
            });
        }
        // HASH ALGORITHM SELECTION METHOD
        private HashAlgorithm GetHashAlgorithm(int algorithmMode){
            switch (algorithmMode){
                case 0: return MD5.Create();
                case 1: return SHA1.Create();
                case 2: return SHA256.Create();
                case 3: return SHA384.Create();
                case 4: return SHA512.Create();
                default: return null;
            }
        }
        // FILE HASH PROCESS CHANGED
        // ======================================================================================================
        private void FileHash_BG_Worker_ProgressChanged(object sender, ProgressChangedEventArgs e){
            Text = TS_SofwareVersion.TS_SofwareVersion(0, ts_version_mode) + " - " + "%" + e.ProgressPercentage;
            FileHashLoadFE_Panel.Width = e.ProgressPercentage * FileHashLoadBG_Panel.Width / 100;
        }
        // FILE HASH PROCESS RUNWORKER COMPLETED
        // ======================================================================================================
        private void FileHash_BG_Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e){
            TSGetLangs software_lang = new TSGetLangs(lang_path);
            Text = TS_SofwareVersion.TS_SofwareVersion(0, ts_version_mode);
            file_hash_enabled_ui();
            //
            FileProgressList = null;
            FileHashTotalFiles = 0;
            //
            MessageBox.Show(Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("FileHashTool", "fht_hash_success").Trim())), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    TSGetLangs software_lang = new TSGetLangs(lang_path);
                    for (int i = 0; i <= FileHashDGV.Rows.Count - 1; i++){
                        if (FileHashDGV.Rows[i].Cells[2].Value == null || (string)FileHashDGV.Rows[i].Cells[2].Value == "" || (string)FileHashDGV.Rows[i].Cells[2].Value == string.Empty){
                            FileHashDGV.Rows[i].Cells[2].Value = Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("FileHashTool", "fht_unreadable").Trim()));
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
                    TSGetLangs software_lang = new TSGetLangs(lang_path);
                    if (Clipboard.GetText() != FileHashDGV.Rows[e.RowIndex].Cells[2].Value.ToString()){
                        Clipboard.SetText(FileHashDGV.Rows[e.RowIndex].Cells[2].Value.ToString());
                        //FileHashDGV.ClearSelection();
                        MessageBox.Show(Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("FileHashTool", "fht_hash_value_copy_success").Trim())), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                TSGetLangs software_lang = new TSGetLangs(lang_path);
                if (FileHashDGV.SelectedRows.Count > 0){
                    string generate_hash_value = FileHashDGV.Rows[FileHashDGV.CurrentCell.RowIndex].Cells[2].Value.ToString().ToLower();
                    string original_value = FileHashCompareTextBox.Text.Trim().ToLower();
                    if (original_value == generate_hash_value){
                        MessageBox.Show(Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("FileHashTool", "fht_hash_match").Trim())), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }else{
                        MessageBox.Show(Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("FileHashTool", "fht_hash_not_match").Trim())), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    FileHashDGV.ClearSelection();
                }else{
                    MessageBox.Show(Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("FileHashTool", "fht_hash_select_notification").Trim())), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }catch (Exception){ }
        }
        // FILE HASH TIMER
        // ======================================================================================================
        private void file_hash_timer(){
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            //
            int fh_second = 0;
            int fh_minute = 0;
            int fh_hour = 0;
            //
            try{
                while (file_hash_timer_mode){
                    TimeSpan elapsed = stopwatch.Elapsed;
                    fh_second = (int)elapsed.TotalSeconds % 60;
                    fh_minute = (int)(elapsed.TotalMinutes % 60);
                    fh_hour = (int)(elapsed.TotalHours);
                    FileHashTimer.Text = string.Format("{0:D2}:{1:D2}:{2:D2}", fh_hour, fh_minute, fh_second);
                    Thread.Sleep(1000);
                }
            }catch (Exception){ }
        }
        // FILE HASH EXPORT HASH DATA
        // ======================================================================================================
        List<string> PrintEngineList = new List<string>();
        private void FileHashExportHashsBtn_Click(object sender, EventArgs e){
            try{
                TSGetLangs software_lang = new TSGetLangs(lang_path);
                switch (file_hash_algorithm_mode){
                    case 0:
                        file_hash_current_mode = Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("FileHashPrintEngine", "fhpe_document_md5").Trim())) + " (*.md5)|*.md5";
                        break;
                    case 1:
                        file_hash_current_mode = Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("FileHashPrintEngine", "fhpe_document_sha1").Trim())) + " (*.sha1)|*.sha1";
                        break;
                    case 2:
                        file_hash_current_mode = Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("FileHashPrintEngine", "fhpe_document_sha256").Trim())) + " (*.sha256)|*.sha256";
                        break;
                    case 3:
                        file_hash_current_mode = Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("FileHashPrintEngine", "fhpe_document_sha384").Trim())) + " (*.sha384)|*.sha384";
                        break;
                    case 4:
                        file_hash_current_mode = Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("FileHashPrintEngine", "fhpe_document_sha512").Trim())) + " (*.sha512)|*.sha512";
                        break;
                }
                //
                for (int i = 0; i < FileHashDGV.Rows.Count; i++){
                    if (!FileHashDGV.Rows[i].IsNewRow){
                        //PrintEngineList.Add(FileHashDGV.Rows[i].Cells[2].Value?.ToString().Trim() + "  " + Path.GetFileName(FileHashDGV.Rows[i].Cells[0].Value?.ToString().Trim()));
                        PrintEngineList.Add(FileHashDGV.Rows[i].Cells[2].Value?.ToString().Trim() + "  " + FileHashDGV.Rows[i].Cells[0].Value?.ToString().Trim());
                    }
                }
                //
                SaveFileDialog save_engine = new SaveFileDialog{
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    Title = string.Format(Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("FileHashPrintEngine", "fhpe_save_directory_notification").Trim())), Application.ProductName),
                    FileName = string.Format(Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("FileHashPrintEngine", "fhpe_save_file_name").Trim())), Application.ProductName),
                    Filter = file_hash_current_mode + "|" + Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("FileHashPrintEngine", "fhpe_document_txt").Trim())) + " (*.txt)|*.txt"
                };
                if (save_engine.ShowDialog() == DialogResult.OK){
                    String combinedText = String.Join(Environment.NewLine, PrintEngineList);
                    File.WriteAllText(save_engine.FileName, combinedText);
                    DialogResult vimera_print_engine_query = MessageBox.Show(string.Format(Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("FileHashPrintEngine", "fhpe_save_hash_report_success_notification").Trim())), Application.ProductName, save_engine.FileName, "\n\n"), Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (vimera_print_engine_query == DialogResult.Yes){
                        Process.Start(save_engine.FileName);
                    }
                    PrintEngineList.Clear();
                    save_engine.Dispose();
                }else{
                    PrintEngineList.Clear();
                    save_engine.Dispose();
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
            TextUpdateHash();
        }
        // TEXT HASH ORIGINAL TEXTBOX TEXT CHANGED
        // ======================================================================================================
        private void TextHashOriginalTextBox_TextChanged(object sender, EventArgs e){
            TextHashUpdateUI();
            TextUpdateHash();
        }
        // TEXT HASH SALTING TEXTBOX TEXT CHANGED
        // ======================================================================================================
        private void TextHashSaltingTextBox_TextChanged(object sender, EventArgs e){
            TextUpdateHash();
        }
        // TEXT HASH SALTING LOCATE MODE INDEX CHANGED
        // ======================================================================================================
        private void TextHashSaltingLocateMode_SelectedIndexChanged(object sender, EventArgs e){
            TextUpdateHash();
        }
        // TEXT HASH SALTING MODE CHECKED CHANGED
        // ======================================================================================================
        private void TextHashSaltingMode_CheckedChanged(object sender, EventArgs e){
            TextHashSaltingTextBox.Enabled = TextHashSaltingMode.Checked;
            TextHashSaltingLocateMode.Visible = TextHashSaltingMode.Checked;
            text_hash_salt_mode = TextHashSaltingMode.Checked ? 1 : 0;
            TextUpdateHash();
        }
        private void TextUpdateHash(){
            if (!string.IsNullOrWhiteSpace(TextHashOriginalTextBox.Text)){
                text_hash_engine(
                    TextHashAlgorithmSelect.SelectedIndex,
                    text_hash_salt_mode,
                    TextHashSaltingLocateMode.SelectedIndex,
                    TextHashOriginalTextBox.Text
                );
            }else{
                TextHashSaltingMode.Enabled = false;
                TextHashSaltingMode.Checked = false;
                TextHashResultCopyBtn.Enabled = false;
                TextHashResultTextBox.Text = string.Empty;
            }
        }
        private void TextHashUpdateUI(){
            bool isTextNotEmpty = !string.IsNullOrWhiteSpace(TextHashOriginalTextBox.Text);
            TextHashSaltingMode.Enabled = isTextNotEmpty;
            TextHashResultCopyBtn.Enabled = isTextNotEmpty;
        }
        // TEXT HASH ENGINE
        // ======================================================================================================
        private void text_hash_engine(int hash_mode, int salt_mode, int salt_locate_mode, string original_text){
            try{
                if (salt_mode == 1){
                    original_text = (salt_locate_mode == 0 ? TextHashSaltingTextBox.Text + original_text : original_text + TextHashSaltingTextBox.Text);
                }
                TextHashResultTextBox.Text = TextComputeHash(hash_mode, original_text);
            }catch (Exception){ }
        }
        private string TextComputeHash(int hash_mode, string original_text){
            byte[] inputBytes = Encoding.UTF8.GetBytes(original_text);
            byte[] hashBytes;
            switch (hash_mode){
                case 0:
                    return ToBinary(inputBytes);
                case 1:
                    return Convert.ToBase64String(inputBytes);
                case 2:
                    using (var ripemd160 = new RIPEMD160Managed()){
                        hashBytes = ripemd160.ComputeHash(inputBytes);
                        return HashStringRotate(hashBytes);
                    }
                case 3:
                    using (MD5 md5 = MD5.Create()){
                        hashBytes = md5.ComputeHash(inputBytes);
                        return HashStringRotate(hashBytes);
                    }
                case 4:
                    using (SHA1 sha1 = SHA1.Create()){
                        hashBytes = sha1.ComputeHash(inputBytes);
                        return HashStringRotate(hashBytes);
                    }
                case 5:
                    using (SHA256 sha256 = SHA256.Create()){
                        hashBytes = sha256.ComputeHash(inputBytes);
                        return HashStringRotate(hashBytes);
                    }
                case 6:
                    using (SHA384 sha384 = SHA384.Create()){
                        hashBytes = sha384.ComputeHash(inputBytes);
                        return HashStringRotate(hashBytes);
                    }
                case 7:
                    using (SHA512 sha512 = SHA512.Create()){
                        hashBytes = sha512.ComputeHash(inputBytes);
                        return HashStringRotate(hashBytes);
                    }
                default:
                    throw new NotSupportedException("Unsupported hash mode.");
            }
        }
        // BINARY CONVERTER
        // ======================================================================================================
        public static string ToBinary(byte[] hash_data){
            return string.Join(" ", hash_data.Select(hash_byte => Convert.ToString(hash_byte, 2).PadLeft(8, '0')));
        }
        // COPY TEXT HASH RESULT
        // ======================================================================================================
        private void TextHashResultCopyBtn_Click(object sender, EventArgs e){
            try{
                TSGetLangs software_lang = new TSGetLangs(lang_path);
                if (Clipboard.GetText() != TextHashResultTextBox.Text){
                    Clipboard.SetText(TextHashResultTextBox.Text);
                    MessageBox.Show(Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("TextHashTool", "tht_hash_copy_notiftication").Trim())), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                TSGetLangs software_lang = new TSGetLangs(lang_path);
                HashCompareResultLabel.Visible = true;
                string hash_1 = FirstHashValueTextBox.Text.Trim().ToLower();
                string hash_2 = SecondHashValueTextBox.Text.Trim().ToLower();
                if (hash_1 == hash_2){
                    hash_compare_status = 0;
                    HashCompareResultLabel.BackColor = TS_ThemeEngine.ColorMode(theme, "HashCompareSuccess");
                    HashCompareResultLabel.ForeColor = TS_ThemeEngine.ColorMode(theme, "HashCompareResultFE");
                    HashCompareResultLabel.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("HashCompareTool", "hct_values_match").Trim()));
                }else{
                    hash_compare_status = 1;
                    HashCompareResultLabel.BackColor = TS_ThemeEngine.ColorMode(theme, "HashCompareFailed");
                    HashCompareResultLabel.ForeColor = TS_ThemeEngine.ColorMode(theme, "HashCompareResultFE");
                    HashCompareResultLabel.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("HashCompareTool", "hct_values_not_match").Trim()));
                }
            }catch (Exception){ }
        }
        // ROTATE BTNS
        // ======================================================================================================
        private void active_page(object btn_target){
            Button active_btn = null;
            disabled_page();
            if (btn_target != null){
                if (active_btn != (Button)btn_target){
                    active_btn = (Button)btn_target;
                    active_btn.BackColor = TS_ThemeEngine.ColorMode(theme, "BtnActiveColor");
                    active_btn.Cursor = Cursors.Default;
                }
            }
        }
        private void disabled_page(){
            foreach (Control disabled_btn in LeftPanel.Controls){
                disabled_btn.BackColor = TS_ThemeEngine.ColorMode(theme, "BtnDeActiveColor");
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
                TSGetLangs software_lang = new TSGetLangs(lang_path);
                switch (target_menu){
                    case 1:
                        if (menu_btns != 1){
                            MainContent.SelectedTab = FileHash;
                            if (!btn_colors_active.Contains(FileHashBtn.BackColor)){ active_page(sender); }
                            HeaderText.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("Header", "header_file_hash").Trim()));
                        }
                        break;
                    case 2:
                        if (menu_btns != 2){
                            MainContent.SelectedTab = TextHash;
                            if (!btn_colors_active.Contains(TextHashBtn.BackColor)){ active_page(sender); }
                            HeaderText.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("Header", "header_text_hash").Trim()));
                        }
                        break;
                    case 3:
                        if (menu_btns != 3){
                            MainContent.SelectedTab = HashCompare;
                            if (!btn_colors_active.Contains(HashCompareBtn.BackColor)){ active_page(sender); }
                            HeaderText.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("Header", "header_hash_compare").Trim()));
                        }
                        break;
                }
                menu_btns = target_menu;
                menu_rp = target_menu;
                header_image_reloader(menu_btns);
            }catch (Exception){ }
        }
        // LANG MODE
        // ======================================================================================================
        private void select_lang_active(object target_lang){
            ToolStripMenuItem selected_lang = null;
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
            if (lang != "en"){ lang_preload(vimera_lang_en, "en"); select_lang_active(sender); }
        }
        private void turkishToolStripMenuItem_Click(object sender, EventArgs e){
            if (lang != "tr"){ lang_preload(vimera_lang_tr, "tr"); select_lang_active(sender); }
        }
        private void lang_preload(string lang_type, string lang_code){
            lang_engine(lang_type, lang_code);
            try{
                TSSettingsSave software_setting_save = new TSSettingsSave(ts_sf);
                software_setting_save.TSWriteSettings(ts_settings_container, "LanguageStatus", lang_code);
            }
            catch (Exception) { }
            // LANG CHANGE NOTIFICATION
            TSGetLangs software_lang = new TSGetLangs(lang_path);
            DialogResult lang_change_message = MessageBox.Show(string.Format(Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("LangChange", "lang_change_notification").Trim())), "\n\n", "\n\n"), Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (lang_change_message == DialogResult.Yes){ Application.Restart(); }
        }
        private void lang_engine(string lang_type, string lang_code){
            try{
                lang_path = lang_type;
                lang = lang_code;
                // GLOBAL ENGINE
                TSGetLangs software_lang = new TSGetLangs(lang_path);
                if (menu_rp == 1){
                    HeaderText.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("Header", "header_file_hash").Trim()));
                }else if (menu_rp == 2){
                    HeaderText.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("Header", "header_text_hash").Trim()));
                }else if (menu_rp == 3){
                    HeaderText.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("Header", "header_hash_compare").Trim()));
                }
                // SETTINGS
                settingsToolStripMenuItem.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("HeaderMenu", "header_menu_settings").Trim()));
                // THEMES
                themeToolStripMenuItem.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("HeaderMenu", "header_menu_theme").Trim()));
                lightThemeToolStripMenuItem.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("HeaderThemes", "theme_light").Trim()));
                darkThemeToolStripMenuItem.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("HeaderThemes", "theme_dark").Trim()));
                // LANGS
                languageToolStripMenuItem.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("HeaderMenu", "header_menu_language").Trim()));
                englishToolStripMenuItem.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("HeaderLangs", "lang_en").Trim()));
                turkishToolStripMenuItem.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("HeaderLangs", "lang_tr").Trim()));
                // INITIAL VIEW
                initialViewToolStripMenuItem.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("HeaderMenu", "header_menu_start").Trim()));
                windowedToolStripMenuItem.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("HeaderViewMode", "header_viev_mode_windowed").Trim()));
                fullScreenToolStripMenuItem.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("HeaderViewMode", "header_viev_mode_full_screen").Trim()));
                // UPDATE
                checkForUpdateToolStripMenuItem.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("HeaderMenu", "header_menu_update").Trim()));
                // ABOUT
                aboutToolStripMenuItem.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("HeaderMenu", "header_menu_about").Trim()));
                // MENU
                FileHashBtn.Text = " " + " " + Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("LeftMenu", "left_file_hash").Trim()));
                TextHashBtn.Text = " " + " " + Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("LeftMenu", "left_text_hash").Trim()));
                HashCompareBtn.Text = " " + " " + Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("LeftMenu", "left_hash_compare").Trim()));
                // FILE HASH
                FileHashSelectFileBtn.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("FileHashTool", "fht_select").Trim()));
                FileHashDGV.Columns[0].HeaderText = Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("FileHashTool", "fht_file_path").Trim()));
                FileHashDGV.Columns[1].HeaderText = Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("FileHashTool", "fht_file_size").Trim()));
                FileHashDGV.Columns[2].HeaderText = Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("FileHashTool", "fht_hash_value").Trim()));
                FileHashUpperHashMode.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("FileHashTool", "fht_hash_uppercase").Trim()));
                FileHashExportHashsBtn.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("FileHashTool", "fht_export_hashs").Trim()));
                FileHashCompareBtn.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("FileHashTool", "fht_compare").Trim()));
                FileHashStartBtn.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("FileHashTool", "fht_start").Trim()));
                // TEXT HASH
                TextHashAlgorithmSelect.Items[0] = Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("TextHashTool", "tht_binary").Trim()));
                TextHashL1.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("TextHashTool", "tht_original_value_input").Trim()));
                TextHashL2.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("TextHashTool", "tht_salting_value_input").Trim()));
                TextHashL3.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("TextHashTool", "tht_creating_hash_value").Trim()));
                TextHashSaltingMode.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("TextHashTool", "tht_salting_mode").Trim()));
                TextHashSaltingLocateMode.Items[0] = Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("TextHashTool", "tht_add_at_the_beginning").Trim()));
                TextHashSaltingLocateMode.Items[1] = Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("TextHashTool", "tht_add_to_end").Trim()));
                TextHashResultCopyBtn.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("TextHashTool", "tht_copy").Trim()));
                // HASH COMPARE
                FirstHashValueLabel.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("HashCompareTool", "hct_first_hash_value_input").Trim()));
                SecondHashValueLabel.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("HashCompareTool", "hct_secondary_hash_value_input").Trim()));
                if (hash_compare_status == 0){
                    HashCompareResultLabel.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("HashCompareTool", "hct_values_match").Trim()));
                }else if (hash_compare_status == 1){
                    HashCompareResultLabel.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("HashCompareTool", "hct_values_not_match").Trim()));
                }
                // OTHER PAGE DYNAMIC UI
                software_other_page_preloader();
            }catch (Exception){ }
        }
        // THEME MODE
        // ======================================================================================================
        private void select_theme_active(object target_theme){
            ToolStripMenuItem selected_theme = null;
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
            if (theme != 1){ theme_engine(1); select_theme_active(sender); }
        }
        private void darkThemeToolStripMenuItem_Click(object sender, EventArgs e){
            if (theme != 0){ theme_engine(0); select_theme_active(sender); }
        }
        // THEME ENGINE
        // ======================================================================================================
        private void theme_engine(int ts){
            try{
                theme = ts;
                if (theme == 1){
                    // TITLEBAR CHANGE 
                    try { if (DwmSetWindowAttribute(Handle, 20, new[]{ 1 }, 4) != 1){ DwmSetWindowAttribute(Handle, 20, new[]{ 0 }, 4); } }catch (Exception){ }
                    // THEME LOGOS
                    FileHashBtn.Image = Properties.Resources.lm_file_hash_light;
                    TextHashBtn.Image = Properties.Resources.lm_text_hash_light;
                    HashCompareBtn.Image = Properties.Resources.lm_hash_compare_light;
                    // SETTINGS
                    settingsToolStripMenuItem.Image = Properties.Resources.tm_settings_light;
                    themeToolStripMenuItem.Image = Properties.Resources.tm_theme_light;
                    languageToolStripMenuItem.Image = Properties.Resources.tm_lang_light;
                    initialViewToolStripMenuItem.Image = Properties.Resources.tm_start_light;
                    checkForUpdateToolStripMenuItem.Image = Properties.Resources.tm_update_light;
                    // ABOUT
                    aboutToolStripMenuItem.Image = Properties.Resources.tm_about_light;
                }else if (theme == 0){
                    // TITLEBAR CHANGE
                    try { if (DwmSetWindowAttribute(Handle, 19, new[]{ 1 }, 4) != 0){ DwmSetWindowAttribute(Handle, 20, new[]{ 1 }, 4); } }catch (Exception){ }
                    // THEME LOGOS
                    FileHashBtn.Image = Properties.Resources.lm_file_hash_dark;
                    TextHashBtn.Image = Properties.Resources.lm_text_hash_dark;
                    HashCompareBtn.Image = Properties.Resources.lm_hash_compare_dark;
                    // SETTINGS
                    settingsToolStripMenuItem.Image = Properties.Resources.tm_settings_dark;
                    themeToolStripMenuItem.Image = Properties.Resources.tm_theme_dark;
                    languageToolStripMenuItem.Image = Properties.Resources.tm_lang_dark;
                    initialViewToolStripMenuItem.Image = Properties.Resources.tm_start_dark;
                    checkForUpdateToolStripMenuItem.Image = Properties.Resources.tm_update_dark;
                    // ABOUT
                    aboutToolStripMenuItem.Image = Properties.Resources.tm_about_dark;
                }
                // OTHER PAGE DYNAMIC UI
                software_other_page_preloader();
                // HEADER
                header_image_reloader(menu_btns);
                header_colors[0] = TS_ThemeEngine.ColorMode(theme, "HeaderBGColorMain");
                header_colors[1] = TS_ThemeEngine.ColorMode(theme, "HeaderFEColorMain");
                HeaderMenu.Renderer = new HeaderMenuColors();
                // ACTIVE BTN 
                btn_colors_active[0] = TS_ThemeEngine.ColorMode(theme, "BtnActiveColor");
                // HEADER PANEL
                HeaderInPanel.BackColor = TS_ThemeEngine.ColorMode(theme, "HeaderBGColor");
                // HEADER PANEL TEXT
                HeaderText.ForeColor = TS_ThemeEngine.ColorMode(theme, "HeaderFEColor");
                // HEADER MENU
                HeaderMenu.ForeColor = TS_ThemeEngine.ColorMode(theme, "HeaderFEColor");
                HeaderMenu.BackColor = TS_ThemeEngine.ColorMode(theme, "HeaderBGColor");
                // HEADER MENU CONTENT
                // SETTINGS
                settingsToolStripMenuItem.ForeColor = TS_ThemeEngine.ColorMode(theme, "HeaderFEColor");
                settingsToolStripMenuItem.BackColor = TS_ThemeEngine.ColorMode(theme, "HeaderBGColor");
                // THEMES
                themeToolStripMenuItem.BackColor = TS_ThemeEngine.ColorMode(theme, "HeaderBGColor");
                themeToolStripMenuItem.ForeColor = TS_ThemeEngine.ColorMode(theme, "HeaderFEColor");
                lightThemeToolStripMenuItem.BackColor = TS_ThemeEngine.ColorMode(theme, "HeaderBGColor");
                lightThemeToolStripMenuItem.ForeColor = TS_ThemeEngine.ColorMode(theme, "HeaderFEColor");
                darkThemeToolStripMenuItem.BackColor = TS_ThemeEngine.ColorMode(theme, "HeaderBGColor");
                darkThemeToolStripMenuItem.ForeColor = TS_ThemeEngine.ColorMode(theme, "HeaderFEColor");
                // LANGS
                languageToolStripMenuItem.BackColor = TS_ThemeEngine.ColorMode(theme, "HeaderBGColor");
                languageToolStripMenuItem.ForeColor = TS_ThemeEngine.ColorMode(theme, "HeaderFEColor");
                englishToolStripMenuItem.BackColor = TS_ThemeEngine.ColorMode(theme, "HeaderBGColor");
                englishToolStripMenuItem.ForeColor = TS_ThemeEngine.ColorMode(theme, "HeaderFEColor");
                turkishToolStripMenuItem.BackColor = TS_ThemeEngine.ColorMode(theme, "HeaderBGColor");
                turkishToolStripMenuItem.ForeColor = TS_ThemeEngine.ColorMode(theme, "HeaderFEColor");
                // INITIAL VIEW
                initialViewToolStripMenuItem.BackColor = TS_ThemeEngine.ColorMode(theme, "HeaderBGColor");
                initialViewToolStripMenuItem.ForeColor = TS_ThemeEngine.ColorMode(theme, "HeaderFEColor");
                windowedToolStripMenuItem.BackColor = TS_ThemeEngine.ColorMode(theme, "HeaderBGColor");
                windowedToolStripMenuItem.ForeColor = TS_ThemeEngine.ColorMode(theme, "HeaderFEColor");
                fullScreenToolStripMenuItem.BackColor = TS_ThemeEngine.ColorMode(theme, "HeaderBGColor");
                fullScreenToolStripMenuItem.ForeColor = TS_ThemeEngine.ColorMode(theme, "HeaderFEColor");
                // UPDATE
                checkForUpdateToolStripMenuItem.BackColor = TS_ThemeEngine.ColorMode(theme, "HeaderBGColor");
                checkForUpdateToolStripMenuItem.ForeColor = TS_ThemeEngine.ColorMode(theme, "HeaderFEColor");
                // ABOUT
                aboutToolStripMenuItem.BackColor = TS_ThemeEngine.ColorMode(theme, "HeaderBGColor");
                aboutToolStripMenuItem.ForeColor = TS_ThemeEngine.ColorMode(theme, "HeaderFEColor");
                // LEFT MENU
                LeftPanel.BackColor = TS_ThemeEngine.ColorMode(theme, "LeftMenuBGAndBorderColor");
                FileHashBtn.BackColor = TS_ThemeEngine.ColorMode(theme, "LeftMenuBGAndBorderColor");
                TextHashBtn.BackColor = TS_ThemeEngine.ColorMode(theme, "LeftMenuBGAndBorderColor");
                HashCompareBtn.BackColor = TS_ThemeEngine.ColorMode(theme, "LeftMenuBGAndBorderColor");
                // LEFT MENU BORDER
                FileHashBtn.FlatAppearance.BorderColor = TS_ThemeEngine.ColorMode(theme, "LeftMenuBGAndBorderColor");
                TextHashBtn.FlatAppearance.BorderColor = TS_ThemeEngine.ColorMode(theme, "LeftMenuBGAndBorderColor");
                HashCompareBtn.FlatAppearance.BorderColor = TS_ThemeEngine.ColorMode(theme, "LeftMenuBGAndBorderColor");
                // LEFT MENU MOUSE HOVER
                FileHashBtn.FlatAppearance.MouseOverBackColor = TS_ThemeEngine.ColorMode(theme, "LeftMenuButtonHoverAndMouseDownColor");
                TextHashBtn.FlatAppearance.MouseOverBackColor = TS_ThemeEngine.ColorMode(theme, "LeftMenuButtonHoverAndMouseDownColor");
                HashCompareBtn.FlatAppearance.MouseOverBackColor = TS_ThemeEngine.ColorMode(theme, "LeftMenuButtonHoverAndMouseDownColor");
                // LEFT MENU MOUSE DOWN
                FileHashBtn.FlatAppearance.MouseDownBackColor = TS_ThemeEngine.ColorMode(theme, "LeftMenuButtonHoverAndMouseDownColor");
                TextHashBtn.FlatAppearance.MouseDownBackColor = TS_ThemeEngine.ColorMode(theme, "LeftMenuButtonHoverAndMouseDownColor");
                HashCompareBtn.FlatAppearance.MouseDownBackColor = TS_ThemeEngine.ColorMode(theme, "LeftMenuButtonHoverAndMouseDownColor");
                // LEFT MENU BUTTON TEXT COLOR
                FileHashBtn.ForeColor = TS_ThemeEngine.ColorMode(theme, "LeftMenuButtonFEColor");
                TextHashBtn.ForeColor = TS_ThemeEngine.ColorMode(theme, "LeftMenuButtonFEColor");
                HashCompareBtn.ForeColor = TS_ThemeEngine.ColorMode(theme, "LeftMenuButtonFEColor");
                // CONTENT BG
                BackColor = TS_ThemeEngine.ColorMode(theme, "PageContainerBGAndPageContentTotalColors");
                FileHash.BackColor = TS_ThemeEngine.ColorMode(theme, "PageContainerBGAndPageContentTotalColors");
                TextHash.BackColor = TS_ThemeEngine.ColorMode(theme, "PageContainerBGAndPageContentTotalColors");
                HashCompare.BackColor = TS_ThemeEngine.ColorMode(theme, "PageContainerBGAndPageContentTotalColors");
                // FILE HASH
                FileHashPanel.BackColor = TS_ThemeEngine.ColorMode(theme, "ContentPanelBGColor");
                FileHashAlgorithmSelect.BackColor = TS_ThemeEngine.ColorMode(theme, "MainAccentColor");
                FileHashAlgorithmSelect.ForeColor = TS_ThemeEngine.ColorMode(theme, "DynamicThemeActiveBtnBG");
                FileHashSelectFileBtn.BackColor = TS_ThemeEngine.ColorMode(theme, "MainAccentColor");
                FileHashSelectFileBtn.FlatAppearance.BorderColor = TS_ThemeEngine.ColorMode(theme, "MainAccentColor");
                FileHashSelectFileBtn.FlatAppearance.MouseDownBackColor = TS_ThemeEngine.ColorMode(theme, "MainAccentColor");
                FileHashSelectFileBtn.ForeColor = TS_ThemeEngine.ColorMode(theme, "DynamicThemeActiveBtnBG");
                FileHashLoadFE_Panel.BackColor = TS_ThemeEngine.ColorMode(theme, "MainAccentColor");
                FileHashDGV.BackgroundColor = TS_ThemeEngine.ColorMode(theme, "DataGridBGColor");
                FileHashDGV.GridColor = TS_ThemeEngine.ColorMode(theme, "DataGridColor");
                FileHashDGV.DefaultCellStyle.BackColor = TS_ThemeEngine.ColorMode(theme, "DataGridBGColor");
                FileHashDGV.DefaultCellStyle.ForeColor = TS_ThemeEngine.ColorMode(theme, "DataGridFEColor");
                FileHashDGV.AlternatingRowsDefaultCellStyle.BackColor = TS_ThemeEngine.ColorMode(theme, "DataGridAlternatingColor");
                FileHashDGV.ColumnHeadersDefaultCellStyle.BackColor = TS_ThemeEngine.ColorMode(theme, "MainAccentColor");
                FileHashDGV.ColumnHeadersDefaultCellStyle.SelectionBackColor = TS_ThemeEngine.ColorMode(theme, "MainAccentColor");
                FileHashDGV.ColumnHeadersDefaultCellStyle.ForeColor = TS_ThemeEngine.ColorMode(theme, "DataGridSelectionColor");
                FileHashDGV.DefaultCellStyle.SelectionBackColor = TS_ThemeEngine.ColorMode(theme, "MainAccentColor");
                FileHashDGV.DefaultCellStyle.SelectionForeColor = TS_ThemeEngine.ColorMode(theme, "DataGridSelectionColor");
                FileHashExportHashsBtn.BackColor = TS_ThemeEngine.ColorMode(theme, "MainAccentColor");
                FileHashExportHashsBtn.FlatAppearance.BorderColor = TS_ThemeEngine.ColorMode(theme, "MainAccentColor");
                FileHashExportHashsBtn.FlatAppearance.MouseDownBackColor = TS_ThemeEngine.ColorMode(theme, "MainAccentColor");
                FileHashExportHashsBtn.ForeColor = TS_ThemeEngine.ColorMode(theme, "DynamicThemeActiveBtnBG");
                FileHashCompareBtn.BackColor = TS_ThemeEngine.ColorMode(theme, "MainAccentColor");
                FileHashCompareBtn.FlatAppearance.BorderColor = TS_ThemeEngine.ColorMode(theme, "MainAccentColor");
                FileHashCompareBtn.FlatAppearance.MouseDownBackColor = TS_ThemeEngine.ColorMode(theme, "MainAccentColor");
                FileHashCompareBtn.ForeColor = TS_ThemeEngine.ColorMode(theme, "DynamicThemeActiveBtnBG");
                FileHashStartBtn.BackColor = TS_ThemeEngine.ColorMode(theme, "MainAccentColor"); 
                FileHashStartBtn.FlatAppearance.BorderColor = TS_ThemeEngine.ColorMode(theme, "MainAccentColor");
                FileHashStartBtn.FlatAppearance.MouseDownBackColor = TS_ThemeEngine.ColorMode(theme, "MainAccentColor");
                FileHashStartBtn.ForeColor = TS_ThemeEngine.ColorMode(theme, "DynamicThemeActiveBtnBG");
                FileHashSelectFilePathTextBox.BackColor = TS_ThemeEngine.ColorMode(theme, "TextBoxBGColor");
                FileHashSelectFilePathTextBox.ForeColor = TS_ThemeEngine.ColorMode(theme, "TextBoxFEColor");
                FileHashUpperHashMode.ForeColor = TS_ThemeEngine.ColorMode(theme, "TextBoxFEColor");
                FileHashTimer.BackColor = TS_ThemeEngine.ColorMode(theme, "LeftMenuButtonHoverAndMouseDownColor");
                FileHashTimer.ForeColor = TS_ThemeEngine.ColorMode(theme, "LeftMenuButtonFEColor");
                FileHashCompareTextBox.BackColor = TS_ThemeEngine.ColorMode(theme, "TextBoxBGColor");
                FileHashCompareTextBox.ForeColor = TS_ThemeEngine.ColorMode(theme, "TextBoxFEColor");
                // TEXT HASH
                TextHashPanel.BackColor = TS_ThemeEngine.ColorMode(theme, "ContentPanelBGColor");
                TextHashAlgorithmSelect.BackColor = TS_ThemeEngine.ColorMode(theme, "MainAccentColor");
                TextHashAlgorithmSelect.ForeColor = TS_ThemeEngine.ColorMode(theme, "DynamicThemeActiveBtnBG");
                TextHashL1.ForeColor = TS_ThemeEngine.ColorMode(theme, "LeftMenuButtonFEColor");
                TextHashL2.ForeColor = TS_ThemeEngine.ColorMode(theme, "LeftMenuButtonFEColor");
                TextHashL3.ForeColor = TS_ThemeEngine.ColorMode(theme, "LeftMenuButtonFEColor");
                TextHashOriginalTextBox.BackColor = TS_ThemeEngine.ColorMode(theme, "TextBoxBGColor");
                TextHashOriginalTextBox.ForeColor = TS_ThemeEngine.ColorMode(theme, "TextBoxFEColor");
                TextHashSaltingMode.ForeColor = TS_ThemeEngine.ColorMode(theme, "TextBoxFEColor");
                TextHashSaltingTextBox.BackColor = TS_ThemeEngine.ColorMode(theme, "TextBoxBGColor");
                TextHashSaltingTextBox.ForeColor = TS_ThemeEngine.ColorMode(theme, "TextBoxFEColor");
                TextHashSaltingLocateMode.BackColor = TS_ThemeEngine.ColorMode(theme, "MainAccentColor");
                TextHashSaltingLocateMode.ForeColor = TS_ThemeEngine.ColorMode(theme, "DynamicThemeActiveBtnBG");
                TextHashResultTextBox.BackColor = TS_ThemeEngine.ColorMode(theme, "TextBoxBGColor");
                TextHashResultTextBox.ForeColor = TS_ThemeEngine.ColorMode(theme, "TextBoxFEColor");
                TextHashResultCopyBtn.BackColor = TS_ThemeEngine.ColorMode(theme, "MainAccentColor");
                TextHashResultCopyBtn.FlatAppearance.BorderColor = TS_ThemeEngine.ColorMode(theme, "MainAccentColor");
                TextHashResultCopyBtn.FlatAppearance.MouseDownBackColor = TS_ThemeEngine.ColorMode(theme, "MainAccentColor");
                TextHashResultCopyBtn.ForeColor = TS_ThemeEngine.ColorMode(theme, "DynamicThemeActiveBtnBG");
                // HASH COMPARE
                HashComparePanel.BackColor = TS_ThemeEngine.ColorMode(theme, "ContentPanelBGColor");
                FirstHashValueLabel.ForeColor = TS_ThemeEngine.ColorMode(theme, "LeftMenuButtonFEColor");
                FirstHashValueTextBox.BackColor = TS_ThemeEngine.ColorMode(theme, "TextBoxBGColor");
                FirstHashValueTextBox.ForeColor = TS_ThemeEngine.ColorMode(theme, "TextBoxFEColor");
                SecondHashValueLabel.ForeColor = TS_ThemeEngine.ColorMode(theme, "LeftMenuButtonFEColor");
                SecondHashValueTextBox.BackColor = TS_ThemeEngine.ColorMode(theme, "TextBoxBGColor");
                SecondHashValueTextBox.ForeColor = TS_ThemeEngine.ColorMode(theme, "TextBoxFEColor");
                // ROTATE MENU
                if (menu_btns == 1){
                    FileHashBtn.BackColor = TS_ThemeEngine.ColorMode(theme, "PageContainerBGAndPageContentTotalColors");
                }else if (menu_btns == 2){
                    TextHashBtn.BackColor = TS_ThemeEngine.ColorMode(theme, "PageContainerBGAndPageContentTotalColors");
                }else if (menu_btns == 3){
                    HashCompareBtn.BackColor = TS_ThemeEngine.ColorMode(theme, "PageContainerBGAndPageContentTotalColors");
                }
                // SAVE CURRENT THEME
                try{
                    TSSettingsSave software_setting_save = new TSSettingsSave(ts_sf);
                    software_setting_save.TSWriteSettings(ts_settings_container, "ThemeStatus", Convert.ToString(ts));
                }catch (Exception){ }
            }catch (Exception){ }
        }
        private void header_image_reloader(int hi_value){
            try{
                if (theme == 1){
                    switch (hi_value){
                        case 1:
                            HeaderImage.Image = Properties.Resources.lm_file_hash_light;
                            break;
                        case 2:
                            HeaderImage.Image = Properties.Resources.lm_text_hash_light;
                            break;
                        case 3:
                            HeaderImage.Image = Properties.Resources.lm_hash_compare_light;
                            break;
                    }
                }else if (theme == 0){
                    switch (hi_value){
                        case 1:
                            HeaderImage.Image = Properties.Resources.lm_file_hash_dark;
                            break;
                        case 2:
                            HeaderImage.Image = Properties.Resources.lm_text_hash_dark;
                            break;
                        case 3:
                            HeaderImage.Image = Properties.Resources.lm_hash_compare_dark;
                            break;
                    }
                }
            }catch (Exception){ }
        }
        // MODULES PAGE DYNAMIC UI
        // ======================================================================================================
        private void software_other_page_preloader(){
            // SOFTWARE ABOUT
            try{
                VimeraAbout software_about = new VimeraAbout();
                string software_about_name = "vimera_about";
                software_about.Name = software_about_name;
                if (Application.OpenForms[software_about_name] != null){
                    software_about = (VimeraAbout)Application.OpenForms[software_about_name];
                    software_about.about_preloader();
                }
            }catch (Exception){ }
        }
        // INITIAL SETINGS
        // ======================================================================================================
        private void select_initial_mode_active(object target_initial_mode){
            ToolStripMenuItem selected_initial_mode = null;
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
                TSSettingsSave software_setting_save = new TSSettingsSave(ts_sf);
                software_setting_save.TSWriteSettings(ts_settings_container, "InitialStatus", get_inital_value);
            }catch (Exception){ }
        }
        // CHECK UPDATE
        // ======================================================================================================
        private void checkForUpdateToolStripMenuItem_Click(object sender, EventArgs e){
            software_update_check(1);
        }
        public bool IsNetworkCheck(){
            Ping ping = new Ping();
            try{
                PingReply reply = ping.Send("www.google.com");
                if (reply.Status == IPStatus.Success){
                    return true;
                }
            }catch (PingException){ }
            return false;
        }
        public void software_update_check(int _check_update_ui){
            string client_version = TS_SoftwareVersion.TS_SofwareVersion(2, ts_version_mode).Trim();
            int client_num_version = Convert.ToInt32(client_version.Replace(".", string.Empty));
            if (IsNetworkCheck() == true){
                string software_version_url = TS_LinkSystem.github_link_lt;
                WebClient webClient = new WebClient();
                try{
                    TSGetLangs software_lang = new TSGetLangs(lang_path);
                    string[] version_content = webClient.DownloadString(software_version_url).Split('=');
                    string last_version = version_content[1].Trim();
                    int last_num_version = Convert.ToInt32(version_content[1].Trim().Replace(".", string.Empty));
                    if (client_num_version < last_num_version){
                        DialogResult info_update = MessageBox.Show(string.Format(Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("SoftwareUpdate", "su_message").Trim())), Application.ProductName, "\n\n", client_version, "\n", last_version, "\n\n"), string.Format(Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("SoftwareUpdate", "su_title").Trim())), Application.ProductName), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (info_update == DialogResult.Yes){
                            Process.Start(TS_LinkSystem.github_link_lr);
                        }
                    }else{
                        if (_check_update_ui == 1){
                            if (client_num_version == last_num_version){
                                MessageBox.Show(string.Format(Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("SoftwareUpdate", "su_no_update").Trim())), Application.ProductName, "\n", client_version), string.Format(Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("SoftwareUpdate", "su_title").Trim())), Application.ProductName), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }catch (WebException){ }
            }else{
                checkForUpdateToolStripMenuItem.Enabled = false;
            }
        }
        // ======================================================================================================
        // VIMERA ABOUT
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e){
            try{
                TSGetLangs software_lang = new TSGetLangs(lang_path);
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
                    MessageBox.Show(string.Format(Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("HeaderHelp", "header_help_info_notification").Trim())), Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("HeaderMenu", "header_menu_about").Trim()))), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }catch (Exception) { }
        }
        // VIMERA EXIT
        // ======================================================================================================
        private void software_exit(){ Application.Exit(); }
        private void Vimera_FormClosing(object sender, FormClosingEventArgs e){ software_exit(); }
    }
}