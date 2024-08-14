using CourseManagementSystem.Api.Controllers;
using CourseManagementSystem.Domain.Entities;
using CourseManagementSystem.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CourseManagementSystem.Tests.Controllers
{
    public class CourseControllerTests
    {
        private readonly Mock<ICourseService> _mockCourseService;
        private readonly CourseController _courseController;

        public CourseControllerTests()
        {
            _mockCourseService = new Mock<ICourseService>();
            _courseController = new CourseController(_mockCourseService.Object);
        }

        [Fact]
        public async Task GetCourseByIdAsync_ShouldReturnNotFound_WhenCourseDoesNotExist()
        {
            var courseId = Guid.NewGuid();

            _mockCourseService
                .Setup(serv => serv.GetCourseByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync((Course)null);

            var result = await _courseController.GetCourseByIdAsync(courseId);

            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal(404, notFoundResult.StatusCode);

            _mockCourseService.Verify(service => service.GetCourseByIdAsync(courseId), Times.Once);
        }

        [Fact]
        public async Task GetCourseByIdAsync_ShouldReturnOk_WhenCourseExist()
        {
            var courseId = Guid.NewGuid();

            var expectedCourse = new Course
            {
                Id = courseId,
                Name = "Sistemas de informação",
                Description = "Curso de sistemas de informação",
            };

            _mockCourseService
                .Setup(serv => serv.GetCourseByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(expectedCourse);

            var result = await _courseController.GetCourseByIdAsync(courseId);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);

            _mockCourseService.Verify(service => service.GetCourseByIdAsync(courseId), Times.Once);
        }
    }
}
