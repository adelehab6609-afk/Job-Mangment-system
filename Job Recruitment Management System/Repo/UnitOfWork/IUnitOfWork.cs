using Job_Recruitment_Management_System.GenericRepo;
using Job_Recruitment_Management_System.Models;
using Job_Recruitment_Management_System.Repo.Custom;
using Job_Recruitment_Management_System.Services;

namespace Job_Recruitment_Management_System.Repo.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IUser user { get; }
        public IJob job { get; }
        public ICompany company { get; }
        public IApplication application { get; }
        public IGenericRepo<CandidateProfile> candidateProfile {  get; }

        Task<int> SaveAsync();

        public ITokenServices TokenServices { get; }
    } 
}
