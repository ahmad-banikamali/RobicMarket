using Application.ProductService.ProductDetailKey.Major.Command.Create;
using Application.ProductService.ProductDetailKey.Major.Command.Create.Dto;
using Application.ProductService.ProductDetailKey.Major.Command.Update;
using Application.ProductService.ProductDetailKey.Major.Command.Update.Dto; 
using Application.ProductService.ProductDetailKey.Major.Query.ReadMultiple;
using Application.ProductService.ProductDetailKey.Major.Query.ReadMultiple.Dto;
using Application.ProductService.ProductDetailKey.Major.Query.ReadSingle;
using Application.ProductService.ProductDetailKey.Major.Query.ReadSingle.Dto;
using Application.ProductService.ProductDetailKey.Minor.Command.Create;
using Application.ProductService.ProductDetailKey.Minor.Command.Create.Dto;
using Application.ProductService.ProductDetailKey.Minor.Command.Update;
using Application.ProductService.ProductDetailKey.Minor.Command.Update.Dto;
using Application.ProductService.ProductDetailKey.Minor.Query.ReadMultiple;
using Application.ProductService.ProductDetailKey.Minor.Query.ReadMultiple.Dto;
using Application.ProductService.ProductDetailKey.Minor.Query.ReadSingle;
using Application.ProductService.ProductDetailKey.Minor.Query.ReadSingle.Dto;
using Common.BaseDto;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductDetailKeyController : ControllerBase
{
    private readonly CreateMajorKey _createMajorKey;
    private readonly UpdateMajorKey _updateMajorKey;
    private readonly ReadMultipleMajorKeys _readMultipleMajorKeys;
    private readonly ReadSingleMajorKey _readSingleMajorKey;
    private readonly ReadSingleMinorKey _readSingleMinorKey;
    private readonly UpdateMinorKey _updateMinorKey;
    private readonly CreateMinorKey _createMinorKey;
    private readonly ReadMultipleMinorKeys _readMultipleMinorKeys;

    public ProductDetailKeyController(
        CreateMajorKey createMajorKey,
        UpdateMajorKey updateMajorKey,
        ReadMultipleMajorKeys readMultipleMajorKeys,
        ReadSingleMajorKey readSingleMajorKey,
        ReadSingleMinorKey readSingleMinorKey,
        UpdateMinorKey updateMinorKey,
        CreateMinorKey createMinorKey,
        ReadMultipleMinorKeys readMultipleMinorKeys
        )
    {
        _createMajorKey = createMajorKey;
        _updateMajorKey = updateMajorKey;
        _readMultipleMajorKeys = readMultipleMajorKeys;
        _createMinorKey = createMinorKey;
        _readMultipleMinorKeys = readMultipleMinorKeys;
        _readSingleMajorKey = readSingleMajorKey;
        _readSingleMinorKey = readSingleMinorKey;
        _updateMinorKey = updateMinorKey;
    }
    
    [HttpPost(template:"major")]
    public Response CreateMajorKey(CreateMajorKeyRequest request)
    {
        return _createMajorKey.Execute(request);
    }
    
    [HttpPost(template:"minor")]
    public Response CreateMinorKey(CreateMinorKeyRequest request)
    {
        return _createMinorKey.Execute(request);
    }
    
    
    [HttpPut(template:"major")]
    public Response UpdateMajorKey(UpdateMajorKeyRequest request)
    {
        return _updateMajorKey.Execute(request);
    }
    
    [HttpPut(template:"minor")]
    public Response UpdateMinorKey(UpdateMinorKeyRequest request)
    {
        return _updateMinorKey.Execute(request);
    }
    
    
    [HttpGet(template: "major")]
    public PaginatedResponse<ReadMultiMajorKeysResponse> ReadMultiMajorKeys([FromQuery]ReadMultMajorKeysRequest request)
    {
        return _readMultipleMajorKeys.Execute(request);
    }
    
    
    [HttpGet(template: "minor")]
    public PaginatedResponse<ReadMultipleMinorKeysResponse> ReadMultiMinorKeys([FromQuery]ReadMultipleMinorKeysRequest request)
    {
        return _readMultipleMinorKeys.Execute(request);
    }
    
    
    [HttpGet(template: "major/{id:int}")]
    public Response<ReadSingleMajorKeyResponse> ReadSingleMajorKeys(int id)
    {
        var request = new ReadSingleMajorKeyRequest() { Id = id};
        
        return _readSingleMajorKey.Execute(request);
    }
    
    
    [HttpGet(template: "minor/{id:int}")]
    public Response<ReadSingleMinorKeyResponse> ReadSingleMinorKeys(int id)
    {
        var request = new ReadSingleMinorKeyRequest() { Id = id};
        return _readSingleMinorKey.Execute(request);
    }
    
}