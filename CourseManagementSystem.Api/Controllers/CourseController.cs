using CourseManagementSystem.Api.Entities;
using CourseManagementSystem.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CourseManagementSystem.Api.Controllers
{
    [ApiController]
    [Route("api/courses")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        [Route("{id}", Name = "GetCourseById")]
        public async Task<IActionResult> GetCourseByIdAsync(Guid id)
        {
            try
            {
                var result = await _courseService.GetCourseByIdAsync(id);
                if (result == null)
                {
                    return NotFound(new { Message = "Course not found" });
                }
                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostCourseAsync(Course course)
        {
            try
            {
                var result = await _courseService.PostCourseAsync(course);
                if (result != null)
                {
                    return StatusCode((int)HttpStatusCode.Created, result);
                }
                else
                {
                    return BadRequest("Course creation failed.");
                }
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
