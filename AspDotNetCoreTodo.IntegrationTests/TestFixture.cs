using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;

namespace AspDotNetCoreTodo.IntegrationTests
{
    //Esta clase se encarga de configurar un TestServer , y ayudará a mantener
    //las pruebas limpias y ordenadas.
    public class TestFixture : IDisposable
    {
        private readonly TestServer _server;

        public TestFixture()
        {
            var builder = new WebHostBuilder()
                .UseStartup<ASPDotNetCoreTodo.Startup>()
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.SetBasePath(Path.Combine(
                        Directory.GetCurrentDirectory(), "..\\..\\..\\..\\AspDotNetCoreTodo"));
                    config.AddJsonFile("appsettings.json");
                });
            _server = new TestServer(builder);

            Client = _server.CreateClient();
            Client.BaseAddress = new Uri("https://localhost:5001");
        }

        public HttpClient Client { get; }

        public void Dispose()
        {
            Client.Dispose();
            _server.Dispose();
        }
    }
}