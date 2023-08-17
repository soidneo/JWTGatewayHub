using FastEndpoints;
using JWTGatewayHub.Core.Aggregates.Auth.LoginAggregate;
using JWTGatewayHub.Core.Aggregates.Auth.UserRoleAggregate;
using JWTGatewayHub.SharedKernel.Helpers;
using JWTGatewayHub.SharedKernel.Interfaces;
using JWTGatewayHub.Web.Endpoints.Security.AuthEndpoints;

namespace JWTGatewayHub.Web.Endpoints.AuthEndpoints;

public class AuthLogin : Endpoint<AuthLoginRequest, AuthLoginResponse>
{
  private readonly IRepository<AuthUser> _repository;
  private readonly IRepository<AuthUserRole> _userRoleRepository;

  public AuthLogin(IRepository<AuthUser> repository, IRepository<AuthUserRole> userRoleRepository)
  {
    _repository = repository;
    _userRoleRepository = userRoleRepository;
  }

  public override void Configure()
  {
    Post(AuthLoginRequest.Route);
    AllowAnonymous();
    Options(x => x
      .WithTags("Auth.Login.Endpoints")); ;
  }
  public override async Task HandleAsync(AuthLoginRequest request, CancellationToken cancellationToken)
  {
    if (!request.Validate(ValidationFailures)) ThrowError("");
    try
    {
      var spec = new AuthUserLoginSpec(request.Username);
      var userLogin = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
      if (userLogin == null)
      {
        await SendUnauthorizedAsync(cancellationToken);
        return;
      }
      bool verified = StringHelper.VerifyPassword(request.Username, request.Password, userLogin!.PasswordHash);
      if (!verified)
      {
        await SendUnauthorizedAsync(cancellationToken);
        return;
      }
      var rolesSpec = new AuthUserRoleListByIdSpec(userLogin.Id);
      var userRoleList = await _userRoleRepository.ListAsync(rolesSpec, cancellationToken);

      var roleList = new List<string>();
      foreach (var userRole in userRoleList)
      {
        roleList.Add(userRole.AuthRole!.RoleName);
      }
      var claims = JwtHelper.GetClaimsFromRoles(roleList, request.Username);
      var token = JwtHelper.GetStringJwtToken(AuthLoginRequest.SigningKey, claims);
      AuthLoginResponse response = new()
      {
        AuthUser = userLogin,
        Token = token
      };
      await SendAsync(response, cancellation: cancellationToken);
    }
    catch (Exception ex)
    {
      ThrowError($"No se pudo acceder al servicio: {ex}");
    }
  }
}
