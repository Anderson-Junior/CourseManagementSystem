using CourseManagementSystem.Api.Entities;
using CourseManagementSystem.Api.Repositories.Interfaces;
using CourseManagementSystem.Api.Services;
using Moq;

namespace CourseManagementSystem.Tests.Services
{
    public class CourseServiceTests
    {
        private readonly Mock<ICourseRepository> _mockCourseRepository;
        private readonly CourseService _courseService;

        public CourseServiceTests()
        {
            _mockCourseRepository = new Mock<ICourseRepository>();
            _courseService = new CourseService(_mockCourseRepository.Object);
        }

        [Fact]
        public async Task PostCourseAsync_ShouldReturnCourse_WhenInputIsValid()
        {
            var courseInput = new Course
            {
                Id = Guid.NewGuid(),
                Name = "Sistemas de informação",
                Description = "Curso de sistemas de informação",
            };

            var expectedCourse = courseInput;

            _mockCourseRepository
                .Setup(repo => repo.PostCourseAsync(It.IsAny<Course>()))
                .ReturnsAsync(expectedCourse);

            var result = await _courseService.PostCourseAsync(courseInput);

            Assert.NotNull(result);
            Assert.Equal(expectedCourse, result);

            _mockCourseRepository.Verify(repo => repo.PostCourseAsync(courseInput), Times.Once());
        }

        [Fact]
        public async Task GetCourseByIdAsync_ShouldReturnCurso_WhenInputIsValid()
        {
            var courseId = Guid.NewGuid();

            var expectedCourse = new Course
            {
                Id = courseId,
                Name = "Sistemas de informação",
                Description = "Curso de sistemas de informação",
            };

            _mockCourseRepository
                .Setup(repo => repo.GetCourseByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(expectedCourse);

            var result = await _courseService.GetCourseByIdAsync(courseId);

            Assert.NotNull(result);
            Assert.Equal(expectedCourse.Id, result.Id);
            Assert.Equal(expectedCourse.Name, result.Name);
            Assert.Equal(expectedCourse.Description, result.Description);
        }
    }
}
