using Job_Recruitment_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Job_Recruitment_Management_System.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<CandidateProfile> CandidateProfiles { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Application> Applications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Application>()
                .HasIndex(a => new { a.CandidateProfileId, a.JobId })
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasOne(u => u.CandidateProfile)
                .WithOne(c => c.User)
                .HasForeignKey<CandidateProfile>(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Company>()
                .HasOne(c => c.Owner)
                .WithMany(u => u.Companies)
                .HasForeignKey(c => c.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Job>()
                .HasOne(j => j.Company)
                .WithMany(c => c.Jobs)
                .HasForeignKey(j => j.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Application>()
                .HasOne(a => a.CandidateProfile)
                .WithMany(c => c.Applications)
                .HasForeignKey(a => a.CandidateProfileId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Application>()
                .HasOne(a => a.Job)
                .WithMany(j => j.Applications)
                .HasForeignKey(a => a.JobId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Job>()
                .Property(j => j.Salary)
                .HasPrecision(18, 2);

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, FullName = "Ahmed Hassan", Email = "ahmed@example.com", Password = "123456", Role = "Candidate", CreatedAt = new DateTime(2026, 9, 1) },
                new User { Id = 2, FullName = "Sara Mohamed", Email = "sara@example.com", Password = "123456", Role = "Employer", CreatedAt = new DateTime(2026, 9, 2) },
                new User { Id = 3, FullName = "Omar Ali", Email = "omar@example.com", Password = "123456", Role = "Admin", CreatedAt = new DateTime(2025, 9, 3) }
            );

            modelBuilder.Entity<CandidateProfile>().HasData(
                new CandidateProfile { Id = 1, Phone = "01012345678", ResumeUrl = "example.com/resume1", Skill = "ASP.NET Core", YearsOfExperience = 3, UserId = 1 },
                new CandidateProfile { Id = 2, Phone = "01098765432", ResumeUrl = "example.com/resume2", Skill = "Java", YearsOfExperience = 2, UserId = 2 },
                new CandidateProfile { Id = 3, Phone = "01055556677", ResumeUrl = "example.com/resume3", Skill = "Python", YearsOfExperience = 1, UserId = 3 }
            );

            modelBuilder.Entity<Company>().HasData(
                new Company { Id = 1, Name = "Tech Solutions", Description = "Software development company", Website = "https://techsolutions.example.com", Location = "Cairo", OwnerId = 2 },
                new Company { Id = 2, Name = "Future Systems", Description = "IT consulting company", Website = "https://futuresystems.example.com", Location = "Giza", OwnerId = 2 },
                new Company { Id = 3, Name = "Digital Works", Description = "Digital services company", Website = "https://digitalworks.example.com", Location = "Alexandria", OwnerId = 2 }
            );

            modelBuilder.Entity<Job>().HasData(
                new Job { Id = 1, Title = "Backend Developer", Description = "Develop APIs using ASP.NET Core", Salary = 30000, Location = "Cairo", EmploymentType = "FullTime", PostedDate = new DateTime(2026, 10, 1), Deadline = new DateTime(2026, 11, 1), Status = "Open", CompanyId = 1 },
                new Job { Id = 2, Title = "Frontend Developer", Description = "Develop web interfaces", Salary = 25000, Location = "Giza", EmploymentType = "FullTime", PostedDate = new DateTime(2026, 10, 2), Deadline = new DateTime(2026, 11, 2), Status = "Open", CompanyId = 2 },
                new Job { Id = 3, Title = "Software Tester", Description = "Test software applications", Salary = 20000, Location = "Alexandria", EmploymentType = "Contract", PostedDate = new DateTime(2026, 10, 3), Deadline = new DateTime(2026, 11, 3), Status = "Open", CompanyId = 3 }
            );

            modelBuilder.Entity<Application>().HasData(
                new Application { Id = 1, ApplicationDate = new DateTime(2026, 10, 5), Status = "Pending", CoverLetter = "Interested in backend development", CandidateProfileId = 1, JobId = 1 },
                new Application { Id = 2, ApplicationDate = new DateTime(2026, 10, 6), Status = "UnderReview", CoverLetter = "Experienced in web technologies", CandidateProfileId = 2, JobId = 2 },
                new Application { Id = 3, ApplicationDate = new DateTime(2026, 10, 7), Status = "Accepted", CoverLetter = "Interested in software quality", CandidateProfileId = 3, JobId = 3 }
            );
        }
    }
}
