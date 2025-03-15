using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Xunit;
using DatacomTestProject.Models;
using DatacomTestProject.Services;
using DatacomTestProject.Data.Repositories;

namespace DatacomTestProject.Tests
{
    public class ApplicationServiceTests
    {
        private readonly Mock<IApplicationRepository> _mockRepository;
        private readonly ApplicationService _applicationService;

        public ApplicationServiceTests()
        {
            _mockRepository = new Mock<IApplicationRepository>();
            _applicationService = new ApplicationService(_mockRepository.Object);
        }

        [Fact]
        public async Task GetAllApplications_ReturnsAllApplications()
        {
            // Arrange
            var applications = new List<Application>
            {
                new Application { Id = 1, CompanyName = "Company A", Position = "Developer" },
                new Application { Id = 2, CompanyName = "Company B", Position = "Designer" }
            };
            _mockRepository.Setup(repo => repo.GetAll()).ReturnsAsync(applications);

            // Act
            var result = await _applicationService.GetAllApplications();

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Equal("Company A", result.First().CompanyName);
        }

        [Fact]
        public async Task GetApplicationById_ReturnsApplication()
        {
            // Arrange
            var application = new Application { Id = 1, CompanyName = "Company A", Position = "Developer" };
            _mockRepository.Setup(repo => repo.GetById(1)).ReturnsAsync(application);

            // Act
            var result = await _applicationService.GetApplicationById(1);

            // Assert

            Assert.NotNull(result);
            Assert.Equal("Company A", result.CompanyName);
        }

        [Fact]
        public async Task CreateApplication_AddsApplication()
        {
            // Arrange
            var application = new Application { CompanyName = "Company A", Position = "Developer" };
            _mockRepository.Setup(repo => repo.Add(application)).ReturnsAsync(application);

            // Act
            var result = await _applicationService.CreateApplication(application);

            // Assert
            _mockRepository.Verify(repo => repo.Add(application), Times.Once);
            
            Assert.NotNull(result);
            Assert.Equal("Company A", result.CompanyName);
            Assert.Equal("Developer", result.Position);
        }

        [Fact]
        public async Task UpdateApplication_UpdatesStatus()
        {
            // Arrange
            var application = new Application { Id = 1, CompanyName = "Company A", Position = "Developer", Status = ApplicationStatus.Initial };
            var updatedApplication = new Application { Id = 1, CompanyName = "Company A", Position = "Developer", Status = ApplicationStatus.Interview };
            _mockRepository.Setup(repo => repo.UpdateStatus(application, ApplicationStatus.Interview)).ReturnsAsync(updatedApplication);

            // Act
            var result = await _applicationService.UpdateApplication(application, ApplicationStatus.Interview);

            // Assert
            _mockRepository.Verify(repo => repo.UpdateStatus(application, ApplicationStatus.Interview), Times.Once);

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal(ApplicationStatus.Interview, result.Status);
            Assert.Equal("Company A", result.CompanyName);
            Assert.Equal("Developer", result.Position);
        }
    }
}
