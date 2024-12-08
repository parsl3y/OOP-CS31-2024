using Library.Entities;
using Library.Interfaces;

public class UserService : IUserService
{
    private readonly List<User> _users = new();

    public void Register(User user)
    {
        _users.Add(user);
    }

    public void Edit(User user)
    {
        var existingUser = _users.FirstOrDefault(u => u.Id == user.Id);
        if (existingUser == null)
        {
            throw new Exception($"User with ID {user.Id} does not exist.");
        }

        existingUser.Name = user.Name;
        existingUser.Email = user.Email;
        existingUser.SubscribedCategories = user.SubscribedCategories;
    }

    public void Delete(int userId)
    {
        var user = _users.FirstOrDefault(u => u.Id == userId);
        if (user == null)
        {
            throw new Exception($"User with ID {userId} does not exist.");
        }

        _users.Remove(user);
    }


    public List<User> GetAllUsers() => _users; 
}