using BO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class RegistrationBLL : IBusiness<Registration>
    {
        private RegistrationDAL _dataLayer;
        
        public RegistrationBLL()
        {
            this._dataLayer = new RegistrationDAL();
        }

        public void Add(Registration entity)
        {
            this._dataLayer.RegistrationRepository.Insert(entity);
        }

        public Registration Get(int id)
        {
            return this._dataLayer.RegistrationRepository.SelectByID(id);
        }

        public List<Registration> GetAll()
        {
            return this._dataLayer.RegistrationRepository.Select().ToList();
        }

        public void Remove(int id)
        {
            this._dataLayer.RegistrationRepository.Delete(id);
        }

        public void Remove(Registration entity)
        {
            this._dataLayer.RegistrationRepository.Delete(entity);
        }

        public void Update(Registration entity)
        {
            this._dataLayer.RegistrationRepository.Update(entity);
        }
    }
}
