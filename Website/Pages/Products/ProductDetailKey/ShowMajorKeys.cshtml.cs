using Application.ProductService.ProductDetailKey.Major.Query.ReadMultiple;
using Application.ProductService.ProductDetailKey.Major.Query.ReadMultiple.Dto;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Website.Pages.Products.ProductDetailKey;

public class ShowMajorKeysModel : PageModel
{
    private readonly ReadMultipleMajorKeys _readMultipleMajorKeys;
    public   List<ReadMultiMajorKeysResponse> MajorKeysResponse { get; set; }

    public ShowMajorKeysModel(ReadMultipleMajorKeys readMultipleMajorKeys)
    {
        _readMultipleMajorKeys = readMultipleMajorKeys;
    }
    
    public void OnGet()
    {
        MajorKeysResponse = _readMultipleMajorKeys.Execute(new ReadMultMajorKeysRequest()).Data.ToList();
    }

    
}