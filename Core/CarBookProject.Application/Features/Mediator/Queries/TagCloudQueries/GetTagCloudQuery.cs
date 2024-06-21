using CarBookProject.Application.Features.Mediator.Results.TagCloudResults;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Queries.TagCloudQueries;

public class GetTagCloudQuery : IRequest<List<GetTagCloudQueryResult>>
{ 
}