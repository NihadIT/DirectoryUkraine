using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DirectoryUkraine.Models
{
    public class UkraineContext : DbContext
    {
        public DbSet<Region> Region { get; set; }          
        public DbSet<District> District { get; set; }       
        public DbSet<City> City { get; set; }

        public UkraineContext(DbContextOptions<UkraineContext> options)
          : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
