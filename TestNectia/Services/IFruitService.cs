using FrutasApi.Dtos.Fruits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrutasApi.Services
{
    public interface IFruitService
    {
        FruitDto Get(Guid id);
        IEnumerable<FruitDto> GetList();
        FruitDto Create(CreateUpdateFruitDto input);
        FruitDto Update(Guid id, CreateUpdateFruitDto input);
        void Delete(Guid id);

    }
}
