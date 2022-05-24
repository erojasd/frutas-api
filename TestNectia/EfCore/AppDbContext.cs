using FrutasApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrutasApi.EfCore
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }
        //Add DbSets
        public DbSet<User> Users { get; set; }
        public DbSet<Fruit> Fruits { get; set; }
    }
}
