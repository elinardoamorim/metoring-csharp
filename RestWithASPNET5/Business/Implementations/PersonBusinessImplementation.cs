using RestWithASPNET5.Data.Converter.Implementations;
using RestWithASPNET5.Data.VO;
using RestWithASPNET5.Models;
using RestWithASPNET5.Repositories;
using RestWithASPNET5.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNET5.Business.Implementations
{
    public class PersonBusinessImplementation : IGenericBusiness<PersonVO>, IPersonBusiness
    {

        private readonly IRepository<Person> _repository;
        private readonly IPersonRepository _personRepository;
        private readonly PersonConverter _converter;

        public PersonBusinessImplementation(IRepository<Person> repository, IPersonRepository personRepository)
        {
            _repository = repository;
            _personRepository = personRepository;
            _converter = new PersonConverter();
        }

        public PersonVO Create(PersonVO person)
        {
            Person personEntity = _converter.Parse(person);
            personEntity = _repository.Create(personEntity);
            return _converter.Parse(personEntity);

        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<PersonVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public PersonVO FindById(long id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }

        public PersonVO Update(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Update(personEntity);
            return _converter.Parse(personEntity);

        }

        public List<PersonVO> FindByName(string name)
        {
            return _converter.Parse(_personRepository.FindByName(name));
        }

        public List<PersonVO> FindByLastName(string lastName)
        {
            return _converter.Parse(_personRepository.FindByLastName(lastName));
        }

        public List<PersonVO> FindByAddress(string address)
        {
            return _converter.Parse(_personRepository.FindByAddress(address));
        }

        public List<PersonVO> FindByGender(string gender)
        {
            return _converter.Parse(_personRepository.FindByGender(gender));
        }
    }
}
