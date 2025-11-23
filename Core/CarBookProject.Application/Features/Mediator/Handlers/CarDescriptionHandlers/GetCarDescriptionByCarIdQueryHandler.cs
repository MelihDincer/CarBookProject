using CarBookProject.Application.Features.Mediator.Queries.CarDescriptionQueries;
using CarBookProject.Application.Features.Mediator.Results.CarDescriptionResults;
using CarBookProject.Application.Interfaces;
using CarBookProject.Application.Interfaces.CarDescriptionInterfaces;
using CarBookProject.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.CarDescriptionHandlers
{
    public class GetCarDescriptionByCarIdQueryHandler : IRequestHandler<GetCarDescriptionByCarIdQuery, GetCarDescriptionByCarIdQueryResult>
    {
        private readonly ICarDescriptionRepository _repository;

        public GetCarDescriptionByCarIdQueryHandler(ICarDescriptionRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarDescriptionByCarIdQueryResult> Handle(GetCarDescriptionByCarIdQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarDescription(request.Id);
            return new GetCarDescriptionByCarIdQueryResult
            {
                CarDescriptionId = value.CarDescriptionID,
                Details = value.Details,
                CarId = value.CarID
            };
        }
    }
}
