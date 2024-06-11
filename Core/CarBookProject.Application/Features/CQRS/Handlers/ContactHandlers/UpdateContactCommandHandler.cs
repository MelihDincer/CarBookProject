using CarBookProject.Application.Interfaces;
using CarBookProject.Application.Features.CQRS.Commands.ContactCommands;
using CarBookProject.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandlers;

public class UpdateContactCommandHandler
{
    private readonly IRepository<Contact> _repository;
    public UpdateContactCommandHandler(IRepository<Contact> repository)
    {
        _repository = repository;
    }
    public async Task Handle(UpdateContactCommand command)
    {
        var values = await _repository.GetByIdAsync(command.ContactID);
        values.Name = command.Name;
        values.Email = command.Email;
        values.Message = command.Message;
        values.SendDate = command.SendDate;
        values.Subject = command.Subject;
        await _repository.UpdateAsync(values);
    }
}
