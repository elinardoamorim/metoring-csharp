using Microsoft.AspNetCore.Mvc;
using RestWithASPNET5.Business;
using RestWithASPNET5.Data.VO;

namespace RestWithASPNET5.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PersonController : ControllerBase
    {
        private IPersonBusiness _personBusiness;

        public PersonController(IPersonBusiness personBusiness)
        {
            _personBusiness = personBusiness;

        }

        [HttpGet]
        public IActionResult Get()
        {
            var persons = _personBusiness.FindAll();
            return Ok(persons);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var person = _personBusiness.FindById(id);
            if(person == null) return NotFound();
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] PersonVO person)
        {
            var newPerson = _personBusiness.Create(person);
            if(newPerson == null) return BadRequest();
            return Ok(newPerson);
        }

        [HttpPut]
        public IActionResult Put([FromBody] PersonVO person)
        {
            var changePerson = _personBusiness.Update(person);
            if(changePerson == null) return BadRequest(); 
            return Ok(changePerson);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            PersonVO person = _personBusiness.FindById(id);
            if(person == null) return NotFound();
            _personBusiness.Delete(id);
            return NoContent();
        }
    }
}