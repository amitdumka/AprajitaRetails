using AprajitaRetails.Server.Data;
using AprajitaRetails.Server.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Runtime.InteropServices;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});
// builder.Services.Configure<ForwardedHeadersOptions>(options =>
// {
//     options.KnownProxies.Add(IPAddress.Parse("192.168.11.21"));
// });
//Detemining which os
//bool isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
//bool isMac = RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
//bool isLinux = RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
string connectionString = "";

if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
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
    connectionString = builder.Configuration.GetConnectionString("DefaultLinux") ?? throw new InvalidOperationException("Connection string 'DefaultLinux' not found.");
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

    builder.Services.AddDbContext<ARDBContext>(options =>
        options.UseSqlServer(connectionString));
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
// if (!builder.Environment.IsDevelopment())
// {
//     builder.Services.AddHttpsRedirection(options =>
//     {
//         options.RedirectStatusCode = (int)HttpStatusCode.PermanentRedirect;
//         options.HttpsPort = 443;
//     });
// }
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
    //app.UseHttpsRedirection();
    
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

app.Run();