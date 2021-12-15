using RestWithAPSNET.Models;
using System.Collections.Generic;

namespace RestWithAPSNET.Services
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
