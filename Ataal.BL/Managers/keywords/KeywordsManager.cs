using Ataal.DAL.Data.Models;
using Ataal.DAL.Repos.keywords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.Managers.keywords
{
    public class KeywordsManager: IKeywordsManager
    {
        private readonly IKeywordsRepo _keywordsRepo;
        public KeywordsManager(IKeywordsRepo keywordsRepo)
        {
            _keywordsRepo = keywordsRepo;
        }
        public List<string> GetAllKeywordsBySectionId(int sectionId)
        {
            var Keywords=_keywordsRepo.GetAllKeywordsBySectionId(sectionId); 
            return Keywords;
        }
    }
}
