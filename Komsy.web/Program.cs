using System;
using Komsy.infrastructure;
using Komsy.infrastructure.Auth.Services;
using Komsy.infrastructure.Lang;
using Komsy.infrastructure.Services.Http;
using Komsy.infrastructure.Services.LocalStorageService;
using Komsy.web;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

public static class Program {

  public static bool IsDevelopment;
  public static async Task Main(string[] args) {

    var builder = WebAssemblyHostBuilder.CreateDefault(args);
    builder.RootComponents.Add<App>("#app");
    builder.RootComponents.Add<HeadOutlet>("head::after");

    AppSettings.IsDevelopment = builder.HostEnvironment.IsDevelopment();

    // builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
    builder.Services.AddScoped(sp => new HttpClient());

    builder.Services.AddScoped<IHttpService, HttpService>();
    builder.Services.AddScoped<IAuthService, AuthService>();
    builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();

    builder.Services.AddMudServices();

    Lang.Init();

    await builder.Build().RunAsync();

  }
}


