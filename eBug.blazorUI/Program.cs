using System;
using System.Net.Http;
using System.Threading.Tasks;
using eBug.blazorUI.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace eBug.blazorUI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(
                sp => new HttpClient {BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)});

            builder.Services.AddHttpClient<BugService>("BugApi", (client) =>
            {
                client.BaseAddress = new Uri(builder.Configuration["ApiEndpoint"]);
            });

            await builder.Build().RunAsync();
        }
    }
}