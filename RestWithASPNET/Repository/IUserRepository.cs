using System;
using RestWithASPNET.Data.VO;
using RestWithASPNET.Models;

namespace RestWithASPNET.Repository
{
    public interface IUserRepository
    {
        User ValidateCredentials(UserVO user);

        User ValidateCredentials(string userName);

        bool RevokeToken(string userName);

        User RefreshUserInfo(User user);
    }
}
