﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Vimera{
    internal class TSModules{
        // LINK SYSTEM
        // ======================================================================================================
        public class TS_LinkSystem{
            public const string
            // Main Control Links
            github_link_lv      = "https://raw.githubusercontent.com/turkaysoftware/vimera/main/Vimera/SoftwareVersion.txt",
            github_link_lr      = "https://github.com/turkaysoftware/vimera/releases/latest",
            // Social Links
            website_link        = "https://www.turkaysoftware.com",
            twitter_x_link      = "https://x.com/turkaysoftware",
            instagram_link      = "https://www.instagram.com/erayturkayy/",
            github_link         = "https://github.com/turkaysoftware",
            youtube_link        = "https://www.youtube.com/@turkaysoftware",
            // Other Links
            ts_wizard           = "https://www.turkaysoftware.com/ts-wizard",
            ts_bmac             = "https://buymeacoffee.com/turkaysoftware";
        }
        // VERSIONS
        // ======================================================================================================
        public class TS_VersionEngine{
            public static string TS_SofwareVersion(int v_type, int v_mode){
                string version_mode = "";
                string versionSubstring = v_mode == 0 ? Application.ProductVersion.Substring(0, 5) : Application.ProductVersion.Substring(0, 7);
                switch (v_type){
                    case 0:
                        version_mode = v_mode == 0 ? $"{Application.ProductName} - v{versionSubstring}" : $"{Application.ProductName} - v{Application.ProductVersion.Substring(0, 7)}";
                        break;
                    case 1:
                        version_mode = $"v{versionSubstring}";
                        break;
                    case 2:
                        version_mode = versionSubstring;
                        break;
                    default:
                        break;
                }
                return version_mode;
            }
        }
        // TS MESSAGEBOX ENGINE
        // ======================================================================================================
        public static class TS_MessageBoxEngine{
            private static readonly Dictionary<int, KeyValuePair<MessageBoxButtons, MessageBoxIcon>> TSMessageBoxConfig = new Dictionary<int, KeyValuePair<MessageBoxButtons, MessageBoxIcon>>(){
                { 1, new KeyValuePair<MessageBoxButtons, MessageBoxIcon>(MessageBoxButtons.OK, MessageBoxIcon.Information) },       // Ok ve Bilgi
                { 2, new KeyValuePair<MessageBoxButtons, MessageBoxIcon>(MessageBoxButtons.OK, MessageBoxIcon.Warning) },           // Ok ve Uyarı
                { 3, new KeyValuePair<MessageBoxButtons, MessageBoxIcon>(MessageBoxButtons.OK, MessageBoxIcon.Error) },             // Ok ve Hata
                { 4, new KeyValuePair<MessageBoxButtons, MessageBoxIcon>(MessageBoxButtons.YesNo, MessageBoxIcon.Question) },       // Yes/No ve Soru
                { 5, new KeyValuePair<MessageBoxButtons, MessageBoxIcon>(MessageBoxButtons.YesNo, MessageBoxIcon.Information) },    // Yes/No ve Bilgi
                { 6, new KeyValuePair<MessageBoxButtons, MessageBoxIcon>(MessageBoxButtons.YesNo, MessageBoxIcon.Warning) },        // Yes/No ve Uyarı
                { 7, new KeyValuePair<MessageBoxButtons, MessageBoxIcon>(MessageBoxButtons.YesNo, MessageBoxIcon.Error) },          // Yes/No ve Hata
                { 8, new KeyValuePair<MessageBoxButtons, MessageBoxIcon>(MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) },    // Retry/Cancel ve Hata
                { 9, new KeyValuePair<MessageBoxButtons, MessageBoxIcon>(MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) }  // Yes/No/Cancel ve Soru
            };
            public static DialogResult TS_MessageBox(Form m_form, int m_mode, string m_message, string m_title = ""){
                if (m_form.InvokeRequired){
                    m_form.Invoke((Action)(() => BringFormToFront(m_form)));
                }else{
                    BringFormToFront(m_form);
                }
                //
                string m_box_title = string.IsNullOrEmpty(m_title) ? Application.ProductName : m_title;
                //
                MessageBoxButtons m_button = MessageBoxButtons.OK;
                MessageBoxIcon m_icon = MessageBoxIcon.Information;
                //
                if (TSMessageBoxConfig.ContainsKey(m_mode)){
                    var m_serialize = TSMessageBoxConfig[m_mode];
                    m_button = m_serialize.Key;
                    m_icon = m_serialize.Value;
                }
                //
                return MessageBox.Show(m_form, m_message, m_box_title, m_button, m_icon);
            }
            private static void BringFormToFront(Form m_form){
                if (m_form.WindowState == FormWindowState.Minimized)
                    m_form.WindowState = FormWindowState.Normal;
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
        public static string ts_df = Application.StartupPath;
        public static string ts_sf = ts_df + @"\" + Application.ProductName + "Settings.ini";
        public static string ts_settings_container = Path.GetFileNameWithoutExtension(ts_sf);
        // SETTINGS SAVE CLASS
        // ======================================================================================================
        public class TSSettingsSave{
            [DllImport("kernel32.dll")]
            private static extern int WritePrivateProfileString(string section, string key, string val, string filePath);
            [DllImport("kernel32.dll")]
            private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
            private readonly string _settingFilePath;
            public TSSettingsSave(string filePath){ _settingFilePath = filePath; }
            public string TSReadSettings(string episode, string settingName){
                StringBuilder stringBuilder = new StringBuilder(4096);
                GetPrivateProfileString(episode, settingName, string.Empty, stringBuilder, 4096, _settingFilePath);
                return stringBuilder.ToString();
            }
            public int TSWriteSettings(string episode, string settingName, string value){
                return WritePrivateProfileString(episode, settingName, value, _settingFilePath);
            }
        }
        // READ LANG PATHS
        // ======================================================================================================
        public static string ts_lf = @"v_langs";                            // Main Path
        public static string ts_lang_en = ts_lf + @"\English.ini";          // English      | en
        public static string ts_lang_tr = ts_lf + @"\Turkish.ini";          // Turkish      | tr
        // READ LANG CLASS
        // ======================================================================================================
        public class TSGetLangs{
            [DllImport("kernel32.dll")]
            private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
            private readonly string _readFilePath;
            public TSGetLangs(string filePath){ _readFilePath = filePath; }
            public string TSReadLangs(string episode, string settingName){
                StringBuilder stringBuilder = new StringBuilder(4096);
                GetPrivateProfileString(episode, settingName, string.Empty, stringBuilder, 4096, _readFilePath);
                return stringBuilder.ToString();
            }
        }
        // TS STRING ENCODER
        // ======================================================================================================
        public static string TS_String_Encoder(string get_text){
            return Encoding.UTF8.GetString(Encoding.Default.GetBytes(get_text)).Trim();
        }
        // TURKISH LETTER CONVERTER
        // ======================================================================================================
        public static string TS_TR_LetterConverter(string called_text){
            if (string.IsNullOrEmpty(called_text)) { return called_text; }
            StringBuilder str_con = new StringBuilder(called_text);
            str_con.Replace('Ç', 'C').Replace('ç', 'c');
            str_con.Replace('Ğ', 'G').Replace('ğ', 'g');
            str_con.Replace('İ', 'I').Replace('ı', 'i');
            str_con.Replace('Ö', 'O').Replace('ö', 'o');
            str_con.Replace('Ş', 'S').Replace('ş', 's');
            str_con.Replace('Ü', 'U').Replace('ü', 'u');
            return str_con.ToString().Trim();
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
                { "TSBT_AccentColor", Color.FromArgb(126, 27, 156) },
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
                { "AccentColor", Color.FromArgb(126, 27, 156) },
                { "AccentColorHover", Color.FromArgb(168, 38, 207) },
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
                { "TSBT_BGColor", Color.FromArgb(21, 23, 32) },
                { "TSBT_BGColor2", Color.FromArgb(25, 31, 42) },
                { "TSBT_AccentColor", Color.FromArgb(229, 33, 255) },
                { "TSBT_LabelColor1", Color.WhiteSmoke },
                { "TSBT_LabelColor2", Color.FromArgb(176, 184, 196) },
                { "TSBT_CloseBG", Color.FromArgb(75, 25, 31, 42) },
                { "TSBT_CloseBGHover", Color.FromArgb(100, 25, 31, 42) },
                // HEADER MENU COLOR MODE
                { "HeaderBGColorMain", Color.FromArgb(25, 31, 42) },
                { "HeaderFEColorMain", Color.FromArgb(222, 222, 222) },
                 // ACTIVE PAGE COLOR
                { "BtnActiveColor", Color.FromArgb(25, 31, 42) },
                { "BtnDeActiveColor", Color.FromArgb(21, 23, 32) },
                // UI COLOR
                { "HeaderFEColor", Color.WhiteSmoke },
                { "HeaderBGColor", Color.FromArgb(21, 23, 32) },
                // ACCENT COLOR
                { "AccentColor", Color.FromArgb(229, 33, 255) },
                { "AccentColorHover", Color.FromArgb(234, 77, 255) },
                //
                { "LeftMenuBGAndBorderColor", Color.FromArgb(21, 23, 32) },
                { "LeftMenuButtonHoverAndMouseDownColor", Color.FromArgb(25, 31, 42) },
                { "LeftMenuButtonFEColor", Color.WhiteSmoke },
                { "PageContainerBGAndPageContentTotalColors", Color.FromArgb(25, 31, 42) },
                { "ContentPanelBGColor", Color.FromArgb(21, 23, 32) },
                { "DataGridBGColor", Color.FromArgb(25, 31, 42) },
                { "DataGridFEColor", Color.WhiteSmoke },
                { "DataGridColor", Color.FromArgb(36, 45, 61) },
                { "DataGridAlternatingColor", Color.FromArgb(21, 23, 32) },
                { "DataGridSelectionColor", Color.FromArgb(21, 23, 32) },
                { "TextBoxBGColor", Color.FromArgb(25, 31, 42) },
                { "TextBoxFEColor", Color.WhiteSmoke },
                { "DynamicThemeActiveBtnBG", Color.FromArgb(21, 23, 32) },
                { "AccentGreen", Color.FromArgb(38, 187, 33) },
                { "AccentRed", Color.FromArgb(255, 51, 51) },
                { "HashCompareResultFE", Color.FromArgb(21, 23, 32) }
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
        public static string TS_NaturalSortKey(string get_name){
            return Regex.Replace(get_name, @"\d+", new_match => new_match.Value.PadLeft(30, '0'));
        }
        // INTERNET CONNECTION STATUS
        // ======================================================================================================
        public static bool IsNetworkCheck(){
            try{
                HttpWebRequest server_request = (HttpWebRequest)WebRequest.Create("http://clients3.google.com/generate_204");
                server_request.KeepAlive = false;
                server_request.Timeout = 2500;
                using (var server_response = (HttpWebResponse)server_request.GetResponse()){
                    return server_response.StatusCode == HttpStatusCode.NoContent;
                }
            }catch{
                return false;
            }
        }
        // TITLE BAR SETTINGS DWM API
        // ======================================================================================================
        [DllImport("DwmApi")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, int[] attrValue, int attrSize);
        // DPI AWARE V2
        // ======================================================================================================
        [DllImport("user32.dll")]
        public static extern bool SetProcessDpiAwarenessContext(IntPtr dpiFlag);
    }
}