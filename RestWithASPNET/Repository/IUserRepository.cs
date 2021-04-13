using System;
using RestWithASPNET.Data.VO;
using RestWithASPNET.Models;

namespace RestWithASPNET.Repository
{
    public interface IUserRepository
    {
        User ValidateCredentials(UserVO user);

        User RefreshUserInfo(User user);
    }
}
