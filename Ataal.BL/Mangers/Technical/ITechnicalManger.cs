using Ataal.BL.DtO.technical;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Ataal.BL.Mangers.technical
{
    public interface ItechnicalManger
    {
        public technicalDtO GetTechnical_Profile(int id);
    }
}
