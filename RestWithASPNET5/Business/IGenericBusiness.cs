using System.Collections.Generic;

namespace RestWithASPNET5.Business
{
    public interface IGenericBusiness<T>
    {
        List<T> FindAll();
        T FindById(long id);
        T Create(T t);
        T Update(T t);
        void Delete(long id);

    }
}
