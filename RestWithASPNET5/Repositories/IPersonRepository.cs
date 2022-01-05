using RestWithASPNET5.Models;
using System.Collections.Generic;

namespace RestWithASPNET5.Repositories
{
    public interface IPersonRepository
    {
        List<Person> FindByName(string name);
        List<Person> FindByLastName(string lastName);
        List<Person> FindByAddress(string address);
        List<Person> FindByGender(string gender);
    }
}
