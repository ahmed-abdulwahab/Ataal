﻿using Ataal.DAL.Data.Context;
using Ataal.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.DAL.Data.Repos.OfferRepo
{
    public class OfferRepo : IOfferRepo
    {
        private readonly AtaalContext ataalContext;

        public OfferRepo(AtaalContext _AtaalContext)
        {
            ataalContext = _AtaalContext;
        }




        //if problemID == -1 it act as ====> getAll Offers For Specific Technical for Specific Problem
        //else it act like getAll Offers For Specific Technical
        public List<Offer> getAll_Offers(int technicalID, int problemID)      
        {
            try
            {
                if(problemID == -1)
                    return ataalContext.Offers.Where(O => O.technicalId == technicalID).ToList();
                return ataalContext.Offers
                    .Where(O => O.technicalId == technicalID && O.problemId == problemID).ToList();
            }
            catch
            {
                return null!;
            }
        }


        public Offer getByID(int id)      
        {
            try
            {
                return ataalContext.Offers.FirstOrDefault(O => O.Id == id)!;
            }
            catch
            {
                return null!;
            }
        }

        public bool CreateOffer(Offer offer)
        {
            try
            {
                offer.AcceptedDate = DateTime.Now;
                ataalContext.Offers.Add(offer);
                ataalContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool AssignOfferAsAccepted(int id)
        {
            try
            {
               var offer= ataalContext.Offers.Include(O=>O.problem).Include(O => O.technical).FirstOrDefault(O=>O.Id == id);

                var technical = offer?.technical;
                if (offer.Accepted == false)
                {
                    offer.Accepted = true;
                    offer.AcceptedDate = DateTime.Now;
                    offer.problem.AcceptedOfferID = offer.Id;
                    technical.NotificationCounter = technical.NotificationCounter + 1;
                    ataalContext.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
                
               
            }
            catch
            {
                return false;
            }
        }



        public bool deleteOffer(int id)
        {
            try
            {
                var offer = ataalContext.Offers.FirstOrDefault(O => O.Id == id)!;
                ataalContext.Offers.Remove(offer);
                ataalContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Offer getByIDUsingTechnical(int technicalId, int ProblemID)
        {
            try
            {
                return ataalContext.Offers.FirstOrDefault(O => O.technicalId == technicalId && O.problemId== ProblemID)!;
            }
            catch
            {
                return null!;
            }
        }

        public bool deleteOfferByTechnicalandProblemId(int TechnicalID, int ProblemID)
        {
            try
            {
                var offer = ataalContext.Offers.FirstOrDefault(O => O.technicalId == TechnicalID && O.problemId == ProblemID)!;
                ataalContext.Offers.Remove(offer);
                ataalContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
