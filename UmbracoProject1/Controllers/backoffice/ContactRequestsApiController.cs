using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Mapping;
using Umbraco.Cms.Web.BackOffice.Controllers;
using UmbracoProject1.umbraco.models.NPoco;
using UmbracoProject1.umbraco.Services;
using UmbracoProject1.ViewModels.Api;

namespace UmbracoProject1.Controllers.backoffice;

public class ContactRequestsApiController : UmbracoAuthorizedApiController
{
    private readonly IContactRequestService _contactRequestService;
    private readonly IUmbracoMapper _mapper;

    public ContactRequestsApiController(IContactRequestService contactRequestService, IUmbracoMapper mapper)
    {
        _contactRequestService = contactRequestService;
        _mapper = mapper;
    }

    public async Task<IActionResult> GetTotalNumber()
    {
        return Ok(await _contactRequestService.GetTotalNumber());
    }

    public async Task<IActionResult> GetAll()
    {
        var contacts = await _contactRequestService.GetAll();

        return Ok(_mapper.MapEnumerable<ContactRequestDBModel, ContactRequestResponseItem>(contacts));
    }
}
