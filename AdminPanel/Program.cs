using AdminPanel.auth;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using AdminPanel.Data;
using Common.Extension;
using Domain;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Repository.DatabaseContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.InjectServices(builder.Configuration);

builder.Services.AddIdentity<ApplicationUser,IdentityRole>()
    .AddEntityFrameworkStores<SqlServerContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<Authenticator>();
builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<Authenticator>());

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();