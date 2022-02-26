using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MoviesLibrary.Web.Client;
using MoviesLibrary.Web.Client.Common;
using MoviesLibrary.Web.Client.Handlers;
using MoviesLibrary.Web.Client.ViewModels;
using Scrutor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddAuthorizationCore();
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.Scan(scan =>
                      scan.FromAssemblyOf<MoviesViewModel>()
                     .AddClasses()
                     .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                     .AsMatchingInterface()
                     .WithScopedLifetime());

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddOptions();
builder.Services.AddHttpClient<IApiClient, ApiClient>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllHeaders",
          builder =>
          {
              builder.AllowAnyOrigin()
                     .AllowAnyHeader()
                     .AllowAnyMethod()
                     .AllowCredentials();
          });
});



await builder.Build().RunAsync();
