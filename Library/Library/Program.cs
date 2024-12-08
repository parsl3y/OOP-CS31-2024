using Library.Entities;

namespace Library;

public class Program
{
    public static void Main()
    {
        
        var container = new LibraryContainer();

        var category = new Category { Id = 1, Name = "Science Fiction" };
        container.LibraryService.AddCategory(category);

        var category1 = new Category { Id = 2, Name = "Historical " };
        container.LibraryService.AddCategory(category1);
        
        var user = new User { Id = 1, Name = "Alice", Email = "alice@example.com" };
        container.LibraryService.RegisterUser(user);
        user.SubscribeToCategory(category);

        var book = new Book { Id = 1, Title = "Dune", Category = category };
        var book2 = new Book { Id = 1, Title = "Astro", Category = category };
        var book3 = new Book { Id = 2, Title = "History", Category = category1 };
        container.LibraryService.AddBook(book);
        container.LibraryService.AddBook(book2);
        container.LibraryService.AddBook(book3);
    }
}