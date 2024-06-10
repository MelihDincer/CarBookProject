﻿using CarBookProject.Application.Features.CQRS.Commands.BannerCommands;
using CarBookProject.Application.Features.CQRS.Handlers.BannerHandlers;
using CarBookProject.Application.Features.CQRS.Queries.BannerQueries;
using CarBookProject.Application.Features.CQRS.Results.BannerResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController : ControllerBase
    {
        private readonly GetBannerByIdQueryHandler _getBannerByIdQueryHandler;
        private readonly GetBannerQueryHandler _getBannerQueryHandler;
        private readonly CreateBannerCommandHandler _createBannerCommandHandler;
        private readonly UpdateBannerCommandHandler _updateBannerCommandHandler;
        private readonly RemoveBannerCommandHandler _removeBannerCommandHandler;

        public BannersController(GetBannerByIdQueryHandler getBannerByIdQueryHandler, GetBannerQueryHandler getBannerQueryHandler, CreateBannerCommandHandler createBannerCommandHandler, UpdateBannerCommandHandler updateBannerCommandHandler, RemoveBannerCommandHandler removeBannerCommandHandler)
        {
            _getBannerByIdQueryHandler = getBannerByIdQueryHandler;
            _getBannerQueryHandler = getBannerQueryHandler;
            _createBannerCommandHandler = createBannerCommandHandler;
            _updateBannerCommandHandler = updateBannerCommandHandler;
            _removeBannerCommandHandler = removeBannerCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> BannerList()
        {
            return Ok(await _getBannerQueryHandler.Handle());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBanner(int id)
        {
            return Ok(await _getBannerByIdQueryHandler.Handle(new GetBannerByIdQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerCommand command)
        {
            await _createBannerCommandHandler.Handle(command);
            return Ok("Öne çıkan bilgisi eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveBanner(int id)
        {
            var value = _removeBannerCommandHandler.Handle(new RemoveBannerCommand(id));
            return Ok("Öne çıkan bilgisi silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBanner(UpdateBannerCommand command)
        {
            await _updateBannerCommandHandler.Handle(command);
            return Ok("Öne çıkan bilgisi güncellendi.");
        }
    }
}