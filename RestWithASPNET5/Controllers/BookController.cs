using Microsoft.AspNetCore.Mvc;
using RestWithASPNET5.Business;
using RestWithASPNET5.Data.VO;
using RestWithASPNET5.Hypermedia.Filters;
using System;
using System.Collections.Generic;

namespace RestWithASPNET5.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/books")]
    public class BookController : ControllerBase
    {
        private IGenericBusiness<BookVO> _crudBusiness;
        private IBookBusiness _bookBusiness;

        public BookController(IGenericBusiness<BookVO> crudBusiness, IBookBusiness bookBusiness)
        {
            _crudBusiness = crudBusiness;
            _bookBusiness = bookBusiness;
        }

        [HttpGet]
        [TypeFilter(typeof(HyperMediaFilter))]
        [ProducesResponseType((200), Type = typeof(List<BookVO>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public ActionResult<List<BookVO>> Get()
        {
            var books = _crudBusiness.FindAll();
            return Ok(books);
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult<BookVO> GetById(long id)
        {
            var book = _crudBusiness.FindById(id);
            if(book == null) return NotFound();
            return Ok(book);
        }

        [HttpGet("get-by-date")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult<BookVO> GetByDateLaunchDate(DateTime dateTime)
        {
            var book = _bookBusiness.FindByLaunchDate(dateTime);
            if (book == null) return NotFound();
            return Ok(book);
        }
        
        [HttpGet("get-by-title")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult<BookVO> GetByDateTitle(string title)
        {
            var book = _bookBusiness.FindByTitle(title);
            if (book == null) return NotFound();
            return Ok(book);
        }
        
        [HttpGet("get-by-author")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult<BookVO> GetByDateAuthor(string author)
        {
            var book = _bookBusiness.FindByAuthor(author);
            if (book == null) return NotFound();
            return Ok(book);
        }
        
        [HttpGet("get-by-price")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult<BookVO> GetByDatePrice(decimal price)
        {
            var book = _bookBusiness.FindByPrice(price);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] BookVO book)
        {
            var newBook = _crudBusiness.Create(book);
            if(newBook == null) BadRequest();
            return Ok(newBook);
        }

        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] BookVO book)
        {
            var changeBook = _crudBusiness.Update(book);
            if(changeBook == null) BadRequest();
            return Ok(changeBook);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            BookVO book = _crudBusiness.FindById(id);
            if (book == null) return NotFound();
            _crudBusiness.Delete(id);
            return NoContent();
        }

    }
}
