using System;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
//
using static Vimera.TSModules;

namespace Vimera{
    public partial class VimeraAbout : Form{
        public VimeraAbout(){ InitializeComponent(); CheckForIllegalCrossThreadCalls = false; }
        // ======================================================================================================
        // MEDIA LINK SYSTEM
        TS_LinkSystem TS_LinkSystem = new TS_LinkSystem();
        private void VimeraAbout_Load(object sender, EventArgs e){
            // COLOR SETTINGS
            try{
                // GET PRELOAD SETTINGS
                about_preloader();
                // IMAGES
                About_Image.BackgroundImage = Properties.Resources.vimera_logo;
            }catch (Exception) { }
        }
        // DYNAMIC UI
        // ======================================================================================================
        public void about_preloader(){
            try{
                if (Vimera.theme == 1){
                    try { if (DwmSetWindowAttribute(Handle, 20, new[] { 1 }, 4) != 1){ DwmSetWindowAttribute(Handle, 20, new[]{ 0 }, 4); } }catch (Exception){ }
                }else if (Vimera.theme == 0 || Vimera.theme == 2){
                    try { if (DwmSetWindowAttribute(Handle, 19, new[] { 1 }, 4) != 0){ DwmSetWindowAttribute(Handle, 20, new[]{ 1 }, 4); } }catch (Exception){ }
                }
                // COLORS
                BackColor = TS_ThemeEngine.ColorMode(Vimera.theme, "PageContainerBGAndPageContentTotalColors");
                About_BG_Panel.BackColor = TS_ThemeEngine.ColorMode(Vimera.theme, "ContentPanelBGColor");
                About_L1.ForeColor = TS_ThemeEngine.ColorMode(Vimera.theme, "LeftMenuButtonFEColor");
                About_L2.ForeColor = TS_ThemeEngine.ColorMode(Vimera.theme, "LeftMenuButtonFEColor");
                //
                About_WebsiteBtn.BackColor = TS_ThemeEngine.ColorMode(Vimera.theme, "MainAccentColor");
                About_WebsiteBtn.FlatAppearance.BorderColor = TS_ThemeEngine.ColorMode(Vimera.theme, "MainAccentColor");
                About_WebsiteBtn.FlatAppearance.MouseDownBackColor = TS_ThemeEngine.ColorMode(Vimera.theme, "MainAccentColor");
                About_WebsiteBtn.ForeColor = TS_ThemeEngine.ColorMode(Vimera.theme, "DynamicThemeActiveBtnBG");
                //
                About_XBtn.BackColor = TS_ThemeEngine.ColorMode(Vimera.theme, "MainAccentColor");
                About_XBtn.FlatAppearance.BorderColor = TS_ThemeEngine.ColorMode(Vimera.theme, "MainAccentColor");
                About_XBtn.FlatAppearance.MouseDownBackColor = TS_ThemeEngine.ColorMode(Vimera.theme, "MainAccentColor");
                About_XBtn.ForeColor = TS_ThemeEngine.ColorMode(Vimera.theme, "DynamicThemeActiveBtnBG");
                //
                About_InstagramBtn.BackColor = TS_ThemeEngine.ColorMode(Vimera.theme, "MainAccentColor");
                About_InstagramBtn.FlatAppearance.BorderColor = TS_ThemeEngine.ColorMode(Vimera.theme, "MainAccentColor");
                About_InstagramBtn.FlatAppearance.MouseDownBackColor = TS_ThemeEngine.ColorMode(Vimera.theme, "MainAccentColor");
                About_InstagramBtn.ForeColor = TS_ThemeEngine.ColorMode(Vimera.theme, "DynamicThemeActiveBtnBG");
                //
                About_GitHubBtn.BackColor = TS_ThemeEngine.ColorMode(Vimera.theme, "MainAccentColor");
                About_GitHubBtn.FlatAppearance.BorderColor = TS_ThemeEngine.ColorMode(Vimera.theme, "MainAccentColor");
                About_GitHubBtn.FlatAppearance.MouseDownBackColor = TS_ThemeEngine.ColorMode(Vimera.theme, "MainAccentColor");
                About_GitHubBtn.ForeColor = TS_ThemeEngine.ColorMode(Vimera.theme, "DynamicThemeActiveBtnBG");
                // ======================================================================================================
                TSGetLangs software_lang = new TSGetLangs(Vimera.lang_path);
                TS_VersionEngine vimera_version = new TS_VersionEngine();
                // TEXTS
                Text = string.Format(Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("SoftwareAbout", "sa_title").Trim())), Application.ProductName);
                About_L1.Text = vimera_version.TS_SofwareVersion(0, Vimera.ts_version_mode);
                About_L2.Text = string.Format(Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("SoftwareAbout", "sa_copyright").Trim())), "\u00a9", DateTime.Now.Year, Application.CompanyName);
                About_WebsiteBtn.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("SoftwareAbout", "sa_website_page").Trim()));
                About_XBtn.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("SoftwareAbout", "sa_twitter_page").Trim()));
                About_InstagramBtn.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("SoftwareAbout", "sa_instagram_page").Trim()));
                About_GitHubBtn.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(software_lang.TSReadLangs("SoftwareAbout", "sa_github_page").Trim()));
            }catch (Exception){ }
        }
        // WEBSITE LINK
        // ======================================================================================================
        private void About_WebsiteBtn_Click(object sender, EventArgs e){
            try{
                Process.Start(TS_LinkSystem.website_link);
            }catch (Exception){ }
        }
        // X LINK
        // ======================================================================================================
        private void About_XBtn_Click(object sender, EventArgs e){
            try{
                Process.Start(TS_LinkSystem.twitter_link);
            }catch (Exception){ }
        }
        // INSTAGRAM LINK
        // ======================================================================================================
        private void About_InstagramBtn_Click(object sender, EventArgs e){
            try{
                Process.Start(TS_LinkSystem.instagram_link);
            }catch (Exception){ }
        }
        // ======================================================================================================
        private void About_GitHubBtn_Click(object sender, EventArgs e){
            try{
                Process.Start(TS_LinkSystem.github_link);
            }catch (Exception){ }
        }
    }
}