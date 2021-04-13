﻿using System;
using RestWithASPNET.Data.VO;

namespace RestWithASPNET.Business
{
    public interface ILoginBusiness
    {
        TokenVO ValidateCredentials(UserVO userCredentials);
    }
}