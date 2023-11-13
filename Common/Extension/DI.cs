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
using Application.Common;
using Application.ProductService.Product.Command.Create;
using Application.ProductService.Product.Command.Delete;
using Application.ProductService.Product.Command.Update;
using Application.ProductService.Product.Query.ReadMultiple;
using Application.ProductService.Product.Query.ReadSingle;
using Application.ProductService.ProductColor.Command;
using Application.ProductService.ProductDetailKey.Major.Command.Create;
using Application.ProductService.ProductDetailKey.Major.Command.Update;
using Application.ProductService.ProductDetailKey.Major.Query.ReadMultiple;
using Application.ProductService.ProductDetailKey.Major.Query.ReadSingle;
using Application.ProductService.ProductDetailKey.Minor.Command.Create;
using Application.ProductService.ProductDetailKey.Minor.Command.Update;
using Application.ProductService.ProductDetailKey.Minor.Query.ReadMultiple;
using Application.ProductService.ProductDetailKey.Minor.Query.ReadSingle;
using Application.ProductService.ProductGuarantee.Command;
using Application.UserService.Query.ReadMultiple;
using Application.Utils.Identity;
using Application.Utils.Mapper;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.DatabaseContext;

using Microsoft.AspNetCore.Identity;

namespace Common.Extension;

public static class DI
{
    public static IServiceCollection InjectServices(this IServiceCollection service,IConfiguration configuration)
    {
    
        
       service.AddDbContext<SqlServerContext>(option =>
        {
            var sqlServerConnectionString = configuration.GetConnectionString("SqlServer");
            option.UseSqlServer(sqlServerConnectionString);
        }); 


       service.AddTransient<IDatabaseContext, SqlServerContext>();


        service.AddAutoMapper(
            typeof(ProductMapper),
            typeof(CommentMapper),
            typeof(ProductKeyMapper),
            typeof(IdentityMapper),
            typeof(ProductDetailItemMapper),
            typeof(BasketMapper),
            typeof(AddressMapper)
        );

        
        service.AddTransient<ReadSingleProduct>();
        service.AddTransient<ReadMultipleProducts>();
        service.AddTransient<UpdateProduct>();
        service.AddTransient<DeleteProduct>(); 

        service.AddTransient<CreateParentComment>();
        service.AddTransient<CreateAnswerComment>();
        service.AddTransient<ReadMultipleComments>();


        service.AddTransient<CreateMajorKey>();
        service.AddTransient<UpdateMajorKey>();
        service.AddTransient<ReadMultipleMajorKeys>();
        service.AddTransient<ReadSingleMajorKey>();


        service.AddTransient<CreateMinorKey>();
        service.AddTransient<UpdateMinorKey>();
        service.AddTransient<ReadSingleMinorKey>();
        service.AddTransient<ReadMultipleMinorKeys>();

        service.AddTransient<CreateColor>();
        service.AddTransient<CreateProduct>();

        service.AddTransient<ReadMultipleUsers>();

        service.AddTransient<AddCity>();
        service.AddTransient<ReadMultipleCities>();
        service.AddTransient<AddProvince>();
        service.AddTransient<ReadMultipleProvinces>();
        service.AddTransient<AddNormalAddress>();
        service.AddTransient<ReadMultipleAddresses>();
        service.AddTransient<CreateDefaultAddress>();
        service.AddTransient<ReadDefaultAddress>(); 

        service.AddTransient<ReadBasket>();
        service.AddTransient<AddBasketToBuyer>();
        service.AddTransient<AddBasketItemToBasket>();

        service.AddTransient<CreateProductGuarantee>();
        
        return service;
    }
}