using System.ComponentModel.DataAnnotations;
using JWTGatewayHub.SharedKernel.Abstracts;

namespace JWTGatewayHub.Web.Endpoints.ContributorEndpoints;
public class CreateContributorRequest : RequestBase
{
  public const string Route = "/Contributors";

  [Required( ErrorMessage = "El nombre es requerido")]
  [RegularExpression(@"^[A-Za-z]{1,30}$", ErrorMessage = "El nombre debe contener solo letras y tener un máximo de 30 caracteres.")]
  public string? Name { get; set; }
}
