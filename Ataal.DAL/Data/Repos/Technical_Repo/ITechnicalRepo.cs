using Ataal.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.DAL.Data.Repos.Technical_Repo
{
    public interface ITechnicalRepo
    {
        public List<Technical> getAllTechnical();
        public Technical getTechnicalByID(int id);
        public Technical deleteTechnical(int id);
        public Technical updateTechnical(int id, Technical technical);
        public Technical Createtechnical(Technical technical);

    }
}
