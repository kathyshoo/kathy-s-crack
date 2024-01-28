using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace kathy_s_crack
{
    public partial class mainForm : Form
    {
        // string 
        // string pathGame;
        // string methodInstall;

        public mainForm()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            labelError.BackColor = System.Drawing.Color.Transparent;
            // labelError.Hide();
            textPath.Text = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Hearts of Iron IV\\";
            comboBoxGame.Text = "download + crack dlcs";
            // "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Hearts of Iron IV";
            string tempSorce;
            using (WebClient wc = new WebClient())
            {
                tempSorce = wc.DownloadString("https://raw.githubusercontent.com/kathyshoo/kinfo/main/infos/info.txt");
            }
            GlobalFields.dictSource = new[] { tempSorce.Split('\n')[0].Split('$')[1], tempSorce.Split('\n')[1].Split('$')[1] };
        }

        private void textChanged_Check(object sender, EventArgs e)
        {
            if (File.Exists(textPath.Text + "\\hoi4.exe"))
            {
                labelError.Hide();
                btnStart.Enabled = true;
                // btnStart.Show();
            }
            else
            {
                labelError.Show();
                btnStart.Enabled = false;
                // btnStart.Hide();
            }
            GlobalFields.pathGame = textPath.Text;
            // labelError.Text = textPath.Text + "\\hoi4.exe";
        }

        private void btnStart_click(object sender, EventArgs e)
        {
            GlobalFields.methodInstall = comboBoxGame.Text;
            // GlobalFields.pathGame = textPath.Text;
            /* if (!Directory.Exists(GlobalFields.pathGame))
            {
                MessageBox.Show(
                "The folder is specified incorrectly. Please select the correct folder where the game is located.",
                "Incorrect folder",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
                );
            } */
            if (comboBoxGame.Text == "")
            {
                MessageBox.Show(
                "Specify the installation method of the crack for game",
                "Incorrect installation method",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
                );
            }
            else
            {
                Hide();
                Form downloadForm = new formDownload();
                downloadForm.ShowDialog();
            }
            
        }

        public static class GlobalFields
        {
            public static string pathGame { get; set; }
            public static string methodInstall { get; set; }
            // public static string tempSorce { get; set; }
            public static string[] dictSource { get; set; }
        }

        private void btnSelectPath_click(object sender, EventArgs e)
        {
            // string pathGame = selectFolderPath.SelectedPath;
            DialogResult selectPathResult = selectFolderPath.ShowDialog();
            if (selectPathResult == DialogResult.OK)
            {
                textPath.Text = selectFolderPath.SelectedPath;
                GlobalFields.pathGame = selectFolderPath.SelectedPath;
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}
