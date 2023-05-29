using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.PublishedModels;
using UmbracoProject1.umbraco.models.Records;

namespace UmbracoProject1.umbraco;

public class ProductService : IProductService
{
    private readonly IUmbracoContextFactory _umbracoContextFactory;

    public ProductService(IUmbracoContextFactory umbracoContextFactory)
    {
        _umbracoContextFactory = umbracoContextFactory;
    }

    public List<ProductResponseItem> GetUmbracoProducts(int number)
    {
        var final = new List<ProductResponseItem>();

        using (var cref = _umbracoContextFactory.EnsureUmbracoContext())
        {
            var contentCashe = cref.UmbracoContext.Content;

            var products = contentCashe
                ?.GetAtRoot()
                ?.FirstOrDefault(x => x.ContentType.Alias == Home.ModelTypeAlias)
                ?.Descendant<Products>()
                ?.Children<Product>()
                ?.Take(number);

            if (products != null && products.Any())
            {
                final = products.Select(x => new ProductResponseItem(x.Id, x?.ProductName ?? x.Name, x?.Photos?.Url() ?? "#")).ToList();
            }

            return final;
        }
    }
}
