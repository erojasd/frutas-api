using FrutasApi.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrutasApi.Dtos.Fruits
{
    public class FruitDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
