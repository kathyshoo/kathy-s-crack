using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
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
            float versionLocal = 0.5F;

            string urlGitHub = "https://github.com/kathyshoo/kathy-s-crack/releases/latest";
            labelError.BackColor = System.Drawing.Color.Transparent;
            label1.BackColor = System.Drawing.Color.Transparent;

            ////

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlGitHub);
            request.AllowAutoRedirect = false;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string redirUrl = response.Headers["Location"];
            response.Close();
            float versionGitHub = float.Parse(redirUrl.Split('/').Last().Substring(1), CultureInfo.InvariantCulture.NumberFormat);

            if (versionGitHub > versionLocal)
            {
                if (MessageBox.Show("На GitHub вышла новая версия", "Вышло обновление", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    System.Diagnostics.Process.Start(urlGitHub);
                }
            }

            /////

            GlobalFields.pathToSaveDirectory = Environment.ExpandEnvironmentVariables("%appdata%") + "\\KathyCrack\\";
            Directory.CreateDirectory(GlobalFields.pathToSaveDirectory);
            GlobalFields.pathToSaveFile = GlobalFields.pathToSaveDirectory + "saveData";

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
            comboBoxGame.Text = "кряк со скачивание dlc";
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
                "Укажите способ установки кряка для игры",
                "Неправильный способ установки",
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
            public static string pathToSaveDirectory { get; set; }
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

        private void comboBoxGame_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxGame.Text == "кряк со скачивание dlc") 
            {
                label1.Show();
            } 
            else
            {
                label1.Hide();
            }
        }
    }
    
}
