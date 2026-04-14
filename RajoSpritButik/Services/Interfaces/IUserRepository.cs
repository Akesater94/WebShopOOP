using Entities.Models;

namespace Services.Interfaces;

public interface IUserRepository
{
    Task<User?> GetUserByUserNameAsync(string userName);
    Task<List<User>> GetAllUsersAsync();
    Task<User?> GetUserAsync(int id);
    Task UpdateAsync(User user);
    Task RemoveUserAsync(int id);
}
