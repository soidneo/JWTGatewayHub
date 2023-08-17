﻿using Microsoft.AspNetCore.Mvc;

namespace JWTGatewayHub.Web.Endpoints.ProjectEndpoints;
public class ListIncompleteRequest
{
  [FromRoute]
  public Guid ProjectId { get; set; }
  [FromQuery]
  public string? SearchString { get; set; }
}
