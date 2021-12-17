using RestWithASPNET5.Models;
using System.Collections.Generic;

namespace RestWithASPNET5.Business
{
    public interface IPersonBusiness
    {
        List<Person> FindAll();
        Person FindById(long id);
        Person Create(Person person);
        Person Update(Person person);
        void Delete(long id);
    }
}
