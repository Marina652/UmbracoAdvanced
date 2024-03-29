﻿using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;

namespace UmbracoProject1.NotificationsHandlers;

public class ContentPublishedNotificationHandler : INotificationHandler<ContentPublishedNotification>
{
    ILogger<ContentPublishedNotificationHandler> _logger;

    public ContentPublishedNotificationHandler(ILogger<ContentPublishedNotificationHandler> logger)
    {
        _logger = logger;
    }

    public void Handle(ContentPublishedNotification notification)
    {
        var publishedEntities = notification.PublishedEntities;

        foreach (var entity in publishedEntities)
        {
            _logger.LogInformation("Published node with id: {nodeId}", entity.Id);
        }
    }
}
