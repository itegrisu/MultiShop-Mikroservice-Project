using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _detailService;

        public CargoDetailsController(ICargoDetailService detailService)
        {
            _detailService = detailService;
        }

        [HttpGet]
        public IActionResult GetAllCargoDetail()
        {
            var values = _detailService.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoDetailById(int id)
        {
            var value = _detailService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
        {
            CargoDetail cargoDetail = new CargoDetail
            {
                Barcode = createCargoDetailDto.Barcode,
                CargoCompanyId = createCargoDetailDto.CargoCompanyId,
                RecieverCustomer = createCargoDetailDto.RecieverCustomer,
                SenderCustomer = createCargoDetailDto.SenderCustomer                
            };
            _detailService.TInsert(cargoDetail);
            return Ok("Kargo Detayları başarıyla eklendi");
        }

        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
        {
            CargoDetail cargoDetail = new CargoDetail
            {
                Barcode = updateCargoDetailDto.Barcode,
                CargoCompanyId = updateCargoDetailDto.CargoCompanyId,
                RecieverCustomer = updateCargoDetailDto.RecieverCustomer,
                SenderCustomer = updateCargoDetailDto.SenderCustomer,
                CargoDetailId = updateCargoDetailDto.CargoDetailId
            };
            _detailService.TUpdate(cargoDetail);
            return Ok("Kargo Şirketi başarıyla güncellendi");
        }

        [HttpDelete]
        public IActionResult RemoveCargoDetail(int id)
        {
            _detailService.TDelete(id);
            return Ok("Kargo Ayrıntıları başarıyla silindi");
        }
    }
}
