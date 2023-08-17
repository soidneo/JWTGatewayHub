using System.ComponentModel.DataAnnotations;
using JWTGatewayHub.SharedKernel.Abstracts;

namespace JWTGatewayHub.Web.Endpoints.Security.AuthEndpoints;

public class AuthUserCreateRequest : RequestBase
{
  public const string Route = "/auth/users";
  [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
  public string UserName { get; set; } = string.Empty;

  [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
  [EmailAddress(ErrorMessage = "Ingrese una dirección de correo electrónico válida.")]
  public string Email { get; set; } = string.Empty;

  [Required(ErrorMessage = "La contraseña es obligatoria.")]
  [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$", ErrorMessage = "La contraseña debe contener al menos 8 caracteres, incluyendo al menos una letra y un número.")]
  public string PasswordHash { get; set; } = string.Empty;

  [RegularExpression(@"^\d{10}$", ErrorMessage = "El número de teléfono debe tener 10 dígitos.")]
  public string PhoneNumber { get; set; } = string.Empty;
  public List<Guid>? Roles { get; set; }

  public bool TwoFactorEnabled { get; set; }

}
