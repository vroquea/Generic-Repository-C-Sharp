using ConsoleAppTest.Entities;
using System.Data.Entity;

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
