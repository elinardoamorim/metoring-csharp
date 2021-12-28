using Microsoft.AspNetCore.Mvc;
using RestWithASPNET5.Business;
using RestWithASPNET5.Data.VO;
using RestWithASPNET5.Hypermedia.Filters;
using System.Collections.Generic;

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
        [TypeFilter(typeof(HyperMediaFilter))]
        [ProducesResponseType((200), Type = typeof(List<PersonVO>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public ActionResult<List<PersonVO>> Get()
        {
            var persons = _personBusiness.FindAll();
            return Ok(persons);
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult<PersonVO> GetById(long id)
        {
            var person = _personBusiness.FindById(id);
            if(person == null) return NotFound();
            return Ok(person);
        }

        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] PersonVO person)
        {
            var newPerson = _personBusiness.Create(person);
            if(newPerson == null) return BadRequest();
            return Ok(newPerson);
        }

        [HttpPut]
        [TypeFilter(typeof (HyperMediaFilter))]
        public IActionResult Put([FromBody] PersonVO person)
        {
            var changePerson = _personBusiness.Update(person);
            if(changePerson == null) return BadRequest(); 
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
            PersonVO person = _personBusiness.FindById(id);
            if(person == null) return NotFound();
            _personBusiness.Delete(id);
            return NoContent();
        }
    }
}