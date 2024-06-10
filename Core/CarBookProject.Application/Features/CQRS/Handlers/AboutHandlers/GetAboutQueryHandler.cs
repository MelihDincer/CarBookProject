﻿using CarBookProject.Application.Features.CQRS.Results.AboutResults;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;

namespace CarBookProject.Application.Features.CQRS.Handlers.AboutHandlers;

public class GetAboutQueryHandler
{
    private readonly IRepository<About> _repository;

    public GetAboutQueryHandler(IRepository<About> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetAboutQueryResult>> Handle()
    {
        var values = await _repository.GetAllAsync();
        return values.Select(x => new GetAboutQueryResult
        {
            AboutID = x.AboutID,
            Description = x.Description,
            ImageUrl = x.ImageUrl,
            Title = x.Title
        }).ToList();
    }
}