using System.ComponentModel.DataAnnotations;

namespace Job_Recruitment_Management_System.DTOS.User
{
    public class UserDTO
    {
        

        [Required, StringLength(100, MinimumLength = 3)]
        public string FullName { get; set; } 

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [AllowedValues(("Candidate"), ("Employer"), ("Admin"))]
        public string Role { get; set; } 

        [Required]
        public DateTime CreatedAt { get; set; }
    }

    public class LoginDTO
    {
        [Required, EmailAddress]
        public string Email { get; set; } 

        [Required]
        public string Password { get; set; }
    }

    public class RegisterDTO
    {
        [Required, StringLength(100, MinimumLength = 3)]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [AllowedValues(("Candidate"), ("Employer"))]
        public string Role { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
