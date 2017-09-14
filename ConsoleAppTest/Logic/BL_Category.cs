using ConsoleAppTest.Context;
using ConsoleAppTest.Entities;
using System.Collections.Generic;

namespace ConsoleAppTest.Logic
{
    public class BL_Category
    {
        static RepoContext repo = new RepoContext();
        public static Category Create(Category model)
        {
            return repo.Create(model);
        }
        public static Category Find(int id)
        {
            return repo.FindEntity<Category>(c => c.Id == id);
        }
        public static IEnumerable<Category> GetAll()
        {
            return repo.GetAll<Category>(c => true);
        }
    }
}
