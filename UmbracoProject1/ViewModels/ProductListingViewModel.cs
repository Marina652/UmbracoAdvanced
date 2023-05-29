using UmbracoProject1.umbraco.models.Records;

namespace UmbracoProject1.ViewModels;

public class ProductListingViewModel
{
    public List<ProductResponseItem> Products { get; set; } = new List<ProductResponseItem>();
}
