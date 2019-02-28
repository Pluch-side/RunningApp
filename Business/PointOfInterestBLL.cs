using BO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class PointOfInterestBLL : IBusiness<PointOfInterest>
    {
        private PointOfInterestDAL _dataLayer;

        public PointOfInterestBLL()
        {
            this._dataLayer = new PointOfInterestDAL();
        }

        public void Add(PointOfInterest entity)
        {
            this._dataLayer.PointOfInterestRepository.Insert(entity);
        }

        public PointOfInterest Get(int id)
        {
            return this._dataLayer.PointOfInterestRepository.SelectByID(id);
        }

        public List<PointOfInterest> GetByCourseID(int courseId)
        {
            return this._dataLayer.PointOfInterestRepository.Select(item => item.CourseID == courseId,null,"TypePOI").ToList();
        }

        public List<PointOfInterest> GetByOrder(int order)
        {
            return this._dataLayer.PointOfInterestRepository.Select(item => item.OrderPOI == order, null, "TypePOI").ToList();
        }

        public List<PointOfInterest> GetAll()
        {
            return this._dataLayer.PointOfInterestRepository.Select().ToList();
        }

        public void Remove(int id)
        {
            this._dataLayer.PointOfInterestRepository.Delete(id);
        }

        public void Remove(PointOfInterest entity)
        {
            this._dataLayer.PointOfInterestRepository.Delete(entity);
        }

        public void RemoveByID(int id)
        {
            this._dataLayer.PointOfInterestRepository.Delete(id);
        }

        public void Update(PointOfInterest entity)
        {
            this._dataLayer.PointOfInterestRepository.Update(entity);
        }
    }
}
