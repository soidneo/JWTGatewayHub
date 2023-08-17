﻿namespace JWTGatewayHub.Web.EndpoGuids.ContributorEndpoGuids;

public class DeleteContributorRequest
{
  public const string Route = "/Contributors/{ContributorId:guid}";
  public static string BuildRoute(Guid contributorId) => Route.Replace("{ContributorId:guid}", contributorId.ToString());

  public Guid ContributorId { get; set; }
}
