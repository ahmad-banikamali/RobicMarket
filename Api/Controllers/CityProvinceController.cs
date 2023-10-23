using Application.AddressService.City.Command;
using Application.AddressService.City.Command.Dto;
using Application.AddressService.City.Query;
using Application.AddressService.City.Query.ReadMultiple.Dto;
using Application.AddressService.Province.Command;
using Application.AddressService.Province.Command.Dto;
using Application.AddressService.Province.Query;
using Application.AddressService.Province.Query.ReadMultiple.Dto;
using Common.BaseDto;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityProvinceController : ControllerBase
    {
        private readonly AddCity _addCity;
        private readonly ReadMultipleCities _readMultipleCities;
        private readonly AddProvince _addProvince;
        private readonly ReadMultipleProvinces _readMultipleProvinces;

        public CityProvinceController(
            AddCity addCity,
            ReadMultipleCities readMultipleCities,
            AddProvince addProvince,
            ReadMultipleProvinces readMultipleProvinces
            )
        {
            _addCity = addCity;
            _readMultipleCities = readMultipleCities;
            _addProvince = addProvince;
            _readMultipleProvinces = readMultipleProvinces; 
        }



        [HttpPost("city")]
        public Response AddCity(AddCityRequest request)
        {
            return _addCity.Execute(request);
        }
        

        [HttpPost("province")]
        public Response AddProvince(AddProvinceRequest request)
        {
            return _addProvince.Execute(request);
        }

        [HttpGet("city")]
        public PaginatedResponse<ReadMultipleCitiesResponse> GetCities([FromQuery]ReadMultipleCitiesRequest request)
        {
            return _readMultipleCities.Execute(request);
        }

        [HttpGet("province")]
        public PaginatedResponse<ReadMultipleProvincesResponse> GetProvinces([FromQuery] ReadMultipleProvincesRequest request)
        {
            return _readMultipleProvinces.Execute(request);
        } 
    }
}
