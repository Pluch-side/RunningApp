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
    public class BaseDAL<T> where T : class
    {
        private DbSet<T> _dbSet;
        private DataEntities _context;

        /*
        * Initialize the context and the dbset
        */
        public BaseDAL(DataEntities context)
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
                query = query.Include(includeProperty);
            }

            ret = query.ToList();

            //Order the query
            if(orderBy != null)
            {
                ret = orderBy(query).ToList();
            }

            return ret;
        }

        /*
        * Select an entity by ID
        * Parameter : The primary key of the entity
        * Return the entity
        */
        public virtual T SelectByID(object id)
        {
            return this._dbSet.Find(id);
        }

        /*
        * Insert an entity in the database
        */
        public virtual void Insert(T entity)
        {
            this._dbSet.Add(entity);
            this._context.SaveChanges();
        }

        /*
        * Delete an entity with it's id
        */
        public virtual void Delete(object id)
        {
            Delete(SelectByID(id));
        }

        /*
        * Delete an entity with itself
        */
        public virtual void Delete(T entity)
        {
            if (this._context.Entry(entity).State == EntityState.Detached)
                this._dbSet.Attach(entity);
            this._dbSet.Remove(entity);
            this._context.SaveChanges();
        }

        /*
        * Update an entity
        */
        public virtual void Update(T entity)
        {
            this._dbSet.Attach(entity);
            this._context.Entry(entity).State = EntityState.Modified;
            this._context.SaveChanges();
        }
    }
}
