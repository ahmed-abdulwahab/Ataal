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



        public bool AddSectionsToTechnical(int[] SectionIds, int TechnicalId)
        {
            var Technical = ataalContext.Technicals
                                        .Include(S => S.Sections)
                                        .FirstOrDefault(T => T.Id == TechnicalId);

            for(int i=0;i<SectionIds.Length;i++)
            {
                Technical.Sections.Add(ataalContext.Sections.Find(SectionIds[i]));
            }
            saveChanges();
            return true;
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
        


        public Technical? getTechnicalByID(int id)
        {
            return ataalContext.Set<Technical>().Where(t => t.Id==id)
                .Include(t => t.AppUser).Include(t => t.Problems_Solved).Include(T=>T.Sections).Include(t=>t.Reviews)!.ThenInclude(r => r.Customer)
                .FirstOrDefault();
        }


        public Technical GetTechnicalIncludeSections(int TechnicalId)
        {
            return ataalContext.Technicals.Include(S => S.Sections).FirstOrDefault(T=>T.Id==TechnicalId);
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

        public int saveChanges()
        {
            return ataalContext.SaveChanges();
        }

        public int? getPoints(int TechnicalID)
        {
             var technical = ataalContext.Technicals.FirstOrDefault(T => T.Id==TechnicalID);

            if (technical == null || technical.Points == null)
                return 0;
            return technical.Points;
        }

        public bool decreasePoints(int technicalID)
        {
            try
            {
                var technical = ataalContext.Technicals.FirstOrDefault(T => T.Id == technicalID);
                technical!.Points -= 10;
                ataalContext.SaveChanges(true);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int getTechnicalNotification(int TechnicalID)
        {
            var technical = ataalContext.Technicals.FirstOrDefault(T => T.Id == TechnicalID);

            if (technical == null || technical.Points == null)
                return 0;
            return technical.NotificationCounter;
        }

        public bool setTechnicalNotificationZero(int TechnicalID)
        {
            try
            {
                var technical = ataalContext.Technicals.FirstOrDefault(T => T.Id == TechnicalID);
                technical.NotificationCounter = 0;
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
