using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using Xunit;

namespace YM.Template.Api.Tests
{
    public static class HttpClientFactory
    {
        public static HttpClient Create()
        {
            var port = FreeTcpPort();
            var baseAddress = $"http://localhost:{port}/api/";

            WebApp.Start<StartUp>(baseAddress);
            var client = new HttpClient();

            try
            {
                client.BaseAddress = new Uri(baseAddress);
                return client;
            }
            catch
            {
                client.Dispose();
                throw;
            }

        }

        private static int FreeTcpPort()
        {
            var l = new TcpListener(IPAddress.Loopback, 0);
            l.Start();
            var port = ((IPEndPoint) l.LocalEndpoint).Port;
            l.Stop();
            return port;
        }
    }
}
