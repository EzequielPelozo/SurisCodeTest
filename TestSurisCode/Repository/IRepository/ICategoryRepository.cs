using TestSurisCode.Models;

namespace TestSurisCode.Repository.IRepository
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
    }
}
