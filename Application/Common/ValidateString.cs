using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Application.Common;

public static class ValidateString
{
    public static bool IsValidEmail(this string source)
    {
        return new EmailAddressAttribute().IsValid(source);
    }
    
    public static bool IsValidPhoneNumber(this string source)
    {
        const string pattern = @"^09[0|1|2|3][0-9]{8}$";
        Regex reg = new Regex(pattern);
        return reg.IsMatch(source);
    }
}