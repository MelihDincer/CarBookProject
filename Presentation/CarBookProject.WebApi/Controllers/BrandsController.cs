using CarBookProject.Application.Features.CQRS.Commands.BrandCommands;
using CarBookProject.Application.Features.CQRS.Handlers.BrandHandlers;
using CarBookProject.Application.Features.CQRS.Queries.BrandQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrandsController : ControllerBase
{
    private readonly CreateBrandCommandHandler _createBrandCommandHandler;
    private readonly GetBrandByIdQueryHandler _getBrandByIdQueryHandler;
    private readonly GetBrandQueryHandler _getBrandQueryHandler;
    private readonly UpdateBrandCommandHandler _updateBrandCommandHandler;
    private readonly RemoveBrandCommandHandler _removeBrandCommandHandler;

    public BrandsController(CreateBrandCommandHandler createBrandCommandHandler, GetBrandByIdQueryHandler getBrandByIdQueryHandler, GetBrandQueryHandler getBrandQueryHandler, UpdateBrandCommandHandler updateBrandCommandHandler, RemoveBrandCommandHandler removeBrandCommandHandler)
    {
        _createBrandCommandHandler = createBrandCommandHandler;
        _getBrandByIdQueryHandler = getBrandByIdQueryHandler;
        _getBrandQueryHandler = getBrandQueryHandler;
        _updateBrandCommandHandler = updateBrandCommandHandler;
        _removeBrandCommandHandler = removeBrandCommandHandler;
    }

    [HttpGet]
    public async Task<IActionResult> BrandList()
    {
        return Ok(await _getBrandQueryHandler.Handle());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBrand(int id)
    {
        return Ok(await _getBrandByIdQueryHandler.Handle(new GetBrandByIdQuery(id)));
    }

    [HttpPost]
    public async Task<IActionResult> CreateBrand(CreateBrandCommand command)
    {
        await _createBrandCommandHandler.Handle(command);
        return Ok("Marka bilgisi eklendi.");
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveBrand(int id)
    {
        await _removeBrandCommandHandler.Handle(new RemoveBrandCommand(id));
        return Ok("Marka bilgisi silindi.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBrand(UpdateBrandCommand command)
    {
        await _updateBrandCommandHandler.Handle(command);
        return Ok("Marka bilgisi güncellendi.");
    }
}
