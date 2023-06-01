using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;
using Umbraco.SampleSite;
using UmbracoProject1.umbraco.Services;

namespace UmbracoProject1.Controllers;

public class TutorialContactController : SurfaceController
{
    private readonly IContactRequestService _contactRequestService;

    public TutorialContactController(IContactRequestService contactRequestService, IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider) : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
    {
        _contactRequestService = contactRequestService;
    }

    public async Task<IActionResult> Submit(ContactFormViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return CurrentUmbracoPage();
        }

        await _contactRequestService.SaveContactRequest(model.Name, model.Email, model.Message);

        ITempDataDictionary tempData = TempData;
        tempData["Message"] = "Submitted successfully";
        return RedirectToCurrentUmbracoPage(QueryString.Create("submit", "true"));
    }

    // https://localhost:44319/umbraco/surface/tutorialcontact/getcontact?id=1
    public async Task<IActionResult> GetContact(int id)
    {
        var contact = await _contactRequestService.GetById(id);

        if (contact == null)
        {
            return NotFound(new {error = "Contact not found"});
        }

        return Ok(contact);
    }
}
