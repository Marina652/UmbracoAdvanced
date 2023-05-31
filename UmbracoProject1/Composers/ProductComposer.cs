using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.Mapping;
using Umbraco.Cms.Web.Common.ApplicationBuilder;
using UmbracoProject1.Mappings;
using UmbracoProject1.Repository;
using UmbracoProject1.umbraco;

namespace UmbracoProject1.Composers;

public class ProductComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.Services.AddScoped<IProductService, ProductService>();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();

        //builder.Services.Configure<UmbracoPipelineOptions>(options => { });

        builder.WithCollectionBuilder<MapDefinitionCollectionBuilder>()
            .Add<ProductMapping>();
    }
}
