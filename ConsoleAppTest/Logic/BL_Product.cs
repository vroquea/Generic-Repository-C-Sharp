using ConsoleAppTest.Context;
using ConsoleAppTest.Entities;
using Repository;
using System.Collections.Generic;

namespace ConsoleAppTest.Logic
{
    public class BL_Product
    {
        static IRepository repo = new RepoContext();
        public static Product Create(Product model, IEnumerable<int> categories, int BrandId)
        {
            List<Category> myCategories = new List<Category>();
            foreach (var category in categories)
            {
                myCategories.Add(BL_Category.Find(category, repo));
            }
            Brand brand = BL_Brand.Find(BrandId,repo);

            model.Categories = myCategories;
            model.Brand = brand;
            return repo.Create(model);
        }
        public static Brand FindBrand(int id)
        {
            return repo.FindEntity<Brand>(b => b.Id == id);
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
