using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Job_Recruitment_Management_System.Models
{
    public class CandidateProfile
    {
        [Key]
        public int Id { get; set; }

        [Required, Phone]
        public string Phone { get; set; } 

        public string? ResumeUrl { get; set; }

        [Required, MaxLength(500)]
        public string Skill { get; set; } 

        [Range(0, 50)]
        public int YearsOfExperience { get; set; }

        // FK (1:1 with User)
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User? User { get; set; }

        public ICollection<Application> Applications { get; set; } = new List<Application>();

    }
}
