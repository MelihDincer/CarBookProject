using CarBookProject.Application.Features.CQRS.Commands.CategoryCommands;
using CarBookProject.Application.Features.CQRS.Handlers.CategoryHandlers;
using CarBookProject.Application.Features.CQRS.Queries.CategoryQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly GetCategoryQueryHandler _getCategoryQueryHandler;
    private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler;
    private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
    private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;
    private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;

    public CategoriesController(GetCategoryQueryHandler getCategoryQueryHandler, GetCategoryByIdQueryHandler getCategoryByIdQueryHandler, CreateCategoryCommandHandler createCategoryCommandHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler, RemoveCategoryCommandHandler removeCategoryCommandHandler)
    {
        _getCategoryQueryHandler = getCategoryQueryHandler;
        _getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
        _createCategoryCommandHandler = createCategoryCommandHandler;
        _updateCategoryCommandHandler = updateCategoryCommandHandler;
        _removeCategoryCommandHandler = removeCategoryCommandHandler;
    }

    [HttpGet]
    public async Task<IActionResult> CategoryList()
    {
        return Ok(await _getCategoryQueryHandler.Handle());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategory(int id)
    {
        return Ok(await _getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id)));
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
    {
        await _createCategoryCommandHandler.Handle(command);
        return Ok("Kategori bilgisi eklendi.");
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveCategory(int id)
    {
        await _removeCategoryCommandHandler.Handle(new RemoveCategoryCommand(id));
        return Ok("Kategori bilgisi silindi.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
    {
        await _updateCategoryCommandHandler.Handle(command);
        return Ok("Kategori bilgisi güncellendi.");
    }
}
