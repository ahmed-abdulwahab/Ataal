using Ataal.DAL.Data.Context;
using Ataal.DAL.Data.Models;
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
                ataalContext.Offers.Add(offer);
                ataalContext.SaveChanges();
                return true;
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
    }
}
