using Fiddler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace EasyGalaxySwapper
{
    internal class Proxy
    {
        public static void Start()
        {
            FiddlerApplication.BeforeRequest += FiddlerApplication_BeforeRequest;
            CONFIG.IgnoreServerCertErrors = true;

            // ルート証明書を出力する
            CertMaker.createRootCert();
            if (!CertMaker.rootCertIsTrusted())
            {
                CertMaker.trustRootCert();
            }

            var startupSettings =
               new FiddlerCoreStartupSettingsBuilder()
                 .ListenOnPort(3935)
                 .RegisterAsSystemProxy()
                 .DecryptSSL()
                 //.ChainToUpstreamGateway()
                 //.MonitorAllConnections()
                 //.HookUsingPACFile()
                 //.CaptureLocalhostTraffic()
                 //.CaptureFTP()
                 .OptimizeThreadPool()
                 //.SetUpstreamGatewayTo("http=CorpProxy:80;https=SecureProxy:443;ftp=ftpGW:20")
                 .Build();
            FiddlerApplication.Startup(startupSettings);

            Console.WriteLine("listening");
            Console.ReadLine();
        }
            
        private static void FiddlerApplication_BeforeRequest(Session oSession)
        {
            if (oSession.fullUrl.Contains("galaxyswapperv2.com/Key/Valid.php"))
            {
                oSession.fullUrl = oSession.fullUrl.Replace("https://galaxyswapperv2.com", "http://127.0.0.1:3936");
            }
        }
    }
}
