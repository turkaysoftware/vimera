﻿using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Reflection;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
//
using static Vimera.TSModules;

namespace Vimera {
    public partial class Vimera : Form { 
        public Vimera(){ InitializeComponent(); CheckForIllegalCrossThreadCalls = false; }
        // GLOBAL VARIABLES
        // ======================================================================================================
        public static string lang, lang_path;
        public static int theme;
        // VARIABLES
        // ======================================================================================================
        int menu_btns = 1, menu_rp = 1, initial_status;
        // FILE HASH
        // ======================================================================================================
        int file_hash_algorithm_mode, file_hash_process_end, file_hash_preloader = 0, file_hash_cancel_async = 0;
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
        // HEADER SETTINGS
        // ======================================================================================================
        private class HeaderMenuColors : ToolStripProfessionalRenderer{
            public HeaderMenuColors() : base(new HeaderColors()){ }
            protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e){ e.ArrowColor = header_colors[1]; base.OnRenderArrow(e); }
        }
        private class HeaderColors : ProfessionalColorTable{
            public override Color MenuItemSelected => header_colors[0];
            public override Color ToolStripDropDownBackground => header_colors[0];
            public override Color ImageMarginGradientBegin => header_colors[0];
            public override Color ImageMarginGradientEnd => header_colors[0];
            public override Color ImageMarginGradientMiddle => header_colors[0];
            public override Color MenuItemSelectedGradientBegin => header_colors[0];
            public override Color MenuItemSelectedGradientEnd => header_colors[0];
            public override Color MenuItemPressedGradientBegin => header_colors[0];
            public override Color MenuItemPressedGradientMiddle => header_colors[0];
            public override Color MenuItemPressedGradientEnd => header_colors[0];
            public override Color MenuItemBorder => header_colors[0];
            public override Color CheckBackground => header_colors[0];
            public override Color ButtonSelectedBorder => header_colors[0];
            public override Color CheckSelectedBackground => header_colors[0];
            public override Color CheckPressedBackground => header_colors[0];
            public override Color MenuBorder => header_colors[0];
            public override Color SeparatorLight => header_colors[1];
            public override Color SeparatorDark => header_colors[1];
        }
        // LOAD SOFTWARE SETTINGS
        // ======================================================================================================
        private void RunSoftwareEngine(){
            try{
                TSGetLangs software_lang = new TSGetLangs(lang_path);
                // BUTTONS DPI AWARE SETTINGS
                int btn_dpi_height = FileHashAlgorithmSelect.Height;
                FileHashExportHashsBtn.Height = btn_dpi_height;
                FileHashCompareBtn.Height = btn_dpi_height;
                // HASH ALGORITHM
                string[] hash_algorithm_file = { "MD5", "SHA-1", "SHA-256", "SHA-384", "SHA-512" };
                string[] hash_algorithm_text = { TS_String_Encoder(software_lang.TSReadLangs("FileHashTool", "fht_binary")), "Base64", "RIPEMD-160", "MD5", "SHA-1", "SHA-256", "SHA-384", "SHA-512" };
                // FILE HASH PRELOAD
                // ======================================================================================================
                for (int i = 0; i <= hash_algorithm_file.Length - 1; i++){
                    FileHashAlgorithmSelect.Items.Add(hash_algorithm_file[i]);
                }
                FileHashAlgorithmSelect.SelectedIndex = 0;
                // DVG
                FileHashDGV.Columns.Add("FP", TS_String_Encoder(software_lang.TSReadLangs("FileHashTool", "fht_file_path")));
                FileHashDGV.Columns.Add("FS", TS_String_Encoder(software_lang.TSReadLangs("FileHashTool", "fht_file_size")));
                FileHashDGV.Columns.Add("HV", TS_String_Encoder(software_lang.TSReadLangs("FileHashTool", "fht_hash_value")));
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
                TextHashAlgorithmSelect.SelectedIndex = 1;
                for (int i = 0; i <= 1; i++){
                    TextHashSaltingLocateMode.Items.Add(i);
                }
                TextHashSaltingLocateMode.SelectedIndex = 0;
            }catch (Exception){ }
            // DOUBLE BUFFERS
            // ======================================================================================================
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, FileHashDGV, new object[] { true });
            // THEME - LANG - VIEW MODE PRELOADER
            // ======================================================================================================
            TSSettingsSave software_read_settings = new TSSettingsSave(ts_sf);
            //
            int theme_mode = int.TryParse(TS_String_Encoder(software_read_settings.TSReadSettings(ts_settings_container, "ThemeStatus")), out int the_status) ? the_status : 1;
            theme_engine(theme_mode);
            darkThemeToolStripMenuItem.Checked = theme_mode == 0;
            lightThemeToolStripMenuItem.Checked = theme_mode == 1;
            //
            string lang_mode = TS_String_Encoder(software_read_settings.TSReadSettings(ts_settings_container, "LanguageStatus"));
            var languageFiles = new Dictionary<string, (object langResource, ToolStripMenuItem menuItem, bool fileExists)>{
                { "en", (ts_lang_en, englishToolStripMenuItem, File.Exists(ts_lang_en)) },
                { "tr", (ts_lang_tr, turkishToolStripMenuItem, File.Exists(ts_lang_tr)) },
            };
            foreach (var langLoader in languageFiles) { langLoader.Value.menuItem.Enabled = langLoader.Value.fileExists; }
            var (langResource, selectedMenuItem, _) = languageFiles.ContainsKey(lang_mode) ? languageFiles[lang_mode] : languageFiles["en"];
            lang_engine(Convert.ToString(langResource), lang_mode);
            selectedMenuItem.Checked = true;
            //
            string initial_mode = TS_String_Encoder(software_read_settings.TSReadSettings(ts_settings_container, "InitialStatus"));
            initial_status = int.TryParse(initial_mode, out int ini_status) && (ini_status == 0 || ini_status == 1) ? ini_status : 0;
            WindowState = initial_status == 1 ? FormWindowState.Maximized : FormWindowState.Normal;
            windowedToolStripMenuItem.Checked = initial_status == 0;
            fullScreenToolStripMenuItem.Checked = initial_status == 1;
        }
        // VIMERA LOAD
        // ====================================================================================================== 
        private void Vimera_Load(object sender, EventArgs e){
            Text = TS_SoftwareVersion.TS_SofwareVersion(0, Program.ts_version_mode);
            HeaderMenu.Cursor = Cursors.Hand; 
            RunSoftwareEngine();
            //
            Task softwareUpdateCheck = Task.Run(() => software_update_check(0));
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
                    var select_files = (string[])e.Data.GetData(DataFormats.FileDrop);
                    file_select_clear_function();
                    foreach (var path in select_files){
                        if (Directory.Exists(path)){
                            // Dizin
                            string[] file_list = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
                            var sorted_file_list = file_list.OrderBy(TS_NaturalSortKey).ToArray();
                            foreach (string file in sorted_file_list){
                                file_select_process_function(file);
                            }
                        }else if (File.Exists(path)){
                            // Dosya
                            file_select_process_function(path);
                        }
                    }
                    FileHashRowsTotalSize();
                    FileHashDGV.ClearSelection();
                }catch (Exception){ }
            }
        }
        // FILE HASH SELECT FILE BTN
        // ======================================================================================================
        private void FileHashSelectFileBtn_Click(object sender, EventArgs e){
            try{
                TSGetLangs software_lang = new TSGetLangs(lang_path);
                using (var select_file = new OpenFileDialog()){
                    //
                    string allFilesFilter = TS_String_Encoder(software_lang.TSReadLangs("FileHashTool", "fht_all_files")) + " (*.*)|*.*";
                    select_file.Filter = allFilesFilter;
                    select_file.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    select_file.Title = Application.ProductName + " - " + TS_String_Encoder(software_lang.TSReadLangs("FileHashTool", "fht_file_select_notification"));
                    select_file.Multiselect = true;
                    //
                    if (select_file.ShowDialog() == DialogResult.OK){
                        file_select_clear_function();
                        var sortedFileNames = select_file.FileNames.OrderBy(TS_NaturalSortKey).ToArray();
                        foreach (string file in sortedFileNames){
                            file_select_process_function(file);
                        }
                        FileHashRowsTotalSize();
                        FileHashDGV.ClearSelection();
                    }
                }
            }catch (Exception){ }
        }
        // FILE HASH FILE SELECT PROCESS FUNCTION
        // ======================================================================================================
        private void file_select_process_function(string get_file){
            double file_size = new FileInfo(get_file).Length; // Byte
            FileHashDGV.Rows.Add(get_file, TS_FormatSize(file_size));
        }
        // FILE HASH IMPORTED TOTAL FILE SIZE
        // ======================================================================================================
        private void FileHashRowsTotalSize(){
            try{
                if (FileHashSizer.Visible == false){ FileHashSizer.Visible = true; }
                double file_hash_rows_total_size = 0;
                foreach (DataGridViewRow get_rows in FileHashDGV.Rows){
                    if (get_rows.Cells[1].Value is string fileSizeText && Regex.IsMatch(fileSizeText, @"([\d,.]+)\s?(B|KB|MB|GB|TB|PB|EB|ZB|YB)", RegexOptions.IgnoreCase)){
                        var regex_match = Regex.Match(fileSizeText, @"([\d,.]+)\s?(B|KB|MB|GB|TB|PB|EB|ZB|YB)", RegexOptions.IgnoreCase);
                        string numberPart = regex_match.Groups[1].Value.Replace(",", ".");
                        string unitPart = regex_match.Groups[2].Value;
                        if (double.TryParse(numberPart, NumberStyles.Any, CultureInfo.InvariantCulture, out double size)){
                            file_hash_rows_total_size += TS_FormatSizeToByte(size, unitPart);
                        }
                    }
                }
                FileHashSizer.Text = TS_FormatSize(file_hash_rows_total_size);
            }catch (Exception){ }
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
            if (FileHash_BG_Worker.CancellationPending){
                e.Cancel = true;
                return;
            }
            //
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
            Parallel.ForEach(FileHashDGV.Rows.Cast<DataGridViewRow>().Select((row, index) => new { row, index }), (item, state) =>{
                if (FileHash_BG_Worker.CancellationPending){
                    e.Cancel = true;
                    state.Stop();
                    return;
                }
                try{
                    string file_path = item.row.Cells[0].Value.ToString();
                    byte[] buffer = new byte[buffer_size];
                    long total_bytes_read = 0;
                    //
                    // FileHashSelectFilePathTextBox.Invoke((Action)(() => FileHashSelectFilePathTextBox.Text = file_path));
                    //
                    using (Stream file = File.OpenRead(file_path)){
                        long size = file.Length;
                        HashAlgorithm hasher = GetHashAlgorithm(file_hash_algorithm_mode);
                        if (hasher != null){
                            int bytes_read;
                            do{
                                if (FileHash_BG_Worker.CancellationPending){
                                    e.Cancel = true;
                                    state.Stop();
                                    return;
                                }
                                //
                                bytes_read = file.Read(buffer, 0, buffer_size);
                                total_bytes_read += bytes_read;
                                hasher.TransformBlock(buffer, 0, bytes_read, null, 0);
                                //
                                int progressPercentage = (int)((double)total_bytes_read / size * 100);
                                lock (lockObject){
                                    FileProgressList[item.index] = progressPercentage;
                                }
                            } while (bytes_read > 0);
                            //
                            hasher.TransformFinalBlock(buffer, 0, 0);
                            item.row.Cells[2].Value = HashStringRotate(hasher.Hash);
                        }
                    }
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
            Text = TS_SoftwareVersion.TS_SofwareVersion(0, Program.ts_version_mode) + " - " + "%" + e.ProgressPercentage;
            FileHashLoadFE_Panel.Width = e.ProgressPercentage * FileHashLoadBG_Panel.Width / 100;
        }
        // FILE HASH PROCESS RUNWORKER COMPLETED
        // ======================================================================================================
        private void FileHash_BG_Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e){
            TSGetLangs software_lang = new TSGetLangs(lang_path);
            Text = TS_SoftwareVersion.TS_SofwareVersion(0, Program.ts_version_mode);
            //
            FileProgressList = null;
            FileHashTotalFiles = 0;
            //
            if (file_hash_cancel_async == 1){
                file_hash_disabled_ui_cancel_async();
                MessageBox.Show(TS_String_Encoder(software_lang.TSReadLangs("FileHashTool", "fht_hash_cancel")), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }else{
                file_hash_enabled_ui();
                MessageBox.Show(TS_String_Encoder(software_lang.TSReadLangs("FileHashTool", "fht_hash_success")), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
        // FILE HASH STOP BTN
        // ======================================================================================================
        private void FileHashStopBtn_Click(object sender, EventArgs e){
            try{
                FileHash_BG_Worker.CancelAsync();
                file_hash_cancel_async = 1;
            }catch (Exception){ }
        }
        // FILE HASH DISABLED UI
        // ======================================================================================================
        private void file_hash_disabled_ui(){
            FileHashStopBtn.Enabled = true;
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
            FileHashStopBtn.Enabled = false;
            file_hash_timer_mode = false;
            FileHashAlgorithmSelect.Enabled = true;
            FileHashSelectFileBtn.Enabled = true;
            FileHashUpperHashMode.Visible = true;
            FileHashExportHashsBtn.Visible = true;
            FileHashLoadBG_Panel.Visible = false;
            FileHashCompareTextBox.Visible = true;
            FileHashCompareTextBox.Enabled = true;
            FileHashCompareBtn.Visible = true;
            FileHashPanel.AllowDrop = true;
            try{
                TSGetLangs software_lang = new TSGetLangs(lang_path);
                int rowCount = FileHashDGV.Rows.Count;
                for (int i = 0; i < rowCount; i++){
                    var cellValue = FileHashDGV.Rows[i].Cells[2].Value;
                    if (string.IsNullOrEmpty(cellValue as string)){
                        FileHashDGV.Rows[i].Cells[2].Value = TS_String_Encoder(software_lang.TSReadLangs("FileHashTool", "fht_unreadable"));
                    }
                }
            }catch (Exception ){ }
            if (WindowState == FormWindowState.Minimized){
                WindowState = FormWindowState.Normal;
            }
            file_hash_process_end = 1;
            file_hash_preloader = 1;
        }
        // FILE HASH CANCEL ASYNC FILE HASH DISABLED UI
        // ======================================================================================================
        private void file_hash_disabled_ui_cancel_async(){
            file_hash_cancel_async = 0;
            FileHashStartBtn.Enabled = true;
            FileHashStopBtn.Enabled = false;
            file_hash_timer_mode = false;
            FileHashTimer.Visible = false;
            FileHashAlgorithmSelect.Enabled = true;
            FileHashSelectFileBtn.Enabled = true;
            FileHashLoadBG_Panel.Visible = false;
            FileHashPanel.AllowDrop = true;
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
                        MessageBox.Show(TS_String_Encoder(software_lang.TSReadLangs("FileHashTool", "fht_hash_value_copy_success")), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }catch (Exception){ }
        }
        // FILE HASH COMPARE BTN ENABLED CHECK MODE
        // ======================================================================================================
        private void FileHashCompareTextBox_TextChanged(object sender, EventArgs e){
            if (!string.IsNullOrEmpty(FileHashCompareTextBox.Text)){
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
                        MessageBox.Show(TS_String_Encoder(software_lang.TSReadLangs("FileHashTool", "fht_hash_match")), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }else{
                        MessageBox.Show(TS_String_Encoder(software_lang.TSReadLangs("FileHashTool", "fht_hash_not_match")), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    FileHashDGV.ClearSelection();
                }else{
                    MessageBox.Show(TS_String_Encoder(software_lang.TSReadLangs("FileHashTool", "fht_hash_select_notification")), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                var hashAlgorithms = new Dictionary<int, string>{
                    { 0, "fhpe_document_md5" },
                    { 1, "fhpe_document_sha1" },
                    { 2, "fhpe_document_sha256" },
                    { 3, "fhpe_document_sha384" },
                    { 4, "fhpe_document_sha512" }
                };
                if (hashAlgorithms.TryGetValue(file_hash_algorithm_mode, out var hashAlgorithmKey)){
                    file_hash_current_mode = TS_String_Encoder(software_lang.TSReadLangs("FileHashPrintEngine", hashAlgorithmKey)) + $" (*.{hashAlgorithmKey.Split('_')[2]})|*.{hashAlgorithmKey.Split('_')[2]}";
                }
                //
                for (int i = 0; i < FileHashDGV.Rows.Count; i++){
                    if (!FileHashDGV.Rows[i].IsNewRow){
                        PrintEngineList.Add(FileHashDGV.Rows[i].Cells[2].Value?.ToString().Trim() + "  " + FileHashDGV.Rows[i].Cells[0].Value?.ToString().Trim());
                    }
                }
                //
                SaveFileDialog save_engine = new SaveFileDialog{
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    Title = string.Format(TS_String_Encoder(software_lang.TSReadLangs("FileHashPrintEngine", "fhpe_save_directory_notification")), Application.ProductName),
                    FileName = string.Format(TS_String_Encoder(software_lang.TSReadLangs("FileHashPrintEngine", "fhpe_save_file_name")), Application.ProductName),
                    Filter = file_hash_current_mode + "|" + TS_String_Encoder(software_lang.TSReadLangs("FileHashPrintEngine", "fhpe_document_txt")) + " (*.txt)|*.txt"
                };
                if (save_engine.ShowDialog() == DialogResult.OK){
                    String combinedText = String.Join(Environment.NewLine, PrintEngineList);
                    File.WriteAllText(save_engine.FileName, combinedText);
                    DialogResult vimera_print_engine_query = MessageBox.Show(string.Format(TS_String_Encoder(software_lang.TSReadLangs("FileHashPrintEngine", "fhpe_save_hash_report_success_notification")), Application.ProductName, save_engine.FileName, "\n\n"), Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
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
        private void TextHashPanel_DragEnter(object sender, DragEventArgs e){
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false)){
                e.Effect = DragDropEffects.All;
            }
        }
        private void TextHashPanel_DragDrop(object sender, DragEventArgs e){
            if (e.Data.GetDataPresent(DataFormats.FileDrop)){
                try{
                    TSGetLangs software_lang = new TSGetLangs(lang_path);
                    var selectedFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
                    if (selectedFiles.Length > 1){
                        MessageBox.Show(TS_String_Encoder(software_lang.TSReadLangs("TextHashTool", "tht_one_file_select")), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    //
                    var get_file = selectedFiles.FirstOrDefault();
                    var validExtensions = new[]{ ".txt", ".csv", ".xml", ".json", ".md", ".md5", ".sha1", ".sha256", ".sha384", ".sha512" };
                    //
                    if (get_file != null && File.Exists(get_file)){
                        string fileExtension = Path.GetExtension(get_file).ToLower();
                        if (validExtensions.Contains(fileExtension)){
                            TextHashOriginalTextBox.Text = TS_String_Encoder(File.ReadAllText(get_file));
                        }else{
                            MessageBox.Show(string.Format(TS_String_Encoder(software_lang.TSReadLangs("TextHashTool", "tht_one_file_select_valid")), "\n\n" ,string.Join(", ", validExtensions)), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }catch (Exception){ }
            }
        }
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
                    MessageBox.Show(TS_String_Encoder(software_lang.TSReadLangs("TextHashTool", "tht_hash_copy_notiftication")), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (!string.IsNullOrEmpty(FirstHashValueTextBox.Text)){
                SecondHashValueTextBox.Enabled = true;
                if (!string.IsNullOrEmpty(SecondHashValueTextBox.Text)){
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
            if (!string.IsNullOrEmpty(FirstHashValueTextBox.Text)){
                if (!string.IsNullOrEmpty(SecondHashValueTextBox.Text)){
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
                    HashCompareResultLabel.Text = TS_String_Encoder(software_lang.TSReadLangs("HashCompareTool", "hct_values_match"));
                }else{
                    hash_compare_status = 1;
                    HashCompareResultLabel.BackColor = TS_ThemeEngine.ColorMode(theme, "HashCompareFailed");
                    HashCompareResultLabel.ForeColor = TS_ThemeEngine.ColorMode(theme, "HashCompareResultFE");
                    HashCompareResultLabel.Text = TS_String_Encoder(software_lang.TSReadLangs("HashCompareTool", "hct_values_not_match"));
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
        // ======================================================================================================
        private void MainContent_Selecting(object sender, TabControlCancelEventArgs e){
            try{
                var tabButtons = new Dictionary<int, Button>{
                    { 0, FileHashBtn },
                    { 1, TextHashBtn },
                    { 2, HashCompareBtn }
                };
                if (tabButtons.TryGetValue(MainContent.SelectedIndex, out var button)){
                    if (!e.TabPage.Enabled){
                        e.Cancel = true;
                    }else{
                        button.PerformClick();
                    }
                }
            }catch (Exception) { }
        }
        // VIMERA DYNAMIC LEFT MENU PRELOADER
        // ======================================================================================================
        private void left_menu_preloader(int target_menu, object sender){
            try{
                TSGetLangs software_lang = new TSGetLangs(lang_path);
                var menuTargets = new Dictionary<int, (TabPage tab, Button button, string headerKey)>{
                    { 1, (FileHash, FileHashBtn, "header_file_hash") },
                    { 2, (TextHash, TextHashBtn, "header_text_hash") },
                    { 3, (HashCompare, HashCompareBtn, "header_hash_compare") }
                };
                if (menu_btns != target_menu && menuTargets.TryGetValue(target_menu, out var target)){
                    MainContent.SelectedTab = target.tab;
                    if (!btn_colors_active.Contains(target.button.BackColor)){
                        active_page(sender);
                    }
                    HeaderText.Text = TS_String_Encoder(software_lang.TSReadLangs("Header", target.headerKey));
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
            if (lang != "en"){ lang_preload(ts_lang_en, "en"); select_lang_active(sender); }
        }
        private void turkishToolStripMenuItem_Click(object sender, EventArgs e){
            if (lang != "tr"){ lang_preload(ts_lang_tr, "tr"); select_lang_active(sender); }
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
            DialogResult lang_change_message = MessageBox.Show(string.Format(TS_String_Encoder(software_lang.TSReadLangs("LangChange", "lang_change_notification")), "\n\n", "\n\n"), Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (lang_change_message == DialogResult.Yes){ Application.Restart(); }
        }
        private void lang_engine(string lang_type, string lang_code){
            try{
                lang_path = lang_type;
                lang = lang_code;
                // GLOBAL ENGINE
                TSGetLangs software_lang = new TSGetLangs(lang_path);
                var headers = new Dictionary<int, string>{
                    { 1, "header_file_hash" },
                    { 2, "header_text_hash" },
                    { 3, "header_hash_compare" }
                };
                if (headers.TryGetValue(menu_rp, out var headerKey)){
                    HeaderText.Text = TS_String_Encoder(software_lang.TSReadLangs("Header", headerKey));
                }
                // SETTINGS
                settingsToolStripMenuItem.Text = TS_String_Encoder(software_lang.TSReadLangs("HeaderMenu", "header_menu_settings"));
                // THEMES
                themeToolStripMenuItem.Text = TS_String_Encoder(software_lang.TSReadLangs("HeaderMenu", "header_menu_theme"));
                lightThemeToolStripMenuItem.Text = TS_String_Encoder(software_lang.TSReadLangs("HeaderThemes", "theme_light"));
                darkThemeToolStripMenuItem.Text = TS_String_Encoder(software_lang.TSReadLangs("HeaderThemes", "theme_dark"));
                // LANGS
                languageToolStripMenuItem.Text = TS_String_Encoder(software_lang.TSReadLangs("HeaderMenu", "header_menu_language"));
                englishToolStripMenuItem.Text = TS_String_Encoder(software_lang.TSReadLangs("HeaderLangs", "lang_en"));
                turkishToolStripMenuItem.Text = TS_String_Encoder(software_lang.TSReadLangs("HeaderLangs", "lang_tr"));
                // INITIAL VIEW
                initialViewToolStripMenuItem.Text = TS_String_Encoder(software_lang.TSReadLangs("HeaderMenu", "header_menu_start"));
                windowedToolStripMenuItem.Text = TS_String_Encoder(software_lang.TSReadLangs("HeaderViewMode", "header_viev_mode_windowed"));
                fullScreenToolStripMenuItem.Text = TS_String_Encoder(software_lang.TSReadLangs("HeaderViewMode", "header_viev_mode_full_screen"));
                // UPDATE
                checkForUpdateToolStripMenuItem.Text = TS_String_Encoder(software_lang.TSReadLangs("HeaderMenu", "header_menu_update"));
                // ABOUT
                aboutToolStripMenuItem.Text = TS_String_Encoder(software_lang.TSReadLangs("HeaderMenu", "header_menu_about"));
                // MENU
                FileHashBtn.Text = " " + " " + TS_String_Encoder(software_lang.TSReadLangs("LeftMenu", "left_file_hash"));
                TextHashBtn.Text = " " + " " + TS_String_Encoder(software_lang.TSReadLangs("LeftMenu", "left_text_hash"));
                HashCompareBtn.Text = " " + " " + TS_String_Encoder(software_lang.TSReadLangs("LeftMenu", "left_hash_compare"));
                // FILE HASH
                FileHashSelectFileBtn.Text = TS_String_Encoder(software_lang.TSReadLangs("FileHashTool", "fht_select"));
                FileHashDGV.Columns[0].HeaderText = TS_String_Encoder(software_lang.TSReadLangs("FileHashTool", "fht_file_path"));
                FileHashDGV.Columns[1].HeaderText = TS_String_Encoder(software_lang.TSReadLangs("FileHashTool", "fht_file_size"));
                FileHashDGV.Columns[2].HeaderText = TS_String_Encoder(software_lang.TSReadLangs("FileHashTool", "fht_hash_value"));
                FileHashUpperHashMode.Text = TS_String_Encoder(software_lang.TSReadLangs("FileHashTool", "fht_hash_uppercase"));
                FileHashExportHashsBtn.Text = TS_String_Encoder(software_lang.TSReadLangs("FileHashTool", "fht_export_hashs"));
                FileHashCompareBtn.Text = TS_String_Encoder(software_lang.TSReadLangs("FileHashTool", "fht_compare"));
                FileHashStartBtn.Text = TS_String_Encoder(software_lang.TSReadLangs("FileHashTool", "fht_start"));
                FileHashStopBtn.Text = TS_String_Encoder(software_lang.TSReadLangs("FileHashTool", "fht_stop"));
                // TEXT HASH
                TextHashAlgorithmSelect.Items[0] = TS_String_Encoder(software_lang.TSReadLangs("TextHashTool", "tht_binary"));
                TextHashL1.Text = TS_String_Encoder(software_lang.TSReadLangs("TextHashTool", "tht_original_value_input"));
                TextHashL2.Text = TS_String_Encoder(software_lang.TSReadLangs("TextHashTool", "tht_salting_value_input"));
                TextHashL3.Text = TS_String_Encoder(software_lang.TSReadLangs("TextHashTool", "tht_creating_hash_value"));
                TextHashSaltingMode.Text = TS_String_Encoder(software_lang.TSReadLangs("TextHashTool", "tht_salting_mode"));
                TextHashSaltingLocateMode.Items[0] = TS_String_Encoder(software_lang.TSReadLangs("TextHashTool", "tht_add_at_the_beginning"));
                TextHashSaltingLocateMode.Items[1] = TS_String_Encoder(software_lang.TSReadLangs("TextHashTool", "tht_add_to_end"));
                TextHashResultCopyBtn.Text = TS_String_Encoder(software_lang.TSReadLangs("TextHashTool", "tht_copy"));
                // HASH COMPARE
                FirstHashValueLabel.Text = TS_String_Encoder(software_lang.TSReadLangs("HashCompareTool", "hct_first_hash_value_input"));
                SecondHashValueLabel.Text = TS_String_Encoder(software_lang.TSReadLangs("HashCompareTool", "hct_secondary_hash_value_input"));
                if (hash_compare_status == 0){
                    HashCompareResultLabel.Text = TS_String_Encoder(software_lang.TSReadLangs("HashCompareTool", "hct_values_match"));
                }else if (hash_compare_status == 1){
                    HashCompareResultLabel.Text = TS_String_Encoder(software_lang.TSReadLangs("HashCompareTool", "hct_values_not_match"));
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
                int set_attribute = theme == 1 ? 20 : 19;
                if (DwmSetWindowAttribute(Handle, set_attribute, new[] { 1 }, 4) != theme){
                    DwmSetWindowAttribute(Handle, 20, new[] { theme == 1 ? 0 : 1 }, 4);
                }
                if (theme == 1){
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
                FileHashSelectFileBtn.FlatAppearance.MouseOverBackColor = TS_ThemeEngine.ColorMode(theme, "MainAccentColorHover");
                FileHashSelectFileBtn.ForeColor = TS_ThemeEngine.ColorMode(theme, "DynamicThemeActiveBtnBG");
                FileHashUpperHashMode.BackColor = TS_ThemeEngine.ColorMode(theme, "TextBoxBGColor");
                FileHashUpperHashMode.ForeColor = TS_ThemeEngine.ColorMode(theme, "TextBoxFEColor");
                FileHashExportHashsBtn.BackColor = TS_ThemeEngine.ColorMode(theme, "MainAccentColor");
                FileHashExportHashsBtn.FlatAppearance.BorderColor = TS_ThemeEngine.ColorMode(theme, "MainAccentColor");
                FileHashExportHashsBtn.FlatAppearance.MouseDownBackColor = TS_ThemeEngine.ColorMode(theme, "MainAccentColor");
                FileHashExportHashsBtn.FlatAppearance.MouseOverBackColor = TS_ThemeEngine.ColorMode(theme, "MainAccentColorHover");
                FileHashExportHashsBtn.ForeColor = TS_ThemeEngine.ColorMode(theme, "DynamicThemeActiveBtnBG");
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
                FileHashCompareBtn.BackColor = TS_ThemeEngine.ColorMode(theme, "MainAccentColor");
                FileHashCompareBtn.FlatAppearance.BorderColor = TS_ThemeEngine.ColorMode(theme, "MainAccentColor");
                FileHashCompareBtn.FlatAppearance.MouseDownBackColor = TS_ThemeEngine.ColorMode(theme, "MainAccentColor");
                FileHashCompareBtn.FlatAppearance.MouseOverBackColor = TS_ThemeEngine.ColorMode(theme, "MainAccentColorHover");
                FileHashCompareBtn.ForeColor = TS_ThemeEngine.ColorMode(theme, "DynamicThemeActiveBtnBG");
                FileHashStartBtn.BackColor = TS_ThemeEngine.ColorMode(theme, "MainAccentColor"); 
                FileHashStartBtn.FlatAppearance.BorderColor = TS_ThemeEngine.ColorMode(theme, "MainAccentColor");
                FileHashStartBtn.FlatAppearance.MouseDownBackColor = TS_ThemeEngine.ColorMode(theme, "MainAccentColor");
                FileHashStartBtn.FlatAppearance.MouseOverBackColor = TS_ThemeEngine.ColorMode(theme, "MainAccentColorHover");
                FileHashStartBtn.ForeColor = TS_ThemeEngine.ColorMode(theme, "DynamicThemeActiveBtnBG");
                FileHashStopBtn.BackColor = TS_ThemeEngine.ColorMode(theme, "MainAccentColor");
                FileHashStopBtn.FlatAppearance.BorderColor = TS_ThemeEngine.ColorMode(theme, "MainAccentColor");
                FileHashStopBtn.FlatAppearance.MouseDownBackColor = TS_ThemeEngine.ColorMode(theme, "MainAccentColor");
                FileHashStopBtn.FlatAppearance.MouseOverBackColor = TS_ThemeEngine.ColorMode(theme, "MainAccentColorHover");
                FileHashStopBtn.ForeColor = TS_ThemeEngine.ColorMode(theme, "DynamicThemeActiveBtnBG");
                FileHashSizer.BackColor = TS_ThemeEngine.ColorMode(theme, "LeftMenuButtonHoverAndMouseDownColor");
                FileHashSizer.ForeColor = TS_ThemeEngine.ColorMode(theme, "LeftMenuButtonFEColor");
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
                TextHashResultCopyBtn.FlatAppearance.MouseOverBackColor = TS_ThemeEngine.ColorMode(theme, "MainAccentColorHover");
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
                var buttonMapping = new Dictionary<int, Button>{
                    { 1, FileHashBtn },
                    { 2, TextHashBtn },
                    { 3, HashCompareBtn }
                };
                if (buttonMapping.TryGetValue(menu_btns, out var button)){
                    button.BackColor = TS_ThemeEngine.ColorMode(theme, "PageContainerBGAndPageContentTotalColors");
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
                var images = new Dictionary<(int theme, int value), Image>{
                    { (1, 1), Properties.Resources.lm_file_hash_light },
                    { (1, 2), Properties.Resources.lm_text_hash_light },
                    { (1, 3), Properties.Resources.lm_hash_compare_light },
                    { (0, 1), Properties.Resources.lm_file_hash_dark },
                    { (0, 2), Properties.Resources.lm_text_hash_dark },
                    { (0, 3), Properties.Resources.lm_hash_compare_dark }
                };
                if (images.TryGetValue((theme, hi_value), out var image)){
                    HeaderImage.Image = image;
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
            if (!IsNetworkCheck()){
                return;
            }
            using (WebClient webClient = new WebClient()){
                try{
                    TSGetLangs software_lang = new TSGetLangs(lang_path);
                    //
                    string client_version = TS_SoftwareVersion.TS_SofwareVersion(2, Program.ts_version_mode).Trim();
                    int client_num_version = Convert.ToInt32(client_version.Replace(".", string.Empty));
                    //
                    string[] version_content = webClient.DownloadString(TS_LinkSystem.github_link_lt).Split('=');
                    string last_version = version_content[1].Trim();
                    int last_num_version = Convert.ToInt32(last_version.Replace(".", string.Empty));
                    //
                    if (client_num_version < last_num_version){
                        // Update available
                        string message = string.Format(TS_String_Encoder(software_lang.TSReadLangs("SoftwareUpdate", "su_message")), Application.ProductName, "\n\n", client_version, "\n", last_version, "\n\n");
                        DialogResult info_update = MessageBox.Show(message, string.Format(TS_String_Encoder(software_lang.TSReadLangs("SoftwareUpdate", "su_title")), Application.ProductName), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (info_update == DialogResult.Yes){
                            Process.Start(TS_LinkSystem.github_link_lr);
                        }
                    }else if (_check_update_ui == 1 && client_num_version == last_num_version){
                        // No update available
                        MessageBox.Show(string.Format(TS_String_Encoder(software_lang.TSReadLangs("SoftwareUpdate", "su_no_update")), Application.ProductName, "\n", client_version), string.Format(TS_String_Encoder(software_lang.TSReadLangs("SoftwareUpdate", "su_title")), Application.ProductName), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }catch (WebException){ }
            }
        }
        // VIMERA ABOUT
        // ======================================================================================================
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
                    MessageBox.Show(string.Format(TS_String_Encoder(software_lang.TSReadLangs("HeaderHelp", "header_help_info_notification")), TS_String_Encoder(software_lang.TSReadLangs("HeaderMenu", "header_menu_about"))), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }catch (Exception){ }
        }
        // VIMERA EXIT
        // ======================================================================================================
        private void software_exit(){ Application.Exit(); }
        private void Vimera_FormClosing(object sender, FormClosingEventArgs e){ software_exit(); }
    }
}