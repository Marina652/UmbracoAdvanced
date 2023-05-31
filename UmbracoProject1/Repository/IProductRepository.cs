using Umbraco.Cms.Web.Common.PublishedModels;
using UmbracoProject1.umbraco.models.ProductItems;

namespace UmbracoProject1.Repository;

public interface IProductRepository
{
    List<Product> GetProducts(string? productSKU, decimal? maxPrice);

    Product Create(ProductCreationItem product);

    bool Delete(int id);
    Product Get(int id);
}
