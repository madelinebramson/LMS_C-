using Library_LMS_C_.Models;
using LMS.API.EC;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ILogger<CourseController> _logger;

        public CourseController(ILogger<CourseController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<Course> Get()
        {
            return new CourseEC().Courses;
        }

        [HttpGet("Course/{id}")]
        public Course? GetId(int id)
        {
            return new CourseEC().GetById(id);
        }

        [HttpDelete("DeleteCourse/{id}")]
        public Course? Delete([FromBody] Course course)
        {
            return new CourseEC().Delete(course);
        }

        [HttpPost("AddOrUpdateCourse")]
        public Course? AddOrUpdate([FromBody] Course course)
        {
            return new CourseEC().Add(course);
        }

        [HttpPost("{id}/AddStudent")]
        public Course? AddStudent([FromBody] Course course, [FromQuery] Student student)
        {
            return new CourseEC().AddStudent(student, course);
        }

    }
}
