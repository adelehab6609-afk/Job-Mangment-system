using System.ComponentModel.DataAnnotations;

namespace Job_Recruitment_Management_System.DTOS
{
    public class companyDto
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
    }

    public class companyDtoGet
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

        public int jobcount { get; set; }    
    }
}
