﻿using Ataal.BL.DtO.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.DTO.Identity
{
    public class AppUserDto
    {
        public string Id { get; set; }
        public string userName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    };
}
