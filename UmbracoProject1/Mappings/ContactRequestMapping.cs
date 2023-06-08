using Umbraco.Cms.Core.Mapping;
using UmbracoProject1.umbraco.models.NPoco;
using UmbracoProject1.ViewModels.Api;

namespace UmbracoProject1.Mappings;

public class ContactRequestMapping : IMapDefinition
{
    public void DefineMaps(IUmbracoMapper mapper)
    {
        mapper.Define<ContactRequestDBModel, ContactRequestResponseItem>((source, context) => new ContactRequestResponseItem(), Map);
    }

    private void Map (ContactRequestDBModel source, ContactRequestResponseItem target, MapperContext mapperContext)
    {
        target.Id = source.Id;
        target.Name = source.Name;
        target.Email = source.Email;
        target.Message = source.Message;
    }
}
