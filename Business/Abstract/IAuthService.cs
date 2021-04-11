using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IDataResult<User> Update(UserForUpdateDto userForUpdate, string password);
        IResult UserExists(string email);
        IResult ExistsId(int userId);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
