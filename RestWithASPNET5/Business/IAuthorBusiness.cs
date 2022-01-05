using RestWithASPNET5.Data.VO;
using System.Collections.Generic;

namespace RestWithASPNET5.Business
{
    public interface IAuthorBusiness
    {
        AuthorVO FindByCPF(string cpf);
        List<AuthorVO> FindByFullName(string nameFull);
    }
}
