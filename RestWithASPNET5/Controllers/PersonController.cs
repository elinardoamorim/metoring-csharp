using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNET5.Business;
using RestWithASPNET5.Data.VO;
using RestWithASPNET5.Hypermedia.Filters;
using System.Collections.Generic;

namespace RestWithASPNET5.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Authorize("Bearer")]
    [Route("api/v{version:ApiVersion}/persons")]
    public class PersonController : ControllerBase
    {
        private IGenericBusiness<PersonVO> _generic;
        private IPersonBusiness _personBusiness;

        public PersonController(IGenericBusiness<PersonVO> personCrudBusiness, IPersonBusiness personBusiness)
        {
            _generic = personCrudBusiness;
            _personBusiness = personBusiness;

        }

        [HttpGet]
        [TypeFilter(typeof(HyperMediaFilter))]
        [ProducesResponseType((200), Type = typeof(List<PersonVO>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public ActionResult<List<PersonVO>> Get()
        {
            var persons = _generic.FindAll();
            return Ok(persons);
        }

        [HttpGet("get-by-name")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult<List<PersonVO>> GetByName(string name)
        {
            var persons = _personBusiness.FindByName(name);
            if(persons == null) return NotFound();
            return Ok(persons);

        }

        [HttpGet("get-by-lastname")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult<List<PersonVO>> GetByLastName(string lastName)
        {
            var persons = _personBusiness.FindByLastName(lastName);
            if (persons == null) return NotFound();
            return Ok(persons);

        }
        
        [HttpGet("get-by-address")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult<List<PersonVO>> GetByAddress(string address)
        {
            var persons = _personBusiness.FindByAddress(address);
            if (persons == null) return NotFound();
            return Ok(persons);

        }
        
        [HttpGet("get-by-gender")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult<List<PersonVO>> GetByGender(string gender)
        {
            var persons = _personBusiness.FindByGender(gender);
            if (persons == null) return NotFound();
            return Ok(persons);

        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult<PersonVO> GetById(long id)
        {
            var person = _generic.FindById(id);
            if(person == null) return NotFound();
            return Ok(person);
        }

        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] PersonVO person)
        {
            var newPerson = _generic.Create(person);
            if(newPerson == null) return BadRequest();
            return Ok(newPerson);
        }

        [HttpPut]
        [TypeFilter(typeof (HyperMediaFilter))]
        public IActionResult Put([FromBody] PersonVO person)
        {
            var changePerson = _generic.Update(person);
            if(changePerson == null) return BadRequest("Invalid person"); 
            return Ok(changePerson);
        }


        /// <summary>
        /// Deleta o cadastro de uma pessoa.
        /// </summary>
        /// <response code="404">Retorna Not Found caso não tenha um usuário com a identificação informada</response>
        /// <response code="204">Retorna No Content caso a exclusão do usuário informado seja bem sucedida</response>
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            PersonVO person = _generic.FindById(id);
            if(person == null) return NotFound();
            _generic.Delete(id);
            return NoContent();
        }
    }
}