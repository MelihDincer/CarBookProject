using CarBookProject.Application.Features.Mediator.Results.FeatureResults;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Queries.FeatureQueries;

//Mediator Design Pattern
//CQRS Design Pattern'da listeleme işlemi gerçekleştirirken Queries kısmında herhangi bir sınıfını oluşturmamıştık. Burada oluşturmamızın sebebi bunu MediatR üzerinden yönetebilmemizdir.
public class GetFeatureQuery : IRequest<List<GetFeatureQueryResult>>
{
}
