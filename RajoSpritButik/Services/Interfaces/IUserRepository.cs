using Entities.Models;

namespace Services.Interfaces;

public interface IUserRepository
{
    Task<User?> GetUserByUserNameAsync(string userName);
}
