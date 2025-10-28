using CarBookProject.Application.Features.Mediator.Results.StatisticsResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Queries.StatisticsQueries
{
    public class GetCarsWithLessThan1000KmQuery : IRequest<GetCarsWithLessThan1000KmQueryResult> 
    {
    }
}
