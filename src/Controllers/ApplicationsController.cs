using Microsoft.AspNetCore.Mvc;
using DatacomTestProject.Models;
using DatacomTestProject.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatacomTestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly ApplicationService _applicationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationsController"/> class.
        /// </summary>
        /// <param name="applicationService">The application service.</param>
        public ApplicationsController(ApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        /// <summary>
        /// Gets all applications.
        /// </summary>
        /// <returns>A list of all applications.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Application>>> GetAllApplications()
        {
            var applications = await _applicationService.GetAllApplications();
            return Ok(applications);
        }

        /// <summary>
        /// Gets an application by its ID.
        /// </summary>
        /// <param name="id">The ID of the application.</param>
        /// <returns>The application with the specified ID, or NotFound if not found.</returns>
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

        /// <summary>
        /// Creates a new application.
        /// </summary>
        /// <param name="application">The application to create.</param>
        /// <returns>The created application.</returns>
        [HttpPost]
        public async Task<ActionResult<Application>> CreateApplication(Application application)
        {
            if (application == null)
            {
                return BadRequest();
            }
            else if (string.IsNullOrEmpty(application.CompanyName) || string.IsNullOrEmpty(application.Position))
            {
                return BadRequest("Company name and position are required.");
            }
            else if (application.DateApplied > DateTime.Now)
            {
                return BadRequest("Applied Date cannot be after today.");
            }

            await _applicationService.CreateApplication(application);
            return CreatedAtAction(nameof(GetApplicationById), new { id = application.Id }, application);
        }

        /// <summary>
        /// Updates the status of an application.
        /// </summary>
        /// <param name="id">The ID of the application.</param>
        /// <param name="payload">The payload containing the new status.</param>
        /// <returns>The updated application.</returns>
        [HttpPut("{id}/Status")]
        public async Task<ActionResult<Application>> UpdateStatus(int id, [FromBody] UpdateApplicationStatusDto payload)
        {
            var status = (ApplicationStatus)payload.status;
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