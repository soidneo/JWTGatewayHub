using FastEndpoints;
using JWTGatewayHub.Core.Aggregates.Auth.LoginAggregate;
using JWTGatewayHub.Core.Aggregates.Auth.UserRoleAggregate;
using JWTGatewayHub.SharedKernel.Helpers;
using JWTGatewayHub.SharedKernel.Interfaces;
using JWTGatewayHub.Web.Endpoints.Security.AuthEndpoints;

namespace JWTGatewayHub.Web.Endpoints.AuthEndpoints;

public class AuthUserCreate : Endpoint<AuthUserCreateRequest, UsersCreateResponse>
{
  private readonly IRepository<AuthUser> _repository;
  private readonly IRepository<AuthUserRole> _roleRepository;

  public AuthUserCreate(IRepository<AuthUser> repository, IRepository<AuthUserRole> roleRepository)
  {
    _repository = repository;
    _roleRepository = roleRepository;
  }

  public override void Configure()
  {
    Post("/Usuarioss");
    Options(x => x
      .RequireAuthorization(p => p.RequireClaim("super-rol", "admin"))
      .WithTags("Auth.User.Endpoints"));
  }
  public override async Task HandleAsync(AuthUserCreateRequest request, CancellationToken cancellationToken)
  {
    if (!request.Validate(ValidationFailures)) ThrowError("");
    try
    {
      var newAuthUser = new AuthUser(request.UserName,
              StringHelper.NormalizeName(request.UserName),
              request.Email,
              StringHelper.NormalizeEmail(request.Email),
              false,
              request.TwoFactorEnabled,
              StringHelper.HashPassword(request.UserName, request.PasswordHash),
              request.PhoneNumber,
              0);
      var createdItem = await _repository.AddAsync(newAuthUser, cancellationToken);
      if (request.Roles != null)
      {
        foreach (var item in request.Roles)
        {
          await _roleRepository.AddAsync(new AuthUserRole(item, newAuthUser.Id), cancellationToken);
        }
      }
      var response = new UsersCreateResponse(createdItem);
      await SendAsync(response, cancellation: cancellationToken);
    }
    catch (Exception)
    {
      ThrowError($"{request.UserName} cant be created");
    }
  }

}
