using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace EasyGalaxySwapper
{
    public partial class Form1 : Form
    {
        static bool NetRuntimeInstalled = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button1.Text = "処理中...";
            Process netChecker = new Process();
            netChecker.StartInfo.FileName = "dotnet.exe";
            netChecker.StartInfo.Arguments = "--list-runtimes";
            netChecker.StartInfo.UseShellExecute = false;
            netChecker.StartInfo.RedirectStandardOutput = true;
            netChecker.Start();
            string results = netChecker.StandardOutput.ReadToEnd();
            netChecker.WaitForExit();
            netChecker.Close();

            if (results.Contains("Microsoft.WindowsDesktop.App 7.0."))
            {
                AllProgress.Value = 50;
                DownloadGalaxySwapper();
            } else
            {
                InstallNetRuntime();
            }
        }

        private void InstallNetRuntime()
        {
            label5.Text = ".NETをダウンロード中";
            WebClient wc = new WebClient();
            wc.DownloadFileAsync(new Uri("https://download.visualstudio.microsoft.com/download/pr/5b2fbe00-507e-450e-8b52-43ab052aadf2/79d54c3a19ce3fce314f2367cf4e3b21/windowsdesktop-runtime-7.0.0-win-x64.exe"), Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Temp", "windowsdesktop-runtime-7.0.0-win-x64.exe"));
            wc.DownloadProgressChanged += NetRuntime_DownloadProgressChanged;
            wc.DownloadFileCompleted += NetRuntime_DownloadFileCompleted;
        }

        private void NetRuntime_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            AllProgress.Value = 25;
            label5.Text = ".NETをインストール中";
            Process netRuntime = new Process();
            netRuntime.StartInfo.FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Temp", "windowsdesktop-runtime-7.0.0-win-x64.exe");
            netRuntime.StartInfo.Arguments = "/quiet";
            netRuntime.StartInfo.UseShellExecute = true;
            netRuntime.EnableRaisingEvents = true;
            netRuntime.SynchronizingObject = this;
            netRuntime.Start();
            netRuntime.Exited += NetRuntime_Exited;
        }

        private void NetRuntime_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            MenuProgress.Value = e.ProgressPercentage;
        }

        private void NetRuntime_Exited(object sender, EventArgs e)
        {
            AllProgress.Value = 50;
            DownloadGalaxySwapper();
        }

        private void DownloadGalaxySwapper()
        {
            label5.Text = "Galaxy Swapperをダウンロード中";
            WebClient wc = new WebClient();
            wc.DownloadFileAsync(new Uri("https://galaxyswapperv2.com/Downloads/Galaxy%20Swapper%20v2.exe"), Path.Combine(Directory.GetCurrentDirectory(), "GalaxySwapperV2.exe"));
            wc.DownloadProgressChanged += Galaxy_DownloadProgressChanged;
            wc.DownloadFileCompleted += Galaxy_DownloadFileCompleted;
        }

        private async void Galaxy_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            AllProgress.Value = 75;
            Process.Start(Path.Combine(Directory.GetCurrentDirectory(), "GalaxySwapperV2.exe"));
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://galaxyswapperv2.com/Key/Create.php");
            var LicenseKeyParser = HttpUtility.ParseQueryString(response.RequestMessage.RequestUri.Query);
            var LicenseKey = LicenseKeyParser["key"];
            Clipboard.SetText(LicenseKey);
            label5.Text = "ライセンスキー: " + LicenseKey + Environment.NewLine + "(クリップボードにコピーしました)";
            AllProgress.Value = 100;
            button1.Text = "再実行";
            button1.Enabled = true;

        }

        private void Galaxy_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            MenuProgress.Value = e.ProgressPercentage;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("https://galaxyswapperv2.com/Discord.php");
        }
    }
}
