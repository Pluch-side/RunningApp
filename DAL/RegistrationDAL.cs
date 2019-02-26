﻿using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RegistrationDAL : IDisposable
    {
        #region Extend BaseDAL
        private BDD_RUNNINGEntities _context = new BDD_RUNNINGEntities();
        private BaseDAL<Registration> registrationRepository;
        private bool disposed = false;

        public  BaseDAL<Registration> RegistrationRepository
        {
            get
            {
                return this.registrationRepository ?? new BaseDAL<Registration>(this._context);
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
