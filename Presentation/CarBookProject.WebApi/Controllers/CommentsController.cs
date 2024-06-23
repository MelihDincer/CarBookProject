using CarBookProject.Application.Features.RepositoryPattern;
using CarBookProject.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentsController : ControllerBase
{
    private readonly IGenericRepository<Comment> _commentRepository;

    public CommentsController(IGenericRepository<Comment> commentRepository)
    {
        _commentRepository = commentRepository;
    }

    [HttpGet]
    public IActionResult CommentList()
    {
        var values = _commentRepository.GetAll();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public IActionResult GetComment(int id)
    {
        return Ok(_commentRepository.GetById(id));
    }

    [HttpPost]
    public IActionResult CreateComment(Comment comment)
    {
        _commentRepository.Add(comment);
        return Ok("Yorum başarıyla eklendi.");
    }

    [HttpDelete]
    public IActionResult DeleteComment(int id)
    {
        _commentRepository.Remove(new Comment { CommentID = id });
        return Ok("Yorum başarıyla silindi.");
    }

    [HttpPut]
    public IActionResult Update(Comment comment)
    {
        _commentRepository.Update(comment);
        return Ok("Yorum başarıyla eklendi.");
    }   
}
