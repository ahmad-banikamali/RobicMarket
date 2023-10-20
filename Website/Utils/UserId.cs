using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Website.Utils;

public static class UserId
{
    public static string GetBuyerId(this PageModel pageModel, UserManager<ApplicationUser> userManager)
    {
        string buyerId;
        var user = pageModel.User;

        //if (user.Identity != null && user.Identity.IsAuthenticated)
            if (user.Identity is { IsAuthenticated: true })
            {
                buyerId = userManager.GetUserId(user)??"";
            }
            else
            {
                //read from cookie
                buyerId = "";
            }

        return buyerId;
    }
}