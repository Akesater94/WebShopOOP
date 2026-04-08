using Entities.Models;

namespace Services.Interfaces;

public interface IUserService
{
    Task<User?> GetUserByUserNameAsync(string userName);
}
