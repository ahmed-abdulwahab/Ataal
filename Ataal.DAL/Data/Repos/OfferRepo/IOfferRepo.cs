using Ataal.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.DAL.Data.Repos.OfferRepo
{
    public interface IOfferRepo
    {
        public bool CreateOffer(Offer offer);
        public List<Offer> getAll_Offers(int technicalID, int problemID);
        public Offer getByID(int id);
        public bool deleteOffer(int id);


    }
}
