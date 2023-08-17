using Ardalis.GuardClauses;
using JWTGatewayHub.SharedKernel;
using JWTGatewayHub.SharedKernel.Interfaces;
using JWTGatewayHub.Core.Aggregates.Auth.UserRoleAggregate;

namespace JWTGatewayHub.Core.Aggregates.Auth.RoleAggregate;
public class AuthRole : EntityBase, IAggregateRoot
{
  public string RoleName { get; set; } = string.Empty;
  public virtual ICollection<AuthUserRole>? AuthUserRoles { get; set; }

  public AuthRole(string roleName)
  {
    RoleName = Guard.Against.Null(roleName, nameof(roleName));
  }
  public void UpdateFields(string roleName)
  {
    RoleName = Guard.Against.Null(roleName, nameof(roleName));
    UpdatedAt = Guard.Against.OutOfSQLDateRange(DateTime.Now, nameof(DateTime));
  }
}
