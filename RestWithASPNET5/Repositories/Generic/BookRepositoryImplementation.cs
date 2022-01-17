using RestWithASPNET5.Models.Context;
using RestWithASPNET5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RestWithASPNET5.Repositories.Implementations
{
    public class BookRepositoryImplementation : IBookRepository
    {
        private SqlServerContext _context;

        public BookRepositoryImplementation(SqlServerContext context)
        {
            _context = context;
        }

        public List<Book> FindByAuthor(string author)
        {
            var books = _context.Books.Include(b => b.Author).Where(authors => authors.Author.Name.ToLower().Contains(author.ToLower())).ToList();
            if (books == null) return null;
            return books;
        }

        public List<Book> FindByLaunchDate(DateTime dateTime)
        {
            var booksDateTime = _context.Books.Where(date => date.LaunchDate.Equals(dateTime)).ToList();
            if (booksDateTime != null) return booksDateTime;
            return null;
        }

        public List<Book> FindByPrice(decimal price)
        {
            var booksPrice = _context.Books.Where(prices => prices.Price.Equals(price)).ToList();
            if (booksPrice != null) return booksPrice;
            return null;
        }

        public List<Book> FindByTitle(string title)
        {
            var books = _context.Books.Include(a => a.Author).Where(titles => titles.Title.ToLower().Contains(title.ToLower())).ToList();
            if (books == null) return null;
            return books;
        }

        public Book FindById(long id)
        {
            var book = _context.Books.Include(a => a.Author).Where(b => b.Id.Equals(id)).FirstOrDefault();
            if(book == null) return null;
            return book;
        }

        public List<Book> FindAll()
        {
            var books = _context.Books.Include(a => a.Author).ToList();
            if(books == null) return null;
            return books;
        }

        public Book Create(Book book)
        {
            try
            {
                _context.Books.Add(book);
                _context.SaveChanges();
            } 
            catch(Exception)
            {
                throw;
            }
            return FindById(book.Id);
        }

        public Book Update(long id, Book book)
        {
            var result = _context.Books.Include(a => a.Author).SingleOrDefault(p => p.Id.Equals(id));
            book.Id = id;
            if(result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(book);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }

            }
            return result;
        }

    }
}
