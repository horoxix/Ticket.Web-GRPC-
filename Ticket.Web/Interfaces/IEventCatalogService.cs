
using EventService;

namespace Ticket.Web.Interfaces
{
    public interface IEventCatalogService
    {
        Task<IEnumerable<Event>> GetAll();
        Task<IEnumerable<Event>> GetByCategoryId(int categoryId);
        Task<IEnumerable<Category>> GetCategories();
    }
}
