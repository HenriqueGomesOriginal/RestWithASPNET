using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using RestWithASPNET.Data.VO;
using RestWithASPNET.Models;
using RestWithASPNET.Models.Context;

namespace RestWithASPNET.Repository.Implementation
{
    public class UserRepositoryImplementation : IUserRepository
    {
        private MySqlContext _context;

        public UserRepositoryImplementation(MySqlContext context)
        {
            _context = context;
        }

        public User ValidateCredentials(UserVO user)
        {
            var pass = ComputeHash(user.Password, new SHA256CryptoServiceProvider());
            User userRet = _context.Users.SingleOrDefault(u => (u.UserName == user.UserName) && (u.Password == pass));
            return userRet;
        }

        public User ValidateCredentials(string userName)
        {
            User userRet = _context.Users.SingleOrDefault(u => (u.UserName == userName));
            return userRet;
        }

        public bool RevokeToken(string userName)
        {
            var user = _context.Users.SingleOrDefault(u => u.UserName.Equals(userName));
            if (user == null) return false;
            user.RefreshToken = null;
            _context.SaveChanges();
            return true;
        }

        private object ComputeHash(string input, SHA256CryptoServiceProvider algotithm)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = algotithm.ComputeHash(inputBytes);

            return BitConverter.ToString(hashedBytes);
        }

        public User RefreshUserInfo(User user)
        {
            if (!Exists(user.Id)) return null;
            var result = _context.Users.SingleOrDefault(p => p.Id.Equals(user.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            return user;
        }

        public bool Exists(string id)
        {
            return _context.Users.Any(p => p.Id.Equals(id));
        }
    }
}
