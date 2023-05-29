using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.BackOffice.Controllers;
using Umbraco.Cms.Web.Common.PublishedModels;
using UmbracoProject1.umbraco;

namespace UmbracoProject1.Controllers.backoffice;

public class ProductListingController : UmbracoAuthorizedApiController
{
    private readonly IProductService _productService;

    // /umbraco/backoffice/api/Productlisting/GetProducts?number=X
    public ProductListingController(IProductService productService)
    {
        _productService = productService;
    }

    public IActionResult GetProducts(int number)
    {
        return Ok(_productService.GetUmbracoProducts(number));
    }

}
