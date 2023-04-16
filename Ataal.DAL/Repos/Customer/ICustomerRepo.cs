using Ataal.DAL.Data.Models;

namespace Ataal.DAL.Repos.Customer
{
	public interface ICustomerRepo
    {
        public int? AddCustomerProblem(Problem problem);
        public Problem? GetProblemByID(int ProblemID);
        public int DeleteProblem(int ProblemID);
        public int SaveChanges();
    }
}
