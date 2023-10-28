using Application.AddressService.City.Command;
using Application.AddressService.City.Query;
using Application.AddressService.DefaultAddress.Command.Create;
using Application.AddressService.DefaultAddress.Query.Read;
using Application.AddressService.NormalAddress.Command;
using Application.AddressService.NormalAddress.Query.ReadMultiple;
using Application.AddressService.Province.Command;
using Application.AddressService.Province.Query;
using Application.BasketService.Command.Create.Basket;
using Application.BasketService.Command.Create.BasketItem;
using Application.BasketService.Query.Basket.Read;
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
using Application.Utils.Identity;
using Application.Utils.Mapper;
using Common;
using Domain;
using Microsoft.AspNetCore.Identity;
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


 

builder.Services.AddIdentity<ApplicationUser,IdentityRole>()
    .AddEntityFrameworkStores<SqlServerContext>()
    .AddDefaultTokenProviders();

builder.Services.AddTransient<IDatabaseContext, SqlServerContext>();


builder.Services.AddAutoMapper(
    typeof(ProductMapper),
    typeof(CommentMapper),
    typeof(ProductKeyMapper),
    typeof(IdentityMapper),
    typeof(ProductDetailItemMapper),
    typeof(BasketMapper),
    typeof(AddressMapper)
);



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
builder.Services.AddTransient<ReadMultipleMajorKeys>();
builder.Services.AddTransient<ReadSingleMajorKey>();


builder.Services.AddTransient<CreateMinorKey>();
builder.Services.AddTransient<UpdateMinorKey>();
builder.Services.AddTransient<ReadSingleMinorKey>();
builder.Services.AddTransient<ReadMultipleMinorKeys>();

builder.Services.AddTransient<ReadBasket>();
builder.Services.AddTransient<AddBasketToBuyer>();
builder.Services.AddTransient<AddBasketItemToBasket>();



builder.Services.AddTransient<AddCity>();
builder.Services.AddTransient<ReadMultipleCities>();
builder.Services.AddTransient<AddProvince>();
builder.Services.AddTransient<ReadMultipleProvinces>();
builder.Services.AddTransient<AddNormalAddress>();
builder.Services.AddTransient<ReadMultipleAddresses>();
builder.Services.AddTransient<CreateDefaultAddress>();
builder.Services.AddTransient<ReadDefaultAddress>(); 

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

app.UseAuthentication();   
app.UseAuthorization();

app.MapRazorPages();

app.Run();