using System.ComponentModel.DataAnnotations;

namespace Job_Recruitment_Management_System.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100, MinimumLength = 3)]
        public string FullName { get; set; } 

        [Required, EmailAddress]
        public string Email { get; set; } 

        [Required]
        public string Password { get; set; }

        [Required]
        [AllowedValues(("Candidate"),("Employer"),("Admin"))]
        public string Role { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        // 1:1 with CandidateProfile
        public CandidateProfile? CandidateProfile { get; set; }

        // 1:M with Company (Employer owns companies)
        public ICollection<Company> Companies { get; set; } = new List<Company>();
    }
}
