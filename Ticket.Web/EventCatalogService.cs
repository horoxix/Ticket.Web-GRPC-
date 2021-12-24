using EventService;
using Ticket.Web.Interfaces;

namespace Ticket.Web
{
    public class EventCatalogService : IEventCatalogService
    {
        private readonly Events.EventsClient _eventsClient;

        public EventCatalogService(Events.EventsClient eventsClient)
        {
            _eventsClient = eventsClient;
        }

        public async Task<IEnumerable<Event>> GetAll()
        {
            var response = await _eventsClient.GetAllAsync(new GetAllEventsRequest());
            return response.Events.ToList();
        }

        public async Task<IEnumerable<Event>> GetByCategoryId(int categoryId)
        {
            var response = await _eventsClient.GetAllByCategoryIdAsync(new GetAllEventsByCategoryIdRequest() { CategoryId = categoryId });
            return response.Events.ToList();
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            var response = await _eventsClient.GetAllCategoriesAsync(new GetAllCategoriesRequest());
            return response.Categories.ToList();
        }
    }
}
