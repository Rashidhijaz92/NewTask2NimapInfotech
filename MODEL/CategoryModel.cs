using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class CategoryModel
    {

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string Product { get; set; }

        public int ProductId { get; set; }

        //public Category Category { get; set; }
    }

    public class Category
    {
        public string CategoryName { get; set; }
    }
}
