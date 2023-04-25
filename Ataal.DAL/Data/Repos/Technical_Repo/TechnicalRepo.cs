using Ataal.DAL.Data.Context;
using Ataal.DAL.Data.Identity;
using Ataal.DAL.Data.Models;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<AppUser> userManager;

        public TechnicalRepo(AtaalContext _AtaalContext, UserManager<AppUser> _userManager)
        {
            ataalContext = _AtaalContext;
            userManager = _userManager;
        }
        public async Task<Technical> deleteTechnical(int id)
        {
            // Technical technical;
            // AppUser appUser;


            var technical = ataalContext.Technicals.Include("AppUser")
                    .FirstOrDefault(t => t.Id == id);

            if (technical == null)
            {
                return null!;
            }



            if (technical.AppUser == null) { return null!; }
            ataalContext.Technicals.Remove(technical);
            ataalContext.SaveChanges();
            await userManager.DeleteAsync(technical.AppUser);
            //await ataalContext.SaveChangesAsync();

            return technical;
        }
        public List<Technical> getAllTechnical()  ///check the null after build the controller
        {
            return ataalContext.Set<Technical>().ToList();
        }


        public List<Technical> getAllTechnicalForSectionId(int SectionId)
        {
            var Section = ataalContext.Sections.Include(S=>S.Technicals)
                .FirstOrDefault(t=>t.Section_ID==SectionId);
            return Section.Technicals.ToList();
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
        public Technical? getNormalTechnicalById(int TechnicalId)
        {
            var technical= ataalContext.Technicals.Find(TechnicalId);
            if(technical == null)
            {
                return null;
            }
            return technical;
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

        public Technical CreateTechnical(Technical technical)
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
