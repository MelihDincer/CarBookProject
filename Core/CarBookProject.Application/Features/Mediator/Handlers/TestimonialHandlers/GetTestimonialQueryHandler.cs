using CarBookProject.Application.Features.Mediator.Queries.TestimonialQueries;
using CarBookProject.Application.Features.Mediator.Results.TestimonialResults;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.TestimonialHandlers;

public class GetTestimonialQueryHandler : IRequestHandler<GetTestimonialQuery, List<GetTestimonialQueryResult>>
{
    private readonly IRepository<Testimonial> _repository;

    public GetTestimonialQueryHandler(IRepository<Testimonial> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetTestimonialQueryResult>> Handle(GetTestimonialQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetAllAsync();
        return values.Select(x => new GetTestimonialQueryResult
        {
            Comment = x.Comment,
            Name = x.Name,
            ImageUrl = x.ImageUrl,
            Title = x.Title,
            TestimonialID = x.TestimonialID
        }).ToList();
    }
}
