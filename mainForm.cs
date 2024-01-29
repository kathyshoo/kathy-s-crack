using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace kathy_s_crack
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            labelError.BackColor = System.Drawing.Color.Transparent;

            GlobalFields.pathToSaveFile = Environment.ExpandEnvironmentVariables("%appdata%") + "\\KathyCrack";
            Directory.CreateDirectory(GlobalFields.pathToSaveFile);
            GlobalFields.pathToSaveFile = GlobalFields.pathToSaveFile + "\\saveData";

            if (File.Exists(GlobalFields.pathToSaveFile))
            {
                using (FileStream file = File.OpenRead(GlobalFields.pathToSaveFile))
                {
                    byte[] buffer = new byte[file.Length];
                    file.Read(buffer, 0, buffer.Length);
                    string textFromFile = Encoding.Default.GetString(buffer);
                    textPath.Text = textFromFile;
                }
            }
            else
            {
                File.Create(GlobalFields.pathToSaveFile);
                textPath.Text = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Hearts of Iron IV\\";
            }
            comboBoxGame.Text = "download + crack dlcs";
        }

        private void textChanged_Check(object sender, EventArgs e)
        {
            if (File.Exists(textPath.Text + "\\hoi4.exe"))
            {
                labelError.Hide();
                btnStart.Enabled = true;
            }
            else
            {
                labelError.Show();
                btnStart.Enabled = false;
            }
            GlobalFields.pathGame = textPath.Text;
        }

        private void btnStart_click(object sender, EventArgs e)
        {
            GlobalFields.methodInstall = comboBoxGame.Text;
            
            using (FileStream file = File.Create(GlobalFields.pathToSaveFile))
            {
                byte[] buffer = Encoding.Default.GetBytes(GlobalFields.pathGame);
                file.Write(buffer, 0, buffer.Length);
            }

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
            public static string pathToSaveFile { get; set; }
        }

        private void btnSelectPath_click(object sender, EventArgs e)
        {
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
