using Ataal.BL.DTO.Customer;
using Ataal.DAL.Data.Models;
using Ataal.BL.DTO.Identity;
using Ataal.BL.DTO.Rate;
using Ataal.BL.DTO.Review;
using Ataal.BL.DTO.Technical;
using Ataal.BL.Managers.Technical;
using Ataal.DAL.Data.Context;
using Ataal.DAL.Data.Identity;
using Ataal.DAL.Data.Models;
using Ataal.DAL.Data.Repos;
using Ataal.DAL.Repos.customer;
using Ataal.DAL.Repos.Reviews;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ataal.BL.DTO.problem;
using Ataal.BL.DTO.recommendation;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ataal.BL.Managers.Customer
{
    public class CustomerManager : ICustomerManager
    {
        private readonly IReviewRepo _reviewRepo;
        private readonly UserManager<AppUser> userManager;
        private readonly IWebHostEnvironment _env;
        private readonly ICustomerRepo customerRepo;

        public CustomerManager(IReviewRepo reviewRepo, 
            UserManager<AppUser> userManager,
            IWebHostEnvironment env, ICustomerRepo customerRepo)
        {
            _reviewRepo = reviewRepo;
            this.userManager = userManager;
            _env = env;
            this.customerRepo = customerRepo;
        }
        public int GetNotificationCount(int CustomerId)
        {

            return customerRepo.GetNotificationCount(CustomerId);
        }

        public NotificationDto GetAllNotification(int CustomerId)
        {
            var Modifiy_Customer = customerRepo.GetNormalCustomerById(CustomerId);
            Modifiy_Customer.NotificationCounter=0;
            customerRepo.SaveChanges();
            var Recommendition= customerRepo.GetRecommenditionForCustomerById(CustomerId);

            /*  NotificationDto notifs=new NotificationDto(RecomenditionList=*/
            List<NotificationDataDto> All_Notification = new List<NotificationDataDto>();
            //List < RecommendationCustomerDto > All= new List<RecommendationCustomerDto>();
            //List<OffersCustomerDto> All_Offers = new List<OffersCustomerDto>();
            var Offers=   customerRepo.GetOffersForCustomerById(CustomerId);
            if (Recommendition != null && Recommendition.Problems != null)
            {
                foreach (var R in Recommendition.Problems)
                {
                    foreach (var Rr in R.Recommendations)
                    {
                        var Customer = customerRepo.GetNormalCustomerById(R.Customer_ID);
                        NotificationDataDto Reco = new NotificationDataDto(
                                   CustomerName: $"{Customer.Frist_Name} {Customer.Last_Name}",
                                   TechnId: Rr.Technical_ID,
                                   TechnicalName: $"{Rr.Technical.Frist_Name} {Rr.Technical.Last_Name}",
                                  ProblemId: R.Problem_ID,
                                  Problem_Title: R.Problem_Title,
                                  OfferId:null,
                                  date: Rr.Date



                                  );
                        All_Notification.Add(Reco);

                    }
                }
            }
            if (Offers != null && Offers.Problems != null)
            {
                foreach (var Problem in Offers.Problems)
                {
                    foreach (var offer in Problem.Offers)
                    {

                        NotificationDataDto Problem_offer = new NotificationDataDto(
                                   OfferId: offer.Id,
                                   TechnId: offer.technicalId,
                                   TechnicalName: $"{offer.technical.Frist_Name} {offer.technical.Last_Name}",
                                  ProblemId: offer.problemId,
                                  Problem_Title: Problem.Problem_Title,
                                  CustomerName:null,
                                  date: offer.Date

                                  );
                        All_Notification.Add(Problem_offer);

                    }
              
                }
            }

            DateTime thirtyDaysAgo = DateTime.Now.AddDays(-30); // calculate the date 30 days ago

            var final_notification = All_Notification.Where(x => x.date >= thirtyDaysAgo)
                                    .OrderByDescending(x => x.date)
                                           .ToList();
            return new NotificationDto(Notifications: final_notification); 

                

        }





        public oneCustomerDto? GetCustomerById(int id)
        {
          var customer=  customerRepo.GetNormalCustomerById(id);
            if (customer != null) {
          return new oneCustomerDto(firstName: customer.Frist_Name, lastName: customer.Last_Name, userName: customer.AppUser.UserName, Email: customer.AppUser.Email, phone: customer.AppUser.PhoneNumber, Photo: customer.Photo, Address: customer.Address);
            }
            return null;

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
               return customerRepo.AddCustomerProblem(problem);
            }
            return null;
            
        }
        public List<ProblemReturnDto>? ReturnProblemsForCustomers(int CustomerId)
        {
            var Problemslist = customerRepo.GetAllProblemsForCustomer(CustomerId);
            if (Problemslist == null)
                return null;
            var Problems = Problemslist.Select(P => new ProblemReturnDto(
                                                  id:P.Problem_ID,
                                                   Title: P.Problem_Title,
                                                    Description: P.Description,
                                                    Date: P.dateTime,
                                                    IsSolved: P.Solved,
                                                    IsVIP: P.VIP,
                                                    Key_Word: P.KeyWord?.KeyWord_Name,
                                                    PhotoPath1: P.PhotoPath1,
                                                    PhotoPath2: P.PhotoPath2,
                                                    PhotoPath3: P.PhotoPath3,
                                                    PhotoPath4: P.PhotoPath4)).ToList();
            return Problems;
        }
        public async Task<int?> UpdatedProblem( updatedProblemDto CustDto)

        {
            var problem = ReturnProblemByID(CustDto.Problem_id);

            if (problem != null)
            {
                DeleteFile(problem.PhotoPath1 ?? "");
                DeleteFile(problem.PhotoPath2 ?? "");
                DeleteFile(problem.PhotoPath3 ?? "");
                DeleteFile(problem.PhotoPath4 ?? "");

               
            }
            if (CustDto != null)
            {
                var Newproblem = new Problem
                {
                    Problem_ID= CustDto.Problem_id,
                    Problem_Title = CustDto.Title,
                    Description = CustDto.Description,
                    Section_ID = CustDto.Section_ID,
                
                    KeyWord_ID = CustDto.KyeWord_ID,
                    PhotoPath1 = await ReturnImagePath(CustDto.File1),
                    PhotoPath2 = await ReturnImagePath(CustDto.File2),//Ask why is there null reference warning                                                 
                    PhotoPath3 = await ReturnImagePath(CustDto.File3),
                    PhotoPath4 = await ReturnImagePath(CustDto.File4),
                };
                return customerRepo.UpdateCustomerProblem(Newproblem);
            }
            return null;

        }
        public async Task<int?> UpdateCustomerProfile(int CustomerId, UpdatedCustomerProfileDto Dto)
        {
            var customer = customerRepo.GetNormalCustomerById(CustomerId);

            if (customer == null)
            {
                return 0;
                throw new Exception("Customer not found");
            }

            if (Dto.PhotoFile != null)
            {
                var photoPath = await ReturnImagePath(Dto.PhotoFile);
                customer.Photo = photoPath;
            }
          

            customer.Frist_Name = Dto.FirstName;
            customer.Last_Name = Dto.LastName;
            customer.Address = Dto.Address;
            customer.AppUser.PhoneNumber = Dto.phone;
            customer.AppUser.Email = Dto.Email;
            customer.AppUser.UserName = Dto.userName;

            customer.Address = Dto.Address;

            customerRepo.SaveChanges();
            return 1;

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
            var problem= customerRepo.GetProblemByID(ProblemID);
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

                customerRepo.DeleteProblem(ProblemID);
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
        public Ataal.DAL.Data.Models.Technical gettechnical(int techincalid)
        {
            return customerRepo.GetTechnicalById(techincalid);
        }


        public CustomerWithTechnicalsBlockedListDto? GetAllBlockedTechnicals(int CustomerId)
        {
            var BlockedList=customerRepo.GetAllBlockedTechnicalFromCustomer(CustomerId);
            var BlockedTechnicals = new CustomerWithTechnicalsBlockedListDto(
                BlockListDtos: BlockedList.Blocked_Technicals_Id.Select(technical =>
                                new ReturnTechnicalForBlockListDto(
                                    id: technical.Id,
                                    name: technical.Frist_Name + " " + technical.Last_Name,
                                    
                                    Photo: technical.Photo,
                                    Rate: technical.Rate,
                                    Brief: technical.Brief,
                                    Address: technical.Address
                                    )).ToList()
                ) ;
                
            if (BlockedTechnicals == null)
                return null;
            return BlockedTechnicals;
        }

        public int CustomerAddingRate(RateCreationDto rateCreationDto)
        {
            var Rate = new Rate
            {
                
                Customer_ID = rateCreationDto.CustomerId,
                Technical_ID = rateCreationDto.TechnicalId,
                Rate_Value = rateCreationDto.RateValue
            };
            
            return customerRepo.AddTechnicalRate(Rate);
        }
        public int AddingTechnicalReview(ReviewCreationDto ReviewDto)
        {

            var NewReview = new Review
            {
                Customer_ID = ReviewDto.Customer_Id,
                Technical_ID = ReviewDto.Technical_Id,
                Description = ReviewDto.Description,
                date = DateTime.Now

            };
            return customerRepo.AddTechnicalReview(NewReview);
        }
        public int ModifyingTechnical_Rate(int TechnicalId)
        {
            return customerRepo.ModifyingTchnicalRate(TechnicalId);
        }
        public bool DeleteReview(int ReviewId)
        {
         var Deleted= customerRepo.DeleteReview(ReviewId);
            if (Deleted == null || Deleted == 0)
            {
                return false;
            }
            return true;
        }
        public bool BlockTechnical(BlockAndUnblockTechnicalAndCustomersDto BDto)
        {
            var Technical =customerRepo.GetTechnicalById(BDto.TechnicalId);
            var CustomerWithBlockedList = customerRepo.GetCustomerWithBlockedList(BDto.CustomerId);
            if (CustomerWithBlockedList != null &&
                CustomerWithBlockedList.Blocked_Technicals_Id != null &&
                CustomerWithBlockedList.Blocked_Technicals_Id.Count == 0
                && Technical != null)
            {
                customerRepo.BlockTechnical(CustomerWithBlockedList, Technical);
                return true;
            }
            else if (CustomerWithBlockedList != null && CustomerWithBlockedList.Blocked_Technicals_Id != null && Technical != null)
            {
                if (!CustomerWithBlockedList.Blocked_Technicals_Id.Contains(Technical))
                {
                    CustomerWithBlockedList.Blocked_Technicals_Id.Add(Technical);
                    return true;
                }
                
            }
            return false;
        }
        
        public bool UnBlockTechnical(BlockAndUnblockTechnicalAndCustomersDto BDto)
        {
            var Technical = customerRepo.GetTechnicalById(BDto.TechnicalId);
            var CustomerWithBlockedList = customerRepo.GetCustomerWithBlockedList(BDto.CustomerId);
            
             if (CustomerWithBlockedList != null && CustomerWithBlockedList.Blocked_Technicals_Id != null && Technical != null)
            {
                if (CustomerWithBlockedList.Blocked_Technicals_Id.Contains(Technical))
                {
                    var value = customerRepo.UnBlockTechnical(CustomerWithBlockedList, Technical);
                    if (value > 0)
                        return true;
                    else
                        return false;
                }

            }
            return false;
        }
        public bool BlockCustomer(BlockAndUnblockTechnicalAndCustomersDto BDto)
        {
            var customer = customerRepo.GetCustomerWithBlockedList(BDto.CustomerId);
            var TechnicalWithBlockedList = customerRepo.GetTechnicalWithBlockedList(BDto.TechnicalId);
            if (TechnicalWithBlockedList != null &&
                TechnicalWithBlockedList.Blocked_Customers_Id != null &&
                TechnicalWithBlockedList.Blocked_Customers_Id.Count == 0
                && customer != null)
            {
                customerRepo.BlockCustomer(customer, TechnicalWithBlockedList);
                return true;
            }
            else if (TechnicalWithBlockedList != null && TechnicalWithBlockedList.Blocked_Customers_Id != null && customer != null)
            {
                if (!TechnicalWithBlockedList.Blocked_Customers_Id.Contains(customer))
                {
                    TechnicalWithBlockedList.Blocked_Customers_Id.Add(customer);
                    return true;
                }

            }
            return false;
        }

        public bool UnBlockCustomer(BlockAndUnblockTechnicalAndCustomersDto BDto)
        {
            var customer = customerRepo.GetCustomerWithBlockedList(BDto.CustomerId);
            var TechnicalWithBlockedList = customerRepo.GetTechnicalById(BDto.TechnicalId);

            if (TechnicalWithBlockedList != null && TechnicalWithBlockedList.Blocked_Customers_Id != null && customer != null)
            {
                if (TechnicalWithBlockedList.Blocked_Customers_Id.Contains(customer))
                {
                    var value = customerRepo.UnBlockCustomer(customer, TechnicalWithBlockedList);
                    if (value > 0)
                        return true;
                    else
                        return false;
                }

            }
            return false;
        }
        public int? UpdateReview(ReviewUpdatedDto ReviewUpdated)
        {


            return customerRepo.UpdateReview(ReviewUpdated.id, ReviewUpdated.Descriotion);
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

            var result = customerRepo.CreateCustomer(Customer);

            if (result == null) return null;

            return customer;
        }


    }
}


