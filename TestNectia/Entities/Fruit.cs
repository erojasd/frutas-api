using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrutasApi.Entities
{
    public class Fruit : Entity<Guid>
    {
        public string Name { get; set; }
    }
}
