namespace Library.Entities;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public List<Category> SubscribedCategories { get; set; } = new();

    public void SubscribeToCategory(Category category)
    {
        if (!SubscribedCategories.Contains(category))
            SubscribedCategories.Add(category);
    }

    public void UnsubscribeFromCategory(Category category)
    {
        if (SubscribedCategories.Contains(category))
            SubscribedCategories.Remove(category);
    }
}