using EventService.Entities;

namespace EventService.Interfaces
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetEvents(int categoryId);
        Task<Event> GetEventById(int eventId);
    }
}
