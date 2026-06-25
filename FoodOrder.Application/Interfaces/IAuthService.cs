using FoodOrder.Application.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrder.Application.Interfaces
{
    public interface IAuthService
    {
        Task<Result<string>> RegisterAsync(string firstName, string lastName, string email, string password);
    }
}
