using Ataal.DAL.Data.Context;
using Ataal.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.DAL.Data.Repos.Report_Repo
{
    public class ReportRepo : IReportRepo
    {
        private readonly AtaalContext ataalContext;

        public ReportRepo(AtaalContext ataalContext)
        {
            this.ataalContext = ataalContext;
        }

        public List<Report> Get_All()
        {
            try
            {

                return ataalContext.Set<Report>().ToList();
            }
            catch
            {
                return null!;
            }
        }

        public Report Get_By_ID(int id)
        {
            try
            {
                return ataalContext.Set<Report>().FirstOrDefault(R => R.Id == id)!;
            }catch 
            {
                return null!;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var report = ataalContext.Set<Report>().FirstOrDefault(r => r.Id == id);

                if (report != null)
                {
                    ataalContext.Set<Report>().Remove(report);
                    ataalContext.SaveChanges();
                    return true;
                }
                return false;

            }
            catch
            {
                return false;
            }
        }

        public bool Add(Report report)
        {
            try
            {
                ataalContext.Set<Report>().Add(report);
                ataalContext.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

    } 
}
