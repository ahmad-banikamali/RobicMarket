using Application.ProductService.ProductDetailKey.Major.Command.Update;
using Application.ProductService.ProductDetailKey.Major.Command.Update.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;

namespace Website.Pages.Products;

public class UpdateMajorKeyModel : PageModel
{
    private readonly UpdateMajorKey _updateMajorKey;

    [BindProperty] public UpdateMajorKeyRequest UpdateMajorKeyRequest { get; set; }

    public UpdateMajorKeyModel(UpdateMajorKey updateMajorKey)
    {
        _updateMajorKey = updateMajorKey;
    }

    public void OnGet()
    {
        
    }
    
    public IActionResult OnPost()
    {
        var response = _updateMajorKey.Execute(UpdateMajorKeyRequest);
        if (response.IsSuccess)
        {
            return RedirectToPage("/Products/ShowMajorKeys");
        }

        return Page();
    }
}