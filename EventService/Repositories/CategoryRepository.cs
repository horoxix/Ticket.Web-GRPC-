using EventService.DbContexts;
using EventService.Entities;
using EventService.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventService.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly EventCatalogDbContext _eventCatalogDbContext;

        public CategoryRepository(EventCatalogDbContext eventCatalogDbContext)
        {
            _eventCatalogDbContext = eventCatalogDbContext;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _eventCatalogDbContext.Categories.ToListAsync();
        }
    }
}
