using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace EasyGalaxySwapper
{
    internal class Listener
    {
        static HttpListener httpListener = new HttpListener();
        public static void Start()
        {
            HttpListener httpListener = new HttpListener();
            httpListener.Prefixes.Add("http://127.0.0.1:3936/");
            httpListener.Start();
            while (true)
            {
                HttpListenerContext httpListenerContext = httpListener.GetContext();
                HttpListenerRequest httpListenerRequest = httpListenerContext.Request;
                HttpListenerResponse httpListenerResponse = httpListenerContext.Response;
                if (httpListenerRequest.HttpMethod == "GET" && httpListenerRequest.Url.LocalPath == "/Key/Valid.php")
                {
                    JObject json = new JObject();
                    json["status"] = 200;
                    json["days"] = 365;
                    string data = json.ToString();
                    httpListenerResponse.StatusCode = 200;
                    httpListenerResponse.ContentType = "application/json";
                    httpListenerResponse.ContentLength64 = Encoding.UTF8.GetBytes(data).Length;
                    httpListenerResponse.OutputStream.Write(Encoding.UTF8.GetBytes(data), 0, Encoding.UTF8.GetBytes(data).Length);
                }
            }
        }

        public static void Stop()
        {
            httpListener.Stop();
        }
    }
}
