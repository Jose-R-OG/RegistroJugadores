using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TIicTacTocJose.BlazorWasm;
using TIicTacTocJose.BlazorWasm.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://gestionhuacalesapijdepena-czdxg0bcgjeedhdm.eastus2-01.azurewebsites.net/") });
builder.Services.AddScoped<IPartidaApiService, PartidaApiService>();
builder.Services.AddScoped<IMovimientosApiService, MovimientosApiService>();
builder.Services.AddScoped<IJugadoresApiService, JugadoresApiService>();

await builder.Build().RunAsync();
