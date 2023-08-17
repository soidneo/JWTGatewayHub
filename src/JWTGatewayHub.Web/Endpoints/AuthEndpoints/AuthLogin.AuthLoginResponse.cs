using JWTGatewayHub.Web.Endpoints.AuthEndpoints;

namespace JWTGatewayHub.Web.Endpoints.Security.AuthEndpoints;

public class AuthLoginResponse
{
  public AuthUserRecord? AuthUser { get; set; }
  public string Token { get; set; } = string.Empty;
}
