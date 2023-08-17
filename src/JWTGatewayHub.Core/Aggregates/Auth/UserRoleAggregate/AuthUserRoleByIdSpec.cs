using Ardalis.Specification;
using JWTGatewayHub.SharedKernel.Enums;

namespace JWTGatewayHub.Core.Aggregates.Auth.UserRoleAggregate;
public class AuthRoleByIdSpec : Specification<AuthUserRole>, ISingleResultSpecification
{
  public AuthRoleByIdSpec(Guid roleId)
  {
    Query
        .Where(x => x.Id == roleId 
                 && x.StatusCode == (int)StateEnum.Enabled);
  }
}
