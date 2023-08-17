using JWTGatewayHub.Core.Aggregates.Auth.LoginAggregate;
using JWTGatewayHub.Infrastructure.Data;

namespace JWTGatewayHub.Web.Seeders;
public class AuthUserSeeder
{
  public static readonly AuthUser[] users = new AuthUser[]
  {
        new AuthUser("usernameTest",
                     "usernametest",
                     "usernameTest@gmail.com",
                     "usernametest@gmail.com",
                     false,
                     false,
                     "AQAAAAIAAYagAAAAEPO2iJkJJAGJgMXp5fyGL7n3uOHvU0f+KXfPJxHfvFFQqmAaVHdBcUya7Qj1iCag7A==",
                     "015768904",
                     0),
  };

  public static void Seed(AppDbContext dbContext)
  {
    if (dbContext.AuthUsers.Any())
    {
      return;
    }

    dbContext.AuthUsers.AddRange(users);
    dbContext.SaveChanges();
  }
}
