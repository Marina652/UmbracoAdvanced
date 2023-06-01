using NPoco;
using Umbraco.Cms.Infrastructure.Persistence.DatabaseAnnotations;

namespace UmbracoProject1.umbraco.models.NPoco;

[TableName("ContactRequests")]
[PrimaryKey("Id", AutoIncrement = true)]
[ExplicitColumns]
public class ContactRequestDBModel
{
    [PrimaryKeyColumn(AutoIncrement = true, IdentitySeed = 1)]
    [Column("Id")]
    public int Id { get; set; }

    [Column("Name")]
    public required string Name { get; set; }

    [Column("Email")] 
    public required string Email { get; set; }

    [Column("Message")]
    [SpecialDbType(SpecialDbTypes.NVARCHARMAX)]
    public required string Message { get; set; }

}
