using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.Mapping;
using UmbracoProject1.Mappings;
using UmbracoProject1.Repository;
using UmbracoProject1.Routing;
using UmbracoProject1.umbraco.Services;

namespace UmbracoProject1.Composers;

public class ProductComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.UrlSegmentProviders().Insert<ProductPageUrlSegmentProvider>();

        builder.Services.AddScoped<IProductService, ProductService>();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();

        builder.Services.AddScoped<IContactRequestService, ContactRequestService>();

        //builder.Services.Configure<UmbracoPipelineOptions>(options => { });

        builder.WithCollectionBuilder<MapDefinitionCollectionBuilder>()
            .Add<ProductMapping>();
    }
}
