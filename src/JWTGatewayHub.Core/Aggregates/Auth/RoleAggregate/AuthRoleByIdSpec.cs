using Ardalis.Specification;
using JWTGatewayHub.SharedKernel.Enums;

namespace JWTGatewayHub.Core.Aggregates.Auth.RoleAggregate;
public class AuthRoleByIdSpec : Specification<AuthRole>, ISingleResultSpecification
{
  public AuthRoleByIdSpec(Guid roleId)
  {
    Query
        .Where(x => x.Id == roleId 
                 && x.StatusCode == (int)StateEnum.Enabled);
  }
}
