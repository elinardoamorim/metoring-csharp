using RestWithASPNET5.Data.Converter.Contract;
using RestWithASPNET5.Data.VO;
using RestWithASPNET5.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNET5.Data.Converter.Implementations
{
    public class BookResumeConverter : IParse<BookResumeVO, Book>, IParse<Book, BookResumeVO>
    {
        public Book Parse(BookResumeVO origin)
        {
            if(origin == null) return null;
            return new Book
            {
                Title = origin.Title,
                Price = origin.Price,
                LaunchDate = origin.LaunchDate,
                AuthorId = origin.Author == null ? null : origin.Author.Id
            };
        }

        public List<Book> Parse(List<BookResumeVO> origins)
        {
            return origins.Select(item => Parse(item)).ToList();
        }

        public BookResumeVO Parse(Book origin)
        {
            if(origin == null) return null;
            return new BookResumeVO
            {
                Title = origin.Title,
                Price = origin.Price,
                LaunchDate = origin.LaunchDate,
                Author = origin.AuthorId == null ? null : new BaseIdVO { Id = origin.Author.Id }
            };
        }

        public List<BookResumeVO> Parse(List<Book> origins)
        {
            return origins.Select(item => Parse(item)).ToList();
        }
    }
}
