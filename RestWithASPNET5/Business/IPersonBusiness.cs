using RestWithASPNET5.Data.VO;
using System;
using System.Collections.Generic;

namespace RestWithASPNET5.Business
{
    public interface IPersonBusiness
    {
        List<PersonVO> FindByName(string name);
        List<PersonVO> FindByLastName(string lastName);
        List<PersonVO> FindByAddress(string address);
        List<PersonVO> FindByGender(string gender);
    }
}
