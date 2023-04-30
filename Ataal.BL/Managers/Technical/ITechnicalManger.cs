﻿using Ataal.BL.DtO.Identity;
using Ataal.BL.DtO.technical;
using Ataal.BL.DTO.Identity;
using Ataal.BL.DTO.Technical;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Ataal.BL.Mangers.technical
{
    public interface ItechnicalManger
    {
        public List<Technical_Name_Photo_Address_Rate> GetAllTechnicals();
        public Task<DetailedTechnicalDTO> GetTechnical_Profile(int id);
        public Task<SideBarTechnicalDto> GetTechnical_SomeInfo(int id);
        public List<TechnicalDto>? getAllTechnicalForSectionId(int SectionId);

        public int deleteTechnical(int id);

        public Task<int> updateTechnical(int id, TechnicalUpdateDto technical);

        public Task<RegisterUserDto> addTechnical(RegisterUserDto technical);

    }
}
