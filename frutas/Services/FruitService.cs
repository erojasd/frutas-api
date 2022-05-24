using FrutasApi.Dtos.Fruits;
using FrutasApi.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrutasApi.Entities;

namespace FrutasApi.Services
{
    public class FruitService : IFruitService
    {
        private readonly AppDbContext _context;

        public FruitService(AppDbContext context)
        {
            _context=context;
        }

        public FruitDto Create(CreateUpdateFruitDto input)
        {

            var entity = new Fruit { Id= Guid.NewGuid(), Name= input.Name };
            _context.Add(entity);
            _context.SaveChanges();
            return new FruitDto { Id = entity.Id, Name = entity.Name };
        }

        public void Delete(Guid id)
        {
            var entity = _context.Fruits.FirstOrDefault(f => f.Id== id);
            if (entity == null)
                throw new Exception("Fruta no encontrada");
            _context.Fruits.Remove(entity);
            _context.SaveChanges();
        }

        public FruitDto Get(Guid id)
        {
            var entity = _context.Fruits.FirstOrDefault(f => f.Id== id);
            if (entity == null)
                return null;
            return new FruitDto
            {
                Id= entity.Id,
                Name= entity.Name
            };
        }

        public IEnumerable<FruitDto> GetList()
        {
            return _context.Fruits.Select(entity => new FruitDto
            {
                Id= entity.Id,
                Name= entity.Name
            }).ToList();
        }

        public FruitDto Update(Guid id, CreateUpdateFruitDto input)
        {
            var entity = _context.Fruits.FirstOrDefault(f => f.Id== id);
            if (entity == null)
                throw new Exception("Fruta no encontrada");

            entity.Name = input.Name;
            _context.Fruits.Update(entity);
            _context.SaveChanges();
            return new FruitDto
            {
                Id= entity.Id,
                Name= entity.Name
            };
        }
    }
}
