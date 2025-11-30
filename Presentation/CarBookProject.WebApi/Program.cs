using CarBookProject.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBookProject.Application.Features.CQRS.Handlers.BannerHandlers;
using CarBookProject.Application.Features.CQRS.Handlers.BrandHandlers;
using CarBookProject.Application.Features.CQRS.Handlers.CarHandlers;
using CarBookProject.Application.Features.CQRS.Handlers.CategoryHandlers;
using CarBookProject.Application.Features.Mediator.Commands.ReviewCommands;
using CarBookProject.Application.Features.Mediator.Handlers.ReservationHandlers;
using CarBookProject.Application.Features.Mediator.Handlers.StatisticsHandlers;
using CarBookProject.Application.Interfaces;
using CarBookProject.Application.Interfaces.BlogInterfaces;
using CarBookProject.Application.Interfaces.CarDescriptionInterfaces;
using CarBookProject.Application.Interfaces.CarFeatureInterfaces;
using CarBookProject.Application.Interfaces.CarInterfaces;
using CarBookProject.Application.Interfaces.CarPricingInterfaces;
using CarBookProject.Application.Interfaces.CommentInterfaces;
using CarBookProject.Application.Interfaces.RentACarInterfaces;
using CarBookProject.Application.Interfaces.ReviewInterfaces;
using CarBookProject.Application.Interfaces.StatisticsInterfaces;
using CarBookProject.Application.Interfaces.TagCloudInterfaces;
using CarBookProject.Application.Services;
using CarBookProject.Application.Tools;
using CarBookProject.Persistence.Context;
using CarBookProject.Persistence.Repositories;
using CarBookProject.Persistence.Repositories.BlogRepositories;
using CarBookProject.Persistence.Repositories.CarDescriptionRepositories;
using CarBookProject.Persistence.Repositories.CarFeatureRepositories;
using CarBookProject.Persistence.Repositories.CarPricingRepositories;
using CarBookProject.Persistence.Repositories.CarRepositories;
using CarBookProject.Persistence.Repositories.CommentRepositories;
using CarBookProject.Persistence.Repositories.RentACarRepositories;
using CarBookProject.Persistence.Repositories.ReviewRepositories;
using CarBookProject.Persistence.Repositories.StatisticsRepositories;
using CarBookProject.Persistence.Repositories.TagCloudRepositories;
using CarBookProject.WebApi.Extensions;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandlers;

var builder = WebApplication.CreateBuilder(args);


//SignalR Registration Process
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed((host) => true)
        .AllowCredentials();
    });
});

//JWT Registration Process
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt=>
{
    opt.RequireHttpsMetadata = false;
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidAudience= JwtTokenDefaults.ValidAudience,
        ValidIssuer = JwtTokenDefaults.ValidIssuer,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key)),
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddProjectServices();

builder.Services.AddApplicationService();
builder.Services.AddControllers().AddFluentValidation(x =>
{
    x.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
