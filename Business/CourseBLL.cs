using BO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CourseBLL : IBusiness<Course>
    {
        private CourseDAL _dataLayer;

        public CourseBLL()
        {
            _dataLayer = new CourseDAL();
        }

        public Course Get(int id)
        {
            return this._dataLayer.CourseRepository.SelectByID(id);
        }

        public List<Course> GetAll()
        {
            return this._dataLayer.CourseRepository.Select().ToList();
        }

        public void Add(Course entity)
        {
            this._dataLayer.CourseRepository.Insert(entity);
        }

        public void Update(Course entity)
        {
            this._dataLayer.CourseRepository.Update(entity);
        }

        public void Remove(Course entity)
        {
            this._dataLayer.CourseRepository.Delete(entity);
        }

        public void Remove(int id)
        {
            this._dataLayer.CourseRepository.Delete(id);
        }
    }
}
