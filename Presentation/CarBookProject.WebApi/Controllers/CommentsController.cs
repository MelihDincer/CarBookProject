using CarBookProject.Application.Features.Mediator.Commands.CommentCommands;
using CarBookProject.Application.Features.Mediator.Queries.CommentQueries;
using CarBookProject.Application.Features.RepositoryPattern;
using CarBookProject.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public CommentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> CommentList()
    {
        var values = await _mediator.Send(new GetCommentQuery());
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetComment(int id)
    {
        var value = await _mediator.Send(new GetCommentByIdQuery(id));
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateComment(CreateCommentCommand command)
    {
        await _mediator.Send(command);
        return Ok("Yorum başarıyla eklendi.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteComment(int id)
    {
        await _mediator.Send(new RemoveCommentCommand(id));
        return Ok("Yorum başarıyla silindi.");
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateCommentCommand command)
    {
        await _mediator.Send(command);
        return Ok("Yorum başarıyla güncellendi.");
    }   
}
