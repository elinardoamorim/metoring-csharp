﻿using RestWithASPNET5.Models;
using RestWithASPNET5.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNET5.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        
        private readonly IRepository<Person> _repository;

        public PersonBusinessImplementation(IRepository<Person> repository)
        {
            _repository = repository;
        }

        public Person Create(Person person)
        {
            return _repository.Create(person);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }

        public Person FindById(long id)
        {
            return _repository.FindByID(id);
        }

        public Person Update(Person person)
        {
            return _repository.Update(person);
        }
    }
}
