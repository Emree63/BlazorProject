using Blazored.LocalStorage;
using Blazorise;
using Blazored.Modal;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using CraftSharp.Data;
using CraftSharp.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using System.Globalization;
using Microsoft.AspNetCore.Components.Authorization;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using CraftSharp;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using Microsoft.JSInterop;
using CraftSharp.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<CustomStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<CustomStateProvider>());
builder.Services.AddScoped<IAuthService, AuthService>();

// Add the controller of the app
builder.Services.AddControllers();

// Add the localization to the app and specify the resources path
builder.Services.AddLocalization(opts => { opts.ResourcesPath = "Resources"; });
builder.Services.AddScoped<UserController>();
builder.Services.AddHttpClient();

builder.Services.AddBlazoredModal();
builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));

builder.Services
   .AddBlazorise()
   .AddBootstrapProviders()
   .AddFontAwesomeIcons();

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped<IDataService, DataApiService>();

// Configure the localtization
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    // Set the default culture of the web site
    options.DefaultRequestCulture = new RequestCulture(new CultureInfo("en-US"));

    // Declare the supported culture
    options.SupportedCultures = new List<CultureInfo> { new CultureInfo("en-US"), new CultureInfo("fr-FR"), new CultureInfo("tr-TR") };
    options.SupportedUICultures = new List<CultureInfo> { new CultureInfo("en-US"), new CultureInfo("fr-FR"), new CultureInfo("tr-TR") };
});

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

// Get the current localization options
var options = ((IApplicationBuilder)app).ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();

if (options?.Value != null)
{
    // use the default localization
    app.UseRequestLocalization(options.Value);
}

// Add the controller to the endpoint
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
