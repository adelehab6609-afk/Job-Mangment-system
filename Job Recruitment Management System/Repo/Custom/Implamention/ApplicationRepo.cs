using Job_Recruitment_Management_System.Data;
using Job_Recruitment_Management_System.GenericRepo;
using Job_Recruitment_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Job_Recruitment_Management_System.Repo.Custom.Implamention
{
    public class ApplicationRepo : GenericRepo<Application>, IApplication
    {
        public ApplicationRepo(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Application>> GetByUserIdAsync(int userId)
        {
            return await _context.Applications.Where(a => a.CandidateProfile!.UserId == userId).ToListAsync();
        }
    }
}
