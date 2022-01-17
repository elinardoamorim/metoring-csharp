using Microsoft.AspNetCore.Mvc;
using RestWithASPNET5.Business;
using RestWithASPNET5.Data.VO;
using RestWithASPNET5.Hypermedia.Filters;
using System.Collections.Generic;

namespace RestWithASPNET5.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:ApiVersion}/authors")]
    public class AuthorController : ControllerBase
    {
        private IGenericBusiness<AuthorVO> _generic;
        private IAuthorBusiness _authorBusiness;

        public AuthorController(IGenericBusiness<AuthorVO> crudBusiness, IAuthorBusiness authorBusiness)
        {
            _generic = crudBusiness;
            _authorBusiness = authorBusiness;
        }

        [HttpGet]
        public ActionResult<List<AuthorVO>> GetAll()
        {
            var authors = _authorBusiness.FindAll();
            return Ok(authors);
        }

        [HttpGet("get-by-name")]
        public ActionResult<List<AuthorVO>> GetByFullName(string nameFull)
        {
            var authors = _authorBusiness.FindByFullName(nameFull);
            if (authors == null) return NotFound("Invalid name");
            return Ok(authors);
        }

        [HttpGet("get-by-cpf")]
        public IActionResult GetByCPF(string cpf)
        {
            var author = _authorBusiness.FindByCPF(cpf);
            if (author == null) return NotFound("Invalid CPF");
            return Ok(author);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var author = _authorBusiness.FindById(id);
            if (author == null) return NotFound("Invalid id");
            return Ok(author);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AuthorVO author)
        {
            var newAuthor = _generic.Create(author);
            if (newAuthor == null) return BadRequest();
            return Ok(newAuthor);
        }
        
        [HttpPut]
        public IActionResult Put([FromBody] AuthorVO author)
        {
            var changeAuthor =  _generic.Update(author);
            if(changeAuthor == null) return BadRequest();
            return Ok(changeAuthor);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            AuthorVO author = _generic.FindById(id);
            if (author == null) return NotFound("Invalid id");
            _generic.Delete(id);
            return NoContent();
        }
    }
}
