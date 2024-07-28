using Mawaqeet;
using Mawaqeet.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IMawaqeetService, MawaqeetService>();

builder.Services.AddScoped(hc => new HttpClient
{
    //Consider populate the value from appsettings / options
    BaseAddress = new Uri("https://api.aladhan.com/v1/")
});

await builder.Build().RunAsync();
