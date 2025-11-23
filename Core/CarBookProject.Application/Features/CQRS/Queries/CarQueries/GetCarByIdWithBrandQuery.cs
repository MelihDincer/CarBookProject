using CarBookProject.Application.Features.CQRS.Results.CarResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.CQRS.Queries.CarQueries
{
    public class GetCarByIdWithBrandQuery
    {
        public int CarId { get; set; }

        public GetCarByIdWithBrandQuery(int carId)
        {
            CarId = carId;
        }
    }
}
