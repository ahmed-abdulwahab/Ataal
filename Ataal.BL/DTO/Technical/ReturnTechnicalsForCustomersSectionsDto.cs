﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.DTO.Technical
{
    public record ReturnTechnicalsForCustomersSectionsDto(
                                                          string name,
                                                          string? phone,
                                                          string? Brief,
                                                          int Rate,
                                                          int AllProblemsCount,
                                                          int AllSolvedProblemsCount,
                                                          string address,
                                                          string? photo);
    
    
}
