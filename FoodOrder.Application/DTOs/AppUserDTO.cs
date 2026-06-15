using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrder.Application.DTOs
{
    public record AppUserDTO(

        Guid Id,
        string Email,
        string UserName,
        string FirstName,
        string LastName,
        DateTime CreatedAt,
        IEnumerable<string> Roles);
    
}
