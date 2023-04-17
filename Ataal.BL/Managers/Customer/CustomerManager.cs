using Ataal.BL.DTO.Customer;
using Ataal.BL.DTO.Identity;
using Ataal.BL.DTO.Rate;
using Ataal.DAL.Data.Context;
using Ataal.DAL.Data.Identity;
using Ataal.DAL.Data.Models;
using Ataal.DAL.Data.Repos;
using Ataal.DAL.Data.Repos.Customer;
using Ataal.DAL.Data.Repos.Technical_Repo;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.Managers.Customer
{
    public class CustomerManager : ICustomerManager
    {
        private readonly ICustomerRepo _customerRepo;

        private readonly IWebHostEnvironment _env;
        private readonly UserManager<AppUser> userManager;

        public CustomerManager(ICustomerRepo customerRepo, IWebHostEnvironment env, UserManager<AppUser> userManager)
        {
            _customerRepo = customerRepo;
            _env = env;
            this.userManager = userManager;
        }
        public async Task<int?> ReturnAddedProblemID(CustomerAddProblemDto CustDto)
        {
            if (CustDto != null)
            {
                var problem = new Problem
                {
                    Problem_Title = CustDto.Title,
                    Description = CustDto.Description,
                    Section_ID = CustDto.Section_ID,
                    Customer_ID = CustDto.Customer_ID,
                    KeyWord_ID = CustDto.KyeWord_ID,
                    PhotoPath1 = await ReturnImagePath(CustDto.File1),
                    PhotoPath2 = await ReturnImagePath(CustDto.File2),//Ask why is there null reference warning                                                 
                    PhotoPath3 = await ReturnImagePath(CustDto.File3),
                    PhotoPath4 = await ReturnImagePath(CustDto.File4),
                };
               return _customerRepo.AddCustomerProblem(problem);
            }
            return null;
            
        }
        public async Task<string?> ReturnImagePath(IFormFile File)
        {
            if (File != null)
            {
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(File.FileName)}";
                var filePath = Path.Combine(_env.WebRootPath, fileName);

                // Save the image to disk
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await File.CopyToAsync(stream);
                }
                return fileName;
            }
            return null;
            
        }
        public Problem? ReturnProblemByID(int ProblemID)
        {
            var problem= _customerRepo.GetProblemByID(ProblemID);
            if(problem!=null)
            {
                return problem;
            }

            return null;
        }
        public bool DeleteProblemWithImagesByProblemID(int ProblemID)
        {
            var problem = ReturnProblemByID(ProblemID);
            
            if(problem != null)
            {
                DeleteFile(problem.PhotoPath1 ?? "");
                DeleteFile(problem.PhotoPath2 ?? "");
                DeleteFile(problem.PhotoPath3 ?? "");
                DeleteFile(problem.PhotoPath4 ?? "");

                _customerRepo.DeleteProblem(ProblemID);
                return true;
            }
            return false;
        }
        public void DeleteFile(string fileName)
        {
            var path = Path.Combine("wwwroot", fileName);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
        public Technical gettechnical(int techincalid)
        {
            return _customerRepo.GetTechnicalById(techincalid);
        }

        public int CustomerAddingRate(RateCreationDto rateCreationDto)
        {
            var Rate = new Rate
            {
                
                Customer_ID = rateCreationDto.CustomerId,
                Technical_ID = rateCreationDto.TechnicalId,
                Rate_Value = rateCreationDto.RateValue
            };
            
            return _customerRepo.AddTechnicalRate(Rate);
        }
        public int ModifyingTechnical_Rate(int TechnicalId)
        {
            return _customerRepo.ModifyingTchnicalRate(TechnicalId);
        }

        public async Task<RegisterUserDto> CreateCustomer(RegisterUserDto customer)
        {
            var AppUser = await userManager.FindByIdAsync(customer.AppUser.Id);

            var Customer = new DAL.Data.Models.Customer()
            {
                Frist_Name = customer.firstName,
                Last_Name = customer.lastName,
                Address = customer.Address,
                AppUser = AppUser!,
                AppUserId = customer.AppUserId
            };

            var result =  _customerRepo.CreateCustomer(Customer);

            if (result == null) return null;

            return customer;
        }
    }
}


