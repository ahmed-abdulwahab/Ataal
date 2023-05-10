using Ataal.BL.DTO.Offer;
using Ataal.DAL.Data.Models;
using Ataal.DAL.Data.Repos.OfferRepo;
using Ataal.DAL.Data.Repos.Technical_Repo;
using Ataal.DAL.Repos.customer;
using Ataal.DAL.Repos.problem;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.Managers.Offer
{
    public class OfferManger : IOfferManger
    {
        private readonly ITechnicalRepo technicalRepo;
        private readonly ICustomerRepo customerRepo;
        private readonly IOfferRepo offerRepo;
        private readonly IProblemRepo _problemRepo;

        public OfferManger(IProblemRepo problemRepo,ITechnicalRepo technicalRepo, ICustomerRepo customerRepo, IOfferRepo offerRepo)
        {
            this.technicalRepo = technicalRepo;
            this.customerRepo = customerRepo;
            this.offerRepo = offerRepo;
            _problemRepo= problemRepo;
        }


        //if problemID == -1 it act as ====> getAll Offers For Specific Technical for Specific Problem
        //else it act like getAll Offers For Specific Technical

        public List<OfferDTO> getAll_Offers(int technicaID, int problemID)
        {
            var allOffers = offerRepo.getAll_Offers(technicaID, problemID);

            return allOffers.Select(O => new OfferDTO
            (
                O.technicalId, 
                O.problemId, 
                O.OfferSalary, 
                O.OfferMassage
            )).ToList();
        }

        public GetByIdOffer getByID(int id)
        {
            var allOffers = offerRepo.getByID(id);

            return new GetByIdOffer
            (

                allOffers.technicalId,
                allOffers.problemId,
                allOffers.OfferSalary,
            allOffers.OfferMassage,
             offerId: allOffers.Id,
           Acepted:allOffers.Accepted

            );
        }

        public bool deleteOffer(int id)
        {
            return offerRepo.deleteOffer(id);
        }


        public bool createOffer(OfferDTO offerDTO)
        {
            var technical = technicalRepo.getTechnicalByID(offerDTO.Technicalid);

            var prblem = customerRepo.GetProblemByID(offerDTO.problemID);

            var Customer_Problem = _problemRepo.GetProblemById(offerDTO.problemID);
            if (technical == null || prblem == null)
                return false;

            var newOffer = new Ataal.DAL.Data.Models.Offer()
            {
                OfferMassage = offerDTO.OfferMassege,
                OfferSalary = offerDTO.OfferSalary,
                problemId = offerDTO.problemID,
                problem = prblem,
                technicalId = offerDTO.Technicalid,
                technical = technical,
            };

            if (!offerRepo.CreateOffer(newOffer)){
                return false;
            }
            else
            {
                Customer_Problem.Customer.NotificationCounter = Customer_Problem.Customer.NotificationCounter + 1;
                _problemRepo.SaveChanges();
                customerRepo.SaveChanges();

                return true;
            }
           
        }

        public OfferDTO getByIDUsingTechnical(int technicalId, int ProblemID)
        {
            var allOffers = offerRepo.getByIDUsingTechnical(technicalId, ProblemID);
            if (allOffers == null)
                return null!;
            return new OfferDTO
            (
                allOffers.technicalId,
                allOffers.problemId,
                allOffers.OfferSalary,
                allOffers.OfferMassage
            );
        }

        public bool deleteOfferByTechnicalandProblemId(int TechnicalID, int ProblemID)
        {
            return offerRepo.deleteOfferByTechnicalandProblemId(TechnicalID, ProblemID);
        }
    }
}
