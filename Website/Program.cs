using Application;
using Application.ProductService.Create;
using Application.ProductService.Read;
using Application.Utils;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Repository.DatabaseContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<SqlServerContext>(option => {
    var sqlServerConnectionString = builder.Configuration.GetConnectionString("SqlServer");
    option.UseSqlServer(sqlServerConnectionString);
});

builder.Services.AddAutoMapper(typeof(Mapper));

builder.Services.AddTransient<IDatabaseContext,SqlServerContext>() ;

builder.Services.AddTransient<CreateProduct>();
builder.Services.AddTransient<ReadSingleProduct>();

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
