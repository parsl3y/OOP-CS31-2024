using Library.Entities;

public interface ILibraryService
{
    void AddBook(Book book);
    void AddCategory(Category category);
    void RegisterUser(User user);
}