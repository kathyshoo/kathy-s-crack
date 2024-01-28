using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;
using static kathy_s_crack.mainForm;
using System.IO;
using SevenZip;
using System.Threading;
using System.Reflection;
using kathy_s_crack.Properties;
using System.Runtime.InteropServices.ComTypes;

namespace kathy_s_crack
{
    public partial class formDownload : Form
    {
        string urlToDlc = "https://pixeldrain.com/api/file/p6EHfzcB?download";


        public formDownload()
        {
            InitializeComponent();
        }

        private async void formDownload_Load(object sender, EventArgs e)
        {
            btnCancel.Hide();
            label1.BackColor = System.Drawing.Color.Transparent;
            label2.BackColor = System.Drawing.Color.Transparent;
            label3.BackColor = System.Drawing.Color.Transparent;
            label4.BackColor = System.Drawing.Color.Transparent;
            // string urlCrack = GlobalFields.dictSource[0];
            // string urlDLC = GlobalFields.dictSource[1];

            string resourceName;
            string tempNameFile;
            if (Environment.Is64BitProcess)
            {
                resourceName = "kathy_s_crack.7z64.dll";
                tempNameFile = "7z64.dll";
            }
            else
            {
                resourceName = "kathy_s_crack.7z.dll";
                tempNameFile = "7z.dll";
            }
            // Получаем поток данных из встроенного ресурса
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                if (stream != null)
                {
                    // Пример: копируем встроенный ресурс в файл на диске
                    using (var res = new FileStream(tempNameFile, FileMode.Create))
                    {
                        stream.CopyTo(res);
                    }
                }
                else
                {
                    
                }
            }
            SevenZipCompressor.SetLibraryPath(tempNameFile);

            using (Stream stream1 = Assembly.GetExecutingAssembly().GetManifestResourceStream("cream_api.zip"))
            {
                if (stream1 != null)
                {
                    using (var res = new FileStream("crack.zip", FileMode.Create))
                    {
                        stream1.CopyTo(res);
                    }
                }
            }


            if (GlobalFields.methodInstall == "download + crack dlcs")
            {
                label4.Text = "downloading";
                await downloadFromSite(urlToDlc, "dlcs.rar");
                // await downloadFromSite(urlCrack, "crack.zip");

                if (File.Exists($"{GlobalFields.pathGame}\\steam_api.dll"))
                {
                    File.Move($"{GlobalFields.pathGame}\\steam_api.dll", $"{GlobalFields.pathGame}\\steam_api_o.dll");
                }
                if (File.Exists($"{GlobalFields.pathGame}\\steam_api64.dll"))
                {
                    File.Move($"{GlobalFields.pathGame}\\steam_api64.dll", $"{GlobalFields.pathGame}\\steam_api64_o.dll");
                }

                label4.Text = "unpacking";
                using (SevenZipExtractor szcArchive = new SevenZipExtractor("crack.zip")) 
                {
                    await szcArchive.ExtractArchiveAsync(GlobalFields.pathGame);
                }
                using (SevenZipExtractor szcArchive = new SevenZipExtractor("dlcs.rar", "cs.rin.ru"))
                {
                    await szcArchive.ExtractArchiveAsync(GlobalFields.pathGame);
                }
                // ZipFile.ExtractToDirectory("crack.zip", GlobalFields.pathGame);
                label4.Text = "ready...";

                File.Delete("crack.zip");
                File.Delete("dlcs.rar");

                if (File.Exists("7z.dll"))
                {
                    File.Delete("7z.dll");
                }
                else if (File.Exists("7z64.dll"))
                {
                    File.Delete("7z64.dll");
                }

                MessageBox.Show("The task is completed",
                    "Succesfully",
                    MessageBoxButtons.OK);
                btnCancel.Show();
            }
            else if (GlobalFields.methodInstall == "only crack dlcs")
            {
                label4.Text = "downloading";
                // await downloadFromSite(urlCrack, "crack.zip");

                progressDownload.Value = 100;

                if (File.Exists($"{GlobalFields.pathGame}\\steam_api.dll") && !File.Exists($"{GlobalFields.pathGame}\\steam_api_o.dll"))
                {
                    File.Move($"{GlobalFields.pathGame}\\steam_api.dll", $"{GlobalFields.pathGame}\\steam_api_o.dll");
                }
                if (File.Exists($"{GlobalFields.pathGame}\\steam_api64.dll") && !File.Exists($"{GlobalFields.pathGame}\\steam_api64_o.dll"))
                {
                    File.Move($"{GlobalFields.pathGame}\\steam_api64.dll", $"{GlobalFields.pathGame}\\steam_api64_o.dll");
                }

                label4.Text = "unpacking";
                using (SevenZipExtractor szcArchive = new SevenZipExtractor("crack.zip"))
                {
                    await szcArchive.ExtractArchiveAsync(GlobalFields.pathGame);
                }

                label4.Text = "ready...";

                File.Delete("crack.zip");

                if (File.Exists("7z.dll"))
                {
                    File.Delete("7z.dll");
                }
                else if (File.Exists("7z64.dll"))
                {
                    File.Delete("7z64.dll");
                }

                MessageBox.Show("The task is completed",
                    "Succesfully",
                    MessageBoxButtons.OK);

                

                btnCancel.Show();
                // progressDownload.Value = 0;
            }
        }

        public async Task downloadFromSite(string urlFile, string nameFile)
        {
            
            using (WebClient wc = new WebClient())
            {
                wc.DownloadProgressChanged += (s, ex) =>
                {
                    label2.Text = $"Downloaded: {ex.ProgressPercentage}% ({((double)ex.BytesReceived / 1048576).ToString("#.#")} MB)";
                    progressDownload.Value = ex.ProgressPercentage;
                };
                await wc.DownloadFileTaskAsync(new Uri(urlFile), nameFile);
            }
        }

        private void formDownloadClosing(object sender, EventArgs e)
        {
            Form mainForm = Application.OpenForms[0];
            mainForm.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }


}
