using Microsoft.AspNetCore.Mvc;
using Library_LMS_C_.Models;
using LMS.API.EC;

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
        public IEnumerable<Person> Get()
        {
            return new Person().Search();
        }

        [HttpGet("/{id}")]
        public Person? GetId(int id)
        {
            return new Person().Get(id);
        }

        [HttpDelete("Delete/{id}")]
        public Person? Delete(int id)
        {
            return new Person().Delete(id);
        }

        [HttpPost]
        public Person? AddOrUpdate([FromBody] Person person)
        {
            return new Person().AddOrUpdate(person);
        }

        [HttpPost("Search")]
        public IEnumerable<Person> Search([FromBody] QueryMessage query)
        {
            return new Person().Search(query.Query);
        }
    }
}