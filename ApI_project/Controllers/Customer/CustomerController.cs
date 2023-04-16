using Ataal.BL.DTO.Customer;
using Ataal.BL.Managers.Customer;
using Ataal.DAL.Data.Models;
using Ataal.DAL.Repos.Customer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ataal.Controllers.Customer
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        
        private readonly ICustomerManager _customerManager;
        public CustomerController(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }

        [HttpPost]
        public IActionResult AddingProblem([FromForm]CustomerAddProblemDto customerAddProblemDto)
        {
            var customerID = _customerManager.ReturnAddedProblemID(customerAddProblemDto);
            if (customerID == null)
            {
                return BadRequest();
            }
            return Ok(customerID);
        }
        [HttpDelete]
        public IActionResult DeletingProblem(int problemID)
        {
            var flag=_customerManager.DeleteProblemWithImagesByProblemID(problemID);
            if (flag!=false)
            {
                return Ok();
            }
            return NotFound();
        }
        

    }
}
