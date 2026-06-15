using FoodOrder.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrder.Application.Interfaces
{
    public interface ITokenService
    {
        public interface ITokenService
        {
            (string Token, DateTime ExpiresAt) CreateToken(AppUserDTO user, IEnumerable<string> roles);
        }
    }
}

