﻿using FastEndpoints;
using JWTGatewayHub.Core.ContributorAggregate;
using JWTGatewayHub.SharedKernel.Interfaces;

namespace JWTGatewayHub.Web.Endpoints.ContributorEndpoints;
public class List : EndpointWithoutRequest<ContributorListResponse>
{
  private readonly IRepository<Contributor> _repository;

  public List(IRepository<Contributor> repository)
  {
    _repository = repository;
  }

  public override void Configure()
  {
    Get("/Contributors");
    AllowAnonymous();
    Options(x => x
      .RequireAuthorization(c => c.RequireClaim("role", "parametrics:list"))
      .WithTags("ContributorEndpoints"));
  }
  public override async Task HandleAsync(CancellationToken cancellationToken)
  {
    var contributors = await _repository.ListAsync(cancellationToken);
    var response = new ContributorListResponse()
    {
      Contributors = contributors
        .Select(project => new ContributorRecord(project.Id, project.Name))
        .ToList()
    };

    await SendAsync(response, cancellation: cancellationToken);
  }
}
