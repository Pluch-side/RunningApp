using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CourseDAL : IDisposable
    {
        #region Extend BaseDAL
        private DataEntities _context = new DataEntities();
        private BaseDAL<Course> courseRepository;
        private bool disposed = false;

        public  BaseDAL<Course> CourseRepository
        {
            get
            {
                return this.courseRepository ?? new BaseDAL<Course>(this._context);
            }
        }

        public void Save()
        {
            this._context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                    this._context.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion Extend BaseDAL
    }
}
