using System;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
//
using static Vimera.VimeraModules;

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
                BackColor = Vimera.ui_colors[5];
                About_BG_Panel.BackColor = Vimera.ui_colors[6];
                About_L1.ForeColor = Vimera.ui_colors[8];
                About_L2.ForeColor = Vimera.ui_colors[8];
                About_XBtn.BackColor = Vimera.ui_colors[11];
                About_XBtn.FlatAppearance.BorderColor = Vimera.ui_colors[11];
                About_XBtn.ForeColor = Vimera.ui_colors[12];
                About_GitHubBtn.BackColor = Vimera.ui_colors[11];
                About_GitHubBtn.FlatAppearance.BorderColor = Vimera.ui_colors[11];
                About_GitHubBtn.ForeColor = Vimera.ui_colors[12];
                // ======================================================================================================
                // GLOBAL LANGS PATH
                TSGetLangs v_lang = new TSGetLangs(Vimera.lang_path);
                VimeraVersionEngine vimera_version = new VimeraVersionEngine();
                // TEXTS
                Text = string.Format(Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.TSReadLangs("VimeraAbout", "va_title").Trim())), Application.ProductName);
                About_L1.Text = vimera_version.VimeraVersion(0, Vimera.v_version_mode);
                About_L2.Text = string.Format(Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.TSReadLangs("VimeraAbout", "va_copyright").Trim())), "\u00a9", DateTime.Now.Year, Application.CompanyName);
                About_XBtn.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.TSReadLangs("VimeraAbout", "va_twitter_page").Trim()));
                About_GitHubBtn.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.TSReadLangs("VimeraAbout", "va_github_page").Trim()));
            }catch (Exception){ }
        }
        // ======================================================================================================
        // ABOUT TWITTER ROTATE BUTTON
        private void About_XBtn_Click(object sender, EventArgs e){
            try{
                Process.Start(TS_LinkSystem.twitter_link);
            }catch (Exception){ }
        }
        // ======================================================================================================
        // ABOUT GITHUB ROTATE BUTTON
        private void About_GitHubBtn_Click(object sender, EventArgs e){
            try{
                Process.Start(TS_LinkSystem.github_link);
            }catch (Exception){ }
        }
    }
}