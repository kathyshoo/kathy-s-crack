using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using static kathy_s_crack.mainForm;
using System.IO;
using SevenZip;
using System.Reflection;

namespace kathy_s_crack
{
    public partial class formDownload : Form
    {
        string urlToDlc = "https://pixeldrain.com/api/file/VBpRs1ec?download";


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

            deleteTempFile();

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
                    using (var res = new FileStream(GlobalFields.pathToSaveDirectory + tempNameFile, FileMode.Create))
                    {
                        stream.CopyTo(res);
                    }
                }
                else
                {
                    
                }
            }
            SevenZipCompressor.SetLibraryPath(tempNameFile);

            using (Stream stream1 = Assembly.GetExecutingAssembly().GetManifestResourceStream("kathy_s_crack.cream_api.zip"))
            {
                if (stream1 != null)
                {
                    using (var res = new FileStream(GlobalFields.pathToSaveDirectory + "crack.zip", FileMode.Create))
                    {
                        stream1.CopyTo(res);
                    }
                }
            }


            if (GlobalFields.methodInstall == "кряк со скачивание dlc")
            {
                label4.Text = "скачивание...";
                await downloadFromSite(urlToDlc, GlobalFields.pathToSaveDirectory + "dlcs.rar");
                // await downloadFromSite(urlCrack, "crack.zip");

                if (File.Exists($"{GlobalFields.pathGame}\\steam_api.dll") && !File.Exists($"{GlobalFields.pathGame}\\steam_api_o.dll"))
                {
                    File.Move($"{GlobalFields.pathGame}\\steam_api.dll", $"{GlobalFields.pathGame}\\steam_api_o.dll");
                }
                if (File.Exists($"{GlobalFields.pathGame}\\steam_api64.dll") && !File.Exists($"{GlobalFields.pathGame}\\steam_api64_o.dll"))
                {
                    File.Move($"{GlobalFields.pathGame}\\steam_api64.dll", $"{GlobalFields.pathGame}\\steam_api64_o.dll");
                }

                label4.Text = "распаковка...";
                using (SevenZipExtractor szcArchive = new SevenZipExtractor(GlobalFields.pathToSaveDirectory + "crack.zip")) 
                {
                    await szcArchive.ExtractArchiveAsync(GlobalFields.pathGame);
                }
                using (SevenZipExtractor szcArchive = new SevenZipExtractor(GlobalFields.pathToSaveDirectory + "dlcs.rar", "cs.rin.ru"))
                {
                    await szcArchive.ExtractArchiveAsync(GlobalFields.pathGame);
                }
                // ZipFile.ExtractToDirectory("crack.zip", GlobalFields.pathGame);
                label4.Text = "Завершено!";

                deleteTempFile();

                MessageBox.Show("Установка выполнена",
                    "Удача",
                    MessageBoxButtons.OK);
                btnCancel.Show();
            }
            else if (GlobalFields.methodInstall == "только кряк")
            {
                label4.Text = "скачивание...";
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

                label4.Text = "распаковка...";
                using (SevenZipExtractor szcArchive = new SevenZipExtractor(GlobalFields.pathToSaveDirectory + "crack.zip"))
                {
                    await szcArchive.ExtractArchiveAsync(GlobalFields.pathGame);
                }

                

                label4.Text = "Завершено!";

                deleteTempFile();

                MessageBox.Show("Установка выполнена",
                    "Удача",
                    MessageBoxButtons.OK);

                

                btnCancel.Show();
                // progressDownload.Value = 0;
            }
        }

        public void deleteTempFile()
        {
            if (File.Exists(GlobalFields.pathToSaveDirectory + "7z.dll"))
            {
                File.Delete(GlobalFields.pathToSaveDirectory + "7z.dll");
            }
            if (File.Exists(GlobalFields.pathToSaveDirectory + "7z64.dll"))
            {
                File.Delete(GlobalFields.pathToSaveDirectory + "7z64.dll");
            }
            if (File.Exists(GlobalFields.pathToSaveDirectory + "crack.zip"))
            {
                File.Delete(GlobalFields.pathToSaveDirectory + "crack.zip");
            }
            if (File.Exists(GlobalFields.pathToSaveDirectory + "dlcs.rar"))
            {
                File.Delete(GlobalFields.pathToSaveDirectory + "dlcs.rar");
            }
        }

        public async Task downloadFromSite(string urlFile, string nameFile)
        {
            using (WebClient wc = new WebClient())
            {
                wc.DownloadProgressChanged += (s, ex) =>
                {
                    label2.Text = $"Скачано: {ex.ProgressPercentage}% ({((double)ex.BytesReceived / 1048576).ToString("#.#")} МБ)";
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
