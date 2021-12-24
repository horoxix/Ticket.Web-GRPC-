using EventService.DbContexts;
using EventService.Entities;
using EventService.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventService.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly EventCatalogDbContext _eventCatalogDbContext;

        public EventRepository(EventCatalogDbContext eventCatalogDbContext)
        {
            _eventCatalogDbContext = eventCatalogDbContext;
        }

        public async Task<IEnumerable<Event>> GetEvents(int categoryId)
        {
            return await _eventCatalogDbContext.Events
                .Include(x => x.Category)
                .Where(x => (x.CategoryId == categoryId || categoryId == 0)).ToListAsync();
        }

        public async Task<Event> GetEventById(int eventId)
        {
            return await _eventCatalogDbContext.Events
                .FirstOrDefaultAsync(x => x.EventId == eventId);
        }
    }
}
