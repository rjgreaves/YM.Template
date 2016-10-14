using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using Microsoft.Owin.Testing;
using Owin;
using Xunit;

namespace YM.Template.Api.Tests
{
    public class ConnectionTests
    {

        [Fact]
        public void CanConnectToDefaultUrl()
        {
            using (var client = HttpClientFactory.Create())
            {
                var response = client.GetAsync("api").Result;

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public void AuthorisedRouteReturns401()
        {
            using (var client = HttpClientFactory.Create())
            {
                var response = client.GetAsync("api/authorisedroute").Result;

                Assert.Equal(HttpStatusCode.MethodNotAllowed, response.StatusCode);
            }
        }
    }
}
