using Ataal.BL.DTO.keywords;
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
        public List<ReturnkeywordsWithIdDto> GetAllKeywordsBySectionId(int sectionId)
        {
            var KeywordsList=_keywordsRepo.GetAllKeywordsBySectionId(sectionId);
            var Keywords = KeywordsList.Select(K => new ReturnkeywordsWithIdDto(
                                                KeywordId: K.KeyWord_ID,
                                                KeywordName: K.KeyWord_Name
                    )).ToList();
            return Keywords;
        }
    }
}
