using MediatR;

namespace JWTGatewayHub.SharedKernel.Abstracts;
public abstract class DomainEventBase : INotification
{
  public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
}
