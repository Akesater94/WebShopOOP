using Entities.Models;
using Services.Interfaces;

namespace Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    public async Task<User?> GetUserByUserNameAsync(string userName)
    {
        return await userRepository.GetUserByUserNameAsync(userName);
    }
}
