using FrutasApi.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrutasApi.Dtos.Users
{
    public class UserDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
