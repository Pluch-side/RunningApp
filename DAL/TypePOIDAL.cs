using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TypePOIDAL : IDisposable
    {
        #region Extend BaseDAL
        private BDD_RUNNINGEntities _context = new BDD_RUNNINGEntities();
        private BaseDAL<TypePOI> typePOIRepository;
        private bool disposed = false;

        public  BaseDAL<TypePOI> TypePOIRepository
        {
            get
            {
                return this.typePOIRepository ?? new BaseDAL<TypePOI>(this._context);
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
