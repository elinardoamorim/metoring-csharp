using RestWithASPNET5.Models.Base;
using System.Collections.Generic;

namespace RestWithASPNET5.Repositories.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T t);
        T FindById(long id);
        List<T> FindAll();
        T Update (T t);
        void Delete(long id);
        bool Exists(long id);
    }
}