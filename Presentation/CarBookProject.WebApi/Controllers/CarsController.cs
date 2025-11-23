using CarBookProject.Application.Features.CQRS.Commands.CarCommands;
using CarBookProject.Application.Features.CQRS.Handlers.CarHandlers;
using CarBookProject.Application.Features.CQRS.Queries.CarQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarsController : ControllerBase
{
    private readonly CreateCarCommandHandler _createCarCommandHandler;
    private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;
    private readonly GetCarQueryHandler _getCarQueryHandler;
    private readonly GetCarWithBrandQueryHandler _getCarWithBrandQueryHandler;
    private readonly UpdateCarCommandHandler _updateCarCommandHandler;
    private readonly RemoveCarCommandHandler _removeCarCommandHandler;
    private readonly GetLast5CarsWithBrandQueryHandler _getLast5CarsWithBrandQueryHandler;
    private readonly GetCarByIdWithBrandQueryHandler _getCarByIdWithBrandQueryHandler;

    public CarsController(CreateCarCommandHandler createCarCommandHandler, GetCarByIdQueryHandler getCarByIdQueryHandler, GetCarQueryHandler getCarQueryHandler, GetCarWithBrandQueryHandler getCarWithBrandQueryHandler, UpdateCarCommandHandler updateCarCommandHandler, RemoveCarCommandHandler removeCarCommandHandler, GetLast5CarsWithBrandQueryHandler getLast5CarsWithBrandQueryHandler, GetCarByIdWithBrandQueryHandler getCarByIdWithBrandQueryHandler)
    {
        _createCarCommandHandler = createCarCommandHandler;
        _getCarByIdQueryHandler = getCarByIdQueryHandler;
        _getCarQueryHandler = getCarQueryHandler;
        _getCarWithBrandQueryHandler = getCarWithBrandQueryHandler;
        _updateCarCommandHandler = updateCarCommandHandler;
        _removeCarCommandHandler = removeCarCommandHandler;
        _getLast5CarsWithBrandQueryHandler = getLast5CarsWithBrandQueryHandler;
        _getCarByIdWithBrandQueryHandler = getCarByIdWithBrandQueryHandler;
    }

    [HttpGet]
    public async Task<IActionResult> CarList()
    {
        return Ok(await _getCarQueryHandler.Handle());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCar(int id)
    {
        return Ok(await _getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id)));
    }

    [HttpPost]
    public async Task<IActionResult> CreateCar(CreateCarCommand command)
    {
        await _createCarCommandHandler.Handle(command);
        return Ok("Araba bilgisi eklendi.");
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveCar(int id)
    {
        await _removeCarCommandHandler.Handle(new RemoveCarCommand(id));
        return Ok("Araba bilgisi silindi.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
    {
        await _updateCarCommandHandler.Handle(command);
        return Ok("Araba bilgisi güncellendi.");
    }

    [HttpGet("GetCarWithBrand")]
    public IActionResult GetCarWithBrand()
    {
        var values = _getCarWithBrandQueryHandler.Handle();
        return Ok(values);
    }

    [HttpGet("GetLast5CarsWithBrand")]
    public IActionResult GetLast5CarsWithBrand()
    {
        var values = _getLast5CarsWithBrandQueryHandler.Handle();
        return Ok(values);
    }

    [HttpGet("GetCarByIdWithBrand")]
    public async Task<IActionResult> GetCarByIdWithBrand(int id)
    {
        var values = await _getCarByIdWithBrandQueryHandler.Handle(new GetCarByIdWithBrandQuery(id));
        return Ok(values);
    }
}
