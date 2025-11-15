using CarBookProject.Application.Features.Mediator.Queries.BlogQueries;
using CarBookProject.Application.Features.Mediator.Results.BlogResults;
using CarBookProject.Application.Interfaces.BlogInterfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.BlogHandlers;

public class GetAllBlogsWithAuthorQueryHandler : IRequestHandler<GetAllBlogsWithAuthorQuery, List<GetAllBlogsWithAuthorQueryResult>>
{
	private readonly IBlogRepository _repository;

	public GetAllBlogsWithAuthorQueryHandler(IBlogRepository repository)
	{
		_repository = repository;
	}

	public async Task<List<GetAllBlogsWithAuthorQueryResult>> Handle(GetAllBlogsWithAuthorQuery request, CancellationToken cancellationToken)
	{
		var values = await _repository.GetAllBlogsWithAuthorAsync();
		return values.Select(x=> new GetAllBlogsWithAuthorQueryResult
		{
			BlogID = x.BlogID,
			AuthorName = x.Author.Name,
			CategoryName = x.Category.Name,
			CoverImageUrl = x.CoverImageUrl,
			CreatedDate = x.CreatedDate,
			Title = x.Title,
			Description = x.Description,
			CommentCount = x.Comments.Count			
		}).ToList();
	}
}
