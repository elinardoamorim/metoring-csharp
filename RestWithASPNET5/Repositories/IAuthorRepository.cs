using RestWithASPNET5.Models;
using System.Collections.Generic;

namespace RestWithASPNET5.Repositories
{
    public interface IAuthorRepository
    {
        List<Author> FindAll();
        Author FindByCPF(string cpf);
        List<Author> FindByFullName(string name);
        Author FindById(long id);
    }
}
