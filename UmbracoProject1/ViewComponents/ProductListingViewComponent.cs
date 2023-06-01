using Microsoft.AspNetCore.Mvc;
using UmbracoProject1.umbraco.Services;
using UmbracoProject1.ViewModels;

namespace UmbracoProject1.ViewComponents;

public class ProductListingViewComponent : ViewComponent
{
    private readonly IProductService _productService;

    public ProductListingViewComponent(IProductService productService)
    {
        _productService = productService;
    }

    public IViewComponentResult Invoke(int number)
    {
        var vm = new ProductListingViewModel()
        {
            Products = _productService.GetUmbracoProducts(number),
        };

        return View(vm);
    }
}
