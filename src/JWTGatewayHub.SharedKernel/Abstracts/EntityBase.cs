using System.ComponentModel.DataAnnotations.Schema;
using Ardalis.GuardClauses;
using JWTGatewayHub.SharedKernel.Enums;

namespace JWTGatewayHub.SharedKernel.Abstracts;
public abstract class EntityBase
{
  public Guid Id { get; set; } = Guid.NewGuid();
  public DateTime CreatedAt { get; set; } = DateTime.Now;
  public DateTime UpdatedAt { get; set; } = DateTime.Now;
  public string JsonFIeld { get; set; } = string.Empty;
  public int StatusCode { get; set; } = (int)StateEnum.Enabled;

  private readonly List<DomainEventBase> _domainEvents = new();
  [NotMapped]
  public IEnumerable<DomainEventBase> DomainEvents => _domainEvents.AsReadOnly();

  protected void RegisterDomainEvent(DomainEventBase domainEvent) => _domainEvents.Add(domainEvent);
  internal void ClearDomainEvents() => _domainEvents.Clear();

  public void Remove()
  {
    StatusCode = Guard.Against.Negative(0);
  }
}
