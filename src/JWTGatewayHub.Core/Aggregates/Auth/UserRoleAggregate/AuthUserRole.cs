using Ardalis.GuardClauses;
using JWTGatewayHub.Core.Aggregates.Auth.LoginAggregate;
using JWTGatewayHub.Core.Aggregates.Auth.RoleAggregate;
using JWTGatewayHub.SharedKernel;
using JWTGatewayHub.SharedKernel.Interfaces;

namespace JWTGatewayHub.Core.Aggregates.Auth.UserRoleAggregate;
public class AuthUserRole : EntityBase, IAggregateRoot
{
  public Guid AuthRoleId { get; set; }
  public Guid AuthUserId { get; set; }
  public virtual AuthRole? AuthRole { get; set; }
  public virtual AuthUser? AuthUser { get; set; }
  public AuthUserRole(Guid authRoleId, Guid authUserId)
  {
    AuthRoleId = Guard.Against.Null(authRoleId, nameof(authRoleId));
    AuthUserId = Guard.Against.Null(authUserId, nameof(authUserId));
  }
  public void UpdateFields(Guid authRoleId, Guid authUserId)
  {
    AuthRoleId = Guard.Against.Null(authRoleId, nameof(authRoleId));
    AuthUserId = Guard.Against.Null(authUserId, nameof(authUserId));
    UpdatedAt = Guard.Against.OutOfSQLDateRange(DateTime.Now, nameof(DateTime));
  }
}
