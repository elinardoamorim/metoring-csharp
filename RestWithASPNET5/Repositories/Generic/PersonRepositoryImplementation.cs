using RestWithASPNET5.Models.Context;
using RestWithASPNET5.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNET5.Repositories.Implementations
{
    public class PersonRepositoryImplementation : IPersonRepository
    {
        private SqlServerContext _context;

        public PersonRepositoryImplementation(SqlServerContext context)
        {
            _context = context;
        }


        public List<Person> FindByName(string name)
        {
            var persons = _context.Persons.Where(p => p.FirstName.ToLower().Contains(name.ToLower()) || p.LastName.ToLower().Contains(name.ToLower())).ToList();
            if(persons != null)
            {
                return persons;
            } 
            else
            {
                return null;
            }
           
        }

        public List<Person> FindByLastName(string lastName)
        {
            var persons = _context.Persons.Where(p => p.LastName.ToLower().Contains(lastName.ToLower())).ToList();
            if(persons != null)
            {
                return persons;
            }
            else
            {
                return null;
            }
        }
        public List<Person> FindByAddress(string address)
        {
            var persons = _context.Persons.Where(p => p.Address.ToLower().Contains(address.ToLower())).ToList();
            if(persons != null)
            {
                return persons;
            }
            else
            {
                return null;
            }
        }
        public List<Person> FindByGender(string gender)
        {
            var persons = _context.Persons.Where(p => p.Gender.ToLower().Contains(gender.ToLower())).ToList();
            if(persons != null)
            {
                return persons;
            }
            else
            {
                return null;
            }
        }
    }
}
