
namespace JWTGatewayHub.Web.EndpoGuids.ProjectEndpoGuids;

public class GetProjectByIdRequest
{
  public const string Route = "/Projects/{ProjectId:guid}";
  public static string BuildRoute(Guid projectId) => Route.Replace("{ProjectId:guid}", projectId.ToString());

  public Guid ProjectId { get; set; }
}
