using Application.ProductService.ProductDetailKey.Major.Command.Create;
using Application.ProductService.ProductDetailKey.Major.Query.ReadMultiple;
using Application.ProductService.ProductDetailKey.Major.Query.ReadMultiple.Dto;
using Application.ProductService.ProductDetailKey.Minor.Command.Create.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Website.Pages.Products;

public class CreateMinorKey : PageModel
{
    private readonly Application.ProductService.ProductDetailKey.Minor.Command.Create.CreateMinorKey _createMinorKey;
    private readonly ReadMultiMajorKeys _readMultiMajorKeys;
    public List<SelectListItem> MajorKeys { get; set; }

    [BindProperty]
    public CreateMinorKeyRequest CreateMinorKeyRequest { get; set; }

    public CreateMinorKey(
        Application.ProductService.ProductDetailKey.Minor.Command.Create.CreateMinorKey createMinorKey,
        ReadMultiMajorKeys readMultiMajorKeys
        
        )
    {
        _createMinorKey = createMinorKey;
        _readMultiMajorKeys = readMultiMajorKeys;
    }

    public void OnGet()
    {
        MajorKeys = _readMultiMajorKeys.Execute(new ReadMultMajorKeysRequest()).Data.Select(x=>new SelectListItem(x.Name,x.Id)).ToList();
        
    }


    public void OnPost()
    {
        _createMinorKey.Execute(CreateMinorKeyRequest);
    }
}