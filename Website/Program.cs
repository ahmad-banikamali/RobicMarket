using Application.CommentService.Command.Create.AnswerComment;
using Application.CommentService.Command.Create.ParentComment;
using Application.ProductService.Command.Create;
using Application.ProductService.Command.Delete;
using Application.ProductService.Command.Update;
using Application.ProductService.Query.ReadMultiProducts;
using Application.ProductService.Query.ReadSingleProduct;
using Application.Utils;
using Common;
using Microsoft.EntityFrameworkCore;
using Repository.DatabaseContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();


builder.Services.AddDbContext<SqlServerContext>(option =>
{
    var sqlServerConnectionString = builder.Configuration.GetConnectionString("SqlServer");
    option.UseSqlServer(sqlServerConnectionString);
});

builder.Services.AddAutoMapper(
    typeof(ProductMapper),
    typeof(CommentMapper)
);

builder.Services.AddTransient<IDatabaseContext, SqlServerContext>();
builder.Services.AddTransient<CreateProduct>();
builder.Services.AddTransient<ReadSingleProduct>();
builder.Services.AddTransient<ReadPaginatedProducts>();
builder.Services.AddTransient<UpdateProduct>();
builder.Services.AddTransient<DeleteProduct>();

builder.Services.AddTransient<CreateParentComment>();
builder.Services.AddTransient<CreateAnswerComment>();


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