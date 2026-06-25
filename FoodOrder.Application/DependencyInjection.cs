using FluentValidation;
using FoodOrder.Application.Common.Behaviours;
using FoodOrder.Application.Features.Auth.Commands.Register;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FoodOrder.Application
{
    public static class DependencyInjection
    {
        public static IHostApplicationBuilder AddApplicationServices(this IHostApplicationBuilder builder)
        {
            builder.Services.AddMediatR(typeof(RegisterCommand).Assembly);
            builder.Services.AddValidatorsFromAssemblyContaining<RegisterCommand>();
            builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return builder;
        }
    }
}
