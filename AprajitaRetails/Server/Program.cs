using AprajitaRetails.Server.Data;
using AprajitaRetails.Server.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Globalization;
using System.Net;
using System.Runtime.InteropServices;


//"SyncFusionLic": "OTIwMjA3QDMyMzAyZTM0MmUzMFlOM29rWTFKdm1xcXRHZi9Sb1FpQTNCSnhBN1JWSC9oeFNaTjYvYWs5MHc9", 20.4.41
var builder = WebApplication.CreateBuilder(args);
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("OTIwMjA3QDMyMzAyZTM0MmUzMFlOM29rWTFKdm1xcXRHZi9Sb1FpQTNCSnhBN1JWSC9oeFNaTjYvYWs5MHc9");

builder.Services.AddMvc().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});

string connectionString = "";
string DBType = builder.Configuration.GetSection("DatabaseMode").Value;

if (DBType == "OracleCloud")
{

    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        OracleConfiguration.TnsAdmin = @"D:\Wallet_AprajitaRetailsDB01";
    else
        OracleConfiguration.TnsAdmin = @"/Users/amitkumar/Wallet_AprajitaRetailsDB01";
    OracleConfiguration.WalletLocation = OracleConfiguration.TnsAdmin;

    connectionString = builder.Configuration.GetConnectionString("OracleAD") ?? throw new InvalidOperationException("Connection string 'OracleAD' not found.");

    builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseOracle(connectionString));

    builder.Services.AddDbContext<ARDBContext>(options =>
        options.UseOracle(connectionString));

}

else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
{
    // Add services to the container.
    connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

    builder.Services.AddDbContext<ARDBContext>(options =>
        options.UseSqlServer(connectionString));
}
else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
{
    connectionString = builder.Configuration.GetConnectionString("DefaultMacCon") ?? throw new InvalidOperationException("Connection string 'DefaultMacCon' not found.");
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

    builder.Services.AddDbContext<ARDBContext>(options =>
        options.UseSqlite(connectionString));
}
else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
{
    var localDeploy = builder.Configuration.GetValue<string>("DeployedServer");
    if (localDeploy == "cloud")
    {
        connectionString = builder.Configuration.GetConnectionString("CloudLinux") ?? throw new InvalidOperationException("Connection string 'DefaultLinux' not found.");

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseMySQL(connectionString));


        builder.Services.AddDbContext<ARDBContext>(options =>
            options.UseMySQL(connectionString));
    }
    else
    {
        connectionString = builder.Configuration.GetConnectionString("DefaultLinux") ?? throw new InvalidOperationException("Connection string 'DefaultLinux' not found.");

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString));


        builder.Services.AddDbContext<ARDBContext>(options =>
            options.UseSqlServer(connectionString));
    }
}
else
{
    connectionString = builder.Configuration.GetConnectionString("DefaultMacCon") ?? throw new InvalidOperationException("Connection string 'DefaultMacCon' not found.");
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

    builder.Services.AddDbContext<ARDBContext>(options =>
        options.UseSqlite(connectionString));
}

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddIdentityServer()
    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

builder.Services.AddAuthentication()
    .AddIdentityServerJwt();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseWebAssemblyDebugging();

}
else
{

    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();


}
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});
app.UseHttpsRedirection();


app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();
// using Microsoft.AspNetCore.HttpOverrides;
app.UseIdentityServer();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.MapFallbackToFile("index.html");
//CultureInfo.CurrentCulture = new CultureInfo("hi-IN", true);
//CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol = "₹";

//CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("hi-IN");
//CultureInfo.CurrentUICulture = CultureInfo.CreateSpecificCulture("hi-IN");
//CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol = "₹";
app.Run();