using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrutasApi.Entities
{
    public class User : Entity<Guid>
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public User() { }

        public User(string name, string password, Guid id)
        : base(id)
        {
            Name= name;
            Password = password;

        }
    }
}
