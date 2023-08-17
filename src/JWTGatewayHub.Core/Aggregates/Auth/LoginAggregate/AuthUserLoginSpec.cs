using Ardalis.Specification;
using JWTGatewayHub.SharedKernel.Enums;

namespace JWTGatewayHub.Core.Aggregates.Auth.LoginAggregate;
public class AuthUserLoginSpec : Specification<AuthUser>, ISingleResultSpecification
{
  public AuthUserLoginSpec(string userName)
  {
    Query
        .Where(x => x.UserName == userName 
                  && x.StatusCode == (int)StateEnum.Enabled);
  }
}
