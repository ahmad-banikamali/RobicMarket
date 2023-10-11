using Application.CommentService.Command.Create;
using Application.CommentService.Command.Create.AnswerComment;
using Application.CommentService.Command.Create.ParentComment;
using Application.CommentService.Query.ReadMultipleComments;
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

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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
builder.Services.AddTransient<ReadMultipleComments>();


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