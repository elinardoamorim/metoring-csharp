using RestWithASPNET5.Models;
using System.Collections.Generic;

namespace RestWithASPNET5.Business
{
    public interface IBookBusiness
    {
        List<Book> FindAll();
        Book FindById(long id);
        Book Create(Book book);
        Book Update(Book book);
        void Delete(long id);
    }
}
