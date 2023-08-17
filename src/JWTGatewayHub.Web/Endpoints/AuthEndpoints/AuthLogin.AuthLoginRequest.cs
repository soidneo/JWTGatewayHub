using System.ComponentModel.DataAnnotations;
using JWTGatewayHub.SharedKernel.Abstracts;

namespace JWTGatewayHub.Web.Endpoints.Security.AuthEndpoints;

public class AuthLoginRequest : RequestBase
{
  public const string Route = "/auth/login";

  [Required(ErrorMessage = "El campo nombre de usuario es requerido.")]
  public string Username { get; set; } = string.Empty;

  [Required(ErrorMessage = "El campo contraseñaes requerido.")]
  public string Password { get; set; } = string.Empty;
}
