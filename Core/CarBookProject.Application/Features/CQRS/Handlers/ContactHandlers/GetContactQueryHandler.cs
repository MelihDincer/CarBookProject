using CarBookProject.Application.Features.CQRS.Results.ContactResults;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandlers;

public class GetContactQueryHandler
{
    private readonly IRepository<Contact> _repository;
    public GetContactQueryHandler(IRepository<Contact> repository)
    {
        _repository = repository;
    }
    public async Task<List<GetContactQueryResult>> Handle()
    {
        var values = await _repository.GetAllAsync();
        return values.Select(x => new GetContactQueryResult
        {
            ContactID = x.ContactID,
            Name = x.Name,
            Email = x.Email,
            Message = x.Message,
            SendDate = x.SendDate,
            Subject = x.Subject
        }).ToList();
    }
}
