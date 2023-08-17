using System.ComponentModel.DataAnnotations;
using System.Reflection;
using JWTGatewayHub.SharedKernel.Helpers;

namespace JWTGatewayHub.SharedKernel.Abstracts;
public abstract class RequestBase
{
  public static string SigningKey = JwtHelper.GetSecretKey();
  public PropertyInfo[] GetAllProperties()
  {
    var type = GetType();
    var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
    return properties;
  }
  public bool Validate(List<FluentValidation.Results.ValidationFailure> validationFailures)
  {
    validationFailures ??= new();
    bool valid = true;
    foreach (var property in GetAllProperties())
    {
      var value = property.GetValue(this);

      if (property.GetCustomAttributes(typeof(ValidationAttribute), true) is not IEnumerable<ValidationAttribute> validationAttributes)
      {
        return valid;
      }
      foreach (var validationAttribute in validationAttributes)
      {
        if (!validationAttribute.IsValid(value) && validationAttribute.ErrorMessage != null)
        {
          validationFailures.Add(new(property.Name, validationAttribute.ErrorMessage));
          valid = false;
        }
      }
    }
    return valid;
  }
}
