using FastEndpoints;
using JWTGatewayHub.Core.Aggregates.Auth.RoleAggregate;
using JWTGatewayHub.SharedKernel.Interfaces;
using JWTGatewayHub.Web.Endpoints.Security.AuthEndpoints;

namespace JWTGatewayHub.Web.Endpoints.AuthEndpoints;

public class AuthRoleCreate : Endpoint<RoleCreateRequest, RoleCreateResponse>
{
  private readonly IRepository<AuthRole> _repository;

  public AuthRoleCreate(IRepository<AuthRole> repository)
  {
    _repository = repository;
  }

  public override void Configure()
  {
    Post(RoleCreateRequest.Route);
    AllowAnonymous();
    Options(x => x
      .WithTags("Auth.Role.Endpoints")); ;
  }
  public override async Task HandleAsync(RoleCreateRequest request, CancellationToken cancellationToken)
  {
    if (!request.Validate(ValidationFailures)) ThrowError("");
    try
    {
      var newAuthRole = new AuthRole(request.RoleName);
      var createdItem = await _repository.AddAsync(newAuthRole!, cancellationToken);
      var response = new RoleCreateResponse(createdItem.RoleName);
      await SendAsync(response, cancellation: cancellationToken);
    }
    catch (Exception)
    {
      ThrowError($"{request.RoleName} cant be created");
    }
  }
}
