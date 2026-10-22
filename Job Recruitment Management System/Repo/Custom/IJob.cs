using Job_Recruitment_Management_System.GenericRepo;
using Job_Recruitment_Management_System.Models;

namespace Job_Recruitment_Management_System.Repo.Custom
{
    public interface IJob : IGenericRepo<Job>
    {
        public Task<Job> GetSalary();

        public Task<Job> GetJob(int id);

        public Task<List<Job>> Search(string word);
    }
}
