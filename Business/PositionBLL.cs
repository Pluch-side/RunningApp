using BO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class PositionBLL : IBusiness<Position>
    {
        private PositionDAL _dataLayer;

        public PositionBLL()
        {
            this._dataLayer = new PositionDAL();
        }

        public void Add(Position entity)
        {
            this._dataLayer.PositionRepository.Insert(entity);
        }

        public Position Get(int id)
        {
            return this._dataLayer.PositionRepository.SelectByID(id);
        }

        public List<Position> GetAll()
        {
            return this._dataLayer.PositionRepository.Select().ToList();
        }

        public void Remove(int id)
        {
            this._dataLayer.PositionRepository.Delete(id);
        }

        public void Remove(Position entity)
        {
            this._dataLayer.PositionRepository.Delete(entity);
        }

        public void Update(Position entity)
        {
            this._dataLayer.PositionRepository.Update(entity);
        }
    }
}
