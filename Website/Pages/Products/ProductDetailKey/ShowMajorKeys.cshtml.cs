using Application.ProductService.ProductDetailKey.Major.Query.ReadMultiple;
using Application.ProductService.ProductDetailKey.Major.Query.ReadMultiple.Dto;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Website.Pages.Products.ProductDetailKey;

public class ShowMajorKeysModel : PageModel
{
    private readonly ReadMultiMajorKeys _readMultiMajorKeys;
    public   List<ReadMultiMajorKeysResponse> MajorKeysResponse { get; set; }

    public ShowMajorKeysModel(ReadMultiMajorKeys readMultiMajorKeys)
    {
        _readMultiMajorKeys = readMultiMajorKeys;
    }
    
    public void OnGet()
    {
        MajorKeysResponse = _readMultiMajorKeys.Execute(new ReadMultMajorKeysRequest()).Data.ToList();
    }

    
}