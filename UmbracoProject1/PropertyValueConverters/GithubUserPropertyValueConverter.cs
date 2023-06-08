using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PropertyEditors;
using UmbracoProject1.umbraco.models.DTOs;

namespace UmbracoProject1.PropertyValueConverters;

public class GithubUserPropertyValueConverter : PropertyValueConverterBase
{
    public override bool IsConverter(IPublishedPropertyType propertyType) =>
        propertyType.EditorAlias.Equals("githubUser");

    public override object? ConvertIntermediateToObject(IPublishedElement owner, IPublishedPropertyType propertyType, PropertyCacheLevel referenceCacheLevel, object? source, bool preview)
    {
        if (source == null) return null;

        return System.Text.Json.JsonSerializer.Deserialize<GithubUserDTO>((string)source);
    }
}
