using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Job_Recruitment_Management_System.Models
{
    public class Application
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime ApplicationDate { get; set; }

        [Required]
        [AllowedValues(("Pending"),("UnderReview"),("Accepted"),("Rejected"))]
        public string Status { get; set; }

        [MaxLength(2000)]
        public string? CoverLetter { get; set; }

        // FKs
        [ForeignKey(nameof(CandidateProfile))]
        public int CandidateProfileId { get; set; }
        public CandidateProfile? CandidateProfile { get; set; }

        [ForeignKey(nameof(Job))]
        public int JobId { get; set; }
        public Job? Job { get; set; }

    }
}
