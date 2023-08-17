using Ardalis.GuardClauses;
using JWTGatewayHub.SharedKernel;
using JWTGatewayHub.SharedKernel.Interfaces;
using JWTGatewayHub.Core.Aggregates.Auth.UserRoleAggregate;

namespace JWTGatewayHub.Core.Aggregates.Auth.LoginAggregate;
public class AuthUser : EntityBase, IAggregateRoot
{
  public string UserName { get; set; } = string.Empty;
  public string NormalizedUserName { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;
  public string NormalizedEmail { get; set; } = string.Empty;
  public bool EmailConfirmed { get; set; }
  public string PasswordHash { get; set; } = string.Empty;
  public string SecurityStamp { get; set; } = Guid.NewGuid().ToString();
  public string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();
  public string PhoneNumber { get; set; } = string.Empty;
  public bool PhoneNumberConfirmed { get; set; }
  public bool TwoFactorEnabled { get; set; }
  public DateTimeOffset? LockoutEnd { get; set; }
  public int AccessFailedCount { get; set; }
  public virtual ICollection<AuthUserRole>? AuthUserRoles { get; set; }

  public AuthUser(string userName,
              string normalizedUserName,
              string email,
              string normalizedEmail,
              bool emailConfirmed,
              bool twoFactorEnabled,
              string passwordHash,
              string phoneNumber,
              int accessFailedCount)
  {
    Guid securityStamp = Guid.NewGuid();
    Guid concurrencyStamp = Guid.NewGuid();
    bool phoneNumberConfirmed = false;
    UserName = Guard.Against.Null(userName, nameof(userName));
    NormalizedUserName = Guard.Against.Null(normalizedUserName, nameof(normalizedUserName));
    Email = Guard.Against.Null(email, nameof(email));
    NormalizedEmail = Guard.Against.Null(normalizedEmail, nameof(normalizedEmail));
    EmailConfirmed = Guard.Against.Null(emailConfirmed, nameof(emailConfirmed));
    PasswordHash = Guard.Against.Null(passwordHash, nameof(passwordHash));
    SecurityStamp = Guard.Against.NullOrEmpty(securityStamp.ToString(), nameof(securityStamp));
    ConcurrencyStamp = Guard.Against.Null(concurrencyStamp.ToString(), nameof(concurrencyStamp));
    PhoneNumber = Guard.Against.Null(phoneNumber, nameof(phoneNumber));
    PhoneNumberConfirmed = Guard.Against.Null(phoneNumberConfirmed, nameof(phoneNumberConfirmed));
    TwoFactorEnabled = Guard.Against.Null(twoFactorEnabled, nameof(twoFactorEnabled));
    AccessFailedCount = Guard.Against.Null(accessFailedCount, nameof(accessFailedCount));
  }
  public void UpdateFields(string userName,
              string normalizedUserName,
              string email,
              string normalizedEmail,
              string securityStamp,
              bool emailConfirmed,
              bool phoneNumberConfirmed,
              bool twoFactorEnabled,
              string passwordHash,
              string phoneNumber,
              int accessFailedCount)
  {
    Guid concurrencyStamp = Guid.NewGuid();
    UserName = Guard.Against.Null(userName, nameof(userName));
    NormalizedUserName = Guard.Against.Null(normalizedUserName, nameof(normalizedUserName));
    Email = Guard.Against.Null(email, nameof(email));
    NormalizedEmail = Guard.Against.Null(normalizedEmail, nameof(normalizedEmail));
    EmailConfirmed = Guard.Against.Null(emailConfirmed, nameof(emailConfirmed));
    PasswordHash = Guard.Against.Null(passwordHash, nameof(passwordHash));
    SecurityStamp = Guard.Against.NullOrEmpty(securityStamp, nameof(securityStamp));
    ConcurrencyStamp = Guard.Against.Null(concurrencyStamp.ToString(), nameof(concurrencyStamp));
    PhoneNumber = Guard.Against.Null(phoneNumber, nameof(phoneNumber));
    PhoneNumberConfirmed = Guard.Against.Null(phoneNumberConfirmed, nameof(phoneNumberConfirmed));
    TwoFactorEnabled = Guard.Against.Null(twoFactorEnabled, nameof(twoFactorEnabled));
    AccessFailedCount = Guard.Against.Null(accessFailedCount, nameof(accessFailedCount));
  }
  public void UpdatePassword(string passwordHash)
  {
    Guid securityStamp = Guid.NewGuid();
    Guid concurrencyStamp = Guid.NewGuid();
    PasswordHash = Guard.Against.Null(passwordHash, nameof(passwordHash));
    SecurityStamp = Guard.Against.NullOrEmpty(securityStamp.ToString(), nameof(securityStamp));
    ConcurrencyStamp = Guard.Against.Null(concurrencyStamp.ToString(), nameof(concurrencyStamp));
  }
  public void UpdateEmailConfirmed(bool emailConfirmed)
  {
    Guid securityStamp = Guid.NewGuid();
    Guid concurrencyStamp = Guid.NewGuid();
    EmailConfirmed = Guard.Against.Null(emailConfirmed, nameof(emailConfirmed));
    SecurityStamp = Guard.Against.NullOrEmpty(securityStamp.ToString(), nameof(securityStamp));
    ConcurrencyStamp = Guard.Against.Null(concurrencyStamp.ToString(), nameof(concurrencyStamp));
  }
  public void UpdatePhoneNumberConfirmed(bool phoneNumberConfirmed)
  {
    Guid securityStamp = Guid.NewGuid();
    Guid concurrencyStamp = Guid.NewGuid();
    PhoneNumberConfirmed = Guard.Against.Null(phoneNumberConfirmed, nameof(phoneNumberConfirmed));
    SecurityStamp = Guard.Against.NullOrEmpty(securityStamp.ToString(), nameof(securityStamp));
    ConcurrencyStamp = Guard.Against.Null(concurrencyStamp.ToString(), nameof(concurrencyStamp));
  }
  public void UpdateTwoFactorEnabled(bool twoFactorEnabled)
  {
    Guid securityStamp = Guid.NewGuid();
    Guid concurrencyStamp = Guid.NewGuid();
    TwoFactorEnabled = Guard.Against.Null(twoFactorEnabled, nameof(twoFactorEnabled));
    SecurityStamp = Guard.Against.NullOrEmpty(securityStamp.ToString(), nameof(securityStamp));
    ConcurrencyStamp = Guard.Against.Null(concurrencyStamp.ToString(), nameof(concurrencyStamp));
  }
  public void UpdateAccessFailedCount(int accessFailedCount)
  {
    AccessFailedCount = Guard.Against.Null(accessFailedCount, nameof(accessFailedCount));
  }
}
