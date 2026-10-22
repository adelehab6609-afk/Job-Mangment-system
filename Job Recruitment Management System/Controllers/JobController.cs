using Job_Recruitment_Management_System.DTOS;
using Job_Recruitment_Management_System.Repo.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Job_Recruitment_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public JobController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]

        public async Task<ActionResult> GetAllSalary()
        {
                var r = await _unitOfWork.job.GetSalary();
                if(r == null)
                {
                return BadRequest("Not found");
                }

            var yasso = new JobDto
            {
                Id = r.Id,
                Title = r.Title,
                Location = r.Location,
                Description = r.Description,
                Deadline = r.Deadline,
                EmploymentType = r.EmploymentType,
                PostedDate = r.PostedDate,
                Salary = r.Salary,
                CompanyId = r.CompanyId,
                Status = r.Status,
            };

            return Ok(yasso);
        }

        [HttpGet("GetOneJob")]

        public async Task<ActionResult> GetOneJob(int id)
        {
            var r = await _unitOfWork.job.GetJob(id);
            if(r == null)
            {
                return NotFound();
            }

            var yasso = new JobDtocompany
            {
                Id = r.Id,
                Title = r.Title,
                Location = r.Location,
                Description = r.Description,
                Deadline = r.Deadline,
                EmploymentType = r.EmploymentType,
                PostedDate = r.PostedDate,
                Salary = r.Salary,
                CompanyId = r.CompanyId,
                Status = r.Status,
                company = new companyDto
                {
                    Id =r.Company.Id,
                    Name = r.Company.Name,
                    Description = r.Company.Description,
                    Location = r.Company.Location,
                    Website = r.Company.Website
                }
            };
            return Ok(yasso);


        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteJob(int id)
        {
            var r = await _unitOfWork.job.GetByIdAsync(id);
            if (r == null)  NotFound();

            await _unitOfWork.job.DeleteAsync(r);
            await _unitOfWork.SaveAsync();

            return Ok("Deleted");
        }
        [HttpGet("Search")]
        public async Task<ActionResult> Search(string word)
        {
            var r = await _unitOfWork.job.Search(word);
            if(r.IsNullOrEmpty()) 
                return BadRequest("كسمك");

            var yasso = r.Select(x=> new JobDto
            {
                Id=x.Id,
                Title = x.Title,
                Description = x.Description,
                
            }).ToList();

            return Ok(yasso);
        }

    }
}
