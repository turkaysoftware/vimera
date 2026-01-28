// ======================================================================================================
// Vimera - Hash Analysis Software
// © Copyright 2023-2026, Eray Türkay.
// Project Type: Open Source
// License: MIT License
// Website: https://www.turkaysoftware.com/vimera
// GitHub: https://github.com/turkaysoftware/vimera
// ======================================================================================================

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Vimera.TSCrcChecksumModule;
// TS MODULES
using static Vimera.TSModules;

namespace Vimera {
    public partial class VimeraMain : Form {
        public VimeraMain(){
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            // LANGUAGE SET TAGS
            // ==================
            arabicToolStripMenuItem.Tag = "ar";
            chineseToolStripMenuItem.Tag = "zh";
            englishToolStripMenuItem.Tag = "en";
            dutchToolStripMenuItem.Tag = "nl";
            frenchToolStripMenuItem.Tag = "fr";
            germanToolStripMenuItem.Tag = "de";
            hindiToolStripMenuItem.Tag = "hi";
            italianToolStripMenuItem.Tag = "it";
            japaneseToolStripMenuItem.Tag = "ja";
            koreanToolStripMenuItem.Tag = "ko";
            polishToolStripMenuItem.Tag = "pl";
            portugueseToolStripMenuItem.Tag = "pt";
            russianToolStripMenuItem.Tag = "ru";
            spanishToolStripMenuItem.Tag = "es";
            turkishToolStripMenuItem.Tag = "tr";
            // LANGUAGE SET EVENTS
            // ==================
            arabicToolStripMenuItem.Click += LanguageToolStripMenuItem_Click;
            chineseToolStripMenuItem.Click += LanguageToolStripMenuItem_Click;
            englishToolStripMenuItem.Click += LanguageToolStripMenuItem_Click;
            dutchToolStripMenuItem.Click += LanguageToolStripMenuItem_Click;
            frenchToolStripMenuItem.Click += LanguageToolStripMenuItem_Click;
            germanToolStripMenuItem.Click += LanguageToolStripMenuItem_Click;
            hindiToolStripMenuItem.Click += LanguageToolStripMenuItem_Click;
            italianToolStripMenuItem.Click += LanguageToolStripMenuItem_Click;
            japaneseToolStripMenuItem.Click += LanguageToolStripMenuItem_Click;
            koreanToolStripMenuItem.Click += LanguageToolStripMenuItem_Click;
            polishToolStripMenuItem.Click += LanguageToolStripMenuItem_Click;
            portugueseToolStripMenuItem.Click += LanguageToolStripMenuItem_Click;
            russianToolStripMenuItem.Click += LanguageToolStripMenuItem_Click;
            spanishToolStripMenuItem.Click += LanguageToolStripMenuItem_Click;
            turkishToolStripMenuItem.Click += LanguageToolStripMenuItem_Click;
            //
            SystemEvents.UserPreferenceChanged += (s, e) => TSUseSystemTheme();
        }
        // GLOBAL VARIABLES
        // ======================================================================================================
        public static string lang, lang_path;
        public static int theme, themeSystem;
        // VARIABLES
        // ======================================================================================================
        int menu_btns = 1, menu_rp = 1, startup_status;
        readonly string ts_wizard_name = "TS Wizard";
        // HASH ALGORITHMS
        // ======================================================================================================
        private readonly string[] hash_algorithms = { "Binary", "Base64", "CRC-32", "CRC-64", "RIPEMD-160", "MD5", "SHA-1", "SHA-256", "SHA-384", "SHA-512" };
        private readonly HashSet<string> checksumExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase){ ".crc32", ".crc64", ".md5", ".sha1", ".sha256", ".sha384", ".sha512" };
        private readonly HashSet<string> validExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { ".txt", ".csv", ".xml", ".json", ".md", ".crc32", ".crc64", ".md5", ".sha1", ".sha256", ".sha384", ".sha512" };
        // FILE HASH
        // ======================================================================================================
        int file_hash_algorithm_mode, file_hash_process_end, file_hash_preloader = 0, file_hash_cancel_async = 0;
        bool file_hash_timer_mode;
        // ======================================================================================================
        // COLOR MODES / Index Mode | 0 = Dark - 1 = Light
        readonly List<Color> btn_colors_active = new List<Color>(){ Color.Transparent };
        static readonly List<Color> header_colors = new List<Color>(){ Color.Transparent, Color.Transparent, Color.Transparent };
        // HEADER SETTINGS
        // ======================================================================================================
        private class HeaderMenuColors : ToolStripProfessionalRenderer{
            public HeaderMenuColors() : base(new HeaderColors()){ }
            protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e){ e.ArrowColor = header_colors[1]; base.OnRenderArrow(e); }
            protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e){
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                float dpiScale = g.DpiX / 96f;
                Rectangle rect = e.ImageRectangle;
                using (Pen anti_alias_pen = new Pen(header_colors[2], 2.2f * dpiScale)){
                    anti_alias_pen.StartCap = LineCap.Round;
                    anti_alias_pen.EndCap = LineCap.Round;
                    anti_alias_pen.LineJoin = LineJoin.Round;
                    PointF p1 = new PointF(rect.Left + rect.Width * 0.18f, rect.Top + rect.Height * 0.52f);
                    PointF p2 = new PointF(rect.Left + rect.Width * 0.38f, rect.Top + rect.Height * 0.72f);
                    PointF p3 = new PointF(rect.Left + rect.Width * 0.78f, rect.Top + rect.Height * 0.28f);
                    g.DrawLines(anti_alias_pen, new[] { p1, p2, p3 });
                }
            }
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
        // UI DPI CHANGER
        // ======================================================================================================
        private int TSDPIChanger(int size){
            return (int)(size * this.DeviceDpi / 96f);
        }
        // LOAD SOFTWARE SETTINGS
        // ======================================================================================================
        private void RunSoftwareEngine(){
            try{
                if (this.DeviceDpi / 96f >= 1.25){
                    HeaderPanel.Padding = new Padding(TSDPIChanger(4), 0, 0, 0);
                    FileHash.Padding = new Padding(TSDPIChanger(8), TSDPIChanger(8), TSDPIChanger(8), TSDPIChanger(8));
                    TextHash.Padding = new Padding(TSDPIChanger(8), TSDPIChanger(8), TSDPIChanger(8), TSDPIChanger(8));
                    HashCompare.Padding = new Padding(TSDPIChanger(8), TSDPIChanger(8), TSDPIChanger(8), TSDPIChanger(8));
                }
                // PAGE ARROW BYPASS
                MainContent.SelectedTab = TextHash;
                MainContent.SelectedTab = FileHash;
                // BUTTONS DPI AWARE SETTINGS
                int btn_dpi_height = FileHashAlgorithmSelect.Height + 2;
                FileHashExportHashsBtn.Height = btn_dpi_height;
                FileHashCompareBtn.Height = btn_dpi_height;
                // FILE HASH PRELOAD
                // ======================================================================================================
                for (int i = 2; i <= hash_algorithms.Length - 1; i++){
                    if (i != 4){
                        FileHashAlgorithmSelect.Items.Add(hash_algorithms[i]);
                    }
                }
                FileHashAlgorithmSelect.SelectedIndex = 3;
                // DVG
                FileHashDGV.Columns.Add("FileHash", "FileHash");
                FileHashDGV.Columns.Add("TextHash", "TextHash");
                FileHashDGV.Columns.Add("HashCompare", "HashCompare");
                FileHashDGV.RowTemplate.Height = (int)(26 * this.DeviceDpi / 96f);
                FileHashDGV.Columns[0].Width = (int)(250 * this.DeviceDpi / 96f);
                FileHashDGV.Columns[1].Width = (int)(100 * this.DeviceDpi / 96f);
                foreach (DataGridViewColumn columnPadding in FileHashDGV.Columns){
                    int scaledPadding = (int)(3 * this.DeviceDpi / 96f);
                    columnPadding.DefaultCellStyle.Padding = new Padding(scaledPadding, 0, 0, 0);
                }
                foreach (DataGridViewColumn OSD_Column in FileHashDGV.Columns){
                    OSD_Column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                FileHashDGV.ClearSelection();
                // TEXT HASH PRELOAD
                // ======================================================================================================
                for (int i = 0; i <= hash_algorithms.Length - 1; i++){
                    TextHashAlgorithmSelect.Items.Add(hash_algorithms[i]);
                }
                TextHashAlgorithmSelect.SelectedIndex = 6;
                for (int i = 0; i <= 2; i++){
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
            int theme_mode = int.TryParse(software_read_settings.TSReadSettings(ts_settings_container, "ThemeStatus"), out int the_status) && (the_status == 0 || the_status == 1 || the_status == 2) ? the_status : 1;
            if (theme_mode == 2) { themeSystem = 2; Theme_engine(GetSystemTheme(2)); } else Theme_engine(theme_mode);
            darkThemeToolStripMenuItem.Checked = theme_mode == 0;
            lightThemeToolStripMenuItem.Checked = theme_mode == 1;
            systemThemeToolStripMenuItem.Checked = theme_mode == 2;
            //
            string lang_mode = software_read_settings.TSReadSettings(ts_settings_container, "LanguageStatus");
            var languageFiles = new Dictionary<string, (object langResource, ToolStripMenuItem menuItem, bool fileExists)>{
                { "ar", (ts_lang_ar, arabicToolStripMenuItem, File.Exists(ts_lang_ar)) },
                { "zh", (ts_lang_zh, chineseToolStripMenuItem, File.Exists(ts_lang_zh)) },
                { "en", (ts_lang_en, englishToolStripMenuItem, File.Exists(ts_lang_en)) },
                { "nl", (ts_lang_nl, dutchToolStripMenuItem, File.Exists(ts_lang_nl)) },
                { "fr", (ts_lang_fr, frenchToolStripMenuItem, File.Exists(ts_lang_fr)) },
                { "de", (ts_lang_de, germanToolStripMenuItem, File.Exists(ts_lang_de)) },
                { "hi", (ts_lang_hi, hindiToolStripMenuItem, File.Exists(ts_lang_hi)) },
                { "it", (ts_lang_it, italianToolStripMenuItem, File.Exists(ts_lang_it)) },
                { "ja", (ts_lang_ja, japaneseToolStripMenuItem, File.Exists(ts_lang_ja)) },
                { "ko", (ts_lang_ko, koreanToolStripMenuItem, File.Exists(ts_lang_ko)) },
                { "pl", (ts_lang_pl, polishToolStripMenuItem, File.Exists(ts_lang_pl)) },
                { "pt", (ts_lang_pt, portugueseToolStripMenuItem, File.Exists(ts_lang_pt)) },
                { "ru", (ts_lang_ru, russianToolStripMenuItem, File.Exists(ts_lang_ru)) },
                { "es", (ts_lang_es, spanishToolStripMenuItem, File.Exists(ts_lang_es)) },
                { "tr", (ts_lang_tr, turkishToolStripMenuItem, File.Exists(ts_lang_tr)) },
            };
            foreach (var langLoader in languageFiles) { langLoader.Value.menuItem.Enabled = langLoader.Value.fileExists; }
            var (langResource, selectedMenuItem, _) = languageFiles.ContainsKey(lang_mode) ? languageFiles[lang_mode] : languageFiles["en"];
            Lang_engine(Convert.ToString(langResource), lang_mode);
            selectedMenuItem.Checked = true;
            //
            string startup_mode = software_read_settings.TSReadSettings(ts_settings_container, "StartupStatus");
            startup_status = int.TryParse(startup_mode, out int str_status) && (str_status == 0 || str_status == 1) ? str_status : 0;
            WindowState = startup_status == 1 ? FormWindowState.Maximized : FormWindowState.Normal;
            windowedToolStripMenuItem.Checked = startup_status == 0;
            fullScreenToolStripMenuItem.Checked = startup_status == 1;
        }
        // LOAD
        // ====================================================================================================== 
        private void Vimera_Load(object sender, EventArgs e){
            Text = TS_VersionEngine.TS_SofwareVersion(0);
            HeaderMenu.Cursor = Cursors.Hand;
            RunSoftwareEngine();
            //
            Task softwareUpdateCheck = Task.Run(() => Software_update_check(0));
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
                    File_select_clear_function();
                    foreach (var path in select_files){
                        if (Directory.Exists(path)){
                            string[] file_list = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
                            var sorted_file_list = file_list.OrderBy(file => TSNaturalSortKey(file, CultureInfo.CurrentCulture)).ToArray();
                            foreach (string file in sorted_file_list){
                                string ext = Path.GetExtension(file);
                                if (checksumExtensions.Contains(ext)){
                                    ChecksumFileImport(file);
                                }else{
                                    File_select_process_function(file);
                                }
                            }
                        }else if (File.Exists(path)){
                            string ext = Path.GetExtension(path);
                            if (checksumExtensions.Contains(ext)){
                                ChecksumFileImport(path);
                            }else{
                                File_select_process_function(path);
                            }
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
                    string allFilesFilter = software_lang.TSReadLangs("FileHashTool", "fht_all_files") + " (*.*)|*.*";
                    select_file.Filter = allFilesFilter;
                    select_file.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    select_file.Title = Application.ProductName + " - " + software_lang.TSReadLangs("FileHashTool", "fht_file_select_notification");
                    select_file.Multiselect = true;
                    if (select_file.ShowDialog() == DialogResult.OK){
                        File_select_clear_function();
                        var sortedFileNames = select_file.FileNames.OrderBy(name => TSNaturalSortKey(name, CultureInfo.CurrentCulture)).ToArray();
                        foreach (string file in sortedFileNames){
                            string ext = Path.GetExtension(file);
                            if (checksumExtensions.Contains(ext)){
                                ChecksumFileImport(file);
                            }else{
                                File_select_process_function(file);
                            }
                        }
                        FileHashRowsTotalSize();
                        FileHashDGV.ClearSelection();
                    }
                }
            }catch (Exception){ }
        }
        // FILE HASH FILE SELECT PROCESS FUNCTION
        // ======================================================================================================
        private void File_select_process_function(string get_file){
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
        // CHECKSUM FILE IMPORTS
        // ======================================================================================================
        private void ChecksumFileImport(string filePath){
            try{
                foreach (var line in File.ReadLines(filePath)){
                    if (string.IsNullOrWhiteSpace(line))
                        continue;
                    var parts = line.Split(new char[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length < 2)
                        continue;
                    string file = parts[1].Trim();
                    if (File.Exists(file)){
                        File_select_process_function(file);
                    }
                }
            }catch (Exception){ }
        }
        // FILE HASH FILE SELECT CLEAR FUNCTION
        // ======================================================================================================
        private void File_select_clear_function(){
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
            //
            Task file_hash_timers = new Task(File_hash_timer);
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
            var fileRows = FileHashDGV.Rows.Cast<DataGridViewRow>().Select((row, index) => new { Index = index, FilePath = row.Cells[0].Value?.ToString(), Row = row }).Where(x => !string.IsNullOrEmpty(x.FilePath)).ToList();
            Parallel.ForEach(fileRows, (item, state) => {
                if (FileHash_BG_Worker.CancellationPending){
                    e.Cancel = true;
                    state.Stop();
                    return;
                }
                try{
                    byte[] buffer = new byte[buffer_size];
                    long total_bytes_read = 0;
                    using (Stream file = File.OpenRead(item.FilePath))
                    using (HashAlgorithm hasher = GetHashAlgorithm(file_hash_algorithm_mode)){
                        if (hasher == null)
                            return;

                        long size = file.Length;
                        int bytes_read;

                        do{
                            if (FileHash_BG_Worker.CancellationPending){
                                e.Cancel = true;
                                state.Stop();
                                return;
                            }

                            bytes_read = file.Read(buffer, 0, buffer_size);
                            total_bytes_read += bytes_read;
                            hasher.TransformBlock(buffer, 0, bytes_read, null, 0);
                            int progressPercentage = (int)((double)total_bytes_read / size * 100);
                            lock (lockObject){
                                FileProgressList[item.Index] = progressPercentage;
                            }
                        } while (bytes_read > 0);
                        hasher.TransformFinalBlock(buffer, 0, 0);
                        //
                        if (item.Row.DataGridView.InvokeRequired){
                            item.Row.DataGridView.Invoke((MethodInvoker)(() => {
                                item.Row.Cells[2].Value = HashStringRotate(hasher.Hash);
                            }));
                        }else{
                            item.Row.Cells[2].Value = HashStringRotate(hasher.Hash);
                        }
                    }
                    //
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
                case 0: return new TSCrc32();
                case 1: return new TSCrc64();
                case 2: return MD5.Create();
                case 3: return SHA1.Create();
                case 4: return SHA256.Create();
                case 5: return SHA384.Create();
                case 6: return SHA512.Create();
                default: return null;
            }
        }
        // FILE HASH PROCESS CHANGED
        // ======================================================================================================
        private void FileHash_BG_Worker_ProgressChanged(object sender, ProgressChangedEventArgs e){
            Text = TS_VersionEngine.TS_SofwareVersion(0) + " - " + "%" + e.ProgressPercentage;
            FileHashLoadFE_Panel.Width = e.ProgressPercentage * FileHashLoadBG_Panel.Width / 100;
        }
        // FILE HASH PROCESS RUNWORKER COMPLETED
        // ======================================================================================================
        private void FileHash_BG_Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e){
            TSGetLangs software_lang = new TSGetLangs(lang_path);
            Text = TS_VersionEngine.TS_SofwareVersion(0);
            //
            FileProgressList = null;
            FileHashTotalFiles = 0;
            //
            if (file_hash_cancel_async == 1){
                File_hash_disabled_ui_cancel_async();
                TS_MessageBoxEngine.TS_MessageBox(this, 1, software_lang.TSReadLangs("FileHashTool", "fht_hash_cancel"));
            }else{
                File_hash_enabled_ui();
                TS_MessageBoxEngine.TS_MessageBox(this, 1, software_lang.TSReadLangs("FileHashTool", "fht_hash_success"));
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
                File_hash_disabled_ui();
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
        private void File_hash_disabled_ui(){
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
        private void File_hash_enabled_ui(){
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
                        FileHashDGV.Rows[i].Cells[2].Value = software_lang.TSReadLangs("FileHashTool", "fht_unreadable");
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
        private void File_hash_disabled_ui_cancel_async(){
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
                        TS_MessageBoxEngine.TS_MessageBox(this, 1, software_lang.TSReadLangs("FileHashTool", "fht_hash_value_copy_success"));
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
                        TS_MessageBoxEngine.TS_MessageBox(this, 1, software_lang.TSReadLangs("FileHashTool", "fht_hash_match"));
                    }else{
                        TS_MessageBoxEngine.TS_MessageBox(this, 3, software_lang.TSReadLangs("FileHashTool", "fht_hash_not_match"));
                    }
                    FileHashDGV.ClearSelection();
                }else{
                    TS_MessageBoxEngine.TS_MessageBox(this, 2, software_lang.TSReadLangs("FileHashTool", "fht_hash_select_notification"));
                }
            }catch (Exception){ }
        }
        // FILE HASH TIMER
        // ======================================================================================================
        private void File_hash_timer(){
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            //
            try{
                while (file_hash_timer_mode){
                    TimeSpan elapsed = stopwatch.Elapsed;
                    //
                    int fh_second = (int)elapsed.TotalSeconds % 60;
                    int fh_minute = (int)(elapsed.TotalMinutes % 60);
                    int fh_hour = (int)(elapsed.TotalHours);
                    FileHashTimer.Text = string.Format("{0:D2}:{1:D2}:{2:D2}", fh_hour, fh_minute, fh_second);
                    Thread.Sleep(1000);
                }
            }catch (Exception){ }
        }
        // FILE HASH EXPORT HASH DATA
        // ======================================================================================================
        readonly List<string> PrintEngineList = new List<string>();
        private void FileHashExportHashsBtn_Click(object sender, EventArgs e){
            try{
                TSGetLangs software_lang = new TSGetLangs(lang_path);
                string file_hash_current_mode = "";
                var hashAlgorithms = new Dictionary<int, string>{
                    { 0, "fhpe_document_crc32" },
                    { 1, "fhpe_document_crc64" },
                    { 2, "fhpe_document_md5" },
                    { 3, "fhpe_document_sha1" },
                    { 4, "fhpe_document_sha256" },
                    { 5, "fhpe_document_sha384" },
                    { 6, "fhpe_document_sha512" }
                };
                if (hashAlgorithms.TryGetValue(file_hash_algorithm_mode, out var hashAlgorithmKey)){
                    file_hash_current_mode = software_lang.TSReadLangs("FileHashPrintEngine", hashAlgorithmKey) + $" (*.{hashAlgorithmKey.Split('_')[2]})|*.{hashAlgorithmKey.Split('_')[2]}";
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
                    Title = string.Format(software_lang.TSReadLangs("FileHashPrintEngine", "fhpe_save_directory_notification"), Application.ProductName),
                    FileName = string.Format(software_lang.TSReadLangs("FileHashPrintEngine", "fhpe_save_file_name"), Application.ProductName),
                    Filter = file_hash_current_mode + "|" + software_lang.TSReadLangs("FileHashPrintEngine", "fhpe_document_txt") + " (*.txt)|*.txt"
                };
                if (save_engine.ShowDialog() == DialogResult.OK){
                    String combinedText = String.Join(Environment.NewLine, PrintEngineList);
                    File.WriteAllText(save_engine.FileName, combinedText);
                    DialogResult vimera_print_engine_query = TS_MessageBoxEngine.TS_MessageBox(this, 5, string.Format(software_lang.TSReadLangs("FileHashPrintEngine", "fhpe_save_hash_success"), Application.ProductName, save_engine.FileName, "\n\n"));
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
                        TS_MessageBoxEngine.TS_MessageBox(this, 2, string.Format(software_lang.TSReadLangs("TextHashTool", "tht_one_file_select")), "1");
                        return;
                    }
                    //
                    var get_file = selectedFiles.FirstOrDefault();
                    //
                    if (get_file != null && File.Exists(get_file)){
                        string fileExtension = Path.GetExtension(get_file).ToLower();
                        if (validExtensions.Contains(fileExtension)){
                            TextHashOriginalTextBox.Text = File.ReadAllText(get_file);
                        }else{
                            TS_MessageBoxEngine.TS_MessageBox(this, 2, string.Format(software_lang.TSReadLangs("TextHashTool", "tht_one_file_select_valid"), "\n\n", string.Join(", ", validExtensions)));
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
            TextUpdateHash();
        }
        private void TextUpdateHash(){
            if (!string.IsNullOrWhiteSpace(TextHashOriginalTextBox.Text)){
                Text_hash_engine(
                    TextHashAlgorithmSelect.SelectedIndex,
                    TextHashSaltingMode.Checked,
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
        private void Text_hash_engine(int hash_mode, bool salt_mode, int salt_locate_mode, string original_text){
            try{
                if (salt_mode){
                    string salt = TextHashSaltingTextBox.Text;
                    switch (salt_locate_mode){
                        case 0:
                            original_text = salt + original_text;
                            break;
                        case 1:
                            original_text += salt;
                            break;
                        case 2:
                            original_text = salt + original_text + salt;
                            break;
                    }
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
                    uint textCrc32 = CalculateCrc32(original_text);
                    return $"{textCrc32:X8}";
                case 3:
                    ulong textCrc64 = CalculateCrc64(original_text);
                    return $"{textCrc64:X16}";
                case 4:
                    using (var ripemd160 = new RIPEMD160Managed()){
                        hashBytes = ripemd160.ComputeHash(inputBytes);
                        return HashStringRotate(hashBytes);
                    }
                case 5:
                    using (MD5 md5 = MD5.Create()){
                        hashBytes = md5.ComputeHash(inputBytes);
                        return HashStringRotate(hashBytes);
                    }
                case 6:
                    using (SHA1 sha1 = SHA1.Create()){
                        hashBytes = sha1.ComputeHash(inputBytes);
                        return HashStringRotate(hashBytes);
                    }
                case 7:
                    using (SHA256 sha256 = SHA256.Create()){
                        hashBytes = sha256.ComputeHash(inputBytes);
                        return HashStringRotate(hashBytes);
                    }
                case 8:
                    using (SHA384 sha384 = SHA384.Create()){
                        hashBytes = sha384.ComputeHash(inputBytes);
                        return HashStringRotate(hashBytes);
                    }
                case 9:
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
                    TS_MessageBoxEngine.TS_MessageBox(this, 1, software_lang.TSReadLangs("TextHashTool", "tht_hash_copy_notiftication"));
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
                    Hash_compare_engine();
                }
            }else{
                SecondHashValueTextBox.Enabled = false;
                HashCompareResult.Visible = false;
            }
        }
        // HASH COMPARE SECOND HASH VALUE TEXT CHANGED
        // ======================================================================================================
        private void SecondHashValueTextBox_TextChanged(object sender, EventArgs e){
            if (!string.IsNullOrEmpty(FirstHashValueTextBox.Text)){
                if (!string.IsNullOrEmpty(SecondHashValueTextBox.Text)){
                    Hash_compare_engine();
                }else{
                    HashCompareResult.Visible = false;
                }
            }
        }
        // HASH COMPARE ENGINE
        // ======================================================================================================
        private void Hash_compare_engine(){
            try{
                HashCompareResult.Visible = true;
                string hash_1 = FirstHashValueTextBox.Text.Trim().ToLower();
                string hash_2 = SecondHashValueTextBox.Text.Trim().ToLower();
                bool hashesMatch = hash_1 == hash_2;
                UpdateHashCompareText(hashesMatch);
                Dynamic_hash_compare_ui(hashesMatch);
            }catch (Exception){ }
        }
        private void Dynamic_hash_compare_ui(bool hashesMatch){
            string accentColorKey = hashesMatch ? "AccentGreen" : "AccentRed";
            Image resultImage = Convert.ToBoolean(theme) ? (hashesMatch ? Properties.Resources.ct_compare_success_light : Properties.Resources.ct_compare_failed_light) : (hashesMatch ? Properties.Resources.ct_compare_success_dark : Properties.Resources.ct_compare_failed_dark);
            var accentColor = TS_ThemeEngine.ColorMode(theme, accentColorKey);
            HashCompareResult.BackColor = accentColor;
            HashCompareResult.ForeColor = TS_ThemeEngine.ColorMode(theme, "HashCompareResultFE");
            HashCompareResult.FlatAppearance.BorderColor = accentColor;
            HashCompareResult.FlatAppearance.MouseDownBackColor = accentColor;
            HashCompareResult.FlatAppearance.MouseOverBackColor = accentColor;
            TSImageRenderer(HashCompareResult, resultImage, 22, ContentAlignment.MiddleRight);
        }
        private void UpdateHashCompareText(bool hashesMatch){
            TSGetLangs software_lang = new TSGetLangs(lang_path);
            HashCompareResult.Text = " " + software_lang.TSReadLangs("HashCompareTool", hashesMatch ? "hct_values_match" : "hct_values_not_match");
        }
        // ROTATE BTNS
        // ======================================================================================================
        private void Active_page(object btn_target){
            Button active_btn = null;
            Disabled_page();
            if (btn_target != null){
                if (active_btn != (Button)btn_target){
                    active_btn = (Button)btn_target;
                    active_btn.BackColor = TS_ThemeEngine.ColorMode(theme, "BtnActiveColor");
                    active_btn.Cursor = Cursors.Default;
                }
            }
        }
        private void Disabled_page(){
            foreach (Control disabled_btn in LeftPanel.Controls){
                disabled_btn.BackColor = TS_ThemeEngine.ColorMode(theme, "BtnDeActiveColor");
                disabled_btn.Cursor = Cursors.Hand;
            }
        }
        private void FileHashBtn_Click(object sender, EventArgs e){
            Left_menu_preloader(1, sender);
        }
        private void TextHashBtn_Click(object sender, EventArgs e){
            Left_menu_preloader(2, sender);
        }
        private void HashCompareBtn_Click(object sender, EventArgs e){
            Left_menu_preloader(3, sender);
        }
        // DYNAMIC ARROW KEYS ROTATE
        // ======================================================================================================
        private void MainContent_Selecting(object sender, TabControlCancelEventArgs e){
            try{
                var tabButtons = new Dictionary<int, Button>{
                    { 0, FileHashBtn },
                    { 1, TextHashBtn },
                    { 2, HashCompareBtn }
                };
                if (!e.TabPage.Enabled){
                    e.Cancel = true;
                }else if (tabButtons.TryGetValue(MainContent.SelectedIndex, out var button)){
                    button.PerformClick();
                }
            }catch (Exception) { }
        }
        // DYNAMIC LEFT MENU PRELOADER
        // ======================================================================================================
        private void Left_menu_preloader(int target_menu, object sender){
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
                        Active_page(sender);
                    }
                    HeaderText.Text = software_lang.TSReadLangs("Header", target.headerKey);
                }
                menu_btns = target_menu;
                menu_rp = target_menu;
                Header_image_reloader(menu_btns);
            }catch (Exception){ }
        }
        // LANG MODE
        // ======================================================================================================
        private void Select_lang_active(object target_lang){
            ToolStripMenuItem selected_lang = null;
            Select_lang_deactive();
            if (target_lang != null){
                if (selected_lang != (ToolStripMenuItem)target_lang){
                    selected_lang = (ToolStripMenuItem)target_lang;
                    selected_lang.Checked = true;
                }
            }
        }
        private void Select_lang_deactive(){
            foreach (ToolStripMenuItem disabled_lang in languageToolStripMenuItem.DropDownItems){
                disabled_lang.Checked = false;
            }
        }
        private void LanguageToolStripMenuItem_Click(object sender, EventArgs e){
            if (sender is ToolStripMenuItem menuItem && menuItem.Tag is string langCode){
                if (lang != langCode && AllLanguageFiles.ContainsKey(langCode)){
                    Lang_preload(AllLanguageFiles[langCode], langCode);
                    Select_lang_active(sender);
                }
            }
        }
        private void Lang_preload(string lang_type, string lang_code){
            Lang_engine(lang_type, lang_code);
            try{
                TSSettingsSave software_setting_save = new TSSettingsSave(ts_sf);
                software_setting_save.TSWriteSettings(ts_settings_container, "LanguageStatus", lang_code);
            }catch (Exception){ }
            // LANG CHANGE NOTIFICATION
            // TSGetLangs software_lang = new TSGetLangs(lang_path);
            // DialogResult lang_change_message = TS_MessageBoxEngine.TS_MessageBox(this, 5, string.Format(software_lang.TSReadLangs("LangChange", "lang_change_notification"), "\n\n", "\n\n"));
            // if (lang_change_message == DialogResult.Yes){ Application.Restart(); }
        }
        private void Lang_engine(string lang_type, string lang_code){
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
                    HeaderText.Text = software_lang.TSReadLangs("Header", headerKey);
                }
                // SETTINGS
                settingsToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderMenu", "header_menu_settings");
                // THEMES
                themeToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderMenu", "header_menu_theme");
                lightThemeToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderThemes", "theme_light");
                darkThemeToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderThemes", "theme_dark");
                systemThemeToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderThemes", "theme_system");
                // LANGS
                languageToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderMenu", "header_menu_language");
                arabicToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderLangs", "lang_ar");
                chineseToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderLangs", "lang_zh");
                englishToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderLangs", "lang_en");
                dutchToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderLangs", "lang_nl");
                frenchToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderLangs", "lang_fr");
                germanToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderLangs", "lang_de");
                hindiToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderLangs", "lang_hi");
                italianToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderLangs", "lang_it");
                japaneseToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderLangs", "lang_ja");
                koreanToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderLangs", "lang_ko");
                polishToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderLangs", "lang_pl");
                portugueseToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderLangs", "lang_pt");
                russianToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderLangs", "lang_ru");
                spanishToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderLangs", "lang_es");
                turkishToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderLangs", "lang_tr");
                // STARTUP MODE
                startupToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderMenu", "header_menu_start");
                windowedToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderViewMode", "header_view_mode_windowed");
                fullScreenToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderViewMode", "header_view_mode_full_screen");
                // UPDATE
                checkForUpdateToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderMenu", "header_menu_update");
                // TS WIZARD
                tSWizardToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderMenu", "header_menu_ts_wizard");
                // DONATE
                donateToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderMenu", "header_menu_donate");
                // ABOUT
                aboutToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderMenu", "header_menu_about");
                // MENU
                FileHashBtn.Text = " " + " " + software_lang.TSReadLangs("LeftMenu", "left_file_hash");
                TextHashBtn.Text = " " + " " + software_lang.TSReadLangs("LeftMenu", "left_text_hash");
                HashCompareBtn.Text = " " + " " + software_lang.TSReadLangs("LeftMenu", "left_hash_compare");
                // FILE HASH
                FileHashSelectFileBtn.Text = " " + software_lang.TSReadLangs("FileHashTool", "fht_select");
                FileHashDGV.Columns[0].HeaderText = software_lang.TSReadLangs("FileHashTool", "fht_file_path");
                FileHashDGV.Columns[1].HeaderText = software_lang.TSReadLangs("FileHashTool", "fht_file_size");
                FileHashDGV.Columns[2].HeaderText = software_lang.TSReadLangs("FileHashTool", "fht_hash_value");
                FileHashUpperHashMode.Text = software_lang.TSReadLangs("FileHashTool", "fht_hash_uppercase");
                FileHashExportHashsBtn.Text = " " + software_lang.TSReadLangs("FileHashTool", "fht_export_hashs");
                FileHashCompareBtn.Text = " " + software_lang.TSReadLangs("FileHashTool", "fht_compare");
                FileHashStartBtn.Text = " " + software_lang.TSReadLangs("FileHashTool", "fht_start");
                FileHashStopBtn.Text = " " + software_lang.TSReadLangs("FileHashTool", "fht_stop");
                // TEXT HASH
                TextHashAlgorithmSelect.Items[0] = software_lang.TSReadLangs("TextHashTool", "tht_binary");
                TextHashL1.Text = software_lang.TSReadLangs("TextHashTool", "tht_original_value_input");
                TextHashL2.Text = software_lang.TSReadLangs("TextHashTool", "tht_salting_value_input");
                TextHashL3.Text = software_lang.TSReadLangs("TextHashTool", "tht_creating_hash_value");
                TextHashSaltingMode.Text = software_lang.TSReadLangs("TextHashTool", "tht_salting_mode");
                TextHashSaltingLocateMode.Items[0] = software_lang.TSReadLangs("TextHashTool", "tht_add_to_start");
                TextHashSaltingLocateMode.Items[1] = software_lang.TSReadLangs("TextHashTool", "tht_add_to_end");
                TextHashSaltingLocateMode.Items[2] = software_lang.TSReadLangs("TextHashTool", "tht_add_to_between");
                TextHashResultCopyBtn.Text = " " + software_lang.TSReadLangs("TextHashTool", "tht_copy");
                // HASH COMPARE
                FirstHashValueLabel.Text = software_lang.TSReadLangs("HashCompareTool", "hct_first_hash_value_input");
                SecondHashValueLabel.Text = software_lang.TSReadLangs("HashCompareTool", "hct_secondary_hash_value_input");
                UpdateHashCompareText(FirstHashValueTextBox.Text.Trim().ToLower() == SecondHashValueTextBox.Text.Trim().ToLower());
                // OTHER PAGE DYNAMIC UI
                Software_other_page_preloader();
            }catch (Exception){ }
        }
        // THEME MODE
        // ======================================================================================================
        private ToolStripMenuItem selected_theme = null;
        private void Select_theme_active(object target_theme)
        {
            if (target_theme == null)
                return;
            ToolStripMenuItem clicked_theme = (ToolStripMenuItem)target_theme;
            if (selected_theme == clicked_theme)
                return;
            Select_theme_deactive();
            selected_theme = clicked_theme;
            selected_theme.Checked = true;
        }
        private void Select_theme_deactive()
        {
            foreach (ToolStripMenuItem theme in themeToolStripMenuItem.DropDownItems)
            {
                theme.Checked = false;
            }
        }
        // THEME SWAP
        // ======================================================================================================
        private void SystemThemeToolStripMenuItem_Click(object sender, EventArgs e){
            themeSystem = 2; Theme_engine(GetSystemTheme(2)); SaveTheme(2); Select_theme_active(sender);
        }
        private void LightThemeToolStripMenuItem_Click(object sender, EventArgs e){
            themeSystem = 0; Theme_engine(1); SaveTheme(1); Select_theme_active(sender);
        }
        private void DarkThemeToolStripMenuItem_Click(object sender, EventArgs e){
            themeSystem = 0; Theme_engine(0); SaveTheme(0); Select_theme_active(sender);
        }
        private void TSUseSystemTheme() { if (themeSystem == 2) Theme_engine(GetSystemTheme(2)); }
        private void SaveTheme(int ts){
            // SAVE CURRENT THEME
            try{
                TSSettingsSave software_setting_save = new TSSettingsSave(ts_sf);
                software_setting_save.TSWriteSettings(ts_settings_container, "ThemeStatus", Convert.ToString(ts));
            }catch (Exception){ }
        }
        // THEME ENGINE
        // ======================================================================================================
        private void Theme_engine(int ts){
            try{
                theme = ts;
                //
                TSThemeModeHelper.SetThemeMode(ts == 0);
                TSThemeModeHelper.InitializeThemeForForm(this);
                //
                if (theme == 1){
                    // SETTINGS
                    TSImageRenderer(settingsToolStripMenuItem, Properties.Resources.tm_settings_light, 0, ContentAlignment.MiddleRight);
                    TSImageRenderer(themeToolStripMenuItem, Properties.Resources.tm_theme_light, 0, ContentAlignment.MiddleRight);
                    TSImageRenderer(languageToolStripMenuItem, Properties.Resources.tm_language_light, 0, ContentAlignment.MiddleRight);
                    TSImageRenderer(startupToolStripMenuItem, Properties.Resources.tm_startup_light, 0, ContentAlignment.MiddleRight);
                    TSImageRenderer(checkForUpdateToolStripMenuItem, Properties.Resources.tm_update_light, 0, ContentAlignment.MiddleRight);
                    TSImageRenderer(tSWizardToolStripMenuItem, Properties.Resources.tm_ts_wizard_light, 0, ContentAlignment.MiddleRight);
                    TSImageRenderer(donateToolStripMenuItem, Properties.Resources.tm_donate_light, 0, ContentAlignment.MiddleRight);
                    TSImageRenderer(aboutToolStripMenuItem, Properties.Resources.tm_about_light, 0, ContentAlignment.MiddleRight);
                    // THEME LOGOS
                    TSImageRenderer(FileHashBtn, Properties.Resources.lm_file_hash_light, 15, ContentAlignment.MiddleLeft);
                    TSImageRenderer(TextHashBtn, Properties.Resources.lm_text_hash_light, 15, ContentAlignment.MiddleLeft);
                    TSImageRenderer(HashCompareBtn, Properties.Resources.lm_hash_compare_light, 15, ContentAlignment.MiddleLeft);
                    // UI
                    TSImageRenderer(FileHashExportHashsBtn, Properties.Resources.ct_export_light, 12, ContentAlignment.MiddleRight);
                    TSImageRenderer(FileHashSelectFileBtn, Properties.Resources.ct_file_select_light, 12, ContentAlignment.MiddleRight);
                    TSImageRenderer(FileHashCompareBtn, Properties.Resources.ct_compare_light, 12, ContentAlignment.MiddleRight);
                    TSImageRenderer(FileHashStartBtn, Properties.Resources.ct_start_light, 21, ContentAlignment.MiddleRight);
                    TSImageRenderer(FileHashStopBtn, Properties.Resources.ct_stop_light, 21, ContentAlignment.MiddleRight);
                    //
                    TSImageRenderer(TextHashResultCopyBtn, Properties.Resources.ct_copy_light, 22, ContentAlignment.MiddleRight);
                }else if (theme == 0){
                    // SETTINGS
                    TSImageRenderer(settingsToolStripMenuItem, Properties.Resources.tm_settings_dark, 0, ContentAlignment.MiddleRight);
                    TSImageRenderer(themeToolStripMenuItem, Properties.Resources.tm_theme_dark, 0, ContentAlignment.MiddleRight);
                    TSImageRenderer(languageToolStripMenuItem, Properties.Resources.tm_language_dark, 0, ContentAlignment.MiddleRight);
                    TSImageRenderer(startupToolStripMenuItem, Properties.Resources.tm_startup_dark, 0, ContentAlignment.MiddleRight);
                    TSImageRenderer(checkForUpdateToolStripMenuItem, Properties.Resources.tm_update_dark, 0, ContentAlignment.MiddleRight);
                    TSImageRenderer(tSWizardToolStripMenuItem, Properties.Resources.tm_ts_wizard_dark, 0, ContentAlignment.MiddleRight);
                    TSImageRenderer(donateToolStripMenuItem, Properties.Resources.tm_donate_dark, 0, ContentAlignment.MiddleRight);
                    TSImageRenderer(aboutToolStripMenuItem, Properties.Resources.tm_about_dark, 0, ContentAlignment.MiddleRight);
                    // THEME LOGOS
                    TSImageRenderer(FileHashBtn, Properties.Resources.lm_file_hash_dark, 15, ContentAlignment.MiddleLeft);
                    TSImageRenderer(TextHashBtn, Properties.Resources.lm_text_hash_dark, 15, ContentAlignment.MiddleLeft);
                    TSImageRenderer(HashCompareBtn, Properties.Resources.lm_hash_compare_dark, 15, ContentAlignment.MiddleLeft);
                    // UI
                    TSImageRenderer(FileHashExportHashsBtn, Properties.Resources.ct_export_dark, 12, ContentAlignment.MiddleRight);
                    TSImageRenderer(FileHashSelectFileBtn, Properties.Resources.ct_file_select_dark, 12, ContentAlignment.MiddleRight);
                    TSImageRenderer(FileHashCompareBtn, Properties.Resources.ct_compare_dark, 12, ContentAlignment.MiddleRight);
                    TSImageRenderer(FileHashStartBtn, Properties.Resources.ct_start_dark, 21, ContentAlignment.MiddleRight);
                    TSImageRenderer(FileHashStopBtn, Properties.Resources.ct_stop_dark, 21, ContentAlignment.MiddleRight);
                    //
                    TSImageRenderer(TextHashResultCopyBtn, Properties.Resources.ct_copy_dark, 22, ContentAlignment.MiddleRight);
                }
                // OTHER PAGE DYNAMIC UI
                Software_other_page_preloader();
                // HEADER
                Header_image_reloader(menu_btns);
                header_colors[0] = TS_ThemeEngine.ColorMode(theme, "HeaderBGColorMain");
                header_colors[1] = TS_ThemeEngine.ColorMode(theme, "HeaderFEColorMain");
                header_colors[2] = TS_ThemeEngine.ColorMode(theme, "AccentColor");
                HeaderMenu.Renderer = new HeaderMenuColors();
                // ACTIVE BTN 
                btn_colors_active[0] = TS_ThemeEngine.ColorMode(theme, "BtnActiveColor");
                // HEADER PANEL
                HeaderInPanel.BackColor = TS_ThemeEngine.ColorMode(theme, "HeaderBGColor");
                // HEADER PANEL TEXT
                HeaderText.ForeColor = TS_ThemeEngine.ColorMode(theme, "HeaderFEColor");
                // HEADER MENU
                var bg = TS_ThemeEngine.ColorMode(theme, "HeaderBGColor");
                var fg = TS_ThemeEngine.ColorMode(theme, "HeaderFEColor");
                HeaderMenu.ForeColor = fg;
                HeaderMenu.BackColor = bg;
                SetMenuStripColors(HeaderMenu, bg, fg);
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
                FileHashAlgorithmSelect.BackColor = TS_ThemeEngine.ColorMode(theme, "SelectBoxBGColor");
                FileHashAlgorithmSelect.ForeColor = TS_ThemeEngine.ColorMode(theme, "SelectBoxFEColor");
                FileHashAlgorithmSelect.HoverBackColor = TS_ThemeEngine.ColorMode(theme, "SelectBoxBGColor");
                FileHashAlgorithmSelect.ButtonColor = TS_ThemeEngine.ColorMode(theme, "SelectBoxBGColor2");
                FileHashAlgorithmSelect.ArrowColor = TS_ThemeEngine.ColorMode(theme, "SelectBoxFEColor");
                FileHashAlgorithmSelect.HoverButtonColor = TS_ThemeEngine.ColorMode(theme, "SelectBoxBGColor2");
                FileHashAlgorithmSelect.BorderColor = TS_ThemeEngine.ColorMode(theme, "SelectBoxBorderColor");
                FileHashAlgorithmSelect.FocusedBorderColor = TS_ThemeEngine.ColorMode(theme, "SelectBoxBorderColor");
                FileHashAlgorithmSelect.DisabledBackColor = TS_ThemeEngine.ColorMode(theme, "SelectBoxBGColor");
                FileHashAlgorithmSelect.DisabledForeColor = TS_ThemeEngine.ColorMode(theme, "SelectBoxFEColor");
                FileHashAlgorithmSelect.DisabledButtonColor = TS_ThemeEngine.ColorMode(theme, "SelectBoxBGColor2");
                FileHashSelectFileBtn.BackColor = TS_ThemeEngine.ColorMode(theme, "AccentColor");
                FileHashSelectFileBtn.FlatAppearance.BorderColor = TS_ThemeEngine.ColorMode(theme, "AccentColor");
                FileHashSelectFileBtn.FlatAppearance.MouseDownBackColor = TS_ThemeEngine.ColorMode(theme, "AccentColor");
                FileHashSelectFileBtn.FlatAppearance.MouseOverBackColor = TS_ThemeEngine.ColorMode(theme, "AccentColorHover");
                FileHashSelectFileBtn.ForeColor = TS_ThemeEngine.ColorMode(theme, "DynamicThemeActiveBtnBG");
                FileHashUpperHashMode.BackColor = TS_ThemeEngine.ColorMode(theme, "TextBoxBGColor");
                FileHashUpperHashMode.ForeColor = TS_ThemeEngine.ColorMode(theme, "TextBoxFEColor");
                FileHashExportHashsBtn.BackColor = TS_ThemeEngine.ColorMode(theme, "AccentColor");
                FileHashExportHashsBtn.FlatAppearance.BorderColor = TS_ThemeEngine.ColorMode(theme, "AccentColor");
                FileHashExportHashsBtn.FlatAppearance.MouseDownBackColor = TS_ThemeEngine.ColorMode(theme, "AccentColor");
                FileHashExportHashsBtn.FlatAppearance.MouseOverBackColor = TS_ThemeEngine.ColorMode(theme, "AccentColorHover");
                FileHashExportHashsBtn.ForeColor = TS_ThemeEngine.ColorMode(theme, "DynamicThemeActiveBtnBG");
                FileHashLoadFE_Panel.BackColor = TS_ThemeEngine.ColorMode(theme, "AccentColor");
                FileHashDGV.BackgroundColor = TS_ThemeEngine.ColorMode(theme, "DataGridBGColor");
                FileHashDGV.GridColor = TS_ThemeEngine.ColorMode(theme, "DataGridColor");
                FileHashDGV.DefaultCellStyle.BackColor = TS_ThemeEngine.ColorMode(theme, "DataGridBGColor");
                FileHashDGV.DefaultCellStyle.ForeColor = TS_ThemeEngine.ColorMode(theme, "DataGridFEColor");
                FileHashDGV.AlternatingRowsDefaultCellStyle.BackColor = TS_ThemeEngine.ColorMode(theme, "DataGridAlternatingColor");
                FileHashDGV.ColumnHeadersDefaultCellStyle.BackColor = TS_ThemeEngine.ColorMode(theme, "AccentColor");
                FileHashDGV.ColumnHeadersDefaultCellStyle.SelectionBackColor = TS_ThemeEngine.ColorMode(theme, "AccentColor");
                FileHashDGV.ColumnHeadersDefaultCellStyle.ForeColor = TS_ThemeEngine.ColorMode(theme, "DataGridSelectionColor");
                FileHashDGV.DefaultCellStyle.SelectionBackColor = TS_ThemeEngine.ColorMode(theme, "AccentColor");
                FileHashDGV.DefaultCellStyle.SelectionForeColor = TS_ThemeEngine.ColorMode(theme, "DataGridSelectionColor");
                FileHashCompareBtn.BackColor = TS_ThemeEngine.ColorMode(theme, "AccentColor");
                FileHashCompareBtn.FlatAppearance.BorderColor = TS_ThemeEngine.ColorMode(theme, "AccentColor");
                FileHashCompareBtn.FlatAppearance.MouseDownBackColor = TS_ThemeEngine.ColorMode(theme, "AccentColor");
                FileHashCompareBtn.FlatAppearance.MouseOverBackColor = TS_ThemeEngine.ColorMode(theme, "AccentColorHover");
                FileHashCompareBtn.ForeColor = TS_ThemeEngine.ColorMode(theme, "DynamicThemeActiveBtnBG");
                FileHashStartBtn.BackColor = TS_ThemeEngine.ColorMode(theme, "AccentColor"); 
                FileHashStartBtn.FlatAppearance.BorderColor = TS_ThemeEngine.ColorMode(theme, "AccentColor");
                FileHashStartBtn.FlatAppearance.MouseDownBackColor = TS_ThemeEngine.ColorMode(theme, "AccentColor");
                FileHashStartBtn.FlatAppearance.MouseOverBackColor = TS_ThemeEngine.ColorMode(theme, "AccentColorHover");
                FileHashStartBtn.ForeColor = TS_ThemeEngine.ColorMode(theme, "DynamicThemeActiveBtnBG");
                FileHashStopBtn.BackColor = TS_ThemeEngine.ColorMode(theme, "AccentColor");
                FileHashStopBtn.FlatAppearance.BorderColor = TS_ThemeEngine.ColorMode(theme, "AccentColor");
                FileHashStopBtn.FlatAppearance.MouseDownBackColor = TS_ThemeEngine.ColorMode(theme, "AccentColor");
                FileHashStopBtn.FlatAppearance.MouseOverBackColor = TS_ThemeEngine.ColorMode(theme, "AccentColorHover");
                FileHashStopBtn.ForeColor = TS_ThemeEngine.ColorMode(theme, "DynamicThemeActiveBtnBG");
                FileHashSizer.BackColor = TS_ThemeEngine.ColorMode(theme, "LeftMenuButtonHoverAndMouseDownColor");
                FileHashSizer.ForeColor = TS_ThemeEngine.ColorMode(theme, "LeftMenuButtonFEColor");
                FileHashTimer.BackColor = TS_ThemeEngine.ColorMode(theme, "LeftMenuButtonHoverAndMouseDownColor");
                FileHashTimer.ForeColor = TS_ThemeEngine.ColorMode(theme, "LeftMenuButtonFEColor");
                FileHashCompareTextBox.BackColor = TS_ThemeEngine.ColorMode(theme, "TextBoxBGColor");
                FileHashCompareTextBox.ForeColor = TS_ThemeEngine.ColorMode(theme, "TextBoxFEColor");
                // TEXT HASH
                TextHashPanel.BackColor = TS_ThemeEngine.ColorMode(theme, "ContentPanelBGColor");
                TextHashAlgorithmSelect.BackColor = TS_ThemeEngine.ColorMode(theme, "SelectBoxBGColor");
                TextHashAlgorithmSelect.ForeColor = TS_ThemeEngine.ColorMode(theme, "SelectBoxFEColor");
                TextHashAlgorithmSelect.HoverBackColor = TS_ThemeEngine.ColorMode(theme, "SelectBoxBGColor");
                TextHashAlgorithmSelect.ButtonColor = TS_ThemeEngine.ColorMode(theme, "SelectBoxBGColor2");
                TextHashAlgorithmSelect.ArrowColor = TS_ThemeEngine.ColorMode(theme, "SelectBoxFEColor");
                TextHashAlgorithmSelect.HoverButtonColor = TS_ThemeEngine.ColorMode(theme, "SelectBoxBGColor2");
                TextHashAlgorithmSelect.BorderColor = TS_ThemeEngine.ColorMode(theme, "SelectBoxBorderColor");
                TextHashAlgorithmSelect.FocusedBorderColor = TS_ThemeEngine.ColorMode(theme, "SelectBoxBorderColor");
                TextHashL1.ForeColor = TS_ThemeEngine.ColorMode(theme, "LeftMenuButtonFEColor");
                TextHashL2.ForeColor = TS_ThemeEngine.ColorMode(theme, "LeftMenuButtonFEColor");
                TextHashL3.ForeColor = TS_ThemeEngine.ColorMode(theme, "LeftMenuButtonFEColor");
                TextHashOriginalTextBox.BackColor = TS_ThemeEngine.ColorMode(theme, "TextBoxBGColor");
                TextHashOriginalTextBox.ForeColor = TS_ThemeEngine.ColorMode(theme, "TextBoxFEColor");
                TextHashSaltingMode.ForeColor = TS_ThemeEngine.ColorMode(theme, "TextBoxFEColor");
                TextHashSaltingTextBox.BackColor = TS_ThemeEngine.ColorMode(theme, "TextBoxBGColor");
                TextHashSaltingTextBox.ForeColor = TS_ThemeEngine.ColorMode(theme, "TextBoxFEColor");
                TextHashSaltingLocateMode.BackColor = TS_ThemeEngine.ColorMode(theme, "SelectBoxBGColor");
                TextHashSaltingLocateMode.ForeColor = TS_ThemeEngine.ColorMode(theme, "SelectBoxFEColor");
                TextHashSaltingLocateMode.HoverBackColor = TS_ThemeEngine.ColorMode(theme, "SelectBoxBGColor");
                TextHashSaltingLocateMode.ButtonColor = TS_ThemeEngine.ColorMode(theme, "SelectBoxBGColor2");
                TextHashSaltingLocateMode.ArrowColor = TS_ThemeEngine.ColorMode(theme, "SelectBoxFEColor");
                TextHashSaltingLocateMode.HoverButtonColor = TS_ThemeEngine.ColorMode(theme, "SelectBoxBGColor2");
                TextHashSaltingLocateMode.BorderColor = TS_ThemeEngine.ColorMode(theme, "SelectBoxBorderColor");
                TextHashSaltingLocateMode.FocusedBorderColor = TS_ThemeEngine.ColorMode(theme, "SelectBoxBorderColor");
                TextHashResultTextBox.BackColor = TS_ThemeEngine.ColorMode(theme, "TextBoxBGColor");
                TextHashResultTextBox.ForeColor = TS_ThemeEngine.ColorMode(theme, "TextBoxFEColor");
                TextHashResultCopyBtn.BackColor = TS_ThemeEngine.ColorMode(theme, "AccentColor");
                TextHashResultCopyBtn.FlatAppearance.BorderColor = TS_ThemeEngine.ColorMode(theme, "AccentColor");
                TextHashResultCopyBtn.FlatAppearance.MouseDownBackColor = TS_ThemeEngine.ColorMode(theme, "AccentColor");
                TextHashResultCopyBtn.FlatAppearance.MouseOverBackColor = TS_ThemeEngine.ColorMode(theme, "AccentColorHover");
                TextHashResultCopyBtn.ForeColor = TS_ThemeEngine.ColorMode(theme, "DynamicThemeActiveBtnBG");
                // HASH COMPARE
                HashComparePanel.BackColor = TS_ThemeEngine.ColorMode(theme, "ContentPanelBGColor");
                FirstHashValueLabel.ForeColor = TS_ThemeEngine.ColorMode(theme, "LeftMenuButtonFEColor");
                FirstHashValueTextBox.BackColor = TS_ThemeEngine.ColorMode(theme, "TextBoxBGColor");
                FirstHashValueTextBox.ForeColor = TS_ThemeEngine.ColorMode(theme, "TextBoxFEColor");
                SecondHashValueLabel.ForeColor = TS_ThemeEngine.ColorMode(theme, "LeftMenuButtonFEColor");
                SecondHashValueTextBox.BackColor = TS_ThemeEngine.ColorMode(theme, "TextBoxBGColor");
                SecondHashValueTextBox.ForeColor = TS_ThemeEngine.ColorMode(theme, "TextBoxFEColor");
                Dynamic_hash_compare_ui(FirstHashValueTextBox.Text.Trim().ToLower() == SecondHashValueTextBox.Text.Trim().ToLower());
                // ROTATE MENU
                var buttonMapping = new Dictionary<int, Button>{
                    { 1, FileHashBtn },
                    { 2, TextHashBtn },
                    { 3, HashCompareBtn }
                };
                if (buttonMapping.TryGetValue(menu_btns, out var button)){
                    button.BackColor = TS_ThemeEngine.ColorMode(theme, "PageContainerBGAndPageContentTotalColors");
                }
            }catch (Exception){ }
        }
        private void SetMenuStripColors(MenuStrip menuStrip, Color bgColor, Color fgColor){
            if (menuStrip == null) return;
            foreach (ToolStripItem item in menuStrip.Items){
                if (item is ToolStripMenuItem menuItem){
                    SetMenuItemColors(menuItem, bgColor, fgColor);
                }
            }
        }
        private void SetMenuItemColors(ToolStripMenuItem menuItem, Color bgColor, Color fgColor){
            if (menuItem == null) return;
            menuItem.BackColor = bgColor;
            menuItem.ForeColor = fgColor;
            foreach (ToolStripItem item in menuItem.DropDownItems){
                if (item is ToolStripMenuItem subMenuItem){
                    SetMenuItemColors(subMenuItem, bgColor, fgColor);
                }
            }
        }
        private void SetContextMenuColors(ContextMenuStrip contextMenu, Color bgColor, Color fgColor){
            if (contextMenu == null) return;
            foreach (ToolStripItem item in contextMenu.Items){
                if (item is ToolStripMenuItem menuItem){
                    SetMenuItemColors(menuItem, bgColor, fgColor);
                }
            }
        }
        private void Header_image_reloader(int hi_value){
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
                    TSImageRenderer(HeaderImage, image, 0, ContentAlignment.MiddleCenter);
                }
            }catch (Exception){ }
        }
        // MODULES PAGE DYNAMIC UI
        // ======================================================================================================
        private void Software_other_page_preloader(){
            // SOFTWARE ABOUT
            try{
                VimeraAbout software_about = new VimeraAbout();
                string software_about_name = "vimera_about";
                software_about.Name = software_about_name;
                if (Application.OpenForms[software_about_name] != null){
                    software_about = (VimeraAbout)Application.OpenForms[software_about_name];
                    software_about.About_preloader();
                }
            }catch (Exception){ }
        }
        // STARTUP SETINGS
        // ======================================================================================================
        private void Select_startup_mode_active(object target_startup_mode){
            ToolStripMenuItem selected_startup_mode = null;
            Select_startup_mode_deactive();
            if (target_startup_mode != null){
                if (selected_startup_mode != (ToolStripMenuItem)target_startup_mode){
                    selected_startup_mode = (ToolStripMenuItem)target_startup_mode;
                    selected_startup_mode.Checked = true;
                }
            }
        }
        private void Select_startup_mode_deactive(){
            foreach (ToolStripMenuItem disabled_startup in startupToolStripMenuItem.DropDownItems){
                disabled_startup.Checked = false;
            }
        }
        private void WindowedToolStripMenuItem_Click(object sender, EventArgs e){
            if (startup_status != 0){ startup_status = 0; Startup_mode_settings("0"); Select_startup_mode_active(sender); }
        }
        private void FullScreenToolStripMenuItem_Click(object sender, EventArgs e){
            if (startup_status != 1){ startup_status = 1; Startup_mode_settings("1"); Select_startup_mode_active(sender); }
        }
        private void Startup_mode_settings(string get_startup_value){
            try{
                TSSettingsSave software_setting_save = new TSSettingsSave(ts_sf);
                software_setting_save.TSWriteSettings(ts_settings_container, "StartupStatus", get_startup_value);
            }catch (Exception){ }
        }
        // SOFTWARE OPERATION CONTROLLER MODULE
        // ======================================================================================================
        private static bool Software_operation_controller(string __target_software_path){
            var exeFiles = Directory.GetFiles(__target_software_path, "*.exe");
            var runned_process = Process.GetProcesses();
            foreach (var exe_path in exeFiles){
                string exe_name = Path.GetFileNameWithoutExtension(exe_path);
                if (runned_process.Any(p => {
                    try{
                        return string.Equals(p.ProcessName, exe_name, StringComparison.OrdinalIgnoreCase);
                    }catch{
                        return false;
                    }
                })){
                    return true;
                }
            }
            return false;
        }
        // TS WIZARD STARTER MODE
        // ======================================================================================================
        private string[] Ts_wizard_starter_mode(){
            string[] ts_wizard_exe_files = { "TSWizard_arm64.exe", "TSWizard_x64.exe", "TSWizard.exe" };
            if (RuntimeInformation.OSArchitecture == Architecture.Arm64){
                return new[] { ts_wizard_exe_files[0], ts_wizard_exe_files[1], ts_wizard_exe_files[2] }; // arm64 > x64 > default
            }else if (Environment.Is64BitOperatingSystem){
                return new[] { ts_wizard_exe_files[1], ts_wizard_exe_files[0], ts_wizard_exe_files[2] }; // x64 > arm64 > default
            }else{
                return new[] { ts_wizard_exe_files[2], ts_wizard_exe_files[1], ts_wizard_exe_files[0] }; // default > x64 > arm64
            }
        }
        // CHECK UPDATE
        // ======================================================================================================
        private void CheckForUpdateToolStripMenuItem_Click(object sender, EventArgs e){
            Task.Run(() => Software_update_check(1));
        }
        public void Software_update_check(int _check_update_ui){
            try{
                TSGetLangs software_lang = new TSGetLangs(lang_path);
                SetUpdateMenuEnabled(false);
                if (!IsNetworkCheck()){
                    if (_check_update_ui == 1){
                        TS_MessageBoxEngine.TS_MessageBox(this, 2, string.Format(software_lang.TSReadLangs("SoftwareUpdate", "su_not_connection"), "\n\n"), string.Format(software_lang.TSReadLangs("SoftwareUpdate", "su_title"), Application.ProductName));
                    }
                    return;
                }
                using (WebClient getLastVersion = new WebClient()){
                    string client_version_raw = TS_VersionParser.ParseUINormalize(Application.ProductVersion);
                    string last_version_raw = TS_VersionParser.ParseUINormalize(getLastVersion.DownloadString(TS_LinkSystem.github_link_lv).Split('=')[1].Trim());
                    Version client_ver = Version.Parse(client_version_raw);
                    Version last_ver = Version.Parse(last_version_raw);
                    if (client_ver < last_ver){
                        string baseDir = Path.Combine(Directory.GetParent(Directory.GetParent(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).FullName).FullName);
                        string ts_wizard_path = Ts_wizard_starter_mode().Select(name => Path.Combine(baseDir, name)).FirstOrDefault(File.Exists);
                        if (!string.IsNullOrEmpty(ts_wizard_path) && File.Exists(ts_wizard_path)){
                            if (!Software_operation_controller(Path.GetDirectoryName(ts_wizard_path))){
                                DialogResult info_update = TS_MessageBoxEngine.TS_MessageBox(this, 5, string.Format(software_lang.TSReadLangs("SoftwareUpdate", "su_available_ts_wizard"), Application.ProductName, "\n\n", client_version_raw, "\n", last_version_raw, "\n\n", ts_wizard_name), string.Format(software_lang.TSReadLangs("SoftwareUpdate", "su_title"), Application.ProductName));
                                if (info_update == DialogResult.Yes){
                                    Process.Start(new ProcessStartInfo { FileName = ts_wizard_path, WorkingDirectory = Path.GetDirectoryName(ts_wizard_path) });
                                }
                            }else{
                                if (_check_update_ui == 1){
                                    TS_MessageBoxEngine.TS_MessageBox(this, 1, string.Format(software_lang.TSReadLangs("HeaderHelp", "header_help_info_notification"), ts_wizard_name));
                                }
                            }
                        }else{
                            DialogResult info_update = TS_MessageBoxEngine.TS_MessageBox(this, 5, string.Format(software_lang.TSReadLangs("SoftwareUpdate", "su_available"), Application.ProductName, "\n\n", client_version_raw, "\n", last_version_raw, "\n\n"), string.Format(software_lang.TSReadLangs("SoftwareUpdate", "su_title"), Application.ProductName));
                            if (info_update == DialogResult.Yes)
                                Process.Start(new ProcessStartInfo(TS_LinkSystem.github_link_lr) { UseShellExecute = true });
                        }
                    }else if (_check_update_ui == 1){
                        string update_msg = client_ver == last_ver ? string.Format(software_lang.TSReadLangs("SoftwareUpdate", "su_not_available"), Application.ProductName, "\n", client_version_raw) : string.Format(software_lang.TSReadLangs("SoftwareUpdate", "su_newer"), "\n\n", $"v{client_version_raw}");
                        TS_MessageBoxEngine.TS_MessageBox(this, 1, update_msg, string.Format(software_lang.TSReadLangs("SoftwareUpdate", "su_title"), Application.ProductName));
                    }
                }
            }catch (Exception ex){
                TSGetLangs software_lang = new TSGetLangs(lang_path);
                TS_MessageBoxEngine.TS_MessageBox(this, 3, string.Format(software_lang.TSReadLangs("SoftwareUpdate", "su_error"), "\n\n", ex.Message), string.Format(software_lang.TSReadLangs("SoftwareUpdate", "su_title"), Application.ProductName));
            }finally{
                SetUpdateMenuEnabled(true);
            }
        }
        private void SetUpdateMenuEnabled(bool enabled){
            if (InvokeRequired){
                BeginInvoke(new Action(() => checkForUpdateToolStripMenuItem.Enabled = enabled));
            }else{
                checkForUpdateToolStripMenuItem.Enabled = enabled;
            }
        }
        // DONATE LINK
        // ======================================================================================================
        private void DonateToolStripMenuItem_Click(object sender, EventArgs e){
            try{
                Process.Start(new ProcessStartInfo(TS_LinkSystem.ts_donate){ UseShellExecute = true });
            }catch (Exception){ }
        }
        // TS WIZARD
        // ======================================================================================================
        private void TSWizardToolStripMenuItem_Click(object sender, EventArgs e){
            try{
                string baseDir = Path.Combine(Directory.GetParent(Directory.GetParent(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).FullName).FullName);
                string ts_wizard_path = Ts_wizard_starter_mode().Select(name => Path.Combine(baseDir, name)).FirstOrDefault(File.Exists);
                //
                TSGetLangs software_lang = new TSGetLangs(lang_path);
                //
                if (ts_wizard_path != null){
                    if (!Software_operation_controller(Path.GetDirectoryName(ts_wizard_path))){
                        Process.Start(new ProcessStartInfo { FileName = ts_wizard_path, WorkingDirectory = Path.GetDirectoryName(ts_wizard_path) });
                    }else{
                        TS_MessageBoxEngine.TS_MessageBox(this, 1, string.Format(software_lang.TSReadLangs("HeaderHelp", "header_help_info_notification"), ts_wizard_name));
                    }
                }else{
                    DialogResult ts_wizard_query = TS_MessageBoxEngine.TS_MessageBox(this, 5, string.Format(software_lang.TSReadLangs("TSWizard", "tsw_content"), software_lang.TSReadLangs("HeaderMenu", "header_menu_ts_wizard"), Application.CompanyName, "\n\n", Application.ProductName, Application.CompanyName, "\n\n"), string.Format("{0} - {1}", Application.ProductName, ts_wizard_name));
                    if (ts_wizard_query == DialogResult.Yes){
                        Process.Start(new ProcessStartInfo(TS_LinkSystem.ts_wizard) { UseShellExecute = true });
                    }
                }
            }catch (Exception){ }
        }
        // TS TOOL LAUNCHER MODULE
        // ======================================================================================================
        private void TSToolLauncher<T>(string formName, string langKey) where T : Form, new(){
            try{
                TSGetLangs software_lang = new TSGetLangs(lang_path);
                T tool = new T { Name = formName };
                if (Application.OpenForms[formName] == null){
                    tool.Show();
                }else{
                    if (Application.OpenForms[formName].WindowState == FormWindowState.Minimized){
                        Application.OpenForms[formName].WindowState = FormWindowState.Normal;
                    }
                    string public_message = string.Format(software_lang.TSReadLangs("HeaderHelp", "header_help_info_notification"), software_lang.TSReadLangs("HeaderMenu", langKey));
                    TS_MessageBoxEngine.TS_MessageBox(this, 1, public_message);
                    Application.OpenForms[formName].Activate();
                }
            }catch (Exception){ }
        }
        // ABOUT
        // ======================================================================================================
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e){
            TSToolLauncher<VimeraAbout>("vimera_about", "header_menu_about");
        }
        // EXIT
        // ======================================================================================================
        private void Software_exit(){ Application.Exit(); }
        private void Vimera_FormClosing(object sender, FormClosingEventArgs e){ Software_exit(); }
    }
}