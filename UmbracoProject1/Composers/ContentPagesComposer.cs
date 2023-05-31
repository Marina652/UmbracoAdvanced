using Umbraco.Cms.Core.Composing;
using UmbracoProject1.Routing;

namespace UmbracoProject1.Composers;

public class ContentPagesComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.ContentFinders().Append<FindContentByOldUrl>();
    }
}
