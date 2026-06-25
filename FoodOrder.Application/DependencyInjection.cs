using FoodOrder.Application.Features.Auth.Commands.Register;
using MediatR;
using Microsoft.Extensions.Hosting;

namespace FoodOrder.Application
{
    public static class DependencyInjection
    {
        public static IHostApplicationBuilder AddApplicationServices(this IHostApplicationBuilder builder)
        {
            builder.Services.AddMediatR(typeof(RegisterCommand).Assembly);
            return builder;
        }
    }
}
