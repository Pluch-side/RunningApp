using BO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class HistoricUserCourseBLL : IBusiness<HistoricUserCourse>
    {
        private HistoricUserCourseDAL _dataLayer;

        public HistoricUserCourseBLL()
        {
            this._dataLayer = new HistoricUserCourseDAL();
        }

        public void Add(HistoricUserCourse entity)
        {
            this._dataLayer.HistoricUserCourseRepository.Insert(entity);
        }

        public HistoricUserCourse Get(int id)
        {
            return this._dataLayer.HistoricUserCourseRepository.SelectByID(id);
        }

        public List<HistoricUserCourse> GetAll()
        {
            return this._dataLayer.HistoricUserCourseRepository.Select().ToList();
        }

        public void Remove(int id)
        {
            this._dataLayer.HistoricUserCourseRepository.Delete(id);
        }

        public void Remove(HistoricUserCourse entity)
        {
            this._dataLayer.HistoricUserCourseRepository.Delete(entity);
        }

        public void Update(HistoricUserCourse entity)
        {
            this._dataLayer.HistoricUserCourseRepository.Update(entity);
        }
    }
}
