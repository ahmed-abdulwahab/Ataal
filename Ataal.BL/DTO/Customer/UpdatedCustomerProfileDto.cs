using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.DTO.Customer
{
    public record UpdatedCustomerProfileDto(
                                            string FirstName,
                                            string LastName,
                                            string Address,
                                            string Email,
                                            string phone,
                                            string userName,
                                            IFormFile? PhotoFile);



        
    
}
