using RestWithASPNET5.Data.VO;
using RestWithASPNET5.Models;
using RestWithASPNET5.Models.Context;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace RestWithASPNET5.Repositories.impl
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlServerContext _context;

        public UserRepository(SqlServerContext context)
        {
            _context = context;
        }

        public string ComputeHash(string password, SHA256CryptoServiceProvider algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(password);
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
        }

        public User RefreshUserInfo(User user)
        {
            if(!_context.Users.Any(u => u.Id.Equals(user.Id))) return null;
            var result = _context.Users.SingleOrDefault(p => p.Id.Equals(user.Id));
            if(result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                    return result;
                }
                catch(Exception)
                {
                    throw;
                }
            }

            return null;
        }

        public bool RevokeToken(string login)
        {
            var user = _context.Users.SingleOrDefault(u => u.Login.Equals(login));
            if (user == null) return false;

            user.RefreshToken = null;
            user.Password = null;
            _context.SaveChanges();
            return true;
        }

        public User ValidateCredentials(UserVO user)
        {
            var pass = ComputeHash(user.Password, new SHA256CryptoServiceProvider());
            return _context.Users.FirstOrDefault(u => (u.Login == user.Login) && (u.Password == pass));
        }

        public User ValidateCredentials(string login)
        {
            return _context.Users.SingleOrDefault(u => u.Login.Equals(login));
        }
    }
}
