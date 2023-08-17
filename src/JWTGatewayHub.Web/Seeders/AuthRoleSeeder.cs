using JWTGatewayHub.Core.Aggregates.Auth.RoleAggregate;
using JWTGatewayHub.Infrastructure.Data;

namespace JWTGatewayHub.Web.Seeders;

public class AuthRoleSeeder
{
  public static void Seed(AppDbContext dbContext)
  {
    if (!dbContext.AuthRoles.Any())
    {
      dbContext.AuthRoles.AddRange(
          new AuthRole("admin"),
          new AuthRole("contributor:create"),
          new AuthRole("contributor:list"),
          new AuthRole("contributor:getbyid"),
          new AuthRole("contributor:update"),
          new AuthRole("contributor:delete")
      );
      dbContext.SaveChanges();
    }
  }
}
