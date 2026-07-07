using FluentValidation;
using FoodOrder.Application.Common.Behaviours;
using FoodOrder.Application.Features.Auth.Commands.Login;
using FoodOrder.Application.Features.Auth.Commands.RefreshToken;
using FoodOrder.Application.Features.Auth.Commands.Register;
using FoodOrder.Application.Features.Auth.Commands.Revoke;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.Design;

namespace FoodOrder.Application
{
    public static class DependencyInjection
    {
        public static IHostApplicationBuilder AddApplicationServices(this IHostApplicationBuilder builder)
        {
            builder.Services.AddMediatR(typeof(RegisterCommand).Assembly);
            builder.Services.AddMediatR(typeof(LoginCommand).Assembly);
            builder.Services.AddMediatR(typeof(RefreshTokenCommand).Assembly);
            builder.Services.AddMediatR(typeof(RevokeCommand).Assembly);
            builder.Services.AddMediatR(typeof(MenuCommand).Assembly);

            builder.Services.AddValidatorsFromAssemblyContaining<RegisterCommand>();
            builder.Services.AddValidatorsFromAssemblyContaining<LoginCommand>();
            builder.Services.AddValidatorsFromAssemblyContaining<RefreshTokenCommand>();
            builder.Services.AddValidatorsFromAssemblyContaining<RevokeCommand>();
            builder.Services.AddValidatorsFromAssemblyContaining<MenuCommand>();

            builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return builder;
        }
    }
}
