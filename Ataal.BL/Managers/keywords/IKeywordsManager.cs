﻿using Ataal.BL.DTO.keywords;
using Ataal.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.Managers.keywords
{
    public interface IKeywordsManager
    {
        public List<ReturnkeywordsWithIdDto> GetAllKeywordsBySectionId(int sectionId);
    }
}
