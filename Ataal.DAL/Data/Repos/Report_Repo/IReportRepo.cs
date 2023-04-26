using Ataal.DAL.Data.Context;
using Ataal.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.DAL.Data.Repos.Report_Repo
{
    public interface IReportRepo
    {
        public List<Report> Get_All();

        public Report Get_By_ID(int id);

        public bool Delete(int id);

        public bool Add(Report report);
    }
}
