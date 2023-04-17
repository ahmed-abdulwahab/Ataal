using Ataal.BL.DTO.Customer;
using Ataal.BL.DTO.Rate;
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

        [HttpPost]
        [Route("rate")]
        public IActionResult CustomerAddRate(RateCreationDto rateDto)
        {
             
            var Value= _customerManager.CustomerAddingRate(rateDto);
            if(Value==0)
            {
                return BadRequest();
            }
            var test= _customerManager.ModifyingTechnical_Rate(rateDto.TechnicalId);
            if(test==0)
            {
                return BadRequest();
            }
            return Ok(Value);
        }
        [HttpGet]
        public IActionResult gettechnicalbyid(int technicalid)
        {

            var technical= _customerManager.gettechnical(technicalid);
            if (technical != null)
            {
                return Ok();

            }
            return BadRequest();
        }
        

    }
}
