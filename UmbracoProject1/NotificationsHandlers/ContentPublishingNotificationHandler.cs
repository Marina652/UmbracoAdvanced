using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;

namespace UmbracoProject1.NotificationsHandlers;

public class ContentPublishingNotificationHandler : INotificationHandler<ContentPublishingNotification>
{
    ILogger<ContentPublishingNotificationHandler> _logger;

    public ContentPublishingNotificationHandler(ILogger<ContentPublishingNotificationHandler> logger)
    {
        _logger = logger;
    }

    public void Handle(ContentPublishingNotification notification)
    {
        var publishedEntities = notification.PublishedEntities;

        foreach(var entity in publishedEntities)
        {
            _logger.LogInformation("Publishing node with id: {nodeId}", entity.Id);
        }
    }
}
