using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }
    }
}
