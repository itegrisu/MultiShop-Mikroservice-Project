using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _CategoriesDefaultComponentPartial : ViewComponent
    {
        //private readonly ICategoryService _categoryService;
        //public _CategoriesDefaultComponentPartial(ICategoryService categoryService)
        //{
        //    _categoryService = categoryService;
        //}
        //public async Task<IViewComponentResult> InvokeAsync()
        //{
        //    var values = await _categoryService.GetAllCategoryAsync();
        //    return View(values);
        //}
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
