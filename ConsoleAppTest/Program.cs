using ConsoleAppTest.Context;
using ConsoleAppTest.Entities;
using ConsoleAppTest.Logic;
using Repository;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Seed
            //seedCategory();
            //seedBrand();
            #endregion

            #region CreateProduct
            //var category1 = BL_Category.Find(1);
            //var category2 = BL_Category.Find(2);
            //var categories = new List<Category> { category1, category2 };
            //var product = new Product { Name = "Prueba de producto", Brand = brand, Categories = categories };
            var categories = BL_Category.GetAll();

            var product = new Product { Name = "Producto many to many", BrandId = 1, Categories = new List<Category> { new Category { Id = 1 }  } };
            var result = BL_Product.CreateWithCategoriesAndBrandUoW(product);
            Console.WriteLine($"Producto creado: {result.Name}");
            #endregion

            #region  GetData
            //var categories = BL_Category.GetAll();
            //var product = BL_Product.FindWithAllRelations(1);
            var categories2 = BL_Category.GetAll();
            #endregion

            Console.ReadLine();
        }

        static void seedBrand()
        {
            var brand = new Brand { Name = "Ego" };
            var result = BL_Brand.Create(brand);
            Console.WriteLine($"New Brand {result.Name} with id: {result.Id}");
        }
        static void seedCategory()
        {
            var cat1 = new Category { Name = "Limpieza" };
            var cat2 = new Category { Name = "Belleza" };
            var result1 = BL_Category.Create(cat1);
            var result2 = BL_Category.Create(cat2);
            Console.WriteLine($"New Category {result1.Name} with id: {result1.Id}");
            Console.WriteLine($"New Category {result2.Name} with id: {result2.Id}");
        }
    }
}
