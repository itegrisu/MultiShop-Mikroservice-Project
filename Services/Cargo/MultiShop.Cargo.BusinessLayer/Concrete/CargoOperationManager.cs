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
    public class CargoOperationManager : ICargoOperationService
    {
        private readonly ICargoOperationDal _operationDal;

        public CargoOperationManager(ICargoOperationDal operationDal)
        {
            _operationDal = operationDal;
        }

        public void TDelete(int id)
        {
            _operationDal.Delete(id);
        }

        public List<CargoOperation> TGetAll()
        {
            return _operationDal.GetAll();
        }

        public CargoOperation TGetById(int id)
        {
            return _operationDal.GetById(id);
        }

        public void TInsert(CargoOperation entity)
        {
            _operationDal.Insert(entity);
        }

        public void TUpdate(CargoOperation entity)
        {
            _operationDal.Update(entity);
        }
    }
}
