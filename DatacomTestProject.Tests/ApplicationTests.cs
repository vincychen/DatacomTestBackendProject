using Xunit;
using DatacomTestProject.Models;

namespace DatacomTestProject.Tests
{
    public class ApplicationTests
    {
        [Fact]
        public void CanCreateApplication()
        {
            // Arrange
            var application = new Application
            {
                CompanyName = "Test Company",
                Position = "Developer",
            };

            // Act & Assert
            Assert.Equal(0, application.Id);
            Assert.Equal("Test Company", application.CompanyName);
            Assert.Equal("Developer", application.Position);
            Assert.Equal(ApplicationStatus.Initial, application.Status);
            Assert.Equal(DateTime.Now.Date, application.DateApplied.Date);
        }

        
    }
}