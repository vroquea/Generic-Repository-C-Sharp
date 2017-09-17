using ConsoleAppTest.Context;
using ConsoleAppTest.Entities;
using Repository;
using System.Collections.Generic;

namespace ConsoleAppTest.Logic
{
    public class BL_Product
    {
        static IRepository repo = new RepoContext();
        static IUnitOfWork repoUoW = new RepoUoWContext();
        public static Product Create(Product model)
        {
            return repo.Create(model);
        }
        public static Brand FindUoW(int id)
        {
            return repoUoW.FindEntity<Brand>(b => b.Id == id);
        }
        public static Category FindCategoryUoW(int id)
        {
            return repoUoW.FindEntity<Category>(b => b.Id == id);
        }
        public static Product CreateUoW(Product model)
        {
            var brand = FindUoW(model.BrandId);
            model.Brand = brand;
            var product = repoUoW.Create(model);
            repoUoW.Save();
            return product;
        }
        public static Product CreateWithCategoriesUoW(Product model)
        {
            var categories = new List<Category>();
            foreach (var category in model.Categories)
            {
                categories.Add(FindCategoryUoW(category.Id));
            }
            model.Categories = categories;
            var product = repoUoW.Create(model);
            repoUoW.Save();
            return product;
        }
        public static Product CreateWithCategoriesAndBrandUoW(Product model)
        {
            var categories = new List<Category>();
            foreach (var category in model.Categories)
            {
                categories.Add(FindCategoryUoW(category.Id));
            }
            var brand = FindUoW(model.BrandId);
            model.Brand = brand;
            model.Categories = categories;
            var product = repoUoW.Create(model);
            repoUoW.Save();
            return product;
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
