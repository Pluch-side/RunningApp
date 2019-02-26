using BO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ApplicationUserBLL : IBusiness<ApplicationUser>
    {
        private ApplicationUserDAL _datalayer;

        public ApplicationUserBLL()
        {
            this._datalayer = new ApplicationUserDAL();
        }

        public void Add(ApplicationUser entity)
        {
            this._datalayer.ApplicationUserRepository.Insert(entity);
        }

        public ApplicationUser Get(int id)
        {
            return this._datalayer.ApplicationUserRepository.SelectByID(id);
        }

        public List<ApplicationUser> GetAll()
        {
            return this._datalayer.ApplicationUserRepository.Select().ToList();
        }

        public void Remove(int id)
        {
            this._datalayer.ApplicationUserRepository.Delete(id);
        }

        public void Remove(ApplicationUser entity)
        {
            this._datalayer.ApplicationUserRepository.Delete(entity);
        }

        public void Update(ApplicationUser entity)
        {
            this._datalayer.ApplicationUserRepository.Update(entity);
        }
    }
}
