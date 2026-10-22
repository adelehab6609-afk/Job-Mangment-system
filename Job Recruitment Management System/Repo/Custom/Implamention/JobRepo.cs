using Job_Recruitment_Management_System.Data;
using Job_Recruitment_Management_System.GenericRepo;
using Job_Recruitment_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks.Dataflow;

namespace Job_Recruitment_Management_System.Repo.Custom.Implamention
{
    public class JobRepo : GenericRepo<Job>, IJob
    {
        public JobRepo(AppDbContext context) : base(context)
        {

        }

        public async Task<Job> GetJob(int id)
        {
            return await _context.Jobs.Include(x => x.Company).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Job> GetSalary()  
        {
           return await _context.Jobs.Distinct().OrderByDescending(x=> x.Salary).Skip(2).FirstOrDefaultAsync();
        }

        public async Task<List<Job>> Search(string word)
        {
            return await _context.Jobs.Where(x=> x.Title.Contains(word.ToLower()) || x.Description.Contains(word.ToLower())).ToListAsync();
        }
    }
}
