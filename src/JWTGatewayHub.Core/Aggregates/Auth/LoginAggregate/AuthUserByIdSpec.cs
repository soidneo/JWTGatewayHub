using Ardalis.Specification;
using JWTGatewayHub.SharedKernel.Enums;

namespace JWTGatewayHub.Core.Aggregates.Auth.LoginAggregate;
public class AuthUserByIdSpec : Specification<AuthUser>, ISingleResultSpecification
{
  public AuthUserByIdSpec(Guid userId)
  {
    Query
       .Where(x => x.Id == userId 
                && x.LockoutEnd == null 
                && x.StatusCode == (int)StateEnum.Enabled);
  }
}
