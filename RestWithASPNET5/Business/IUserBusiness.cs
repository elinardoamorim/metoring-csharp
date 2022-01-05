using RestWithASPNET5.Data.VO;

namespace RestWithASPNET5.Business
{
    public interface IUserBusiness
    {
        bool Create(UserVO user);
    }
}
