using Job_Recruitment_Management_System.DTOS;
using Job_Recruitment_Management_System.Repo.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Job_Recruitment_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;

        public ApplicationController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        [HttpGet]
        [Authorize(Roles = "Candidate")]
        public async Task<IActionResult> GetMyApplications()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var applications = await _unitofwork.application.GetByUserIdAsync(userId);

            var result = applications.Select(a => new ApplicationDto
            {
                Id = a.Id,
                ApplicationDate = a.ApplicationDate,
                Status = a.Status,
                CoverLetter = a.CoverLetter,
                JobId = a.JobId
            }).ToList();

            return Ok(result);
        }
    }
}
