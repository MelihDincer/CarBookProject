using CarBookProject.Application.Features.Mediator.Results.BlogResults;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Queries.BlogQueries;

public class GetAllBlogsWithAuthorQuery : IRequest<List<GetAllBlogsWithAuthorQueryResult>>
{
}
