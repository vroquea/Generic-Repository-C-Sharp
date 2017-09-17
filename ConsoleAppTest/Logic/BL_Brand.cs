using ConsoleAppTest.Context;
using ConsoleAppTest.Entities;
using Repository;
using System.Collections.Generic;

namespace ConsoleAppTest.Logic
{
    public class BL_Brand
    {
        static IRepository repo = new RepoContext();

        public static Brand Create(Brand model)
        {
            return repo.Create(model);
        }
        public static Brand Find(int id)
        {
            return repo.FindEntity<Brand>(b => b.Id == id);
        }
        public static Brand Find(int id, IRepository repository)
        {
            return repository.FindEntity<Brand>(b => b.Id == id);
        }
        public static IEnumerable<Brand> GetAll()
        {
            return repo.GetAll<Brand>(b => true);
        }
    }
}
