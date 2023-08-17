using System.Globalization;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Identity;

namespace JWTGatewayHub.SharedKernel.Helpers;
public static class StringHelper
{
  public static string NormalizeName(string name)
  {
    string trimmedName = name.Trim();
    TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
    string normalizedName = textInfo.ToTitleCase(trimmedName);
    return normalizedName;
  }
  public static string NormalizeEmail(string email)
  {
    string trimmedEmail = email.Trim();
    string normalizedEmail = trimmedEmail.ToLower();
    if (!IsValidEmail(normalizedEmail))
    {
      throw new ArgumentException("El correo electrónico no tiene un formato válido.");
    }
    return normalizedEmail;
  }
  public static bool IsValidEmail(string email)
  {
    string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
    return Regex.IsMatch(email, pattern);
  }

  public static string HashPassword(string user, string password)
  {
    var passwordHasher = new PasswordHasher<string>();
    return passwordHasher.HashPassword(user, password);
  }

  public static bool VerifyPassword(string user, string password, string hashedPassword)
  {
    var passwordHasher = new PasswordHasher<string>();
    var result = passwordHasher.VerifyHashedPassword(user, hashedPassword, password);

    return result == PasswordVerificationResult.Success;
  }

}
