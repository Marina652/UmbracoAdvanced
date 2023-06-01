using UmbracoProject1.umbraco.models.Records;

namespace UmbracoProject1.umbraco.Services;

public interface IProductService
{
    List<ProductResponseItem> GetUmbracoProducts(int number);
}
