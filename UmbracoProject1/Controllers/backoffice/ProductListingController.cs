using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.BackOffice.Controllers;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace UmbracoProject1.Controllers.backoffice;

public class ProductListingController : UmbracoAuthorizedApiController
{
    IUmbracoContextFactory _umbracoContextFactory;

    // /umbraco/backoffice/api/Productlisting/GetProducts?number=X
    public ProductListingController(IUmbracoContextFactory umbracoContextFactory)
    {
        _umbracoContextFactory = umbracoContextFactory;
    }

    private record ProductResponse(int id, string name, string imageUrl);

    public IActionResult GetProducts(int number)
    {
        var final = new List<ProductResponse>();

        using(var cref = _umbracoContextFactory.EnsureUmbracoContext())
        {
            var contentCashe = cref.UmbracoContext.Content;

            var products = contentCashe
                ?.GetAtRoot()
                ?.FirstOrDefault(x => x.ContentType.Alias == Home.ModelTypeAlias)
                ?.Descendant<Products>()
                ?.Children<Product>()
                ?.Take(number);

            if(products != null && products.Any())
            {
                final = products.Select(x => new ProductResponse(x.Id, x?.ProductName ?? x.Name, x?.Photos?.Url() ?? "#")).ToList();
            }

            return Ok(final);
        }
    }

}
