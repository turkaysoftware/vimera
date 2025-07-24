﻿using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Reflection;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;
//
using static Vimera.TSModules;

namespace Vimera{
    public partial class VimeraAbout : Form{
        public VimeraAbout(){
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, AboutTable, new object[] { true });
            //
            PanelHeader.Parent = ImageAbout;
            CloseAboutBtn.Parent = PanelHeader;
            //
            TSImageRenderer(CloseAboutBtn, Properties.Resources.ts_close, 20);
        }
        // DRAGGING VARIABLES
        // ======================================================================================================
        private bool formIsDragging = false;
        private Point formDraggingStartPoint = new Point(0, 0);
        // ABOUT LOAD
        // ======================================================================================================
        private void VimeraAbout_Load(object sender, EventArgs e){
            try{
                LabelDeveloper.Text = Application.CompanyName;
                LabelSoftware.Text = Application.ProductName;
                LabelVersion.Text = TS_VersionEngine.TS_SofwareVersion(1, Program.ts_version_mode);
                LabelCopyright.Text = TS_SoftwareCopyrightDate.ts_scd_preloader;
                //
                AboutTable.Columns.Add("x", "x");
                AboutTable.Columns.Add("x", "x");
                AboutTable.Columns[0].Width = 110;
                var get_langs_file = new List<string>{
                    ts_lang_en,
                    ts_lang_tr,
                }.Where(check_file => File.Exists(check_file)).ToList();
                foreach (var file in get_langs_file){
                    TSSettingsSave software_read_settings = new TSSettingsSave(file);
                    string[] get_name = TS_String_Encoder(software_read_settings.TSReadSettings("Main", "lang_name")).Split('/');
                    string get_lang_translator = TS_String_Encoder(software_read_settings.TSReadSettings("Main", "translator"));
                    AboutTable.Rows.Add(get_name[0].Trim(), get_lang_translator.Trim());
                }
                AboutTable.AllowUserToResizeColumns = false;
                foreach (DataGridViewColumn A_Column in AboutTable.Columns) { A_Column.SortMode = DataGridViewColumnSortMode.NotSortable; }
                AboutTable.ClearSelection();
                // GET PRELOAD SETTINGS
                about_preloader();
            }catch (Exception){ }
        }
        // DYNAMIC UI
        // ======================================================================================================
        public void about_preloader(){
            try{
                // COLOR SETTINGS
                int set_attribute = Vimera.theme == 1 ? 20 : 19;
                if (DwmSetWindowAttribute(Handle, set_attribute, new[] { 1 }, 4) != Vimera.theme){
                    DwmSetWindowAttribute(Handle, 20, new[] { Vimera.theme == 1 ? 0 : 1 }, 4);
                }
                BackColor = TS_ThemeEngine.ColorMode(Vimera.theme, "TSBT_BGColor2");
                PanelTxt.BackColor = TS_ThemeEngine.ColorMode(Vimera.theme, "TSBT_BGColor2");
                //
                LabelDeveloper.ForeColor = TS_ThemeEngine.ColorMode(Vimera.theme, "TSBT_LabelColor1");
                LabelSoftware.ForeColor = TS_ThemeEngine.ColorMode(Vimera.theme, "TSBT_AccentColor");
                LabelVersion.ForeColor = TS_ThemeEngine.ColorMode(Vimera.theme, "TSBT_LabelColor2");
                LabelCopyright.ForeColor = TS_ThemeEngine.ColorMode(Vimera.theme, "TSBT_LabelColor2");
                //
                foreach (Control ui_buttons in PanelTxt.Controls){
                    if (ui_buttons is Button about_button){
                        about_button.ForeColor = TS_ThemeEngine.ColorMode(Vimera.theme, "DynamicThemeActiveBtnBG");
                        about_button.BackColor = TS_ThemeEngine.ColorMode(Vimera.theme, "AccentColor");
                        about_button.FlatAppearance.BorderColor = TS_ThemeEngine.ColorMode(Vimera.theme, "AccentColor");
                        about_button.FlatAppearance.MouseDownBackColor = TS_ThemeEngine.ColorMode(Vimera.theme, "AccentColor");
                        about_button.FlatAppearance.MouseOverBackColor = TS_ThemeEngine.ColorMode(Vimera.theme, "AccentColorHover");
                    }
                }
                //
                TSImageRenderer(About_WebsiteBtn, Vimera.theme == 1 ? Properties.Resources.ct_website_light : Properties.Resources.ct_website_dark, 15, ContentAlignment.MiddleRight);
                TSImageRenderer(About_XBtn, Vimera.theme == 1 ? Properties.Resources.ct_x_light : Properties.Resources.ct_x_dark, 15, ContentAlignment.MiddleRight);
                TSImageRenderer(About_InstagramBtn, Vimera.theme == 1 ? Properties.Resources.ct_instagram_light : Properties.Resources.ct_instagram_dark, 15, ContentAlignment.MiddleRight);
                TSImageRenderer(About_GitHubBtn, Vimera.theme == 1 ? Properties.Resources.ct_github_light : Properties.Resources.ct_github_dark, 15, ContentAlignment.MiddleRight);
                TSImageRenderer(About_YouTube, Vimera.theme == 1 ? Properties.Resources.ct_youtube_light : Properties.Resources.ct_youtube_dark, 12, ContentAlignment.MiddleRight);
                //
                AboutTable.BackgroundColor = TS_ThemeEngine.ColorMode(Vimera.theme, "DataGridBGColor");
                AboutTable.GridColor = TS_ThemeEngine.ColorMode(Vimera.theme, "DataGridColor");
                AboutTable.DefaultCellStyle.BackColor = TS_ThemeEngine.ColorMode(Vimera.theme, "DataGridBGColor");
                AboutTable.DefaultCellStyle.ForeColor = TS_ThemeEngine.ColorMode(Vimera.theme, "DataGridFEColor");
                AboutTable.AlternatingRowsDefaultCellStyle.BackColor = TS_ThemeEngine.ColorMode(Vimera.theme, "DataGridAlternatingColor");
                AboutTable.ColumnHeadersDefaultCellStyle.BackColor = TS_ThemeEngine.ColorMode(Vimera.theme, "AccentColor");
                AboutTable.ColumnHeadersDefaultCellStyle.SelectionBackColor = TS_ThemeEngine.ColorMode(Vimera.theme, "TextBoxBGColor");
                AboutTable.ColumnHeadersDefaultCellStyle.ForeColor = TS_ThemeEngine.ColorMode(Vimera.theme, "DynamicThemeActiveBtnBG");
                AboutTable.DefaultCellStyle.SelectionBackColor = TS_ThemeEngine.ColorMode(Vimera.theme, "TextBoxBGColor");
                AboutTable.DefaultCellStyle.SelectionForeColor = TS_ThemeEngine.ColorMode(Vimera.theme, "DynamicThemeActiveBtnBG");
                //
                CloseAboutBtn.BackColor = TS_ThemeEngine.ColorMode(Vimera.theme, "TSBT_CloseBG");
                CloseAboutBtn.FlatAppearance.BorderColor = TS_ThemeEngine.ColorMode(Vimera.theme, "TSBT_CloseBG");
                CloseAboutBtn.FlatAppearance.MouseOverBackColor = TS_ThemeEngine.ColorMode(Vimera.theme, "TSBT_CloseBGHover");
                CloseAboutBtn.FlatAppearance.MouseDownBackColor = TS_ThemeEngine.ColorMode(Vimera.theme, "TSBT_CloseBGHover");
                // ======================================================================================================
                // TEXTS
                TSGetLangs software_lang = new TSGetLangs(Vimera.lang_path);
                Text = string.Format(TS_String_Encoder(software_lang.TSReadLangs("SoftwareAbout", "sa_title")), Application.ProductName);
                About_WebsiteBtn.Text = " " + TS_String_Encoder(software_lang.TSReadLangs("SoftwareAbout", "sa_website_page"));
                About_XBtn.Text = " " + TS_String_Encoder(software_lang.TSReadLangs("SoftwareAbout", "sa_twitter_page"));
                About_InstagramBtn.Text = " " + TS_String_Encoder(software_lang.TSReadLangs("SoftwareAbout", "sa_instagram_page"));
                About_GitHubBtn.Text = " " + TS_String_Encoder(software_lang.TSReadLangs("SoftwareAbout", "sa_github_page"));
                About_YouTube.Text = " " + TS_String_Encoder(software_lang.TSReadLangs("SoftwareAbout", "sa_youtube_page"));
                //
                AboutTable.Columns[0].HeaderText = TS_String_Encoder(software_lang.TSReadLangs("SoftwareAbout", "sa_lang_name"));
                AboutTable.Columns[1].HeaderText = TS_String_Encoder(software_lang.TSReadLangs("SoftwareAbout", "sa_lang_translator"));
            }catch (Exception){ }
        }
        // DGV CLEAR SELECTION
        // ======================================================================================================
        private void AboutTable_SelectionChanged(object sender, EventArgs e){ AboutTable.ClearSelection(); }
        // WEBSITE LINK
        // ======================================================================================================
        private void About_WebsiteBtn_Click(object sender, EventArgs e){
            try{
                Process.Start(new ProcessStartInfo(TS_LinkSystem.website_link){ UseShellExecute = true });
            }catch (Exception){ }
        }
        // X LINK
        // ======================================================================================================
        private void About_XBtn_Click(object sender, EventArgs e){
            try{
                Process.Start(new ProcessStartInfo(TS_LinkSystem.twitter_x_link){ UseShellExecute = true });
            }catch (Exception){ }
        }
        // INSTAGRAM LINK
        // ======================================================================================================
        private void About_InstagramBtn_Click(object sender, EventArgs e){
            try{
                Process.Start(new ProcessStartInfo(TS_LinkSystem.instagram_link){ UseShellExecute = true });
            }catch (Exception){ }
        }
        // GITHUB LINK
        // ======================================================================================================
        private void About_GitHubBtn_Click(object sender, EventArgs e){
            try{
                Process.Start(new ProcessStartInfo(TS_LinkSystem.github_link){ UseShellExecute = true });
            }catch (Exception){ }
        }
        private void About_YouTube_Click(object sender, EventArgs e){
            try{
                Process.Start(new ProcessStartInfo(TS_LinkSystem.youtube_link){ UseShellExecute = true });
            }catch (Exception){ }
        }
        // FORM DRAGGING SYSTEM
        // ======================================================================================================
        private void PanelHeader_MouseDown(object sender, MouseEventArgs e){
            if (e.Button == MouseButtons.Left){
                formIsDragging = true;
                formDraggingStartPoint = new Point(e.X, e.Y);
            }
        }
        private void PanelHeader_MouseMove(object sender, MouseEventArgs e){
            if (formIsDragging){
                Point form_location = PointToScreen(e.Location);
                this.Location = new Point(form_location.X - formDraggingStartPoint.X, form_location.Y - formDraggingStartPoint.Y);
            }
        }
        private void PanelHeader_MouseUp(object sender, MouseEventArgs e){ formIsDragging = false; }
        // CLOSE ABOUT
        // ======================================================================================================
        private void CloseAboutBtn_Click(object sender, EventArgs e){ Close(); }
    }
}