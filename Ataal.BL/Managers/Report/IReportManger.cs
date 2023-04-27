using Ataal.BL.DTO.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.BL.Managers.Report
{
    public interface IReportManger
    {
        public List<ReportDTO> getAll();
        public ReportDTO getByID(int id);
        public bool DeleteById(int id);
        public bool createReport(ReportPostDTO reportDto);


    }
}
