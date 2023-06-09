﻿using Ataal.BL.DTO.Offer;
using Ataal.DAL.Data.Models;
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

        public GetByIdOffer getByID(int id);
        public bool deleteOffer(int id);

        public OfferDTO getByIDUsingTechnical(int technicalId,int ProblemID);




        public bool deleteOfferByTechnicalandProblemId(int TechnicalID,int ProblemID);
    }
}
