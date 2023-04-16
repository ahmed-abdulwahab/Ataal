using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.DAL.CustomValidation.CustomerValidation
{
    public class Max_Rate : ValidationAttribute
    {
        int total;

        public Max_Rate(int number)
        {
            total = number;
        }

        public override bool IsValid(object? obj)
        {
            if (obj == null) { return false; }
            else
            {
                if (obj is int)
                {
                    int suppliedtotal = (int)obj;
                    if (suppliedtotal <= total)
                    {
                        return true;
                    }
                    else
                    {
                        ErrorMessage = "Invaild Total Price " + total;
                        return false;
                    }
                }
                else { return false; }
            }

        }
    }
}
