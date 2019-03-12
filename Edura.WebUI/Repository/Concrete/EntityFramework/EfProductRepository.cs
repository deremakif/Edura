using Edura.WebUI.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Edura.WebUI.Entity;

namespace Edura.WebUI.Repository.Concrete.EntityFramework
{
    public class EfProductRepository : IProductRepository
    {
        private EduraContext context;

        public EfProductRepository(EduraContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Product> Products => context.Products;
    }
}
