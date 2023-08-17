using Ardalis.Specification;
using JWTGatewayHub.Core.ContributorAggregate;

namespace JWTGatewayHub.Core.ProjectAggregate.Specifications;
public class ContributorByIdSpec : Specification<Contributor>, ISingleResultSpecification
{
  public ContributorByIdSpec(Guid contributorId)
  {
    Query
        .Where(contributor => contributor.Id == contributorId);
  }
}
