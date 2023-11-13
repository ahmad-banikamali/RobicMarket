using Application.AddressService.City.Command;
using Application.AddressService.City.Command.Dto;
using Application.Test.Common;
using FakeItEasy;
using FluentAssertions;

namespace Application.Test.AddressService.City.Command;


public class AddCityTest: IClassFixture<InMemoryDbContextFixture>
{
    private readonly InMemoryDbContextFixture _inMemoryDbContextFixture;


    public AddCityTest(InMemoryDbContextFixture inMemoryDbContextFixture)
    {
        _inMemoryDbContextFixture = inMemoryDbContextFixture;
    }
  

    [Fact]
    public void AddCity_Execute_Response()
    {
        //arrange
        var cityName = "test city name";
        var provinceId = 2;
        var addCityRequest = new AddCityRequest
        {
            Name = cityName,
            ProvinceId = provinceId
        };

        var mapper = _inMemoryDbContextFixture.GetMapper;
        
        A.CallTo(()=>mapper.Map<Domain.City>(addCityRequest)).Returns(new Domain.City
        {
            ProvinceId = provinceId,
            Name = cityName
        });
        
        
        var addCity = new AddCity(_inMemoryDbContextFixture.GetDatabase,mapper);
        
        //act
        var a =addCity.Execute(addCityRequest);
        
        //assert
        a.Should().NotBeNull();
    }
}