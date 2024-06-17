using CarBookProject.Application.Features.Mediator.Commands.AuthorCommands;
using CarBookProject.Application.Features.Mediator.Queries.AuthorQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthorsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> AuthorList()
    {
        return Ok(await _mediator.Send(new GetAuthorQuery()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAuthor(int id)
    {
        return Ok(await _mediator.Send(new GetAuthorByIdQuery(id)));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAuthor(CreateAuthorCommand command)
    {
        await _mediator.Send(command);
        return Ok("Yazar başarıyla eklendi");
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveAuthor(int id)
    {
        await _mediator.Send(new RemoveAuthorCommand(id));
        return Ok("Yazar başarıyla silindi");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAuthor(UpdateAuthorCommand command)
    {
        await _mediator.Send(command);
        return Ok("Yazar başarıyla güncellendi");
    }
}
