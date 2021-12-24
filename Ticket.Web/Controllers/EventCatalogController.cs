using Microsoft.AspNetCore.Mvc;
using Ticket.Web.Interfaces;
using Ticket.Web.Models;
using Ticket.Web.Models.Views;

namespace Ticket.Web.Controllers
{
    public class EventCatalogController : Controller
    {
        private readonly IEventCatalogService eventCatalogService;
        private readonly Settings settings;

        public EventCatalogController(IEventCatalogService eventCatalogService, Settings settings)
        {
            this.eventCatalogService = eventCatalogService;
            this.settings = settings;
        }

        public async Task<IActionResult> Index(int categoryId)
        {
            var getCategories = eventCatalogService.GetCategories();
            var getEvents = categoryId == 0 ? eventCatalogService.GetAll() : eventCatalogService.GetByCategoryId(categoryId);

            await Task.WhenAll(new Task[] { getCategories, getEvents });

            return View(
                new EventListModel
                {
                    Events = getEvents.Result,
                    Categories = getCategories.Result,
                    NumberOfItems = 0,
                    SelectedCategory = categoryId
                }
            );
        }
    }
}
