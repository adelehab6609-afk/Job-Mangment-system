namespace Job_Recruitment_Management_System.DTOS
{
    public class ApplicationDto
    {
        public int Id { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? CoverLetter { get; set; }
        public int JobId { get; set; }
    }
}
