using System;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using static Vimera.VimeraModules;

namespace Vimera{
    public partial class VimeraAbout : Form{
        public VimeraAbout(){ InitializeComponent(); CheckForIllegalCrossThreadCalls = false; }
 
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
                About_L3.ForeColor = Vimera.ui_colors[8];
                About_GitHubBtn.BackColor = Vimera.ui_colors[11];
                About_GitHubBtn.FlatAppearance.BorderColor = Vimera.ui_colors[11];
                About_GitHubBtn.ForeColor = Vimera.ui_colors[12];
                // ======================================================================================================
                // GLOBAL LANGS PATH
                VimeraGetLangs v_lang = new VimeraGetLangs(Vimera.lang_path);
                // TEXTS
                Text = string.Format(Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("VimeraAbout", "va_title").Trim())), Application.ProductName);
                About_L1.Text = string.Format("{0} {1}", Application.ProductName, Application.ProductVersion.Substring(0, 4));
                About_L2.Text = string.Format(Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("VimeraAbout", "va_copyright").Trim())), "\u00a9", DateTime.Now.Year, Application.CompanyName);
                About_L3.Text = string.Format(Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("VimeraAbout", "va_open_source").Trim())), Application.ProductName);
                About_GitHubBtn.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(v_lang.VimeraReadLangs("VimeraAbout", "va_github_page").Trim()));
            }catch (Exception){ }
        }
        private void About_GitHubBtn_Click(object sender, EventArgs e){
            try{
                Process.Start(Vimera.github_link + "/vimera");
            }catch (Exception){ }
        }
    }
}