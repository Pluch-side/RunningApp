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
            this.UpdateOrder(entity,true);
            this._dataLayer.PointOfInterestRepository.Insert(entity);
        }

        public PointOfInterest Get(int id)
        {
            return this._dataLayer.PointOfInterestRepository.SelectByID(id);
        }

        public List<PointOfInterest> GetByCourseID(int courseId)
        { 
            return this._dataLayer.PointOfInterestRepository.Select(item => item.CourseID == courseId, p => p.OrderBy(item => item.OrderPOI),"TypePOI").ToList();
        }

        public List<PointOfInterest> GetByOrder(int order, int courseID)
        {
            return this._dataLayer.PointOfInterestRepository.Select(item => item.OrderPOI == order && item.CourseID == courseID, null, "TypePOI").ToList();
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
            this.UpdateOrder(entity, false);
        }

        public void RemoveByID(int id)
        {
            this._dataLayer.PointOfInterestRepository.Delete(id);
            this.UpdateOrder(this._dataLayer.PointOfInterestRepository.SelectByID(id), false);
        }

        public void Update(PointOfInterest entity)
        {
            this._dataLayer.PointOfInterestRepository.Update(entity);
            this.UpdateOrder(entity,true);
        }

        private void UpdateOrder(PointOfInterest newP, bool add)
        {
            if (add)
            {
                PointOfInterest poi = this._dataLayer.PointOfInterestRepository.Select(item => item.OrderPOI == newP.OrderPOI && item.CourseID == newP.CourseID).FirstOrDefault();
                if (poi != null)
                {
                    List<PointOfInterest> listPoints = this._dataLayer.PointOfInterestRepository.Select(item => item.OrderPOI >= newP.OrderPOI && item.CourseID == newP.CourseID && item.ID != newP.ID).ToList();
                    if (listPoints.Count > 0)
                    {
                        for (int i = listPoints.Count - 1; i >= 0; i--)
                        {
                            listPoints[i].OrderPOI++;
                            this._dataLayer.PointOfInterestRepository.Update(listPoints[i]);
                        }
                    }
                }
            }
            else
            {
                List<PointOfInterest> listPoints = this._dataLayer.PointOfInterestRepository.Select().ToList();
                int oldOrder = -1;
                foreach(PointOfInterest poi in listPoints)
                {
                    if(oldOrder != -1)
                    {
                        bool update = false;
                        while (oldOrder < poi.OrderPOI - 1)
                        {
                            poi.OrderPOI--;
                            update = true;                     
                        }
                        if(update)
                            this._dataLayer.PointOfInterestRepository.Update(poi);
                    }
                    oldOrder = poi.OrderPOI;
                }
            }
            
        } 
    }
}
