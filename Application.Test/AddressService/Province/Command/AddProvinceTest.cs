using Application.AddressService.Province.Command;
using Application.AddressService.Province.Command.Dto;
using Application.Test.Common;
using FakeItEasy;
using FluentAssertions;

namespace Application.Test.AddressService.Province.Command;

public class AddProvinceTest: IClassFixture<InMemoryDbContextFixture>
{
    private readonly InMemoryDbContextFixture _inMemoryDbContextFixture;

    public AddProvinceTest(InMemoryDbContextFixture inMemoryDbContextFixture)
    {
        _inMemoryDbContextFixture = inMemoryDbContextFixture;
    }


    [Fact]
    public void AddProvince_Execute_Response()
    {
        //arrange 
        var mapper = _inMemoryDbContextFixture.GetMapper;
        var addProvince = new AddProvince(_inMemoryDbContextFixture.GetDatabase,mapper);
        var addProvinceRequest = A.Fake<AddProvinceRequest>();
        const string provinceName = "test province";
        
        A.CallTo(() => addProvinceRequest.Name).Returns(provinceName);

        A.CallTo(() => mapper.Map<Domain.Province>(addProvinceRequest))
            .Returns(new Domain.Province { Name = provinceName });
        
        //act
        var response =addProvince.Execute(addProvinceRequest);
        var provinces = _inMemoryDbContextFixture.GetDatabase.Set<Domain.Province>().ToList();

        
        //assert
        response.Should().NotBeNull();
        provinces.Should().NotBeEmpty();
    }

}