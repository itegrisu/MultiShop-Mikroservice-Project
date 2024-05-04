using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BusinessLayer.Concrete
{
    public class CargoDetailManager : ICargoDetailService
    {
        private readonly ICargoDetailDal _detailDal;

        public CargoDetailManager(ICargoDetailDal detailDal)
        {
            _detailDal = detailDal;
        }

        public void TDelete(int id)
        {
            _detailDal.Delete(id);
        }

        public List<CargoDetail> TGetAll()
        {
            return _detailDal.GetAll();
        }

        public CargoDetail TGetById(int id)
        {
            return _detailDal.GetById(id);
        }

        public void TInsert(CargoDetail entity)
        {
            _detailDal.Insert(entity);
        }

        public void TUpdate(CargoDetail entity)
        {
            _detailDal.Update(entity);
        }
    }
}
