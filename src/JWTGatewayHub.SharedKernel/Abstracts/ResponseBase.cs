namespace JWTGatewayHub.SharedKernel.Abstracts;
public abstract class ResponseBase
{
  public string Name { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public string ShortName { get; set; } = string.Empty;
  public ResponseBase(string name, string description, string shortName)
  {
    Name = name;
    Description = description;
    ShortName = shortName;
  }
}
