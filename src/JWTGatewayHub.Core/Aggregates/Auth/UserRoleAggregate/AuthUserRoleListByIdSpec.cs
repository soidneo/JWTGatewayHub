using Ardalis.Specification;
using JWTGatewayHub.SharedKernel.Enums;

namespace JWTGatewayHub.Core.Aggregates.Auth.UserRoleAggregate;
public class AuthUserRoleListByIdSpec : Specification<AuthUserRole>, ISingleResultSpecification
{
  public AuthUserRoleListByIdSpec(Guid userId)
  {
    Query
        .Where(x => x.AuthUserId == userId
                 && x.StatusCode == (int)StateEnum.Enabled)
        .Include("AuthRole")
        .Include("AuthUser");
  }
}
