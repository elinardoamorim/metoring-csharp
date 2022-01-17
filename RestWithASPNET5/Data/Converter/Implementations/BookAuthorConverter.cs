using RestWithASPNET5.Data.Converter.Contract;
using RestWithASPNET5.Data.VO;
using RestWithASPNET5.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNET5.Data.Converter.Implementations
{
    public class BookAuthorConverter : IParse<BookAuthorVO, Book>, IParse<Book, BookAuthorVO>
    {
        public Book Parse(BookAuthorVO origin)
        {
            if (origin == null) return null;
            return new Book
            {
                Id = origin.Id
            };
        }

        public List<Book> Parse(List<BookAuthorVO> origins)
        {
            if (origins == null) return null;
            return origins.Select(item => Parse(item)).ToList();
        }

        public BookAuthorVO Parse(Book origin)
        {
            if (origin == null) return null;
            return new BookAuthorVO
            {
                Id = origin.Id,
                Title = origin.Title,
                Price = origin.Price,
                LaunchDate = origin.LaunchDate
            };
        }

        public List<BookAuthorVO> Parse(List<Book> origins)
        {
            if (origins == null) return null;
            return origins.Select(item => Parse(item)).ToList();
        }
    }
}
