using Ardalis.Result;

namespace JWTGatewayHub.Core.Interfaces;
public interface IDeleteContributorService
{
  public Task<Result> DeleteContributor(Guid contributorId);
}
