using CarBookProject.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBookProject.Application.Features.CQRS.Handlers.BannerHandlers;
using CarBookProject.Application.Features.CQRS.Handlers.BrandHandlers;
using CarBookProject.Application.Features.CQRS.Handlers.CarHandlers;
using CarBookProject.Application.Features.CQRS.Handlers.CategoryHandlers;
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
using UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandlers;

namespace CarBookProject.WebApi.Extensions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services)
        {
            // Add services to the container.
            services.AddScoped<CarBookContext>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(ICarRepository), typeof(CarRepository));
            services.AddScoped(typeof(IBlogRepository), typeof(BlogRepository));
            services.AddScoped(typeof(ICarPricingRepository), typeof(CarPricingRepository));
            services.AddScoped(typeof(ITagCloudRepository), typeof(TagCloudRepository));
            services.AddScoped(typeof(ICommentRepository), typeof(CommentRepository));
            services.AddScoped(typeof(IStatisticsRepository), typeof(StatisticsRepository));
            services.AddScoped(typeof(IRentACarRepository), typeof(RentACarRepository));
            services.AddScoped(typeof(ICarFeatureRepository), typeof(CarFeatureRepository));
            services.AddScoped(typeof(ICarDescriptionRepository), typeof(CarDescriptionRepository));
            services.AddScoped(typeof(IReviewRepository), typeof(ReviewRepository));

            services.AddScoped<GetAboutQueryHandler>();
            services.AddScoped<GetAboutByIdQueryHandler>();
            services.AddScoped<CreateAboutCommandHandler>();
            services.AddScoped<UpdateAboutCommandHandler>();
            services.AddScoped<RemoveAboutCommandHandler>();

            services.AddScoped<GetBannerQueryHandler>();
            services.AddScoped<GetBannerByIdQueryHandler>();
            services.AddScoped<CreateBannerCommandHandler>();
            services.AddScoped<UpdateBannerCommandHandler>();
            services.AddScoped<RemoveBannerCommandHandler>();

            services.AddScoped<GetBrandQueryHandler>();
            services.AddScoped<GetBrandByIdQueryHandler>();
            services.AddScoped<CreateBrandCommandHandler>();
            services.AddScoped<UpdateBrandCommandHandler>();
            services.AddScoped<RemoveBrandCommandHandler>();

            services.AddScoped<GetCarQueryHandler>();
            services.AddScoped<GetCarWithBrandQueryHandler>();
            services.AddScoped<GetCarByIdQueryHandler>();
            services.AddScoped<CreateCarCommandHandler>();
            services.AddScoped<UpdateCarCommandHandler>();
            services.AddScoped<RemoveCarCommandHandler>();
            services.AddScoped<GetLast5CarsWithBrandQueryHandler>();
            services.AddScoped<GetCarByIdWithBrandQueryHandler>();

            services.AddScoped<GetCategoryQueryHandler>();
            services.AddScoped<GetCategoryByIdQueryHandler>();
            services.AddScoped<CreateCategoryCommandHandler>();
            services.AddScoped<UpdateCategoryCommandHandler>();
            services.AddScoped<RemoveCategoryCommandHandler>();

            services.AddScoped<GetContactQueryHandler>();
            services.AddScoped<GetContactByIdQueryHandler>();
            services.AddScoped<CreateContactCommandHandler>();
            services.AddScoped<UpdateContactCommandHandler>();
            services.AddScoped<RemoveContactCommandHandler>();

            services.AddScoped<GetCarCountQueryHandler>();

            services.AddScoped<CreateReservationCommandHandler>();
            return services;
        }
    }
}
