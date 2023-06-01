﻿using Microsoft.EntityFrameworkCore.Migrations;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Migrations;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Core.Scoping;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Infrastructure.Migrations;
using Umbraco.Cms.Infrastructure.Migrations.Upgrade;
using UmbracoProject1.umbraco.models.NPoco.Migrations;

namespace UmbracoProject1.NotificationsHandlers;

public class RunContactRequestMigration : INotificationHandler<UmbracoApplicationStartingNotification>
{
    private readonly IMigrationPlanExecutor _migrationPlanExecutor;
    private readonly ICoreScopeProvider _coreScopeProvider;
    private readonly IKeyValueService _keyValueService;

    private readonly IRuntimeState _runtimeState;

    public RunContactRequestMigration(
        IMigrationPlanExecutor migrationPlanExecutor, 
        ICoreScopeProvider coreScopeProvider, 
        IKeyValueService keyValueService, 
        IRuntimeState runtimeState)
    {
        _migrationPlanExecutor = migrationPlanExecutor;
        _coreScopeProvider = coreScopeProvider;
        _keyValueService = keyValueService;
        _runtimeState = runtimeState;
    }

    public void Handle(UmbracoApplicationStartingNotification notification)
    {
        if(_runtimeState.Level < Umbraco.Cms.Core.RuntimeLevel.Run)
        {
            return;
        }

        var migrationPlan = new MigrationPlan("ContactRequests");

        migrationPlan.From(string.Empty)
            .To<AddContactRequestTable>("contactrequest-db");

        var upgrader = new Upgrader(migrationPlan);
        upgrader.Execute(_migrationPlanExecutor, _coreScopeProvider, _keyValueService);
    }
}
