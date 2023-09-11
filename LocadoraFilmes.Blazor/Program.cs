using Blazored.LocalStorage;
using LocadoraFilmes.Blazor;
using LocadoraFilmes.Blazor.Services;
using LocadoraFilmes.Blazor.Services.Interfaces;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddBlazoredLocalStorage();

builder.Services.AddHttpClient<ISecurityService, SecurityService>(client =>
            client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
        );
builder.Services.AddHttpClient<ILocacaoService, LocacaoService>(client =>
            client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
        );
builder.Services.AddHttpClient<IFilmeService, FilmeService>(client =>
            client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
        );

await builder.Build().RunAsync();
