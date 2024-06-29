using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _OfferDiscountDefaultComponentPartial : ViewComponent
    {
        //private readonly IOfferDiscountService _offerDiscountService;
        //public _OfferDiscountDefaultComponentPartial(IOfferDiscountService offerDiscountService)
        //{
        //    _offerDiscountService = offerDiscountService;
        //}
        //public async Task<IViewComponentResult> InvokeAsync()
        //{
        //    var values = await _offerDiscountService.GetAllOfferDiscountAsync();
        //    return View(values);
        //}

        private readonly IHttpClientFactory _httpClientFactory;
        public _OfferDiscountDefaultComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/OfferDiscounts");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultOfferDiscountDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
