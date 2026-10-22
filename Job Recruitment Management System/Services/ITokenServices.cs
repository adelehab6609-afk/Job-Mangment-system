using Job_Recruitment_Management_System.DTOS.User;
using Job_Recruitment_Management_System.Models;

namespace Job_Recruitment_Management_System.Services
{
    public interface ITokenServices
    {
        Task<string> GetToken(User user);
        Task<string> Login(LoginDTO loginDTO);
    }
}
