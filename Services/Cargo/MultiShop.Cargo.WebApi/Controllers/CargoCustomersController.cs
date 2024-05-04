using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _customerService;

        public CargoCustomersController(ICargoCustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult GetAllCargoCustomer()
        {
            var values = _customerService.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCustomerById(int id)
        {
            var value = _customerService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
        {
            CargoCustomer cargoCustomer = new()
            {
                Adress = createCargoCustomerDto.Adress,
                District = createCargoCustomerDto.District,
                Email = createCargoCustomerDto.Email,
                Name = createCargoCustomerDto.Name,
                Phone = createCargoCustomerDto.Phone,
                Surname = createCargoCustomerDto.Surname,
                UserCustomerId = createCargoCustomerDto.UserCustomerId
            };

            _customerService.TInsert(cargoCustomer);
            
            return Ok("Kargo Müşterisi başarıyla oluşturuldu");
        }

        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
        {

            CargoCustomer cargoCustomer = new()
            {
                Adress = updateCargoCustomerDto.Adress,
                District = updateCargoCustomerDto.District,
                Email = updateCargoCustomerDto.Email,
                Name = updateCargoCustomerDto.Name,
                Phone = updateCargoCustomerDto.Phone,
                Surname = updateCargoCustomerDto.Surname,
                UserCustomerId = updateCargoCustomerDto.UserCustomerId,
                CargoCustomerId = updateCargoCustomerDto.CargoCustomerId
            };

            _customerService.TUpdate(cargoCustomer);

            return Ok("Kargo Müşterisi başarıyla güncellendi");
        }

        [HttpDelete]
        public IActionResult RemoveCargoCustomer(int id)
        {
            _customerService.TDelete(id);
            return Ok("Kargo Müştreisi başarıyla silindi");
        }
    }
}
