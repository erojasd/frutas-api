using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrutasApi.EfCore
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {

                context.Users.Add(
                   new Entities.User("admin", passwordHash("123456"), Guid.NewGuid())
                    );


                context.SaveChanges();
            }
        }

        /// <summary>
        /// Encripta el password
        /// https://docs.microsoft.com/en-us/aspnet/core/security/data-protection/consumer-apis/password-hashing?view=aspnetcore-2.2
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private static string passwordHash(string password)
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
