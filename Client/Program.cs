using LearnApps.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Blazor;

namespace LearnApps.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDMxODM0QDMxMzkyZTMxMmUzMGVJczhEeEVVcDRnRC90WHdHM3d3aDZnUUdpeEc2Mk56ZDh6RVNlOWFDSkk9");
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddSyncfusionBlazor();

            builder.Services.AddHttpClient("LearnApps.AnonymousAPI", client => {
                client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
            });

            builder.Services.AddHttpClient("LearnApps.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("LearnApps.ServerAPI"));

            builder.Services.AddApiAuthorization(options => {
                options.UserOptions.RoleClaim = "role";
            });

            builder.Services.AddScoped<IDeckService, DeckService>();
            builder.Services.AddScoped<IFlashCardService, FlashCardService>();


            await builder.Build().RunAsync();
        }
    }
}
