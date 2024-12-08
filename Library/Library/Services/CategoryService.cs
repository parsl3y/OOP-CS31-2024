using Library.Entities;
using Library.Interfaces;

public class CategoryService : ICategoryService
{
    private readonly List<Category> _categories = new();

    public void Add(Category category)
    {
        _categories.Add(category);
    }

    public void Edit(Category category)
    {
        var existingCategory = _categories.FirstOrDefault(c => c.Id == category.Id);
        if (existingCategory == null)
        {
            throw new Exception($"Category with ID {category.Id} does not exist.");
        }

        existingCategory.Name = category.Name;
    }

    public void Delete(int categoryId)
    {
        var category = _categories.FirstOrDefault(c => c.Id == categoryId);
        if (category == null)
        {
            throw new Exception($"Category with ID {categoryId} does not exist.");
        }

        _categories.Remove(category);
    }

    public List<Category> GetAllCategories() => _categories;
}