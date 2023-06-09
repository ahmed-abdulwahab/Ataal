﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ataal.DAL.Data.Context;
using Ataal.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Ataal.DAL.Repos.Section
{
	public class SectionRepo : ISectionRepo
	{
		private readonly AtaalContext ataalContext;
        public SectionRepo(AtaalContext _ataalContext)
        {
			ataalContext = _ataalContext;
        }
        public int AddNewSection(Data.Models.Section section)
		{
			ataalContext.Sections.Add(section);
			return SaveChanges();
		}

		public int DeleteSection(int id)
		{
			var DeletedSection = GetSectionById(id);
			if (DeletedSection == null) { return 0; }
			ataalContext.Remove(DeletedSection);
			return SaveChanges();
		}

		public List<Data.Models.Section> GetAllSections()
		{
			return ataalContext
				.Set<Data.Models.Section>()
				.Include(t=>t.Technicals)
				.Include(k=>k.KeyWords)
				.Include(p=>p.Problems).ThenInclude(k=>k.KeyWord).ToList();
		}
        public List<Data.Models.Section> GetAllSectionsforCustomerneed()
        {
            return ataalContext
                .Set<Data.Models.Section>()
                .Include(t => t.Technicals)
                .Include(k => k.KeyWords)
                .Include(p => p.Problems.Where(s=>s.Solved!=true))
				.ThenInclude(C=>C.Customer).ToList();
				
        }

        public List<Data.Models.Section> GetAllSections_Customer()
        {
            return ataalContext
                .Set<Data.Models.Section>()
                .Include(t => t.Technicals)
                .Include(k => k.KeyWords)
                .Include(p => p.Problems)
                    .ThenInclude(c => c.Customer)
                .ToList();
        }


        public Data.Models.Section? GetSectionById(int id)
		{
			var Section = ataalContext.Sections.FirstOrDefault(s => s.Section_ID == id);
			return Section;
		}

		public Data.Models.Section GetSectionByIdWithDetails(int id)
		{
			return ataalContext
			.Set<Data.Models.Section>()
			.Include(t => t.Technicals)
			.Include(k => k.KeyWords)
			.Include(p => p.Problems)
			.FirstOrDefault(s=>s.Section_ID == id);
		}
        public List<Technical> GetAllTechnicalsForSectionIdSortedByRate(int sectionId)
		{
			var Technicals = ataalContext.Technicals
				.Include(P => P.Problems_Solved)
				.Include(s => s.Sections.Where(S => S.Section_ID == sectionId))
				.Include(T => T.AppUser).ToList();
			return Technicals.Where(t=>t.Rate>=2).OrderByDescending(T=>T.Rate).Take(5).ToList();
		}

        public int SaveChanges()
		{
			return ataalContext.SaveChanges();
		}

		public DAL.Data.Models.Section UpdateSection(Data.Models.Section section, int id)
		{
			var ChosenSection = ataalContext.Sections.SingleOrDefault(S => S.Section_ID == id);
			if (ChosenSection == null) return null;
			ChosenSection.Section_Name = section.Section_Name;
			ChosenSection.Description = section.Description;
			SaveChanges();
			return ChosenSection;
			
		}

        public List<Data.Models.Section> GetaAllSectionsForTechnical(int technicalID)
        {
            var technical = ataalContext.Technicals.Include(T=>T.Sections).FirstOrDefault(T=>T.Id == technicalID);

			var sections = technical?.Sections?.ToList() ?? null;
			return sections!;
        }
    }
}
