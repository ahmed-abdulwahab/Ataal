using Ataal.DAL.Data.Context;
using Ataal.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.DAL.Repos.keywords
{
    public class KeywordsRepo : IKeywordsRepo
    {
        private readonly AtaalContext _ataalContext;
        public KeywordsRepo(AtaalContext ataalContext)
        {
            _ataalContext = ataalContext;
        }
        public List<KeyWords> GetAllKeywordsBySectionId(int sectionId)
        {
            return _ataalContext.KeyWords.ToList();
                                
        }

        public int SaveChanges()
        {
            return _ataalContext.SaveChanges();
        }
    }
}
