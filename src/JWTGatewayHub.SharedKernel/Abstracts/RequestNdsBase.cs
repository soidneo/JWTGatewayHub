using System.ComponentModel.DataAnnotations;

namespace JWTGatewayHub.SharedKernel.Abstracts;
public abstract class RequestNdsBase : RequestBase
{
  [Required(ErrorMessage = "El campo Nombre es requerido.")]
  [RegularExpression(@"^.+[a-zA-ZáéíóúÁÉÍÓÚñÑüÜ\s.'-]{1,50}$", ErrorMessage = "El campo Nombre debe contener entre 2 y 50 caracteres y solo puede contener letras, espacios, puntos, apostrofes y guiones.")]
  public string Name { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  [RegularExpression(@"^[a-zA-Z0-9]{1,5}$", ErrorMessage = "El campo Abreviatura debe contener entre 2 y 5 caracteres y solo puede contener letras, espacios, puntos, apostrofes y guiones.")]
  public virtual string ShortName { get; set; } = string.Empty;
}
