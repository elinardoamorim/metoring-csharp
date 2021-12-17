using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNET5.Business;
using RestWithASPNET5.Models;

namespace RestWithASPNET5.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BookController : ControllerBase
    {
        private IBookBusiness _bookBusiness;

        public BookController(IBookBusiness bookBusiness)
        {
            _bookBusiness = bookBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var books = _bookBusiness.FindAll();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var book = _bookBusiness.FindById(id);
            if(book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            var newBook = _bookBusiness.Create(book);
            if(newBook == null) BadRequest();
            return Ok(newBook);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Book book)
        {
            var changeBook = _bookBusiness.Update(book);
            if(changeBook == null) BadRequest();
            return Ok(changeBook);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Book book = _bookBusiness.FindById(id);
            if (book == null) return NotFound();
            _bookBusiness.Delete(id);
            return NoContent();
        }

    }
}
