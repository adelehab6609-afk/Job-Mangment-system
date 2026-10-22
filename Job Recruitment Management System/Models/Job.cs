using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Job_Recruitment_Management_System.Models
{
    public class Job 
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Title { get; set; } 

        [Required]
        public string Description { get; set; } 

        [Required]
        public string Location { get; set; } 

        [Required, Range(0, 1000000)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Salary { get; set; }

        [Required]
        [AllowedValues(("Internship"),("Contract"),("PartTime"),("FullTime"))]
        public string EmploymentType { get; set; } 

        [Required]
        public DateTime PostedDate { get; set; }

        [Required]
        public DateTime Deadline { get; set; }

        [Required]
        [RegularExpression("^(Open|Closed)$", ErrorMessage = "Status must be Open or Closed")]
        public string Status { get; set; } = string.Empty;

        // FK
        [ForeignKey(nameof(Company))]
        public int CompanyId { get; set; }
        public Company? Company { get; set; }

        public ICollection<Application> Applications { get; set; } = new List<Application>();
    }
}
