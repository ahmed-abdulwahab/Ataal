
using Ataal.DAL.Data.Models;

namespace Ataal.DAL.Repos.Section
{
	public interface ISectionRepo
	{
        
        public List<Data.Models.Section> GetAllSections();
        public List<Data.Models.Section> GetAllSections_Customer();
        public Data.Models.Section GetSectionByIdWithDetails(int id );
		public Data.Models.Section? GetSectionById(int id);
		public int AddNewSection(Data.Models.Section section);
		public Data.Models.Section? UpdateSection(Data.Models.Section section , int id);
        public List<Technical> GetAllTechnicalsForSectionIdSortedByRate(int sectionId);
        public int DeleteSection(int id);
		public int SaveChanges();

	}
}
