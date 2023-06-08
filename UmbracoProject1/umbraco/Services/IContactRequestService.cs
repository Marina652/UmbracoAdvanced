using UmbracoProject1.umbraco.models.NPoco;

namespace UmbracoProject1.umbraco.Services;

public interface IContactRequestService
{
    Task<ContactRequestDBModel?> GetById(int id);
    Task<int> SaveContactRequest(string name, string email, string message);

    Task<List<ContactRequestDBModel>> GetAll();
    Task<int> GetTotalNumber();
}
