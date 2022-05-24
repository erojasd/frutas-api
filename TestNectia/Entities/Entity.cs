using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FrutasApi.Entities
{
    public class Entity<T>
    {
        [Key]
        public T Id { get; set; }
        public Entity()
        {

        }
        public Entity(T id)
        {
            Id= id;
        }
    }
}
