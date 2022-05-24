using FrutasApi.Dtos.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrutasApi.Services
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetAll();
        UserDto Create(CreateUserDto input);
        bool CheckUserExists(string name);
        PasswordValidDto Login(string name, string password);
    }
}
