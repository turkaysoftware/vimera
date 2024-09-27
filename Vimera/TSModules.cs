using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Vimera{
    internal class TSModules{
        // LINK SYSTEM
        // ======================================================================================================
        public class TS_LinkSystem{
            public string
            website_link = "https://www.turkaysoftware.com",
            twitter_link = "https://x.com/turkaysoftware",
            instagram_link = "https://www.instagram.com/erayturkayy/",
            github_link = "https://github.com/turkaysoftware",
            //
            github_link_lt = "https://raw.githubusercontent.com/turkaysoftware/vimera/main/Vimera/SoftwareVersion.txt",
            github_link_lr = "https://github.com/turkaysoftware/vimera/releases/latest";
        }
        // ======================================================================================================
        // VERSIONS
        public class TS_VersionEngine{
            public string TS_SofwareVersion(int v_type, int v_mode){
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
        // ======================================================================================================
        // SAVE PATHS
        public static string vimera_lf = @"v_langs";                                // Main Path
        public static string vimera_lang_en = vimera_lf + @"\English.ini";          // English    | en
        public static string vimera_lang_tr = vimera_lf + @"\Turkish.ini";          // Turkish    | tr
        // ======================================================================================================
        // VIMERA SETTINGS SAVE CLASS
        public class TSGetLangs{
            [DllImport("kernel32.dll")]
            private static extern long GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
            private readonly string _saveFilePath;
            public TSGetLangs(string filePath) { _saveFilePath = filePath; }
            public string TSReadLangs(string episode, string settingName){
                StringBuilder stringBuilder = new StringBuilder(512);
                GetPrivateProfileString(episode, settingName, string.Empty, stringBuilder, 511, _saveFilePath);
                return stringBuilder.ToString();
            }
        }
        // TS THEME ENGINE
        // ======================================================================================================
        public class TS_ThemeEngine{
            // Light Theme Colors
            public static readonly Dictionary<string, Color> LightTheme = new Dictionary<string, Color>{
                // HEADER MENU COLOR MODE
                { "HeaderBGColorMain", Color.FromArgb(222, 222, 222) },
                { "HeaderFEColorMain", Color.FromArgb(31, 31, 31) },
                // ACTIVE PAGE COLOR
                { "BtnActiveColor", Color.WhiteSmoke },
                { "BtnDeActiveColor", Color.FromArgb(235, 235, 235) },
                // UI COLOR
                { "HeaderFEColor", Color.FromArgb(32, 32, 32) },
                { "HeaderBGColor", Color.FromArgb(235, 235, 235) },
                { "LeftMenuBGAndBorderColor", Color.FromArgb(235, 235, 235) },
                { "LeftMenuButtonHoverAndMouseDownColor", Color.WhiteSmoke },
                { "LeftMenuButtonFEColor", Color.FromArgb(32, 32, 32) },
                { "PageContainerBGAndPageContentTotalColors", Color.WhiteSmoke },
                { "ContentPanelBGColor", Color.FromArgb(235, 235, 235) },
                { "DataGridBGColor", Color.White },
                { "DataGridFEColor", Color.FromArgb(32, 32, 32) },
                { "DataGridColor", Color.FromArgb(217, 217, 217) },
                { "DataGridAlternatingColor", Color.FromArgb(235, 235, 235) },
                { "DataGridSelectionColor", Color.WhiteSmoke },
                { "MainAccentColor", Color.FromArgb(105, 81, 147) },
                { "TextBoxBGColor", Color.WhiteSmoke },
                { "TextBoxFEColor", Color.FromArgb(32, 32, 32) },
                { "DynamicThemeActiveBtnBG", Color.WhiteSmoke },
                { "HashCompareSuccess", Color.FromArgb(18, 119, 69) },
                { "HashCompareFailed", Color.FromArgb(156, 37, 77) },
                { "HashCompareResultFE", Color.WhiteSmoke }
            };
            // Dark Theme Colors
            public static readonly Dictionary<string, Color> DarkTheme = new Dictionary<string, Color>{
                // HEADER MENU COLOR MODE
                { "HeaderBGColorMain", Color.FromArgb(31, 31, 31) },
                { "HeaderFEColorMain", Color.FromArgb(222, 222, 222) },
                 // ACTIVE PAGE COLOR
                { "BtnActiveColor", Color.FromArgb(31, 31, 31) },
                { "BtnDeActiveColor", Color.FromArgb(24, 24, 24) },
                // UI COLOR
                { "HeaderFEColor", Color.WhiteSmoke },
                { "HeaderBGColor", Color.FromArgb(24, 24, 24) },
                { "LeftMenuBGAndBorderColor", Color.FromArgb(24, 24, 24) },
                { "LeftMenuButtonHoverAndMouseDownColor", Color.FromArgb(31, 31, 31) },
                { "LeftMenuButtonFEColor", Color.WhiteSmoke },
                { "PageContainerBGAndPageContentTotalColors", Color.FromArgb(31, 31, 31) },
                { "ContentPanelBGColor", Color.FromArgb(24, 24, 24) },
                { "DataGridBGColor", Color.FromArgb(31, 31, 31) },
                { "DataGridFEColor", Color.WhiteSmoke },
                { "DataGridColor", Color.FromArgb(50, 50, 50) },
                { "DataGridAlternatingColor", Color.FromArgb(24, 24, 24) },
                { "DataGridSelectionColor", Color.WhiteSmoke },
                { "MainAccentColor", Color.FromArgb(113, 88, 157) },
                { "TextBoxBGColor", Color.FromArgb(31, 31, 31) },
                { "TextBoxFEColor", Color.WhiteSmoke },
                { "DynamicThemeActiveBtnBG", Color.WhiteSmoke },
                { "HashCompareSuccess", Color.FromArgb(18, 119, 69) },
                { "HashCompareFailed", Color.FromArgb(156, 37, 77) },
                { "HashCompareResultFE", Color.WhiteSmoke }
            };
            // Method to get color for the current theme
            public static Color ColorMode(int theme, string key){
                if (theme == 0){
                    return DarkTheme.ContainsKey(key) ? DarkTheme[key] : Color.Transparent;
                }else if (theme == 1){
                    return LightTheme.ContainsKey(key) ? LightTheme[key] : Color.Transparent;
                }
                return Color.Transparent;
            }
        }
        // ======================================================================================================
        // SAVE PATHS
        public static string ts_df = Application.StartupPath;
        public static string ts_sf = ts_df + @"\VimeraSettings.ini";
        public static string ts_settings_container = Path.GetFileNameWithoutExtension(ts_sf);
        // ======================================================================================================
        // VIMERA SETTINGS SAVE CLASS
        public class TSSettingsSave{
            [DllImport("kernel32.dll")]
            private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
            [DllImport("kernel32.dll")]
            private static extern long GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
            private readonly string _saveFilePath;
            public TSSettingsSave(string filePath) { _saveFilePath = filePath; }
            public string TSReadSettings(string episode, string settingName){
                StringBuilder stringBuilder = new StringBuilder(512);
                GetPrivateProfileString(episode, settingName, string.Empty, stringBuilder, 511, _saveFilePath);
                return stringBuilder.ToString();
            }
            public long TSWriteSettings(string episode, string settingName, string value){
                return WritePrivateProfileString(episode, settingName, value, _saveFilePath);
            }
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
        // TITLE BAR SETTINGS DWM API
        // ======================================================================================================
        [DllImport("DwmApi")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, int[] attrValue, int attrSize);
        // ======================================================================================================
        // DPI AWARE
        [DllImport("user32.dll")]
        public static extern bool SetProcessDPIAware();
    }
}