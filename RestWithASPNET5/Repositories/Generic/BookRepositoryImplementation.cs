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
            //var booksAuthor = _context.Books.Include(b => b.Author).Where(authors => authors.Author.Name.ToLower().Contains(author.ToLower())).ToList();
            var books = _context.Books.Include(b => b.Author).ToList();
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
            var booksTitle = _context.Books.Where(titles => titles.Title.ToLower().Contains(title.ToLower())).ToList();
            if (booksTitle != null) return booksTitle;
            return null;
        }
    }
}
