using Library.Entities;

namespace Library.Interfaces;

public interface ICategoryService
{
    void Add(Category category);
    void Edit(Category category);
    void Delete(int categoryId);
    List<Category> GetAllCategories();
}