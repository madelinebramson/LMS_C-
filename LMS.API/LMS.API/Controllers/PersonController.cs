using Microsoft.AspNetCore.Mvc;
using LMS.API.EC;
using LMS.API.Database;
using Library_LMS_C_.Models;

namespace PP.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<Student> Get()
        {
            return new PersonEC().Students;
        }

        [HttpGet("Student/{id}")]
        public Person? GetId(int id)
        {
            return new PersonEC().GetById(id);
        }

        [HttpDelete("DeleteStudent/{id}")]
        public Person? Delete(int id)
        {
            return new PersonEC().Remove(id);
        }

        [HttpPost("AddOrUpdateStudent")]
        public Person? AddOrUpdate([FromBody] Student student)
        {
            return new PersonEC().Add(student);
        }

    }
}