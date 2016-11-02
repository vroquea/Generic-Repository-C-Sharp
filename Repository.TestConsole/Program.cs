using Repository.NWBusiness;
using Repository.NWEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.TestConsole
{
    public class Program
    {

        static void Main(string[] args)
        {
            IEnumerable<Product> result = null;
            Task.Run(async () =>
            {
                result = await GetProducts();
            }).Wait();

            foreach (var product in result)
            {
                Console.WriteLine($"Id: {product.ProductID} || Name: {product.ProductName}");
                Console.WriteLine($"Category: {product.Category.CategoryName}");
                Console.WriteLine("---------------------------------------------------------------------------------------");
            }

            Console.Read();
        }

        static async Task<IEnumerable<Product>> GetProducts()
        {
            BL_Product repo = new BL_Product();
            var products = await repo.GetAllWithRelationAsync();
            return products;
        }

    }
}
