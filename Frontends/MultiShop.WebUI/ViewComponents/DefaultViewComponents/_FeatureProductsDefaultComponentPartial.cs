﻿using Microsoft.AspNetCore.Mvc;
namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _FeatureProductsDefaultComponentPartial : ViewComponent
    {
        //private readonly IProductService _productService;
        //public _FeatureProductsDefaultComponentPartial(IProductService productService)
        //{
        //    _productService = productService;
        //}
        //public async Task<IViewComponentResult> InvokeAsync()
        //{
        //    var values = await _productService.GetAllProductAsync();
        //    return View(values);
        //}

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
