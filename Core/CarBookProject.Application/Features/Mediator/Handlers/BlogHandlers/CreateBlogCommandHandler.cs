using CarBookProject.Application.Features.Mediator.Commands.BlogCommands;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.BlogHandlers;

public class CreatePricingCommandHandler : IRequestHandler<CreateBlogCommand>
{
    private readonly IRepository<Blog> _repository;
    public CreatePricingCommandHandler(IRepository<Blog> repository)
    {
        _repository = repository;
    }
    public async Task Handle(CreateBlogCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new Blog
        {
            AuthorID = request.AuthorID,
            CategoryID = request.CategoryID,
            CoverImageUrl = request.CoverImageUrl,
            CreatedDate = request.CreatedDate,
            Title = request.Title
        });
    }
}
