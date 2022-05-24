using FrutasApi.Dtos.Users;
using FrutasApi.EfCore;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrutasApi.Entities;

namespace FrutasApi.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context=context;
        }

        public bool CheckUserExists(string name)
        {
            return _context.Users.Any(r => r.Name == name);
        }

        public UserDto Create(CreateUserDto input)
        {
            var entity = new User(input.Name, passwordHash(input.Password), Guid.NewGuid());
            _context.Users.Add(entity);
            _context.SaveChanges();
            return new UserDto
            {
                Id= entity.Id,
                Name = input.Name
            };
        }

        public IEnumerable<UserDto> GetAll()
        {
            return _context.Users.Select(u => new UserDto
            {
                Id= u.Id,
                Name= u.Name
            });
        }

        public PasswordValidDto Login(string name, string password)
        {
            password = passwordHash(password);
            var exists = _context.Users.Any(r => r.Name == name && r.Password == password);
            return new PasswordValidDto
            {
                Name = name,
                IsAuthenticated = exists
            };
        }

        /// <summary>
        /// Encripta el password
        /// https://docs.microsoft.com/en-us/aspnet/core/security/data-protection/consumer-apis/password-hashing?view=aspnetcore-2.2
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private string passwordHash(string password)
        {
            byte[] salt = new byte[128 / 8];
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));
        }
    }
}
