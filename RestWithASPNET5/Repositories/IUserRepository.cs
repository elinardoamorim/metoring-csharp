using RestWithASPNET5.Data.VO;
using RestWithASPNET5.Models;
using System.Security.Cryptography;

namespace RestWithASPNET5.Repositories
{
    public interface IUserRepository
    {
        User ValidateCredentials(UserVO user);
        User ValidateCredentials(string login);
        bool RevokeToken(string login);
        User RefreshUserInfo(User user);
        string ComputeHash(string password, SHA256CryptoServiceProvider algorithm);
    }
}
