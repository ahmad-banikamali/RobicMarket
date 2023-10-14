using Application.CommentService.Command.Create.AnswerComment;
using Application.CommentService.Command.Create.ParentComment;
using Application.CommentService.Query.ReadMultipleComments;
using Application.ProductService.Product.Command.Create;
using Application.ProductService.Product.Command.Delete;
using Application.ProductService.Product.Command.Update;
using Application.ProductService.Product.Query.ReadMultiple;
using Application.ProductService.Product.Query.ReadSingle;
using Application.ProductService.ProductDetailKey.Major.Command.Create;
using Application.ProductService.ProductDetailKey.Major.Command.Update;
using Application.ProductService.ProductDetailKey.Major.Query.ReadMultiple;
using Application.ProductService.ProductDetailKey.Major.Query.ReadSingle;
using Application.ProductService.ProductDetailKey.Minor.Command.Create;
using Application.ProductService.ProductDetailKey.Minor.Command.Update;
using Application.ProductService.ProductDetailKey.Minor.Query.ReadMultiple;
using Application.ProductService.ProductDetailKey.Minor.Query.ReadSingle;
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
    typeof(CommentMapper),
    typeof(ProductKeyMapper),
    typeof(ProductDetailItemMapper)
);

builder.Services.AddTransient<IDatabaseContext, SqlServerContext>();


builder.Services.AddTransient<CreateProduct>();
builder.Services.AddTransient<ReadSingleProduct>();
builder.Services.AddTransient<ReadMultipleProducts>();
builder.Services.AddTransient<UpdateProduct>();
builder.Services.AddTransient<DeleteProduct>(); 

builder.Services.AddTransient<CreateParentComment>();
builder.Services.AddTransient<CreateAnswerComment>();
builder.Services.AddTransient<ReadMultipleComments>();


builder.Services.AddTransient<CreateMajorKey>();
builder.Services.AddTransient<UpdateMajorKey>();
builder.Services.AddTransient<ReadMultiMajorKeys>();
builder.Services.AddTransient<ReadSingleMajorKey>();


builder.Services.AddTransient<CreateMinorKey>();
builder.Services.AddTransient<UpdateMinorKey>();
builder.Services.AddTransient<ReadSingleMinorKey>();
builder.Services.AddTransient<ReadMultipleMinorKeys>();


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