using Entities.Models;
using Services.Interfaces;

namespace Services;

public class UserService(IUserRepository userRepository, IUserAddressService userAddressService) : IUserService
{
    public async Task<User?> GetUserByUserNameAsync(string userName)
    {
        return await userRepository.GetUserByUserNameAsync(userName);
    }

    public async Task<List<Address>> GetAllAddressesAsync(int id)
    {
        return await userAddressService.GetAllAddressesAsync(id);
    }
}
