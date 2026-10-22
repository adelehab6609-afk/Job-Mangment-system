using Job_Recruitment_Management_System.DTOS;
using Job_Recruitment_Management_System.Repo.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Job_Recruitment_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompaniesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]

        public async Task<ActionResult> GetAllCompanies()
        {
            var r = await _unitOfWork.company.GetallCompanies();
            if(r == null) return NotFound();

            var yasso = r.Select(x => new companyDtoGet
            {
                Id = x.Id,
                Name = x.Name,
                Website = x.Website,
                Description = x.Description,
                Location = x.Location,
               jobcount = x.Jobs.Count(),
            }).ToList();

            return Ok(yasso);
        }
    }
}
