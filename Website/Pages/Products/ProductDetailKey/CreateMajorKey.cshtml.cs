using Application.ProductService.ProductDetailKey.Major.Command.Create;
using Application.ProductService.ProductDetailKey.Major.Command.Create.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Website.Pages.Products.ProductDetailKey;

public class CreateMajorKeyModel : PageModel
{
    private readonly CreateMajorKey _createMajorKey;

    [BindProperty]
    public CreateMajorKeyRequest CreateMajorKeyRequest { get; set; }

    public CreateMajorKeyModel(CreateMajorKey createMajorKey)
    {
        _createMajorKey = createMajorKey;
    }

    public void OnGet()
    {
    }

    public void OnPost()
    {
        _createMajorKey.Execute(CreateMajorKeyRequest);
    }
}