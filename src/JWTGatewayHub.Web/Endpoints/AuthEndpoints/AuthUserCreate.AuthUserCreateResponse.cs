using JWTGatewayHub.Core.Aggregates.Auth.LoginAggregate;
using JWTGatewayHub.Web.Endpoints.AuthEndpoints;

namespace JWTGatewayHub.Web.Endpoints.Security.AuthEndpoints;

public class UsersCreateResponse
{
  public AuthUserRecord User { get; set; }
  public UsersCreateResponse(AuthUser model)
  {
    User = model!;
  }
}
