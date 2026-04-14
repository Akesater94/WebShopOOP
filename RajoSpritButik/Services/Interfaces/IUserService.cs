using Entities.Models;

namespace Services.Interfaces;

public interface IUserService
{
    Task<User?> GetUserByUserNameAsync(string userName);
    Task<List<Address>> GetAllAddressesAsync(int id);
    Task<List<User>> GetAllUsersAsync();
    Task<User?> GetUserAync(int id);
    Task UpdateAsync(User user);
    Task<List<ContactInfo>> GetContactInfosAsync(int id);
    Task RemoveUserAsync(int id);
}
