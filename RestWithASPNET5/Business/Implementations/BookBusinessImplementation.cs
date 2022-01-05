using RestWithASPNET5.Data.Converter.Implementations;
using RestWithASPNET5.Data.VO;
using RestWithASPNET5.Models;
using RestWithASPNET5.Repositories;
using RestWithASPNET5.Repositories.Generic;
using System;
using System.Collections.Generic;

namespace RestWithASPNET5.Business.Implementations
{
    public class BookBusinessImplementation : IGenericBusiness<BookVO>, IBookBusiness
    {
        private IRepository<Book> _repository;
        private IBookRepository _bookRepository;
        private readonly BookConverter _converter;

        public BookBusinessImplementation(IRepository<Book> repository, IBookRepository bookRepository)
        {
            _repository = repository;
            _bookRepository = bookRepository;
            _converter = new BookConverter();
        }

        public BookVO Create(BookVO book)
        {
            Book bookEntity = _converter.Parse(book);
            bookEntity = _repository.Create(bookEntity);
            return _converter.Parse(bookEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<BookVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public BookVO FindById(long id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }

        public BookVO Update(BookVO book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _repository.Update(bookEntity);
            return _converter.Parse(bookEntity);
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
