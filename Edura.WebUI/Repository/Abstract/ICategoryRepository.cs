using Edura.WebUI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Edura.WebUI.Repository.Abstract
{
   public interface ICategoryRepository
    {
        Category Get(int id);
        IQueryable<Category> GetAll();
        IQueryable<Category> Find(Expression<Func<Category, bool>> predicate);
        void Add(Category entity);
        void Delete(Category entity);
        void Edit(Category entity);
        void Save();
    }
}
