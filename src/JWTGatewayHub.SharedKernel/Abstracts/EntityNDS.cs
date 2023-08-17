using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace JWTGatewayHub.SharedKernel.Abstracts;
public abstract class EntityNDS : EntityBase
{
  [Required]
  [StringLength(100)]
  public string Name { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  [StringLength(5)]
  public virtual string ShortName { get; set; } = string.Empty;

  public EntityNDS(string name, string description, string shortName = "")
  {
    Name = Guard.Against.Null(name, nameof(name));
    Description = Guard.Against.Null(description, nameof(description));
    ShortName = Guard.Against.Null(shortName, nameof(shortName));
  }
  public void UpdateBasicFields(string name, string description, string shortName = "")
  {
    Name = Guard.Against.Null(name, nameof(name));
    Description = Guard.Against.Null(description, nameof(description));
    ShortName = Guard.Against.Null(shortName, nameof(shortName));
    UpdatedAt = Guard.Against.OutOfSQLDateRange(DateTime.Now, nameof(DateTime));
  }
}
