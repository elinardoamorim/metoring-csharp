using RestWithASPNET5.Data.Converter.Implementations;
using RestWithASPNET5.Data.VO;
using RestWithASPNET5.Models;
using RestWithASPNET5.Repositories;
using RestWithASPNET5.Repositories.Generic;
using System.Collections.Generic;

namespace RestWithASPNET5.Business.Implementations
{
    public class AuthorBusinessImplementation : IGenericBusiness<AuthorVO>, IAuthorBusiness
    {
        private readonly IRepository<Author> _repository;
        private readonly IAuthorRepository _authorRepository;
        private readonly AuthorConverter _converter;
        private readonly BookAuthorConverter _bookAuthorConverter;


        public AuthorBusinessImplementation(IRepository<Author> repository, IAuthorRepository authorRepository)
        {
            _repository = repository;
            _authorRepository = authorRepository;
            _converter = new AuthorConverter();
        }

        public AuthorVO Create(AuthorVO t)
        {
            Author authorEntity = _converter.Parse(t);
            authorEntity = _repository.Create(authorEntity);
            return _converter.Parse(authorEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<AuthorVO> FindAll()
        {
            return _converter.Parse(_authorRepository.FindAll());
        }
        public AuthorVO FindById(long id)
        {
            return _converter.Parse(_authorRepository.FindById(id));
        }
        public AuthorVO Update(AuthorVO t)
        {
            var personEntity = _converter.Parse(t);
            personEntity = _repository.Update(personEntity);
            return _converter.Parse(personEntity);
        }

        public AuthorVO FindByCPF(string cpf)
        {
            return _converter.Parse(_authorRepository.FindByCPF(cpf));
        }

        public List<AuthorVO> FindByFullName(string nameFull)
        {
            return _converter.Parse(_authorRepository.FindByFullName(nameFull));
        }
    }
}
