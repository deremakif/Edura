using Edura.WebUI.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Edura.WebUI.Entity;
using System.Linq.Expressions;

namespace Edura.WebUI.Repository.Concrete.EntityFramework
{
    public class EfCategoryRepository : EfGenericRepository<Category>, ICategoryRepository
    {
        public EfCategoryRepository(EduraContext context) : base(context)
        {
        }

        public EduraContext EduraContext
        {
            get { return context as EduraContext; }
        }

        public Category GetByName(string name)
        {
            return EduraContext.Categories
                .Where(i => i.CategoryName == name)
                .FirstOrDefault();
        }
    }
}
