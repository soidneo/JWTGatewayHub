﻿namespace JWTGatewayHub.Web.EndpoGuids.ContributorEndpoGuids;

public class CreateContributorResponse
{
  public CreateContributorResponse(Guid id, string name)
  {
    Id = id;
    Name = name;
  }
  public Guid Id { get; set; }
  public string Name { get; set; }
}
