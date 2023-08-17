using JWTGatewayHub.Core.ProjectAggregate;
using JWTGatewayHub.Core.ProjectAggregate.Specifications;
using JWTGatewayHub.SharedKernel.Interfaces;
using JWTGatewayHub.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JWTGatewayHub.Web.Controllers;
[Route("[controller]")]
public class ProjectController : Controller
{
  private readonly IRepository<Project> _projectRepository;

  public ProjectController(IRepository<Project> projectRepository)
  {
    _projectRepository = projectRepository;
  }

  // GET project/{projectId?}
  [HttpGet("{projectId:guid}")]
  public async Task<IActionResult> Index(Guid projectId)
  {
    var spec = new ProjectByIdWithItemsSpec(projectId);
    var project = await _projectRepository.FirstOrDefaultAsync(spec);
    if (project == null)
    {
      return NotFound();
    }

    var dto = new ProjectViewModel
    {
      Id = project.Id,
      Name = project.Name,
      Items = project.Items
                    .Select(item => ToDoItemViewModel.FromToDoItem(item))
                    .ToList()
    };
    return View(dto);
  }
}
