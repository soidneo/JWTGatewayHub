using FastEndpoints;
using JWTGatewayHub.Core.ContributorAggregate;
using JWTGatewayHub.SharedKernel.Interfaces;
using JWTGatewayHub.Web.EndpoGuids.ContributorEndpoGuids;

namespace JWTGatewayHub.Web.Endpoints.ContributorEndpoints;
public class Create : Endpoint<CreateContributorRequest, CreateContributorResponse>
{
  private readonly IRepository<Contributor> _repository;

  public Create(IRepository<Contributor> repository)
  {
    _repository = repository;
  }

  public override void Configure()
  {
    Post(CreateContributorRequest.Route);
    Options(x => x
      .RequireAuthorization(c => c.RequireClaim("role", "parametrics:create"))
      .WithTags("ContributorEndpoints"));
  }
  public override async Task HandleAsync(
    CreateContributorRequest request,
    CancellationToken cancellationToken)
  {
    if (request.Name == null)
    {
      ThrowError("Name is required");
    }

    var newContributor = new Contributor(request.Name);
    var createdItem = await _repository.AddAsync(newContributor, cancellationToken);
    var response = new CreateContributorResponse
    (
      id: createdItem.Id,
      name: createdItem.Name
    );

    await SendAsync(response, cancellation: cancellationToken);
  }
}
