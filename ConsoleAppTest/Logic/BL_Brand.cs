using ConsoleAppTest.Context;
using ConsoleAppTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.Logic
{
    public class BL_Brand
    {
        static RepoContext repo = new RepoContext();

        public static Brand Create(Brand model)
        {
            return repo.Create<Brand>(model);
        }
        public static Brand Find(int id)
        {
            return repo.FindEntity<Brand>(b => b.Id == id);
        }
        public static IEnumerable<Brand> GetAll()
        {
            return repo.GetAll<Brand>(b => true);
        }
    }
}
