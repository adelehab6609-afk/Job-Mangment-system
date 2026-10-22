using Job_Recruitment_Management_System.Data;
using Job_Recruitment_Management_System.GenericRepo;
using Job_Recruitment_Management_System.Models;
using Job_Recruitment_Management_System.Repo.Custom;
using Job_Recruitment_Management_System.Services;

namespace Job_Recruitment_Management_System.Repo.UnitOfWork
{
    public class UintOfWork : IUnitOfWork
    {
        private AppDbContext _context;

        public IUser user { get; }

        public IJob job { get; }

        public ICompany company { get; }

        public IApplication application { get; }

        public IGenericRepo<CandidateProfile> candidateProfile { get; }

        public ITokenServices TokenServices { get; }

        public UintOfWork(AppDbContext context, IUser user, IJob job, ICompany company, IApplication application, IGenericRepo<CandidateProfile> candidateProfile,ITokenServices tokenServices)
        {
            _context = context;
            this.user = user;
            this.job = job;
            this.company = company;
            this.application = application;
            this.candidateProfile = candidateProfile;
            TokenServices = tokenServices;
        }

        public async Task<int> SaveAsync() =>  await _context.SaveChangesAsync();
       
    }
}
