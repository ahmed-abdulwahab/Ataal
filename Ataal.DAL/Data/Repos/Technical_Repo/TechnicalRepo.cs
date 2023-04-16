using Ataal.DAL.Data.Context;
using Ataal.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.DAL.Data.Repos.Technical_Repo
{
    public class TechnicalRepo : ITechnicalRepo
    {
        private readonly AtaalContext ataalContext;

        public TechnicalRepo(AtaalContext _AtaalContext)
        {
            ataalContext = _AtaalContext;
        }
        public Technical deleteTechnical(int id)
        {

            var technical =  ataalContext.Set<Technical>()?.FirstOrDefault(T => T.Id == id);

            if (technical == null)
            {
                return null!;
            }

            try
            {
                ataalContext.Set<Technical>().Remove(technical);
                ataalContext.SaveChanges();
                return technical;
            }
            catch
            {
                return null!;
            }
        }

        public List<Technical> getAllTechnical()                     ///check the null after build the controller
        {
            return ataalContext.Set<Technical>().ToList();
        }

        public Technical getTechnicalByID(int id)
        {
            var technicals = ataalContext.Set<Technical>().Include("AppUser");
            if(!technicals.Any()) 
            {
                return null!;
            }
            return technicals.FirstOrDefault(T => T.Id == id)!;
        }

        public Technical updateTechnical(int id, Technical technical)
        {
            var OldTechnical = ataalContext.Set<Technical>()?.FirstOrDefault(T=>T.Id==id)!;

            if (OldTechnical == null)
            {
                return null!;
            }
            try
            {
                ataalContext.Entry(OldTechnical).CurrentValues.SetValues(technical);
                ataalContext.SaveChanges();
                return technical;
            }
            catch
            {
                return null!;
            }
        }

        public Technical Createtechnical(Technical technical)
        {
            try
            {
                ataalContext.Technicals.Add(technical);
                ataalContext.SaveChanges();
                return technical;
            }
            catch
            {
                return null!;
            }
        }
    }
}
