using Ataal.BL.DTO.Report;
using Ataal.DAL.Data.Models;
using Ataal.DAL.Data.Repos.Report_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.Managers.Report
{
    public class ReportManger : IReportManger
    {
        private readonly IReportRepo reportRepo;

        public ReportManger(IReportRepo reportRepo)
        {
            this.reportRepo = reportRepo;
        }

        public List<ReportDTO> getAll()
        {
            try
            {
                var allReports = reportRepo.Get_All();
                return allReports.Select(R => new ReportDTO
                    (
                        id:R.Id,
                        Review_ID:R.Review_ID,
                        Cause:R.Causes.ToString(),
                        Description:R.Description,
                        Created_Date:R.Created_Date
                    )).ToList();
            }
            catch
            {
                return null!;
            }
        }

        public ReportDTO getByID(int id)
        {
            try
            {
                var report = reportRepo.Get_By_ID(id);
                return new ReportDTO
                    (
                        id: report.Id,
                        Review_ID: report.Review_ID,
                        Cause: report.Causes.ToString(),
                        Description: report.Description,
                        Created_Date: report.Created_Date
                    );
            }
            catch
            {
                return null!;
            }
        }

        public bool DeleteById(int id)
        {
            try
            {
                return reportRepo.Delete(id);
            }
            catch
            {
                return false;
            }
        }

        public bool createReport(ReportPostDTO reportDto)    //is it okay if i didnt assign the navigation property when i declare new object
        {

            Causes causes;
            Causes.TryParse(reportDto.Cause,out causes);

            var newReport = new Ataal.DAL.Data.Models.Report() 
            {
                Description = reportDto.Description,
                Review_ID = reportDto.Review_ID,
                Created_Date= reportDto.Created_Date,
                Causes = causes,
                TechnicalId = reportDto.technicalid
            };
            
            return reportRepo.Add(newReport);

        }
    }
}
