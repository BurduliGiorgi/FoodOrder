using Azure.Core;
using FoodOrder.Application.Common;
using FoodOrder.Application.Common.Interfaces;
using FoodOrder.Domain.Constants;
using FoodOrder.Infrastructure.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrder.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        public AuthService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<Result<string>> RegisterAsync(string firstName, string lastName, string email, string password)
        {
            var existingUser = await _userManager.FindByEmailAsync(email);
            if (existingUser != null)
            {
                return Result<string>.Failure("User with this email already exists.");
            }

            var user = new AppUser
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                UserName = email,
            };
            var result = await _userManager.CreateAsync(user, password);
            if(!result.Succeeded) {
                return Result<string>.Failure(result.Errors.First().Description);
            }
            await _userManager.AddToRoleAsync(user, Roles.User);
            return Result<string>.Success("User registered successfully.");
        }
    }
}