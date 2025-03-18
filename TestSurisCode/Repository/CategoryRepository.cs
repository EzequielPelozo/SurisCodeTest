using TestSurisCode.Data;
using TestSurisCode.Models;
using TestSurisCode.Repository.IRepository;

namespace TestSurisCode.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public ICollection<Category> GetCategories()
        {
            return _db.Categories.OrderBy(c => c.Name).ToList();
        }
    }
}
