using Application;
using Application.ProductService.Create;
using Application.ProductService.Delete;
using Application.ProductService.Read;
using Application.ProductService.Update;
using Application.Utils;
using Microsoft.EntityFrameworkCore;
using Repository.DatabaseContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<SqlServerContext>(option => {
    var sqlServerConnectionString = builder.Configuration.GetConnectionString("SqlServer");
    option.UseSqlServer(sqlServerConnectionString);
});

builder.Services.AddAutoMapper(typeof(Mapper)); 
builder.Services.AddTransient<IDatabaseContext,SqlServerContext>() ; 
builder.Services.AddTransient<CreateProduct>();
builder.Services.AddTransient<ReadSingleProduct>();
builder.Services.AddTransient<ReadPaginatedProducts>(); 
builder.Services.AddTransient<UpdateProduct>();
builder.Services.AddTransient<DeleteProduct>();
builder.Services.AddTransient<DeleteAllProducts>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
