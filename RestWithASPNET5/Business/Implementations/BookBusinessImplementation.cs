using RestWithASPNET5.Data.Converter.Implementations;
using RestWithASPNET5.Data.VO;
using RestWithASPNET5.Models;
using RestWithASPNET5.Repositories;
using RestWithASPNET5.Repositories.Generic;
using System;
using System.Collections.Generic;

namespace RestWithASPNET5.Business.Implementations
{
    public class BookBusinessImplementation : IBookBusiness
    {
        private readonly IRepository<Book> _repository;
        private readonly IBookRepository _bookRepository;
        private readonly BookConverter _converter;
        private readonly BookResumeConverter _bookResumeConverter;

        public BookBusinessImplementation(IRepository<Book> repository, IBookRepository bookRepository)
        {
            _repository = repository;
            _bookRepository = bookRepository;
            _converter = new BookConverter();
            _bookResumeConverter = new BookResumeConverter();
        }

        public BookVO Create(BookResumeVO book)
        {
            Book bookEntity = _bookResumeConverter.Parse(book);
            bookEntity = _bookRepository.Create(bookEntity); 
            return _converter.Parse(bookEntity);
        }

        public BookVO Update(long id, BookResumeVO book)
        {
            var bookEntity = _bookResumeConverter.Parse(book);
            bookEntity = _bookRepository.Update(id, bookEntity);
            return _converter.Parse(bookEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<BookVO> FindAll()
        {
            return _converter.Parse(_bookRepository.FindAll());
        }

        public BookVO FindById(long id)
        {
            return _converter.Parse(_bookRepository.FindById(id));
        }

        public List<BookVO> FindByTitle(string title)
        {
            return _converter.Parse(_bookRepository.FindByTitle(title));
        }

        public List<BookVO> FindByAuthor(string author)
        {
            return _converter.Parse(_bookRepository.FindByAuthor(author));
        }

        public List<BookVO> FindByLaunchDate(DateTime dateTime)
        {
            return _converter.Parse(_bookRepository.FindByLaunchDate(dateTime));
        }

        public List<BookVO> FindByPrice(decimal price)
        {
            return _converter.Parse(_bookRepository.FindByPrice(price));
        }
    }
}
