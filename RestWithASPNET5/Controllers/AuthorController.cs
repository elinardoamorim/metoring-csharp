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
        private IGenericBusiness<AuthorVO> _crudBusiness;
        private IAuthorBusiness _authorBusiness;

        public AuthorController(IGenericBusiness<AuthorVO> crudBusiness, IAuthorBusiness authorBusiness)
        {
            _crudBusiness = crudBusiness;
            _authorBusiness = authorBusiness;
        }

        [HttpGet]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult<List<AuthorVO>> Get()
        {
            var authors = _crudBusiness.FindAll();
            return Ok(authors);
        }

        [HttpGet("get-by-name")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult<List<AuthorVO>> GetByFullName(string nameFull)
        {
            var authors = _authorBusiness.FindByFullName(nameFull);
            if (authors == null) return NotFound("Invalid name");
            return Ok(authors);
        }

        [HttpGet("get-by-cpf")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult GetByCPF(string cpf)
        {
            var author = _authorBusiness.FindByCPF(cpf);
            if (author == null) return NotFound("Invalid CPF");
            return Ok(author);
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult GetById(long id)
        {
            var author = _crudBusiness.FindById(id);
            if (author == null) return NotFound("Invalid id");
            return Ok(author);
        }

        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] AuthorVO author)
        {
            var newAuthor = _crudBusiness.Create(author);
            if (newAuthor == null) return BadRequest();
            return Ok(newAuthor);
        }
        
        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] AuthorVO author)
        {
            var changeAuthor =  _crudBusiness.Update(author);
            if(changeAuthor == null) return BadRequest();
            return Ok(changeAuthor);
        }

        [HttpDelete("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Delete(long id)
        {
            AuthorVO author = _crudBusiness.FindById(id);
            if (author == null) return NotFound("Invalid id");
            _crudBusiness.Delete(id);
            return NoContent();
        }
    }
}
