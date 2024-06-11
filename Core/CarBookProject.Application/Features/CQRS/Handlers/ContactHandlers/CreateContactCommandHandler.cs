using CarBookProject.Application.Features.CQRS.Commands.ContactCommands;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandlers;

public class CreateContactCommandHandler
{
    private readonly IRepository<Contact> _repository;
    public CreateContactCommandHandler(IRepository<Contact> repository)
    {
        _repository = repository;
    }
    public async Task Handle(CreateContactCommand command)
    {
        await _repository.CreateAsync(new Contact
        {
            Name = command.Name,
            Email= command.Email,
            Message = command.Message,
            SendDate = command.SendDate,
            Subject = command.Subject
        });
    }
}
