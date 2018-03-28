using Microsoft.EntityFrameworkCore;
using NCC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NCC.Infrustructure.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Person> Persons { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=OnlineStoreDB;Trusted_Connection=True;MultipleActiveResultSets=true");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
