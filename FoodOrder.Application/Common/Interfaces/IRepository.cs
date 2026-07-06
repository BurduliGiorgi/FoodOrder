using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrder.Application.Common.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T id);
    }
}
