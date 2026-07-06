using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrder.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}
