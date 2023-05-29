using UmbracoProject1.umbraco.models.Records;

namespace UmbracoProject1.umbraco;

public interface IProductService
{
    List<ProductResponseItem> GetUmbracoProducts(int number);
}
