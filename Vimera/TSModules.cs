using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Vimera{
    internal class TSModules{
        // STARTUP LOCATION
        // ======================================================================================================
        private static readonly string StartupPath = Application.StartupPath;
        // LINK SYSTEM
        // ======================================================================================================
        public class TS_LinkSystem{
            public const string
            // Main Control Links
            github_link_lv      = "https://raw.githubusercontent.com/turkaysoftware/vimera/main/Vimera/SoftwareVersion.txt",
            github_link_lr      = "https://github.com/turkaysoftware/vimera/releases/latest",
            // Social Links
            website_link        = "https://www.turkaysoftware.com",
            github_link         = "https://github.com/turkaysoftware",
            // Other Links
            ts_wizard           = "https://www.turkaysoftware.com/ts-wizard",
            ts_donate           = "https://buymeacoffee.com/turkaysoftware";
        }
        // VERSIONS
        // ======================================================================================================
        public class TS_VersionEngine{
            public static string TS_SofwareVersion(int v_mode){
                string version_mode = "";
                switch (v_mode){
                    case 0:
                        version_mode = string.Format("{0} - v{1}", Application.ProductName, TS_VersionParser.ParseUINormalize(Application.ProductVersion));
                        break;
                    case 1:
                        version_mode = string.Format("v{0}", TS_VersionParser.ParseUINormalize(Application.ProductVersion));
                        break;
                }
                return version_mode;
            }
        }
        // VERSION PARSER
        // ======================================================================================================
        public static class TS_VersionParser{
            public static string ParseUINormalize(string version){
                Version v = Normalize(version);
                if (v.Revision > 0)
                    return $"{v.Major}.{v.Minor}.{v.Build}.{v.Revision}";
                if (v.Build > 0)
                    return $"{v.Major}.{v.Minor}.{v.Build}";
                return $"{v.Major}.{v.Minor}";
            }
            private static Version Normalize(string version){
                if (string.IsNullOrWhiteSpace(version))
                    return new Version(0, 0, 0, 0);
                version = version.Trim();
                var parts = version.Split('.');
                while (parts.Length < 4){
                    version += ".0";
                    parts = version.Split('.');
                }
                if (!Version.TryParse(version, out var v))
                    v = new Version(0, 0, 0, 0);
                return v;
            }
        }
        // TS MESSAGEBOX ENGINE
        // ======================================================================================================
        public static class TS_MessageBoxEngine{
            private static readonly Dictionary<int, KeyValuePair<MessageBoxButtons, MessageBoxIcon>> TSMessageBoxConfig = new Dictionary<int, KeyValuePair<MessageBoxButtons, MessageBoxIcon>>(){
                { 1, new KeyValuePair<MessageBoxButtons, MessageBoxIcon>(MessageBoxButtons.OK, MessageBoxIcon.Information) },           // Ok and Info
                { 2, new KeyValuePair<MessageBoxButtons, MessageBoxIcon>(MessageBoxButtons.OK, MessageBoxIcon.Warning) },               // Ok and Warning
                { 3, new KeyValuePair<MessageBoxButtons, MessageBoxIcon>(MessageBoxButtons.OK, MessageBoxIcon.Error) },                 // Ok and Error
                { 4, new KeyValuePair<MessageBoxButtons, MessageBoxIcon>(MessageBoxButtons.YesNo, MessageBoxIcon.Question) },           // Yes/No and Quest
                { 5, new KeyValuePair<MessageBoxButtons, MessageBoxIcon>(MessageBoxButtons.YesNo, MessageBoxIcon.Information) },        // Yes/No and Info
                { 6, new KeyValuePair<MessageBoxButtons, MessageBoxIcon>(MessageBoxButtons.YesNo, MessageBoxIcon.Warning) },            // Yes/No and Warning
                { 7, new KeyValuePair<MessageBoxButtons, MessageBoxIcon>(MessageBoxButtons.YesNo, MessageBoxIcon.Error) },              // Yes/No and Error
                { 8, new KeyValuePair<MessageBoxButtons, MessageBoxIcon>(MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) },        // Retry/Cancel and Error
                { 9, new KeyValuePair<MessageBoxButtons, MessageBoxIcon>(MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) },     // Yes/No/Cancel and Quest
                { 10, new KeyValuePair<MessageBoxButtons, MessageBoxIcon>(MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) }  // Yes/No/Cancel and Info
            };
            public static DialogResult TS_MessageBox(Form m_form, int m_mode, string m_message, string m_title = ""){
                if (m_form != null && m_form.InvokeRequired){
                    return (DialogResult)m_form.Invoke(new Func<DialogResult>(() => TS_MessageBox(m_form, m_mode, m_message, m_title)));
                }
                if (m_form != null){
                    BringFormToFront(m_form);
                }
                string m_box_title = string.IsNullOrEmpty(m_title) ? Application.ProductName : m_title;
                MessageBoxButtons m_button = MessageBoxButtons.OK;
                MessageBoxIcon m_icon = MessageBoxIcon.Information;
                if (TSMessageBoxConfig.ContainsKey(m_mode)){
                    var m_serialize = TSMessageBoxConfig[m_mode];
                    m_button = m_serialize.Key;
                    m_icon = m_serialize.Value;
                }
                return MessageBox.Show(m_form, m_message, m_box_title, m_button, m_icon);
            }
            private static void BringFormToFront(Form m_form){
                if (m_form.WindowState == FormWindowState.Minimized){
                    m_form.WindowState = FormWindowState.Normal;
                }
                m_form.BringToFront();
                m_form.Activate();
            }
        }
        // TS SOFTWARE COPYRIGHT DATE
        // ======================================================================================================
        public class TS_SoftwareCopyrightDate{
            public static string ts_scd_preloader = string.Format("\u00a9 2023-{0}, {1}.", DateTime.Now.Year, Application.CompanyName);
        }
        // SETTINGS SAVE PATHS
        // ======================================================================================================
        public static readonly string ts_sf = StartupPath + @"\" + Application.ProductName + "Settings.ini";
        public static readonly string ts_settings_container = Path.GetFileNameWithoutExtension(ts_sf);
        // SETTINGS SAVE CLASS
        // ======================================================================================================
        public class TSSettingsSave{
            private readonly string _iniFilePath;
            private readonly object _fileLock = new object();
            public TSSettingsSave(string filePath) { _iniFilePath = filePath; }
            public string TSReadSettings(string sectionName, string keyName){
                lock (_fileLock){
                    if (!File.Exists(_iniFilePath)) { return string.Empty; }
                    string[] lines = File.ReadAllLines(_iniFilePath, Encoding.UTF8);
                    bool isInSection = string.IsNullOrEmpty(sectionName);
                    foreach (string rawLine in lines){
                        string line = rawLine.Trim();
                        if (line.Length == 0 || line.StartsWith(";")) { continue; }
                        if (line.StartsWith("[") && line.EndsWith("]")){
                            isInSection = line.Equals("[" + sectionName + "]", StringComparison.OrdinalIgnoreCase);
                            continue;
                        }
                        if (isInSection){
                            int equalsIndex = line.IndexOf('=');
                            if (equalsIndex > 0){
                                string currentKey = line.Substring(0, equalsIndex).Trim();
                                if (currentKey.Equals(keyName, StringComparison.OrdinalIgnoreCase)){
                                    return line.Substring(equalsIndex + 1).Trim();
                                }
                            }
                        }
                    }
                    return string.Empty;
                }
            }
            public void TSWriteSettings(string sectionName, string keyName, string value){
                lock (_fileLock){
                    List<string> lines = File.Exists(_iniFilePath) ? File.ReadAllLines(_iniFilePath, Encoding.UTF8).ToList() : new List<string>();
                    bool sectionFound = string.IsNullOrEmpty(sectionName);
                    bool keyUpdated = false;
                    int insertIndex = lines.Count;
                    for (int i = 0; i < lines.Count; i++){
                        string trimmedLine = lines[i].Trim();
                        if (trimmedLine.Length == 0 || trimmedLine.StartsWith(";")) { continue; }
                        if (trimmedLine.StartsWith("[") && trimmedLine.EndsWith("]")){
                            if (sectionFound && !keyUpdated){
                                insertIndex = i;
                                break;
                            }
                            sectionFound = trimmedLine.Equals("[" + sectionName + "]", StringComparison.OrdinalIgnoreCase);
                            continue;
                        }
                        if (sectionFound){
                            int equalsIndex = trimmedLine.IndexOf('=');
                            if (equalsIndex > 0){
                                string currentKey = trimmedLine.Substring(0, equalsIndex).Trim();
                                if (currentKey.Equals(keyName, StringComparison.OrdinalIgnoreCase)){
                                    lines[i] = keyName + "=" + value;
                                    keyUpdated = true;
                                    break;
                                }
                            }
                        }
                    }
                    if (!sectionFound){
                        if (lines.Count > 0) { lines.Add(""); }
                        lines.Add("[" + sectionName + "]");
                        lines.Add(keyName + "=" + value);
                    }else if (!keyUpdated){
                        insertIndex = (insertIndex == lines.Count) ? lines.Count : insertIndex;
                        lines.Insert(insertIndex, keyName + "=" + value);
                    }
                    try{
                        File.WriteAllLines(_iniFilePath, lines, Encoding.UTF8);
                    }catch (IOException){ }
                }
            }
            public void TSDeleteSetting(string sectionName, string keyName){
                lock (_fileLock){
                    if (!File.Exists(_iniFilePath)) return;
                    List<string> lines = File.ReadAllLines(_iniFilePath, Encoding.UTF8).ToList();
                    bool isInSection = string.IsNullOrEmpty(sectionName);
                    for (int i = 0; i < lines.Count; i++){
                        string line = lines[i].Trim();
                        if (line.Length == 0 || line.StartsWith(";")) continue;
                        if (line.StartsWith("[") && line.EndsWith("]")){
                            isInSection = line.Equals("[" + sectionName + "]", StringComparison.OrdinalIgnoreCase);
                            continue;
                        }
                        if (isInSection){
                            int eqIndex = line.IndexOf('=');
                            if (eqIndex > 0){
                                string currentKey = line.Substring(0, eqIndex).Trim();
                                if (currentKey.Equals(keyName, StringComparison.OrdinalIgnoreCase)){
                                    lines.RemoveAt(i);
                                    break;
                                }
                            }
                        }
                    }
                    try{
                        File.WriteAllLines(_iniFilePath, lines, Encoding.UTF8);
                    }catch (IOException) { }
                }
            }
        }
        // READ LANG PATHS
        // ======================================================================================================
        public static readonly string ts_lf = Path.Combine(StartupPath, "v_langs");     // Main Path
        public static readonly string ts_lang_ar = ts_lf + @"\Arabic.ini";              // Arabic       | ar
        public static readonly string ts_lang_zh = ts_lf + @"\Chinese.ini";             // Chinese      | zh
        public static readonly string ts_lang_en = ts_lf + @"\English.ini";             // English      | en
        public static readonly string ts_lang_nl = ts_lf + @"\Dutch.ini";               // Nederlands   | nl
        public static readonly string ts_lang_fr = ts_lf + @"\French.ini";              // French       | fr
        public static readonly string ts_lang_de = ts_lf + @"\German.ini";              // German       | de
        public static readonly string ts_lang_hi = ts_lf + @"\Hindi.ini";               // Hindi        | hi
        public static readonly string ts_lang_it = ts_lf + @"\Italian.ini";             // Italian      | it
        public static readonly string ts_lang_ja = ts_lf + @"\Japanese.ini";            // Japanese     | ja
        public static readonly string ts_lang_ko = ts_lf + @"\Korean.ini";              // Korean       | ko
        public static readonly string ts_lang_pl = ts_lf + @"\Polish.ini";              // Polish       | pl
        public static readonly string ts_lang_pt = ts_lf + @"\Portuguese.ini";          // Portuguese   | pt
        public static readonly string ts_lang_ru = ts_lf + @"\Russian.ini";             // Russian      | ru
        public static readonly string ts_lang_es = ts_lf + @"\Spanish.ini";             // Spanish      | es
        public static readonly string ts_lang_tr = ts_lf + @"\Turkish.ini";             // Turkish      | tr
        // LANGUAGE MANAGE FUNCTIONS
        // ======================================================================================================
        public static readonly Dictionary<string, string> AllLanguageFiles = new Dictionary<string, string> {
            { "ar", ts_lang_ar },
            { "zh", ts_lang_zh },
            { "en", ts_lang_en },
            { "nl", ts_lang_nl },
            { "fr", ts_lang_fr },
            { "de", ts_lang_de },
            { "hi", ts_lang_hi },
            { "it", ts_lang_it },
            { "ja", ts_lang_ja },
            { "ko", ts_lang_ko },
            { "pl", ts_lang_pl },
            { "pt", ts_lang_pt },
            { "ru", ts_lang_ru },
            { "es", ts_lang_es },
            { "tr", ts_lang_tr },
        };
        public static string TSPreloaderSetDefaultLanguage(string ui_lang){
            bool anyLanguageFileExists = AllLanguageFiles.Values.Any(File.Exists);
            bool isUiLangValid = !string.IsNullOrEmpty(ui_lang) && AllLanguageFiles.ContainsKey(ui_lang) && File.Exists(AllLanguageFiles[ui_lang]);
            return anyLanguageFileExists && isUiLangValid ? ui_lang : "en";
        }
        public static List<string> AvailableLanguages = AllLanguageFiles.Values.Where(filePath => File.Exists(filePath)).ToList();
        // READ LANG CLASS
        // ======================================================================================================
        public class TSGetLangs{
            private readonly string _iniFilePath;
            private readonly object _cacheLock = new object();
            private string[] _cachedLines = null;
            private DateTime _lastFileWriteTime = DateTime.MinValue;
            public TSGetLangs(string iniFilePath) { _iniFilePath = iniFilePath; }
            public string TSReadLangs(string sectionName, string keyName){
                string[] iniLines = GetIniLinesCached();
                bool isInSection = string.IsNullOrEmpty(sectionName);
                foreach (string rawLine in iniLines){
                    string line = rawLine.Trim();
                    if (line.Length == 0 || line.StartsWith(";")) { continue; }
                    if (line.StartsWith("[") && line.EndsWith("]")){
                        isInSection = line.Equals("[" + sectionName + "]", StringComparison.OrdinalIgnoreCase);
                        continue;
                    }
                    if (isInSection){
                        int eqIndex = line.IndexOf('=');
                        if (eqIndex > 0){
                            string currentKey = line.Substring(0, eqIndex).Trim();
                            if (currentKey.Equals(keyName, StringComparison.OrdinalIgnoreCase)){
                                return line.Substring(eqIndex + 1).Trim();
                            }
                        }
                    }
                }
                return string.Empty;
            }
            private string[] GetIniLinesCached(){
                lock (_cacheLock){
                    try{
                        if (!File.Exists(_iniFilePath)) { return new string[0]; }
                        DateTime currentWriteTime = File.GetLastWriteTimeUtc(_iniFilePath);
                        if (_cachedLines == null || currentWriteTime != _lastFileWriteTime){
                            _cachedLines = File.ReadAllLines(_iniFilePath, Encoding.UTF8);
                            _lastFileWriteTime = currentWriteTime;
                        }
                        return _cachedLines;
                    }catch (IOException){
                        return new string[0];
                    }
                }
            }
        }
        // TS THEME ENGINE
        // ======================================================================================================
        public class TS_ThemeEngine{
            // LIGHT THEME COLORS
            // ====================================
            public static readonly Dictionary<string, Color> LightTheme = new Dictionary<string, Color>{
                // TS PRELOADER
                { "TSBT_BGColor", Color.FromArgb(236, 242, 248) },
                { "TSBT_BGColor2", Color.White },
                { "TSBT_AccentColor", Color.FromArgb(118, 85, 177) },
                { "TSBT_LabelColor1", Color.FromArgb(51, 51, 51) },
                { "TSBT_LabelColor2", Color.FromArgb(100, 100, 100) },
                { "TSBT_CloseBG", Color.FromArgb(25, 255, 255, 255) },
                { "TSBT_CloseBGHover", Color.FromArgb(50, 255, 255, 255) },
                // HEADER MENU COLOR MODE
                { "HeaderBGColorMain", Color.White },
                { "HeaderFEColorMain", Color.FromArgb(51, 51, 51) },
                // ACTIVE PAGE COLOR
                { "BtnActiveColor", Color.White },
                { "BtnDeActiveColor", Color.FromArgb(236, 242, 248) },
                // UI COLOR
                { "HeaderFEColor", Color.FromArgb(51, 51, 51) },
                { "HeaderBGColor", Color.FromArgb(236, 242, 248) },
                // ACCENT COLOR
                { "AccentColor", Color.FromArgb(118, 85, 177) },
                { "AccentColorHover", Color.FromArgb(133, 96, 197) },
                //
                { "SelectBoxBGColor", Color.White },
                { "SelectBoxBGColor2", Color.FromArgb(236, 242, 248) },
                { "SelectBoxFEColor", Color.FromArgb(51, 51, 51) },
                { "SelectBoxBorderColor", Color.FromArgb(223, 233, 243) },
                { "CheckBoxUnCheckBorderColor", Color.FromArgb(98, 98, 98) },
                //
                { "LeftMenuBGAndBorderColor", Color.FromArgb(236, 242, 248) },
                { "LeftMenuButtonHoverAndMouseDownColor", Color.White },
                { "LeftMenuButtonFEColor", Color.FromArgb(51, 51, 51) },
                { "PageContainerBGAndPageContentTotalColors", Color.White },
                { "ContentPanelBGColor", Color.FromArgb(236, 242, 248) },
                { "DataGridBGColor", Color.White },
                { "DataGridFEColor", Color.FromArgb(51, 51, 51) },
                { "DataGridColor", Color.FromArgb(226, 226, 226) },
                { "DataGridAlternatingColor", Color.FromArgb(236, 242, 248) },
                { "DataGridSelectionColor", Color.White },
                { "TextBoxBGColor", Color.White },
                { "TextBoxFEColor", Color.FromArgb(51, 51, 51) },
                { "DynamicThemeActiveBtnBG", Color.White },
                { "AccentGreen", Color.FromArgb(28, 122, 25) },
                { "AccentRed", Color.FromArgb(207, 24, 0) },
                { "HashCompareResultFE", Color.White }
            };
            // DARK THEME COLORS
            // ====================================
            public static readonly Dictionary<string, Color> DarkTheme = new Dictionary<string, Color>{
                // TS PRELOADER
                { "TSBT_BGColor", Color.FromArgb(27, 30, 34) },
                { "TSBT_BGColor2", Color.FromArgb(34, 38, 44) },
                { "TSBT_AccentColor", Color.FromArgb(164, 118, 243) },
                { "TSBT_LabelColor1", Color.WhiteSmoke },
                { "TSBT_LabelColor2", Color.FromArgb(176, 184, 196) },
                { "TSBT_CloseBG", Color.FromArgb(75, 34, 38, 44) },
                { "TSBT_CloseBGHover", Color.FromArgb(75, 27,30, 34) },
                // HEADER MENU COLOR MODE
                { "HeaderBGColorMain", Color.FromArgb(34, 38, 44) },
                { "HeaderFEColorMain", Color.FromArgb(222, 222, 222) },
                 // ACTIVE PAGE COLOR
                { "BtnActiveColor", Color.FromArgb(34, 38, 44) },
                { "BtnDeActiveColor", Color.FromArgb(27, 30, 34) },
                // UI COLOR
                { "HeaderFEColor", Color.WhiteSmoke },
                { "HeaderBGColor", Color.FromArgb(27, 30, 34) },
                // ACCENT COLOR
                { "AccentColor", Color.FromArgb(164, 118, 243) },
                { "AccentColorHover", Color.FromArgb(176, 136, 245) },
                 //
                { "SelectBoxBGColor", Color.FromArgb(34, 38, 44) },
                { "SelectBoxBGColor2", Color.FromArgb(27, 30, 34) },
                { "SelectBoxFEColor", Color.WhiteSmoke },
                { "SelectBoxBorderColor", Color.FromArgb(42, 47, 53) },
                { "CheckBoxUnCheckBorderColor", Color.FromArgb(170, 170, 170) },
                //
                { "LeftMenuBGAndBorderColor", Color.FromArgb(27, 30, 34) },
                { "LeftMenuButtonHoverAndMouseDownColor", Color.FromArgb(34, 38, 44) },
                { "LeftMenuButtonFEColor", Color.WhiteSmoke },
                { "PageContainerBGAndPageContentTotalColors", Color.FromArgb(34, 38, 44) },
                { "ContentPanelBGColor", Color.FromArgb(27, 30, 34) },
                { "DataGridBGColor", Color.FromArgb(34, 38, 44) },
                { "DataGridFEColor", Color.WhiteSmoke },
                { "DataGridColor", Color.FromArgb(42, 47, 53) },
                { "DataGridAlternatingColor", Color.FromArgb(27, 30, 34) },
                { "DataGridSelectionColor", Color.FromArgb(27, 30, 34) },
                { "TextBoxBGColor", Color.FromArgb(34, 38, 44) },
                { "TextBoxFEColor", Color.WhiteSmoke },
                { "DynamicThemeActiveBtnBG", Color.FromArgb(27, 30, 34) },
                { "AccentGreen", Color.FromArgb(38, 187, 33) },
                { "AccentRed", Color.FromArgb(255, 77, 77) },
                { "HashCompareResultFE", Color.FromArgb(27, 30, 34) }
            };
            // THEME SWITCHER
            // ====================================
            public static Color ColorMode(int theme, string key){
                if (theme == 0){
                    return DarkTheme.ContainsKey(key) ? DarkTheme[key] : Color.Transparent;
                }else if (theme == 1){
                    return LightTheme.ContainsKey(key) ? LightTheme[key] : Color.Transparent;
                }
                return Color.Transparent;
            }
        }
        // THEME MODE HELPER
        // ======================================================================================================
        public static class TSThemeModeHelper{
            private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;
            [DllImport("dwmapi.dll", PreserveSig = true)]
            private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
            [DllImport("uxtheme.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
            private static extern int SetWindowTheme(IntPtr hWnd, string pszSubAppName, string pszSubIdList);
            private static bool _isDarkModeEnabled = false;
            public static bool IsDarkModeEnabled => _isDarkModeEnabled;
            public static void SetThemeMode(bool enableTMode){
                _isDarkModeEnabled = enableTMode;
            }
            public static void InitializeThemeForForm(Form targetForm){
                if (targetForm == null || targetForm.IsDisposed)
                    return;
                ApplyThemeModeToForm(targetForm, _isDarkModeEnabled);
            }
            private static void ApplyThemeModeToForm(Form targetForm, bool enableRequire){
                if (targetForm == null || targetForm.IsDisposed)
                    return;
                int useDark = enableRequire ? 1 : 0;
                DwmSetWindowAttribute(targetForm.Handle, DWMWA_USE_IMMERSIVE_DARK_MODE, ref useDark, sizeof(int));
                ApplyScrollTheme(targetForm, enableRequire ? "DarkMode_Explorer" : "Explorer");
            }
            private static void ApplyScrollTheme(Control parentControl, string targetTheme){
                if (parentControl == null || parentControl.IsDisposed)
                    return;
                if (parentControl.Tag as string != targetTheme){
                    SetWindowTheme(parentControl.Handle, targetTheme, null);
                    parentControl.Tag = targetTheme;
                }
                foreach (Control childControl in parentControl.Controls){
                    ApplyScrollTheme(childControl, targetTheme);
                }
            }
        }
        public static int GetSystemTheme(int theme_mode){
            if (theme_mode == 2){
                using (var getSystemThemeKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize")){
                    theme_mode = (int)(getSystemThemeKey?.GetValue("SystemUsesLightTheme") ?? 1);
                }
            }
            return theme_mode;
        }
        // DPI SENSITIVE DYNAMIC IMAGE RENDERER
        // ======================================================================================================
        public static void TSImageRenderer(object baseTarget, Image sourceImage, int basePadding, ContentAlignment imageAlign = ContentAlignment.MiddleCenter){
            if (sourceImage == null || baseTarget == null) return;
            const int minImageSize = 16;
            try{
                int calculatedSize;
                Image previousImage = null;
                Image ResizeImage(Image targetImg, int targetSize){
                    Bitmap resizedEngine = new Bitmap(targetSize, targetSize, PixelFormat.Format32bppArgb);
                    using (Graphics renderGraphics = Graphics.FromImage(resizedEngine)){
                        renderGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        renderGraphics.SmoothingMode = SmoothingMode.AntiAlias;
                        renderGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        renderGraphics.CompositingQuality = CompositingQuality.HighQuality;
                        renderGraphics.DrawImage(targetImg, 0, 0, targetSize, targetSize);
                    }
                    return resizedEngine;
                }
                if (baseTarget is Control targetControl){
                    float dpi = targetControl.DeviceDpi > 0 ? targetControl.DeviceDpi : 96f;
                    float dpiScaleFactor = dpi / 96f;
                    int paddingWithScale = (int)Math.Round(basePadding * dpiScaleFactor);
                    //
                    calculatedSize = targetControl.Height - paddingWithScale;
                    if (calculatedSize <= 0) { calculatedSize = minImageSize; }
                    Image resizedImage = ResizeImage(sourceImage, calculatedSize);
                    if (targetControl is Button buttonMode){
                        previousImage = buttonMode.Image;
                        buttonMode.Image = resizedImage;
                        buttonMode.ImageAlign = imageAlign;
                    }else if (targetControl is PictureBox pictureBoxMode){
                        previousImage = pictureBoxMode.Image;
                        pictureBoxMode.Image = resizedImage;
                        pictureBoxMode.SizeMode = PictureBoxSizeMode.Zoom;
                    }else{
                        resizedImage.Dispose();
                    }
                }else if (baseTarget is ToolStripItem toolStripItemMode){
                    calculatedSize = toolStripItemMode.Height - basePadding;
                    if (calculatedSize <= 0) { calculatedSize = minImageSize; }
                    Image resizedImage = ResizeImage(sourceImage, calculatedSize);
                    previousImage = toolStripItemMode.Image;
                    toolStripItemMode.Image = resizedImage;
                }else{
                    return;
                }
                if (previousImage != null && previousImage != sourceImage) { previousImage.Dispose(); }
            }catch (Exception){ }
        }
        // DYNAMIC SIZE COUNT ALGORITHM
        // ======================================================================================================
        public static string TS_FormatSize(double bytes){
            string[] suffixes = { "B", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
            int suffixIndex = 0;
            double doubleBytes = bytes;
            while (doubleBytes >= 1024 && suffixIndex < suffixes.Length - 1){
                doubleBytes /= 1024;
                suffixIndex++;
            }
            return $"{doubleBytes:0.##} {suffixes[suffixIndex]}";
        }
        public static double TS_FormatSizeNoType(double bytes){
            while (bytes >= 1024){
                bytes /= 1024;
            }
            return Math.Round(bytes, 2);
        }
        public static double TS_FormatSizeToByte(double get_size, string get_unit){
            switch (get_unit.ToUpper().Trim()){
                case "B": return get_size;
                case "KB": return get_size * 1024;
                case "MB": return get_size * Math.Pow(1024, 2);
                case "GB": return get_size * Math.Pow(1024, 3);
                case "TB": return get_size * Math.Pow(1024, 4);
                case "PB": return get_size * Math.Pow(1024, 5);
                case "EB": return get_size * Math.Pow(1024, 6);
                case "ZB": return get_size * Math.Pow(1024, 7);
                case "YB": return get_size * Math.Pow(1024, 8);
                default: return 0;
            }
        }
        // TS NATURAL SORT KEY ALGORITHM
        // ======================================================================================================
        public static string TSNaturalSortKey(string input, CultureInfo culture, int paddingLength = 30){
            if (input == null) { return ""; }
            string padded = Regex.Replace(input, @"\d+", match => match.Value.PadLeft(paddingLength, '0'));
            string normalized = padded.Normalize(NormalizationForm.FormD);
            if (culture == null) { culture = CultureInfo.CurrentCulture; }
            string lowerCased = normalized.ToLower(culture);
            return lowerCased;
        }
        // INTERNET CONNECTION STATUS
        // ======================================================================================================
        public static bool IsNetworkCheck(){
            try{
                var check_net = (HttpWebRequest)WebRequest.Create("http://clients3.google.com/generate_204");
                check_net.Method = "GET";
                check_net.KeepAlive = false;
                check_net.Proxy = null;
                check_net.Timeout = 2500;
                check_net.ReadWriteTimeout = 2500;
                check_net.AllowAutoRedirect = false;
                using (var resp_net = (HttpWebResponse)check_net.GetResponse()){
                    return resp_net.StatusCode == HttpStatusCode.NoContent;
                }
            }catch (WebException){
                return false;
            }
        }
        // DPI AWARE V2
        // ======================================================================================================
        [DllImport("user32.dll", PreserveSig = true)]
        public static extern bool SetProcessDpiAwarenessContext(IntPtr dpiFlag);
        public static readonly IntPtr DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2 = new IntPtr(-4);
    }
}