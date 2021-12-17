using RestWithASPNET5.Models;
using RestWithASPNET5.Repositories;
using RestWithASPNET5.Repositories.Implementations;
using System.Collections.Generic;

namespace RestWithASPNET5.Business.Implementations
{
    public class BookBusinessImplementation : IBookBusiness
    {
        private IRepository<Book> _repository;

        public BookBusinessImplementation(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public Book Create(Book book)
        {
            return _repository.Create(book);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<Book> FindAll()
        {
            return _repository.FindAll();
        }

        public Book FindById(long id)
        {
            return _repository.FindByID(id);
        }

        public Book Update(Book book)
        {
            return _repository.Update(book);
        }
    }
}
