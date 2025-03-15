using Microsoft.AspNetCore.Mvc;
using DatacomTestProject.Models;
using DatacomTestProject.Services;

namespace DatacomTestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly ApplicationService _applicationService;

        public ApplicationsController(ApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Application>>> GetAllApplications()
        {
            var applications = await _applicationService.GetAllApplications();
            return Ok(applications);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Application>> GetApplicationById(int id)
        {
            var application = await _applicationService.GetApplicationById(id);
            if (application == null)
            {
                return NotFound();
            }
            return Ok(application);
        }

        [HttpPost]
        public async Task<ActionResult<Application>> CreateApplication(Application application)
        {
            if (application == null)
            {
                return BadRequest();
            } else if (string.IsNullOrEmpty(application.CompanyName) || string.IsNullOrEmpty(application.Position))
            {
                return BadRequest("Company name and position are required.");
            }
    
            await _applicationService.CreateApplication(application);
            return CreatedAtAction(nameof(GetApplicationById), new { 
                id = application.Id }, application);
        }

        [HttpPut("{id}/Status")]
        public async Task<ActionResult<Application>> UpdateStatus(int id, [FromBody] ApplicationStatus status)
        {

            if (!Enum.IsDefined(typeof(ApplicationStatus), status))
            {
                return BadRequest("Invalid status.");
            }

            if (status == ApplicationStatus.Initial)
            {
                return BadRequest("Cannot set status to Initial.");
            }

            if (id <= 0) 
            {
                return BadRequest("Invalid id.");
            }

            var application = await _applicationService.GetApplicationById(id);
            if (application == null)
            {
                return BadRequest("Application not found.");
            }


            application = await _applicationService.UpdateApplication(application, status);

            return Ok(application);
        }
    }
}