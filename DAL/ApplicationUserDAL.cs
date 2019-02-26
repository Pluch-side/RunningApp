using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ApplicationUserDAL : IDisposable
    {
        #region Extend BaseDAL
        private BDD_RUNNINGEntities _context = new BDD_RUNNINGEntities();
        private BaseDAL<ApplicationUser> applicationUserRepository;
        private bool disposed = false;

        public  BaseDAL<ApplicationUser> ApplicationUserRepository
        {
            get
            {
                return this.applicationUserRepository ?? new BaseDAL<ApplicationUser>(this._context);
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
