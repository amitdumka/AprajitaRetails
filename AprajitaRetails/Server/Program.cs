using AprajitaRetails.Server.Data;
using Newtonsoft.Json.Serialization;
using AprajitaRetails.Server.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using System;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});

//Detemining which os
//bool isWindows = System.Runtime.InteropServices.RuntimeInformation
//                                              .IsOSPlatform(OSPlatform.Windows);
//bool isMac = System.Runtime.InteropServices.RuntimeInformation
//                                               .IsOSPlatform(OSPlatform.OSX);
//bool isLinux = System.Runtime.InteropServices.RuntimeInformation
//                                              .IsOSPlatform(OSPlatform.Linux);
//string connectionString = "";

//if (isWindows)
//{
//    // Add services to the container.
//    connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
//    builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(connectionString));

//    builder.Services.AddDbContext<ARDBContext>(options =>
//        options.UseSqlServer(connectionString));
//}
//else if (isMac) {

//    connectionString = builder.Configuration.GetConnectionString("DefaultMacCon") ?? throw new InvalidOperationException("Connection string 'DefaultMacCon' not found.");
//    builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlite(connectionString));

//    //builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    //options.UseSqlite(connectionString));

//    builder.Services.AddDbContext<ARDBContext>(options =>
//        options.UseSqlite(connectionString));
//}
//else if (isLinux) { }
//else
//{
var connectionString = builder.Configuration.GetConnectionString("DefaultMacCon") ?? throw new InvalidOperationException("Connection string 'DefaultMacCon' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlite(connectionString));

//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//options.UseSqlite(connectionString));

builder.Services.AddDbContext<ARDBContext>(options =>
    options.UseSqlite(connectionString));
//}



builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddIdentityServer()
    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

builder.Services.AddAuthentication()
    .AddIdentityServerJwt();

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

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseIdentityServer();
app.UseAuthorization();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
