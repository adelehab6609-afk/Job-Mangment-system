using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Job_Recruitment_Management_System.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Name { get; set; } 

        [Required, MaxLength(1000)]
        public string Description { get; set; } 

        public string? Website { get; set; }

        [Required]
        public string Location { get; set; } 

        // FK (each company has one owner)
        [ForeignKey(nameof(Owner))]
        public int OwnerId { get; set; }
        public User? Owner { get; set; }

        public ICollection<Job> Jobs { get; set; } = new List<Job>();

    }
}