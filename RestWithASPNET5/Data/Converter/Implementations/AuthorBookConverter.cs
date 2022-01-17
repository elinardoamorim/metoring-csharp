using RestWithASPNET5.Data.Converter.Contract;
using RestWithASPNET5.Data.VO;
using RestWithASPNET5.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNET5.Data.Converter.Implementations
{
    public class AuthorBookConverter : IParse<AuthorBookVO, Author>, IParse<Author, AuthorBookVO>
    {
        public Author Parse(AuthorBookVO origin)
        {
            return new Author
            {
                Id = origin.Id,
                Name = origin.Name,
                CPF = origin.Cpf
            };
        }

        public List<Author> Parse(List<AuthorBookVO> origins)
        {
            return origins.Select(item => Parse(item)).ToList();
        }

        public AuthorBookVO Parse(Author origin)
        {
            return new AuthorBookVO
            {
                Id = origin.Id,
                Name = origin.Name,
                Cpf = origin.CPF
            };
        }

        public List<AuthorBookVO> Parse(List<Author> origins)
        {
            return origins.Select(item => Parse(item)).ToList();
        }
    }
}
