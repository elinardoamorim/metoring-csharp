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
            return new Book
            {
                Id = origin.Id,
                Title = origin.Title,
                Author = new AuthorConverter().Parse(origin.Author),
                Price = origin.Price,
                LaunchDate = origin.LaunchDate
            };
        }

        public BookVO Parse(Book origin)
        {
            if (origin == null) return null;
            return new BookVO
            {
                Id = origin.Id,
                Title = origin.Title,
                Author = new AuthorConverter().Parse(origin.Author),
                Price = origin.Price,
                LaunchDate = origin.LaunchDate
            };
        }

        public List<Book> Parse(List<BookVO> origins)
        {
            if (origins == null) return null;
            return origins.Select(item => Parse(item)).ToList();
        }

        public List<BookVO> Parse(List<Book> origins)
        {
            if (origins == null) return null;
            return origins.Select(item => Parse(item)).ToList();
        }
    }
}
