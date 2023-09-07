using EventManagment.Application.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EventManagment.Application
{
    public static class ApplicationInstaller
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var baseAssembly = Assembly.GetExecutingAssembly();
            services.AddValidatorsFromAssembly(baseAssembly);
            services.AddAutoMapper(baseAssembly);

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(baseAssembly);
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>)); // fluent validation
            });

            ValidatorOptions.Global.LanguageManager.Enabled = false; // only fluent msg in English
            return services;
        }
    }
}