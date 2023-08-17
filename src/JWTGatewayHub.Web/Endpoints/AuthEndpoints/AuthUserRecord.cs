using JWTGatewayHub.Core.Aggregates.Auth.LoginAggregate;

namespace JWTGatewayHub.Web.Endpoints.AuthEndpoints;
public record AuthUserRecord(
        string userName,
        string normalizedUserName,
        string email,
        string normalizedEmail,
        bool emailConfirmed,
        string passwordHash,
        string securityStamp,
        string concurrencyStamp,
        string phoneNumber,
        bool phoneNumberConfirmed,
        bool twoFactorEnabled,
        DateTimeOffset? lockoutEnd,
        int accessFailedCount)
{
  public static implicit operator AuthUserRecord?(AuthUser model)
    => new(model.UserName,
                              model.NormalizedUserName,
                              model.Email,
                              model.NormalizedEmail,
                              model.EmailConfirmed,
                              model.PasswordHash,
                              model.SecurityStamp,
                              model.ConcurrencyStamp,
                              model.PhoneNumber,
                              model.PhoneNumberConfirmed,
                              model.TwoFactorEnabled,
                              model.LockoutEnd,
                              model.AccessFailedCount);
}
