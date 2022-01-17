using RestWithASPNET5.Data.Converter.Contract;
using RestWithASPNET5.Data.VO;
using RestWithASPNET5.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNET5.Data.Converter.Implementations
{
    public class BookConverter : IParse<BookVO, Book>, IParse<Book, BookVO>
    {
        public Book Parse(BookVO origin)
        {
            if(origin == null) return null;

            var book = new Book
            {
                Id =(long) origin.Id,
                Title = origin.Title,
                Price = origin.Price,
                LaunchDate = origin.LaunchDate
            };

            if(origin.Author != null)
            {
                book.Author.Id = origin.Author.Id;
            }
            return book;
        }

        public BookVO Parse(Book origin)
        {
            if (origin == null) return null;
            return new BookVO
            {
                Id = origin.Id,
                Title = origin.Title,
                Price = origin.Price,
                LaunchDate = origin.LaunchDate,
                Author = origin.Author == null ? null : new AuthorBookConverter().Parse(origin.Author)
            };
        }

        public List<Book> Parse(List<BookVO> origins)
        {
            if (origins == null) return null;
            List<Book> books = origins.Select(item => Parse(item)).ToList();
            return books;
        }

        public List<BookVO> Parse(List<Book> origins)
        {
            if (origins == null) return null;
            return origins.Select(item => Parse(item)).ToList();
        }
    }
}
