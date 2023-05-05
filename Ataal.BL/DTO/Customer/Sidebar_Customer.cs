using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.DTO.Customer
{
    public record Sidebar_Customer
        (int id, string firstName,string lastName ,string? Photo,string address,int numOfProblems);


}
