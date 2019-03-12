using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.WebUI.Entity
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }
    }
}
