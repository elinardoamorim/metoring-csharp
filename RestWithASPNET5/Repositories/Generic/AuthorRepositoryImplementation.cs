using Microsoft.EntityFrameworkCore;
using RestWithASPNET5.Models;
using RestWithASPNET5.Models.Context;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNET5.Repositories.Generic
{
    public class AuthorRepositoryImplementation : IAuthorRepository
    {
        private SqlServerContext _context;

        public AuthorRepositoryImplementation(SqlServerContext context)
        {
            _context = context;
        }

        public Author FindByCPF(string cpf)
        {
            var author = _context.Authors.SingleOrDefault(a => a.CPF.Equals(cpf));
            if (author == null) return null;
            return author;
        }

        public List<Author> FindByFullName(string name)
        {
            var authors = _context.Authors.Where(a => (a.Name.ToLower().Equals(name.ToLower())) || (a.LastName.ToLower().Equals(name.ToLower()))).ToList();
            if(authors == null) return null;
            return authors;
        }

        public Author FindById(long id)
        {
            var author = _context.Authors.Include(b => b.Books).SingleOrDefault(a => a.Id.Equals(id));
            if(author == null) return null;
            return author;

        }

        public List<Author> FindAll()
        {
            return _context.Authors.Include(b => b.Books).ToList();
        }
    }
}
