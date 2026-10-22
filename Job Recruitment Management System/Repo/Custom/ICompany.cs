using Job_Recruitment_Management_System.GenericRepo;
using Job_Recruitment_Management_System.Models;

namespace Job_Recruitment_Management_System.Repo.Custom
{
    public interface ICompany : IGenericRepo<Company>
    {
        public Task<List<Company>> GetallCompanies();
    }
}
