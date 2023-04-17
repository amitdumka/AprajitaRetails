using System.Globalization;
using Append.Blazor.Printing;
using AprajitaRetails.Client;
using AprajitaRetails.Client.Helpers;
using AprajitaRetails.Helpers;
using Blazor.AdminLte;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Popups;

//"SyncFusionLic": "OTIwMjA3QDMyMzAyZTM0MmUzMFlOM29rWTFKdm1xcXRHZi9Sb1FpQTNCSnhBN1JWSC9oeFNaTjYvYWs5MHc9", 20.4.41
var builder = WebAssemblyHostBuilder.CreateDefault(args);
// Register Syncfusion license
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("OTIwMjA3QDMyMzAyZTM0MmUzMFlOM29rWTFKdm1xcXRHZi9Sb1FpQTNCSnhBN1JWSC9oeFNaTjYvYWs5MHc9");
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("AprajitaRetails.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
builder.Services.AddHttpClient("AprajitaRetails.ServerAPI.Auth", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("AprajitaRetails.ServerAPI"));
builder.Services.AddAdminLte();
builder.Services.AddScoped<SfDialogService>();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddScoped<IFilesManager, WasmFilesManager>();
builder.Services.AddScoped<LocalStorageAccessor>();
builder.Services.AddScoped<DataHelper>();
builder.Services.AddSingleton<ClientSetting>();
builder.Services.AddApiAuthorization();
//builder.Services.AddScoped<SessionStorageAccessor>();

// Radzen Addition
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();
builder.Services.AddScoped<IPrintingService, PrintingService>();
//CultureInfo.CurrentCulture = new CultureInfo("hi-IN", true);
//CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol = "₹";

//CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("hi-IN");
//CultureInfo.CurrentUICulture = CultureInfo.CreateSpecificCulture("hi-IN");
//CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol = "₹";


await builder.Build().RunAsync();