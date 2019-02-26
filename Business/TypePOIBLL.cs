using BO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class TypePOIBLL : IBusiness<TypePOI>
    {
        private TypePOIDAL _dataLayer;

        public TypePOIBLL()
        {
            this._dataLayer = new TypePOIDAL();
        }

        public void Add(TypePOI entity)
        {
            this._dataLayer.TypePOIRepository.Insert(entity);
        }

        public TypePOI Get(int id)
        {
            return this._dataLayer.TypePOIRepository.SelectByID(id);
        }

        public List<TypePOI> GetAll()
        {
            return this._dataLayer.TypePOIRepository.Select().ToList() ;
        }

        public void Remove(int id)
        {
            this._dataLayer.TypePOIRepository.Delete(id);
        }

        public void Remove(TypePOI entity)
        {
            this._dataLayer.TypePOIRepository.Delete(entity);
        }

        public void Update(TypePOI entity)
        {
            this._dataLayer.TypePOIRepository.Update(entity);
        }
    }
}
