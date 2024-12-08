using Library.Entities;

namespace Library.Interfaces;

public interface IUserService
{
    void Register(User user);
    void Edit(User user);
    void Delete(int userId);
    List<User> GetAllUsers();
}