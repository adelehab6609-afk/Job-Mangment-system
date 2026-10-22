using Job_Recruitment_Management_System.Data;
using Job_Recruitment_Management_System.GenericRepo;
using Job_Recruitment_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Job_Recruitment_Management_System.Repo.Custom.Implamention
{
    public class CompanyRepo : GenericRepo<Company>, ICompany
    {
        public CompanyRepo(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Company>> GetallCompanies()
        {
            return await _context.Companies.Include(x=> x.Jobs).OrderByDescending(x=> x.Jobs.Count()).ToListAsync();
        }
    }
}
