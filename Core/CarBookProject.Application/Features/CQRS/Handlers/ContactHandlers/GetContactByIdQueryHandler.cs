using CarBookProject.Application.Features.CQRS.Queries.ContactQueries;
using CarBookProject.Application.Features.CQRS.Results.ContactResults;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandlers;

public class GetContactByIdQueryHandler
{
    private readonly IRepository<Contact> _repository;
    public GetContactByIdQueryHandler(IRepository<Contact> repository)
    {
        _repository = repository;
    }
    public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery query)
    {
        var values = await _repository.GetByIdAsync(query.Id);
        return new GetContactByIdQueryResult
        {
            ContactID = values.ContactID,
            Name = values.Name,
            Email = values.Email,
            Subject = values.Subject,
            SendDate = values.SendDate,
            Message = values.Message
        };
    }
}
