using ConsoleAppTest.Context;
using ConsoleAppTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.Logic
{
    public class BL_Product
    {
        static RepoContext repo = new RepoContext();

        public static Product Create(Product model)
        {
            return repo.Create<Product>(model);
        }

        public static Product Find(int id)
        {
            return repo.FindEntity<Product>(p => p.Id == id);
        }
        public static Product FindWthRelation(int id)
        {
            return repo.FindEntity<Product,Brand>(p => p.Id == id, p => p.Brand);
        }
        public static Product FindWthRelation(int id,params string[] relations)
        {
            return repo.FindEntity<Product>(p => p.Id == id, relations);
        }
    }
}
