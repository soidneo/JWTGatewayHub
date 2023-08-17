using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace JWTGatewayHub.SharedKernel.Helpers;
public static class JwtHelper
{
  private static readonly string _secretKey = "T$4r%6&EFu8=?/iYF%5544FuiYUu/&IJGf";
  public static Claim[] GetClaimsFromRoles(List<string> roleList, string username)
  {
    var claimsList = new List<Claim>
    {
      new Claim(ClaimTypes.Name, username)
    };
    foreach (var role in roleList)
    {
      claimsList.Add(new Claim(ClaimTypes.Role, role));
    }

    return claimsList.ToArray();
  }

  public static SecurityToken GetJwtToken(string signKey, Claim[] claims)
  {
    var tokenHandler = new JwtSecurityTokenHandler();
    var byteKey = Encoding.UTF8.GetBytes(signKey);
    var tokenDes = new SecurityTokenDescriptor
    {
      Subject = new ClaimsIdentity(claims),
      Expires = DateTime.UtcNow.AddMinutes(60),
      SigningCredentials = new SigningCredentials(
              new SymmetricSecurityKey(byteKey),
              SecurityAlgorithms.HmacSha256Signature
        )
    };
    return tokenHandler.CreateToken(tokenDes);
  }
  public static string GetStringJwtToken(string signKey, Claim[] claims)
  {
    var tokenHandler = new JwtSecurityTokenHandler();
    return tokenHandler.WriteToken(GetJwtToken(signKey, claims));
  }

  public static ClaimsPrincipal ReadToken(string jwtToken)
  {
    try
    {
      JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
      TokenValidationParameters validationParameters = new TokenValidationParameters
      {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey))
      };
      ClaimsPrincipal claimsPrincipal = tokenHandler.ValidateToken(jwtToken, validationParameters, out SecurityToken validatedToken);
      return claimsPrincipal;
    }
    catch (Exception)
    {
      throw;
    }



  }
  public static string GetSecretKey() => _secretKey;
}
