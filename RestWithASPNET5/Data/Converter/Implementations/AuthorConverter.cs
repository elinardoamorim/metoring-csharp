using RestWithASPNET5.Data.Converter.Contract;
using RestWithASPNET5.Data.VO;
using RestWithASPNET5.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNET5.Data.Converter.Implementations
{
    public class AuthorConverter : IParse<AuthorVO, Author>, IParse<Author, AuthorVO>
    {
        public Author Parse(AuthorVO origin)
        {
            if (origin == null) return null;
            return new Author
            {
                Id = origin.Id,
                CPF = origin.CPF,
                Name = origin.Name,
                LastName = origin.LastName,
                Books = new BookAuthorConverter().Parse(origin.Books)
            };
        }

        public List<Author> Parse(List<AuthorVO> origins)
        {
            if (origins == null) return null;
            return origins.Select(item => Parse(item)).ToList();
        }

        public AuthorVO Parse(Author origin)
        {
            if(origin == null) return null;
            return new AuthorVO
            {
                Id = origin.Id,
                CPF = origin.CPF,
                Name = origin.Name,
                LastName = origin.LastName,
                Books = new BookAuthorConverter().Parse(origin.Books)
            };
        }

        public List<AuthorVO> Parse(List<Author> origins)
        {
            if(origins == null) return null;
            return origins.Select(item => Parse(item)).ToList();
        }
    }
}
