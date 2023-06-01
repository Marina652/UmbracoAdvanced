using Umbraco.Cms.Infrastructure.Migrations;

namespace UmbracoProject1.umbraco.models.NPoco.Migrations;

public class AddContactRequestTable : MigrationBase
{
    public AddContactRequestTable(IMigrationContext context) : base(context)
    {
    }

    protected override void Migrate()
    {
        if (!TableExists("ContactRequests"))
        {
            Create.Table<ContactRequestDBModel>().Do();

            Logger.LogDebug("Database table {DbTable} migrated successfully", "ContactRequests");
        }
    }
}
