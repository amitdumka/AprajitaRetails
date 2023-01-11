using AprajitaRetails.Client;
using AprajitaRetails.Helpers;
using Blazor.AdminLte;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("AprajitaRetails.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
builder.Services.AddHttpClient("AprajitaRetails.ServerAPI.Auth", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("AprajitaRetails.ServerAPI"));
builder.Services.AddAdminLte();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddScoped<IFilesManager, WasmFilesManager>();
builder.Services.AddScoped<LocalStorageAccessor>();

builder.Services.AddApiAuthorization();
//builder.Services.AddScoped<SessionStorageAccessor>();

// Radzen Addition
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();






await builder.Build().RunAsync();
