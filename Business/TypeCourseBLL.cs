using BO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class TypeCourseBLL : IBusiness<TypeCourse>
    {
        private TypeCourseDAL _dataLayer;

        public TypeCourseBLL()
        {
            this._dataLayer = new TypeCourseDAL();
        }

        public void Add(TypeCourse entity)
        {
            this._dataLayer.TypeCourseRepository.Insert(entity);
        }

        public TypeCourse Get(int id)
        {
            return this._dataLayer.TypeCourseRepository.SelectByID(id);
        }

        public List<TypeCourse> GetAll()
        {
            return this._dataLayer.TypeCourseRepository.Select().ToList();
        }

        public void Remove(int id)
        {
            this._dataLayer.TypeCourseRepository.Delete(id);
        }

        public void Remove(TypeCourse entity)
        {
            this._dataLayer.TypeCourseRepository.Delete(entity);
        }

        public void Update(TypeCourse entity)
        {
            this._dataLayer.TypeCourseRepository.Update(entity);
        }
    }
}
