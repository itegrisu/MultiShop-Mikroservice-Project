using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompaniesController : ControllerBase
    {
        private readonly ICargoCompanyService _companyService;

        public CargoCompaniesController(ICargoCompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public IActionResult GetAllCargoCompanies()
        {
            var values = _companyService.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCompanyById(int id)
        {
            var value = _companyService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
        {
            CargoCompany cargoCompany = new CargoCompany
            {
                CargoCompanyName = createCargoCompanyDto.CargoCompanyName
            };
            _companyService.TInsert(cargoCompany);
            return Ok("Kargo Şirketi başarıyla eklendi");
        }

        [HttpPut]
        public IActionResult UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            CargoCompany cargoCompany = new CargoCompany
            {
                CargoCompanyId = updateCargoCompanyDto.CargoCompanyId,
                CargoCompanyName = updateCargoCompanyDto.CargoCompanyName
            };
            _companyService.TUpdate(cargoCompany);
            return Ok("Kargo Şirketi başarıyla güncellendi");
        }

        [HttpDelete]
        public IActionResult RemoveCargoCompany(int id)
        {
            _companyService.TDelete(id);
            return Ok("Kargo Şirketi başarıyla silindi");
        }
    }
}
