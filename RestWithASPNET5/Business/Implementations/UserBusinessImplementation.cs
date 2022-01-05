using RestWithASPNET5.Data.VO;
using RestWithASPNET5.Models;
using RestWithASPNET5.Repositories;
using RestWithASPNET5.Repositories.Generic;
using System;
using System.Security.Cryptography;

namespace RestWithASPNET5.Business.Implementations
{
    public class UserBusinessImplementation : IUserBusiness
    {
        private readonly IRepository<User> _repository;
        private readonly IUserRepository _userRepository;

        public UserBusinessImplementation(IRepository<User> repository, IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }
        public bool Create(UserVO userVO)
        {
            var pass = _userRepository.ComputeHash(userVO.Password, new SHA256CryptoServiceProvider());

            var user = new User()
            {
                Login = userVO.Login,
                Password = pass,
                RefreshTokenExpiryTime = DateTime.Now.AddDays(7)
            };

            user = _repository.Create(user);

            return user == null ? false : true;
        }
    }
}
