using Application.Utils.Identity;
using Application.Utils.Mapper;
using Common.Extension;
using Domain;
using Microsoft.AspNetCore.Identity;
using Repository.DatabaseContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddAutoMapper(
    typeof(ProductMapper),
    typeof(CommentMapper),
    typeof(ProductKeyMapper),
    typeof(IdentityMapper),
    typeof(ProductDetailItemMapper),
    typeof(BasketMapper),
    typeof(AddressMapper)
);

builder.Services.InjectServices(builder.Configuration);

builder.Services.AddIdentity<ApplicationUser,IdentityRole>()
    .AddEntityFrameworkStores<SqlServerContext>()
    .AddDefaultTokenProviders();


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