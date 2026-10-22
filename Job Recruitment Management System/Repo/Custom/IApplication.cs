using Job_Recruitment_Management_System.GenericRepo;
using Job_Recruitment_Management_System.Models;

namespace Job_Recruitment_Management_System.Repo.Custom
{
    public interface IApplication : IGenericRepo<Application> 
    {
        Task<List<Application>> GetByUserIdAsync(int userId);
    }
}
