    using Job_Recruitment_Management_System.Data;
    using Job_Recruitment_Management_System.DTOS.User;
    using Job_Recruitment_Management_System.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;

    namespace Job_Recruitment_Management_System.Services
    {
        public class TokenServices : ITokenServices
        {
            private readonly AppDbContext _context;
            private readonly IConfiguration _configuration;
            public TokenServices(AppDbContext context, IConfiguration configuration)
            {
                _configuration = configuration;
                _context = context;
            }

            public async Task<string> GetToken(User user)
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var claimssss = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier , user.Id.ToString()),
                    new Claim(ClaimTypes.Role , user.Role),
                    new Claim(ClaimTypes.Email , user.Email),
                };
                var token = new JwtSecurityToken(
                    claims: claimssss,
                    issuer: _configuration["JWT:Issuer"],
                    audience: _configuration["JWT:Audience"],
                    signingCredentials: creds,
                    expires: DateTime.Now.AddHours(2)
                );
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            public Task<string> Login(LoginDTO loginDTO)
            {
                var a = _context.Users.FirstOrDefault(a => a.Email == loginDTO.Email && a.Password == loginDTO.Password);
                if (a == null)
                {
                    return null;
                }
                var m = GetToken(a);
                return (m);
            }

       
    }
}
