using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.DTO.Customer
{
    public record oneCustomerDto(
         string Email,
            string phone,
         string firstName,
         string lastName,
         string Address,
         string userName,
         string? Photo
        );
}

     
    
