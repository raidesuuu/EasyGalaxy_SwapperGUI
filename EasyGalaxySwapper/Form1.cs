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
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace EasyGalaxySwapper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //NetRuntimeUtility
        private void CheckNetRuntime(bool verifyOnly)
        {
            Process netChecker = new Process();
            string results;
            try
            {
                netChecker.StartInfo.FileName = "dotnet.exe";
                netChecker.StartInfo.Arguments = "--list-runtimes";
                netChecker.StartInfo.UseShellExecute = false;
                netChecker.StartInfo.RedirectStandardOutput = true;
                netChecker.Start();
                results = netChecker.StandardOutput.ReadToEnd();
                netChecker.WaitForExit();
                netChecker.Close();

                if (results.Contains("Microsoft.WindowsDesktop.App 7.0."))
                {
                    if (!verifyOnly) return;
                    DownloadGalaxySwapper();
                }
                else
                {
                    if (!verifyOnly) return;
                    InstallNetRuntime();
                }
            }
            catch (Exception)
            {
                if (!verifyOnly) return;
                InstallNetRuntime();
            }
        }

        private void InstallNetRuntime()
        {
            WebClient wc = new WebClient();
            wc.DownloadFileAsync(new Uri("https://download.visualstudio.microsoft.com/download/pr/5b2fbe00-507e-450e-8b52-43ab052aadf2/79d54c3a19ce3fce314f2367cf4e3b21/windowsdesktop-runtime-7.0.0-win-x64.exe"), Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Temp", "windowsdesktop-runtime-7.0.0-win-x64.exe"));
            wc.DownloadFileCompleted += NetRuntime_DownloadFileCompleted;
        }

        private void NetRuntime_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Process netRuntime = new Process();
            netRuntime.StartInfo.FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Temp", "windowsdesktop-runtime-7.0.0-win-x64.exe");
            netRuntime.StartInfo.Arguments = "/quiet";
            netRuntime.StartInfo.UseShellExecute = true;
            netRuntime.EnableRaisingEvents = true;
            netRuntime.SynchronizingObject = this;
            netRuntime.Start();
            netRuntime.Exited += NetRuntime_Exited;
        }

        private void NetRuntime_Exited(object sender, EventArgs e) => DownloadGalaxySwapper();

        //GalaxySwapperUtility
        private void DownloadGalaxySwapper()
        {
            WebClient wc = new WebClient();
            wc.DownloadFileAsync(new Uri("https://raw.githubusercontent.com/raidesuuu/EasyGalaxy_SwapperGUI/master/GalaxySwapperBinary.exe"), Path.Combine(Directory.GetCurrentDirectory(), "GalaxySwapperV2.exe"));
            wc.DownloadFileCompleted += Galaxy_DownloadFileCompleted;
        }

        private void Galaxy_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e) => ProxyHandler();

        //MessageBoxUtility
        private bool ShowMessageBox()
        {
            //Configure MessageBox
            string title = "アクションが必要 : EasyGalaxy Swapper GUI";
            string description =
                "Galaxy Swapperを認証するには、下記のステップの手段が必要です。\n" +
                "1. 適当なライセンスキーを入れて、「Activate」をクリックします。\n" +
                "> 「000000-000000-000000」を使用してはいけません。(空白もNG)\n" +
                "2. アラートが表示されたら、「OK」をクリックします。\n" +
                "3. Galaxy Swapperが使用できることを確認します。\n" +
                "4. 確認できたら、このダイアログで「はい」をクリックしてください。\n" +
                "「はい」をクリックしない場合、インターネットに接続できなくなる可能性があります。\n" +
                "間違って強制終了してしまった場合、システム設定からプロキシを無効にしてください。";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo; ;
            MessageBoxIcon icon = MessageBoxIcon.Warning;

            DialogResult dr = MessageBox.Show(description, title, buttons, icon);
            if (dr == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                ShowMessageBox();
                return false;
            }
        }

        private void ProxyHandler()
        {
            //Proxy Warning
            MessageBox.Show("証明書の確認ウインドウが表示されたら、「はい」をクリックしてください。\n「OK」をクリックして処理を続行します。", "注意 : EasyGalaxy Swapper GUI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //Launch "Proxy"
            Thread thread = new Thread(Listener.Start);
            thread.Start();
            Proxy.Start();

            //Launch "Galaxy Swapper"
            Process.Start(Path.Combine(Directory.GetCurrentDirectory(), "GalaxySwapperV2.exe"));

            if (ShowMessageBox())
            {
                Fiddler.FiddlerApplication.Shutdown();
                thread.Join();
                Listener.Stop();
            }
        }



        //EventListener
        private void button1_Click(object sender, EventArgs e)
        {
            actions_run.Enabled = false;
            actions_run.Text = "処理中...";
            label5.Text = "処理中...";
            CheckNetRuntime(true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Launch "discord.com" on Default Browser
            Process.Start("https://galaxyswapperv2.com/Discord.php");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Close Fiddler
            if (Fiddler.FiddlerApplication.IsStarted())
            {
                Fiddler.FiddlerApplication.Shutdown();
            }
            Application.Exit();
        }

        private void actions_downloadOnly_Click(object sender, EventArgs e)
        {

        }
    }
}
