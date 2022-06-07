using System.Reflection;
using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductSearch.Application.MapProfiles;
using ProductSearch.Application.PipelineBehaviours;
using ProductSearch.Application.Validators;

namespace ProductSearch.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<FilterProductQueryValidator>());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            #region Configure Mapper

            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<ProductMapProfile>();
            });
            config.CreateMapper();

            #endregion

            return services;
        }
    }
}