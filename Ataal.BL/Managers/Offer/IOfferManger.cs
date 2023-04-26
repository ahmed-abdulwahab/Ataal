using Ataal.BL.DTO.Offer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.Managers.Offer
{
    public interface IOfferManger
    {
        public bool createOffer(OfferDTO offerDTO);
        public List<OfferDTO> getAll_Offers(int technicaID, int problemID);

        public OfferDTO getByID(int id);
        public bool deleteOffer(int id);

    }
}
