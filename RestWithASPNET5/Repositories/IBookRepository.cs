using RestWithASPNET5.Models;
using System;
using System.Collections.Generic;

namespace RestWithASPNET5.Repositories
{
    public interface IBookRepository
    {
        List<Book> FindByTitle(string title);
        List<Book> FindByAuthor(string author);
        List<Book> FindByLaunchDate(DateTime dateTime);
        List<Book> FindByPrice(decimal price);
    }
}
