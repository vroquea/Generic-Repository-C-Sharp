using ConsoleAppTest.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.Context
{
    public class FakeContext : DbContext
    {
        public FakeContext() : base("name=FakeConnection")
        {

        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
    }
}
