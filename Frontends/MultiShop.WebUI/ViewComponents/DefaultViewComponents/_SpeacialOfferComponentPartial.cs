using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _SpeacialOfferComponentPartial : ViewComponent
    {
    //    private readonly ISpecialOfferService _specialOfferService;
    //    public _SpeacialOfferComponentPartial(ISpecialOfferService specialOfferService)
    //    {
    //        _specialOfferService = specialOfferService;
    //    }
    //    public async Task<IViewComponentResult> InvokeAsync()
    //    {
    //        var values = await _specialOfferService.GetAllSpecialOfferAsync();
    //        return View(values);
    //    }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
