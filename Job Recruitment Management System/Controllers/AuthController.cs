using Job_Recruitment_Management_System.DTOS.User;
using Job_Recruitment_Management_System.Models;
using Job_Recruitment_Management_System.Repo.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Job_Recruitment_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO) 
        {
            var r = await _unitOfWork.TokenServices.Login(loginDTO);
            if (r == null) { return Unauthorized("Invaild Email and PassWord"); }
            return Ok(r);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            if (registerDTO.Role != "Candidate" && registerDTO.Role != "Employer")
                return BadRequest("Role must be Candidate or Employer");

            if (await _unitOfWork.user.Emailx(registerDTO.Email) == true)
                return Conflict("Email already exists");

            if (await _unitOfWork.user.PasswordExist(registerDTO.Password) == true)
                return Conflict("password already exists");

            var user = new User()
            {
                FullName = registerDTO.FullName,
                Email = registerDTO.Email,
                Password = registerDTO.Password,
                Role = registerDTO.Role,
                CreatedAt = DateTime.UtcNow,
            };
            await _unitOfWork.user.AddAsync(user);
            await _unitOfWork.SaveAsync();

            return Created();
        }
    }
}
