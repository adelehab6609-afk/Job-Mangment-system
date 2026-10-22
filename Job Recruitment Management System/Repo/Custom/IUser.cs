using Job_Recruitment_Management_System.GenericRepo;
using Job_Recruitment_Management_System.Models;

namespace Job_Recruitment_Management_System.Repo.Custom
{
    public interface IUser : IGenericRepo<User>
    {
       public Task<bool?> Emailx(string email);

        public Task<bool?> PasswordExist(string password);
    }
}
