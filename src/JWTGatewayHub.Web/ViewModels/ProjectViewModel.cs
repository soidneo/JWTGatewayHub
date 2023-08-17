namespace JWTGatewayHub.Web.ViewModels;

public class ProjectViewModel
{
  public Guid Id { get; set; }
  public string? Name { get; set; }
  public List<ToDoItemViewModel> Items = new();
}
