// Dieses File startet die Blazor-Anwendung.
// - Hier wird der WebAssemblyHost gebaut.
// - Services (z.B. HttpClient) werden registriert.
// - Am Ende wird die App im Browser gestartet.

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using KlasseAuto.Blazor;
using KlasseAuto.Blazor.Data;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient());

builder.Services.AddScoped<WeatherApiService>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
