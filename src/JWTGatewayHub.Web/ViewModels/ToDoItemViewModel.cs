﻿using JWTGatewayHub.Core.ProjectAggregate;

namespace JWTGatewayHub.Web.ViewModels;
public class ToDoItemViewModel
{
  public Guid Id { get; set; }
  public string? Title { get; set; }
  public string? Description { get; set; }
  public bool IsDone { get; private set; }

  public static ToDoItemViewModel FromToDoItem(ToDoItem item)
  {
    return new ToDoItemViewModel()
    {
      Id = item.Id,
      Title = item.Title,
      Description = item.Description,
      IsDone = item.IsDone
    };
  }
}
