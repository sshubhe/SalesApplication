using System;
using Microsoft.EntityFrameworkCore;
using Sales.Entities;

namespace Sales.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<SalesRecord> Sales { get; set; }
        public DbSet<Countries> CountriesData { get; set; }
        //public DbSet<Years> YearsData { get; set; }
    }
}
