﻿using Ataal.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.DAL.Repos.keywords
{
    public interface IKeywordsRepo
    {
        public List<KeyWords> GetAllKeywordsBySectionId(int sectionId);
        public int SaveChanges();
    }
}
