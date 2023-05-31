using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Cms.Core.Strings;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace UmbracoProject1.Routing;

public class ProductPageUrlSegmentProvider : IUrlSegmentProvider
{
    private readonly IUrlSegmentProvider _provider;
    private readonly IPublishedSnapshotAccessor _publishedSnapshotAccessor;

    private readonly string _SKUAlias;

    public ProductPageUrlSegmentProvider(IShortStringHelper stringHelper, IPublishedSnapshotAccessor publishedSnapshotAccessor)
    {
        _provider = new DefaultUrlSegmentProvider(stringHelper);
        _publishedSnapshotAccessor = publishedSnapshotAccessor;

        _SKUAlias = Product.GetModelPropertyType(_publishedSnapshotAccessor, x => x.Sku).Alias;
    }

    public string? GetUrlSegment(Umbraco.Cms.Core.Models.IContentBase content, string? culture = null)
    {
        // Only apply this rule for product pages
        if(content.ContentType.Alias != Product.ModelTypeAlias)
        {
            return null;
        }

        var currentSegment = _provider.GetUrlSegment(content, culture);
        var productSKU = content.GetValue<string>(_SKUAlias)?.ToLower() ?? string.Empty;

        return !string.IsNullOrEmpty(productSKU) ? $"{currentSegment}--{productSKU}" : currentSegment;
    }
}
