using JWTGatewayHub.Core.Aggregates.Auth.UserRoleAggregate;
using JWTGatewayHub.Infrastructure.Data;

namespace JWTGatewayHub.Web.Seeders;

public class AuthUserRolesSeeder
{
  public static void Seed(AppDbContext dbContext)
  {
    if (!dbContext.AuthUserRoles.Any())
    {
      var role1 = dbContext.AuthRoles.FirstOrDefault(x => x.RoleName == "admin")!.Id;
      var role2 = dbContext.AuthRoles.FirstOrDefault(x => x.RoleName == "contributor:create")!.Id;
      var role3 = dbContext.AuthRoles.FirstOrDefault(x => x.RoleName == "contributor:list")!.Id;
      var userId = dbContext.AuthUsers.FirstOrDefault(x => x.StatusCode == 1)!.Id;
      dbContext.AuthUserRoles.AddRange(
          new AuthUserRole(role1, userId),
          new AuthUserRole(role2, userId),
          new AuthUserRole(role3, userId)
      );
      dbContext.SaveChanges();
    }
  }
}
