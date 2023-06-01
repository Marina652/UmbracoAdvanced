using Umbraco.Cms.Core.Notifications;
using UmbracoProject1.NotificationsHandlers;

namespace UmbracoProject1.Extensions;

public static class UmbracoBuilderExtensions
{ 
    public static IUmbracoBuilder AddContactRequestTable(this IUmbracoBuilder builder)
    {
        builder.AddNotificationHandler<UmbracoApplicationStartingNotification, RunContactRequestMigration>();

        return builder;
    }
}
