using ConsoleAppTest.Context;
using ConsoleAppTest.Entities;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleAppTest.Logic
{
    public class BL_Product
    {
        static RepoContext repo = new RepoContext();

        public static Product Create(Product model)
        {
            return repo.Create(model);
        }
        public static Product Find(int id)
        {
            return repo.FindEntity<Product>(p => p.Id == id);
        }
        public static Product FindWithBrand(int id)
        {
            return repo.FindEntity<Product,Brand>(p => p.Id == id, p => p.Brand);
        }
        public static Product FindWithCategories(int id)
        {
            return repo.FindEntity<Product, IEnumerable<Category>>(p => p.Id == id, p => p.Categories);
        }
        public static Product FindWithAllRelations(int id)
        {
            return repo.FindEntity<Product>(p => p.Id == id, nameof(Product.Categories), nameof(Product.Brand));
        }
    }
}
