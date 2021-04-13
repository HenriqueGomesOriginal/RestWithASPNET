using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using RestWithASPNET.Configurations;
using RestWithASPNET.Data.VO;
using RestWithASPNET.Repository;
using RestWithASPNET.Services;

namespace RestWithASPNET.Business.Implementation
{
    public class LoginBusinessImplementation : ILoginBusiness
    {
        private const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";
        private TokenConfiguration _configuration;
        private IUserRepository _repository;
        private readonly ITokenService _service;

        public LoginBusinessImplementation(TokenConfiguration configuration, IUserRepository repository, ITokenService service)
        {
            _configuration = configuration;
            _repository = repository;
            _service = service;
        }   

        public TokenVO ValidateCredentials(UserVO userCredentials)
        {
            var user = _repository.ValidateCredentials(userCredentials);
            if (user == null) return null;
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)

            };

            var accessToken = _service.GenerateAccessToken(claims);
            var refreshToken = _service.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(_configuration.DaysToExpiry);

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);

            var auxUser = new UserVO();
            auxUser.Password = user.Password;
            auxUser.UserName = user.UserName;

            _repository.ValidateCredentials(auxUser);

            return new TokenVO(
                true,
                createDate.ToString(DATE_FORMAT),
                expirationDate.ToString(DATE_FORMAT),
                accessToken,
                refreshToken
            );
        }

        public TokenVO ValidateCredentials(TokenVO token)
        {
            var accessToken = token.AccessToken;
            var refreshToken = token.RefreshToken;

            var principal = _service.GetPrincipalFromExpiryToken(accessToken);
            var userName = principal.Identity.Name;
            var user = _repository.ValidateCredentials(userName);

            if (user != null ||
                user.RefreshToken != refreshToken ||
                user.RefreshTokenExpiryTime <= DateTime.Now) return null;

            accessToken = _service.GenerateAccessToken(principal.Claims);
            refreshToken = _service.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(_configuration.DaysToExpiry);

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);

            var auxUser = new UserVO();
            auxUser.Password = user.Password;
            auxUser.UserName = user.UserName;

            _repository.ValidateCredentials(auxUser);

            return new TokenVO(
                true,
                createDate.ToString(DATE_FORMAT),
                expirationDate.ToString(DATE_FORMAT),
                accessToken,
                refreshToken
            );
        }

        public bool RevokeToken(string userName)
        {
            var result = _repository.RevokeToken(userName);
            if (result != true) return false;
            return true;
        }
    }
}
