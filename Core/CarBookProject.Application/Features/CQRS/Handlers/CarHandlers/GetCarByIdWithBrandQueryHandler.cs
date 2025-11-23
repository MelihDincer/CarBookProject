using CarBookProject.Application.Features.CQRS.Queries.CarQueries;
using CarBookProject.Application.Features.CQRS.Results.CarResults;
using CarBookProject.Application.Interfaces.CarInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarByIdWithBrandQueryHandler 
    {
        private ICarRepository _carRepository;

        public GetCarByIdWithBrandQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<GetCarByIdWithBrandQueryResult> Handle(GetCarByIdWithBrandQuery query)
        {
            var value = _carRepository.GetCarByIdWithBrands(query.CarId);
            return new GetCarByIdWithBrandQueryResult
            {
                CarID = value.CarID,
                BrandName = value.Brand.Name,
                Model = value.Model,
                Seat = value.Seat,
                Transmission = value.Transmission,
                Fuel = value.Fuel,
                Km = value.Km,
                Luggage = value.Luggage,
                CoverImageUrl = value.CoverImageUrl,
                BigImageUrl = value.BigImageUrl
            };
        }
    }
}
