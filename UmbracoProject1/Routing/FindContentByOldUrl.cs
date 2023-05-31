using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace UmbracoProject1.Routing;

public class FindContentByOldUrl : IContentFinder
{
    private readonly IUmbracoContextAccessor _umbracoContextAccessor;

    public FindContentByOldUrl(IUmbracoContextAccessor umbracoContextAccessor)
    {
        _umbracoContextAccessor = umbracoContextAccessor;
    }

    public Task<bool> TryFindContent(IPublishedRequestBuilder request)
    {
        var path = request.Uri.AbsoluteUri;
        var cache = _umbracoContextAccessor.GetRequiredUmbracoContext().Content;

        var match = cache.GetAtRoot().FirstOrDefault()
            ?.Descendants<ContentPage>()
            .FirstOrDefault(x => x.Value<string>("oldUrl") == path);

        if (match == null)
        {
            return Task.FromResult(false);
        }

        request.SetRedirectPermanent(match.Url());

        return Task.FromResult(true);
    }
}
