using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.AddressService.City.Command;
using Application.AddressService.City.Query;
using Application.AddressService.DefaultAddress.Command.Create.Dto;
using Application.AddressService.DefaultAddress.Query.Read;
using Application.AddressService.NormalAddress.Command;
using Application.AddressService.NormalAddress.Query.ReadMultiple;
using Application.AddressService.Province.Command;
using Application.AddressService.Province.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly AddNormalAddress _addNormalAddress;
        private readonly ReadMultipleAddresses _readMultipleAddresses;
        private readonly CreateDefaultAddressRequest _createDefaultAddressRequest;
        private readonly ReadDefaultAddress _readDefaultAddress;

        public AddressController(
            AddNormalAddress addNormalAddress,
            ReadMultipleAddresses readMultipleAddresses,
            CreateDefaultAddressRequest createDefaultAddressRequest,
            ReadDefaultAddress readDefaultAddress
            )
        { 
            _addNormalAddress = addNormalAddress;
            _readMultipleAddresses = readMultipleAddresses;
            _createDefaultAddressRequest = createDefaultAddressRequest;
            _readDefaultAddress = readDefaultAddress;
        }
    }
}
