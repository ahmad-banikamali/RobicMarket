using System.Security.Claims;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Website.Utils;

public static class UserId
{
    public static string GetBuyerId(this PageModel pageModel)
    {
        string buyerId;
        var user = pageModel.User;

        //if (user.Identity != null && user.Identity.IsAuthenticated)
            if (user.Identity is { IsAuthenticated: true })
            {
                buyerId = pageModel.User.FindFirstValue(ClaimTypes.NameIdentifier)??"";
            }
            else
            {
                //read from cookie
                buyerId = "";
            }

        return buyerId;
    }
    public static string? GetUserId(this PageModel pageModel)
    {
        return pageModel.User.FindFirstValue(ClaimTypes.NameIdentifier);

    }
}