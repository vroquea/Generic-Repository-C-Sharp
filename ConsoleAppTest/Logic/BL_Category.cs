using ConsoleAppTest.Context;
using ConsoleAppTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.Logic
{
    public class BL_Category
    {
        static RepoContext repo = new RepoContext();
        public static Category Create(Category model)
        {
            return repo.Create<Category>(model);
        }
        public static Category Find(int id)
        {
            return repo.FindEntity<Category>(c => c.Id == id);
        }
    }
}
