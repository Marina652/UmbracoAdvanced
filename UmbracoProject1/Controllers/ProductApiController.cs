using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Validation.AspNetCore;
using Umbraco.Cms.Core.Mapping;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Web.Common.PublishedModels;
using UmbracoProject1.Repository;
using UmbracoProject1.umbraco.models.ProductItems;
using UmbracoProject1.ViewModels.Api;

namespace UmbracoProject1.Controllers;

// /umbraco/api/productapi/{action}
[Route("api/products")]
[Authorize(AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme)]
public class ProductApiController : UmbracoApiController
{
    private readonly IProductRepository _productRepository; 
    private readonly IUmbracoMapper _mapper;

    public ProductApiController(IProductRepository productRepository, IUmbracoMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public record ProductReadRequest(string? productSKU, decimal? maxPrice);

    [HttpGet]
    public IActionResult Read([FromQuery] ProductReadRequest request)
    {
        var mapped = _mapper.MapEnumerable<Product, ProductApiResponseItem>(_productRepository.GetProducts(request.productSKU, request.maxPrice));

        return Ok(mapped);
    }

    [HttpPost]
    public IActionResult Create([FromBody]ProductCreationItem request)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest("Fields error");
        }

        var product = _productRepository.Create(request);

        if(product == null)
        {
            StatusCode(StatusCodes.Status500InternalServerError, $"Error creating product");
        }

        return Ok(_mapper.Map<Product, ProductApiResponseItem>(product));
    }

    [HttpPut]
    public IActionResult Update()
    {
        return Ok("Update");
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var result = _productRepository.Delete(id);

        return result ? Ok() : StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting product with id {id}");
    }
}
