using Ataal.BL.DTO.Customer;
using Ataal.BL.DTO.Rate;
using Ataal.BL.DTO.Review;
using Ataal.BL.Managers.Customer;
using Ataal.DAL.Data.Models;
using Ataal.DAL.Repos.customer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client.Region;

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
        public async Task<IActionResult> AddingProblem([FromForm]CustomerAddProblemDto customerAddProblemDto)
        //public IActionResult AddingProblem([FromForm]CustomerAddProblemDto customerAddProblemDto)
        {
            var problemId = await _customerManager.ReturnAddedProblemID(customerAddProblemDto);
            if (problemId == null)
            //var customerID = _customerManager.ReturnAddedProblemID(customerAddProblemDto);
            //if (customerID == null)
            {
                return BadRequest();
            }
            return Ok(problemId);
            //return Ok(customerID);
        }
        [HttpGet]
        [Route("GetAllProblemsForCustomer/{CustomerId}")]
        public IActionResult GetAllProblemsForCustomer(int CustomerId)
        {
            var problems = _customerManager.ReturnProblemsForCustomers(CustomerId);
            if (problems == null)
                return NotFound();
            return Ok(problems);
        }
        [HttpGet]
        [Route("GetAllTechnicansCustomerNeed/{CustomerId}")]
        public IActionResult GetAllTechnicansCustomerNeed(int CustomerId)
        {
            var Technicans=_customerManager.ReturnAllTechnicansForCustomerNeed(CustomerId);
            if(Technicans==null)
                return NotFound();
            return Ok(Technicans);
        }

        [HttpPost]
        [Route("update_Problem/{ProblemId}")]
        public async Task<IActionResult> UpdatingingProblem(int ProblemId,[FromForm] updatedProblemDto CustDto)
        {
            if (ProblemId != CustDto.Problem_id)
                return BadRequest();
            var Affected = await _customerManager.UpdatedProblem(CustDto);
            if (Affected == null) // check if it = 0
            {
                return BadRequest();
            }

            return Ok();
        }


        [HttpPut("UpdateCustomerProfile/{id}")]
        //[Route("UpdateCustomerProfile")]
        public async Task<IActionResult> UpdateCustomerProfile(int id, [FromForm] UpdatedCustomerProfileDto dto)
        {
            await _customerManager.UpdateCustomerProfile(id, dto);

            return Ok();
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
                return Ok(technical);

            }
            return BadRequest();
        }

        [HttpGet]
        [Route("{customerId}")]
        public IActionResult GetCustomerById(int customerId)
        {

            var customer = _customerManager.GetCustomerById(customerId);
            if (customer != null)
            {
                return Ok(customer);

            }
            return BadRequest();
        }

        [HttpGet]
        [Route("/appuser/{AppUserId}")]
        public IActionResult GetCustomerByAppUser(string AppUserId)
        {

            var customer = _customerManager.GetCustomerByAppUser(AppUserId);
            if (customer != null)
            {
                return Ok(customer);

            }
            return BadRequest();
        }


        [HttpGet]
        [Route("/Adminuser/{AppUserId}")]
        public IActionResult GetAdminByAppUser(string AppUserId)
        {

            var Admin = _customerManager.GetAdminByAppUser(AppUserId);
            if (Admin != null)
            {
                return Ok(Admin);

            }
            return BadRequest();
        }




        [HttpGet]
        [Route("/Techappuser/{AppUserId}")]
        public IActionResult GetTechnByAppUser(string AppUserId)
        {

            var customer = _customerManager.GetTechByAppUser(AppUserId);
            if (customer != null)
            {
                return Ok(customer);

            }
            return BadRequest();
        }

        //GetCustomerByAppUser


        [HttpPost]
        [Route("Review")]
        public IActionResult AddingTechnicalReview(ReviewCreationDto ReviewDto)
        {
          var Affected = _customerManager.AddingTechnicalReview(ReviewDto);
            if (Affected == 0)
            {
                return BadRequest();
            }
            return Ok();
            // I want to return created
        }
        [HttpDelete]
        [Route("Review")]
        public IActionResult DeleteReview(int Review_Id)
        {
            var flag = _customerManager.DeleteReview(Review_Id);
            if (flag != false)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpPost]
        [Route("Review/{id}")]
        public IActionResult UpdateReview ( int id,ReviewUpdatedDto ReviewUpdated)
        {
            if(id!= ReviewUpdated.id) return BadRequest();
            var Affected = _customerManager.UpdateReview(ReviewUpdated);
            if (Affected == 0|| Affected==null)
            {
                return BadRequest();
            }
            return Ok();
           
        }
        [HttpPost]
        [Route("BlockTechnical")]
        public IActionResult BlockTechnical(BlockAndUnblockTechnicalAndCustomersDto BDto)
        {
            var Value = _customerManager.BlockTechnical(BDto);
            if (Value == true)
                return Ok(BDto.TechnicalId);
            else
               return NotFound();
        }
        [HttpPost]
        [Route("UnBlockTechnical")]
        public IActionResult UnBlockTechnical(BlockAndUnblockTechnicalAndCustomersDto BDto)
        {
            var Value = _customerManager.UnBlockTechnical(BDto);
            if (Value == true)
                return Ok(BDto.TechnicalId);
            else
                return NotFound();
        }

        [HttpPost]
        [Route("BlockCustomer")]
        public IActionResult BlockCustomer(BlockAndUnblockTechnicalAndCustomersDto BDto)
        {
            var Value = _customerManager.BlockCustomer(BDto);
            if (Value == true)
                return Ok(BDto.CustomerId);
            else
                return NotFound();
        }
        [HttpPost]
        [Route("UnBlockCustomer")]
        public IActionResult UnBlockCustomer(BlockAndUnblockTechnicalAndCustomersDto BDto)
        {
            var Value = _customerManager.UnBlockCustomer(BDto);
            if (Value == true)
                return Ok(BDto.CustomerId);
            else
                return NotFound();
        }

        [HttpGet]
        [Route("GetAllBlockedTechnicals/{CustomerId}")]
        public IActionResult GetAllBlockedTechnicals(int CustomerId)
        {
            var TechList = _customerManager.GetAllBlockedTechnicals(CustomerId);
            if (TechList == null)
                return NotFound();
            return Ok(TechList.BlockListDtos);
        }

        [HttpGet]
        [Route("GetAllNotification/{CustomerId}")]
        public IActionResult GetNotificationCount(int CustomerId)
        {
            var Number = _customerManager.GetNotificationCount(CustomerId);
          
            return Ok(Number);
        }

        [HttpGet]
        [Route("GetAllNotificationData/{CustomerId}")]
        public IActionResult GeAlltNotification(int CustomerId)
        {
            var Data = _customerManager.GetAllNotification(CustomerId);

            return Ok(Data);
        }

       

        [HttpGet]
        [Route("GetBlockedCustomers/{id}")]
        public ActionResult<ICollection<UnBlocked_BlockedCustomersDto>> GetBlockedCustomers(int id)
        {
            var AllBlockedCustomers = _customerManager.GetBlockedCustomers(id);

            if (AllBlockedCustomers == null) return NotFound();

            return Ok(AllBlockedCustomers);
        }

        [HttpGet]
        [Route("GetUnBlockedCustomers/{id}")]
        public ActionResult<ICollection<UnBlocked_BlockedCustomersDto>> GetUnBlockedCustomers(int id)
        {
            var AllUnBlockedCustomers = _customerManager.GetUnBlockedCustomers(id);

            if (AllUnBlockedCustomers == null) return NotFound();

            return Ok(AllUnBlockedCustomers);
        }


    }
}
