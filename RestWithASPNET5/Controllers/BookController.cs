using Microsoft.AspNetCore.Mvc;
using RestWithASPNET5.Business;
using RestWithASPNET5.Data.VO;

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
        public IActionResult Post([FromBody] BookVO book)
        {
            var newBook = _bookBusiness.Create(book);
            if(newBook == null) BadRequest();
            return Ok(newBook);
        }

        [HttpPut]
        public IActionResult Put([FromBody] BookVO book)
        {
            var changeBook = _bookBusiness.Update(book);
            if(changeBook == null) BadRequest();
            return Ok(changeBook);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            BookVO book = _bookBusiness.FindById(id);
            if (book == null) return NotFound();
            _bookBusiness.Delete(id);
            return NoContent();
        }

    }
}
