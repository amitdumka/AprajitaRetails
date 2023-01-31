using AprajitaRetails.ClientUI;
using Blazor.AdminLte;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using Syncfusion.Blazor.Popups;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddHttpClient("AprajitaRetails.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
builder.Services.AddHttpClient("AprajitaRetails.ServerAPI.Auth", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("AprajitaRetails.ServerAPI"));
builder.Services.AddAdminLte();
builder.Services.AddScoped<SfDialogService>();
builder.Services.AddSyncfusionBlazor();
//builder.Services.AddScoped<IFilesManager, WasmFilesManager>();
//builder.Services.AddScoped<LocalStorageAccessor>();
//builder.Services.AddScoped<DataHelper>();
//builder.Services.AddSingleton<ClientSetting>();
builder.Services.AddApiAuthorization();
//builder.Services.AddScoped<SessionStorageAccessor>();

// Radzen Addition
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//builder.Services.AddOidcAuthentication(options =>
//{
//    // Configure your authentication provider options here.
//    // For more information, see https://aka.ms/blazor-standalone-auth
//    builder.Configuration.Bind("Local", options.ProviderOptions);
//});

await builder.Build().RunAsync();
