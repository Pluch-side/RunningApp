using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TypeCourseDAL : IDisposable
    {
        #region Extend BaseDAL
        private DataEntities _context = new DataEntities();
        private BaseDAL<TypeCourse> typeCourseRepository;
        private bool disposed = false;

        public  BaseDAL<TypeCourse> TypeCourseRepository
        {
            get
            {
                return this.typeCourseRepository ?? new BaseDAL<TypeCourse>(this._context);
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
