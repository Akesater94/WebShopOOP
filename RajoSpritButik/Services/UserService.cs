using Entities.Models;
using Services.Interfaces;

namespace Services;

public class UserService(IUserRepository userRepository, IUserAddressService userAddressService, IContactInfoService contactInfoService) : IUserService
{
    public async Task<User?> GetUserByUserNameAsync(string userName)
    {
        return await userRepository.GetUserByUserNameAsync(userName);
    }

    public async Task<List<Address>> GetAllAddressesAsync(int id)
    {
        return await userAddressService.GetAllAddressesAsync(id);
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        return await userRepository.GetAllUsersAsync();
    }

    public async Task<User?> GetUserAync(int id)
    {
        return await userRepository.GetUserAsync(id);
    }

    public async Task UpdateAsync(User user)
    {
        await userRepository.UpdateAsync(user);
    }

    public async Task<List<ContactInfo>> GetContactInfosAsync(int id)
    {
        return await contactInfoService.GetUserContactInfosAsync(id);
    }

    public async Task RemoveUserAsync(int id)
    {
        await userRepository.RemoveUserAsync(id);
    }
}
