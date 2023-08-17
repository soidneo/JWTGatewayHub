using JWTGatewayHub.Web.Endpoints.ProjectEndpoints;

namespace JWTGatewayHub.Web.EndpoGuids.ProjectEndpoGuids;

public class ListIncompleteResponse
{
  public ListIncompleteResponse(Guid projectId, List<ToDoItemRecord> incompleteItems)
  {
    ProjectId = projectId;
    IncompleteItems = incompleteItems;
  }
  public Guid ProjectId { get; set; }
  public List<ToDoItemRecord> IncompleteItems { get; set; }
}
