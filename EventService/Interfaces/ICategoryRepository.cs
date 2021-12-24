using EventService.Entities;

namespace EventService.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategories();
    }
}
