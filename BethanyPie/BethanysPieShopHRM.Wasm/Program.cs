using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BethanysPieShopHRM.Wasm.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BethanysPieShopHRM.Wasm
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            // builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddHttpClient<IEmployeeDataService, EmployeeDataService>(client => {
                client.BaseAddress = new Uri("http://localhost:44350/");
            });

            await builder.Build().RunAsync();
        }
    }
}