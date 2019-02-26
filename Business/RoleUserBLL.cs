using BO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class RoleUserBLL : IBusiness<RoleUser>
    {
        private RoleUserDAL _dataLayer;

        public RoleUserBLL()
        {
            this._dataLayer = new RoleUserDAL();
        }

        public void Add(RoleUser entity)
        {
            this._dataLayer.RoleUserRepository.Insert(entity);
        }

        public RoleUser Get(int id)
        {
            return this._dataLayer.RoleUserRepository.SelectByID(id);
        }

        public List<RoleUser> GetAll()
        {
            return this._dataLayer.RoleUserRepository.Select().ToList();
        }

        public void Remove(int id)
        {
            this._dataLayer.RoleUserRepository.Delete(id);
        }

        public void Remove(RoleUser entity)
        {
            this._dataLayer.RoleUserRepository.Delete(entity);
        }

        public void Update(RoleUser entity)
        {
            this._dataLayer.RoleUserRepository.Update(entity);
        }
    }
}
