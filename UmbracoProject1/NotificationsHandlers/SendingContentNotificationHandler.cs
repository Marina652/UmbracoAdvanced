using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Models.ContentEditing;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Core.Security;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace UmbracoProject1.NotificationsHandlers;

public class SendingContentNotificationHandler : INotificationHandler<SendingContentNotification>
{
    private readonly IBackOfficeSecurityAccessor _backOfficeSecurityAccessor;

    public SendingContentNotificationHandler(IBackOfficeSecurityAccessor backOfficeSecurityAccessor)
    {
        _backOfficeSecurityAccessor = backOfficeSecurityAccessor;
    }

    public void Handle(SendingContentNotification notification)
    {
        var currentUser = _backOfficeSecurityAccessor.BackOfficeSecurity.CurrentUser;

        if(!currentUser.Groups.Any(x => x.Alias == Constants.Security.AdminGroupAlias))
        {
            // *Umbraco actions*
            // update/save  A
            // publish      U
            // unpublish    Z
            // create       C (create content)


            //notification.Content.AllowedActions = notification.Content.AllowedActions.Where(x => x != "U");
            //notification.Content.AllowedActions = notification.Content.AllowedActions.Where(x => x != "Z");

            var actionsToRemove = new List<string> { "Z", "A"};

            notification.Content.AllowedActions = notification.Content.AllowedActions.Where(x => !actionsToRemove.Contains(x));
            notification.Content.AllowPreview = false;
        }

        SetDefaultValueForPublicationDate(notification);
    }

    private void SetDefaultValueForPublicationDate(SendingContentNotification notification)
    {
        if (notification.Content.ContentTypeAlias != Blogpost.ModelTypeAlias)
        {
            return;
        }

        foreach (var variant in notification.Content.Variants)
        {
            var publishedDateProperty = variant.Tabs.SelectMany(f => f.Properties)
                .FirstOrDefault(f => f.Alias.InvariantEquals("publicationDate"));

            if (variant.State != ContentSavedState.NotCreated)
            {
                return;
            }

            if (publishedDateProperty != null)
            {
                publishedDateProperty.Value = DateTime.Now;
            }
        }
    }
}
