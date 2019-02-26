using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using System.Data.Entity;
using System.Linq.Expressions;

namespace DAL
{
    public class GenericsDAL<T> where T : class
    {
        private DbSet<T> _dbSet;
        private BDD_RUNNINGEntities _context;

        public GenericsDAL(BDD_RUNNINGEntities context)
        {
            this._context = context;
            this._dbSet = context.Set<T>();
        }

        /*
        * Query on an entities to get the list
        * Parameter:
        * | filter : predicat to use condition on the query
        * | orderBy : order the list 
        * | includeProperties : allow the generics to get join table properties
        * Return a IEnumerable of the entity
        */
        public virtual IEnumerable<T> Select(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = this._dbSet;
            IEnumerable<T> ret = new List<T>();

            //Adding condition where to the query
            if(filter != null)
            {
                query = query.Where(filter);
            }

            //Adding join table property in the query
            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperties);
            }

            ret = query.ToList();

            //Order the query
            if(orderBy != null)
            {
                ret = orderBy(query).ToList();
            }

            return ret;
        }
    }
}
