using ConsoleAppTest.Context;
using ConsoleAppTest.Entities;
using System.Collections.Generic;

namespace ConsoleAppTest.Logic
{
    public class BL_Brand
    {
        static RepoContext repo = new RepoContext();
        static RepoUoWContext repoUoW = new RepoUoWContext();

        public static Brand Create(Brand model)
        {
            return repo.Create(model);
        }
        public static Brand Find(int id)
        {
            return repo.FindEntity<Brand>(b => b.Id == id);
        }
        public static Brand FindUoW(int id)
        {
            return repoUoW.FindEntity<Brand>(b => b.Id == id);
        }
        public static IEnumerable<Brand> GetAll()
        {
            return repo.GetAll<Brand>(b => true);
        }
    }
}
