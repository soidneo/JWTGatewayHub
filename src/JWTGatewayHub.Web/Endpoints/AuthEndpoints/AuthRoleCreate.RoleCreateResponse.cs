namespace JWTGatewayHub.Web.Endpoints.Security.AuthEndpoints;

public class RoleCreateResponse
{
  public string Name { get; set; }
  public RoleCreateResponse(string name)
  {
    Name = name;
  }
}
