using CarBookProject.Application.Features.Mediator.Queries.TestimonialQueries;
using CarBookProject.Application.Features.Mediator.Results.TestimonialResults;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.TestimonialHandlers;

public class GetTestimonialByIdQueryHandler : IRequestHandler<GetTestimonialByIdQuery, GetTestimonialByIdQueryResult>
{
    private readonly IRepository<Testimonial> _repository;

    public GetTestimonialByIdQueryHandler(IRepository<Testimonial> repository)
    {
        _repository = repository;
    }

    public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        return new GetTestimonialByIdQueryResult
        {
            TestimonialID = value.TestimonialID,
            Comment = value.Comment,
            ImageUrl = value.ImageUrl,
            Name = value.Name,
            Title = value.Title
        };
    }
}
