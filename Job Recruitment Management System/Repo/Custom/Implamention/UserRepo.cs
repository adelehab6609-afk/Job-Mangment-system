using Job_Recruitment_Management_System.Data;
using Job_Recruitment_Management_System.GenericRepo;
using Job_Recruitment_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Job_Recruitment_Management_System.Repo.Custom.Implamention
{
    public class UserRepo : GenericRepo<User>, IUser
    {
        public UserRepo(AppDbContext context) : base(context)
        {
        }

        public async Task<bool?> Emailx(string email)
        {
          return await _context.Users.AnyAsync(x=> x.Email == email);
        }

        public async Task<bool?> PasswordExist(string password)
        {
            return await _context.Users.AnyAsync(x=> x.Password == password);
        }
    }
}
