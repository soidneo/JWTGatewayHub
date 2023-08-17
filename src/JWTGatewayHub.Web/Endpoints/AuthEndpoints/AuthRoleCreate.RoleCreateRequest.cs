using System.ComponentModel.DataAnnotations;
using JWTGatewayHub.SharedKernel.Abstracts;

namespace JWTGatewayHub.Web.Endpoints.Security.AuthEndpoints;

public class RoleCreateRequest : RequestBase
{
  public const string Route = "/auth/roles";
  [Required(ErrorMessage = "El nombre de el rol es obligatorio.")]
  public string RoleName { get; set; } = string.Empty;

}
