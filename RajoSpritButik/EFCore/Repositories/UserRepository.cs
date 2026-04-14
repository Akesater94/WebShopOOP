using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace EFCore.Repositories;

public class UserRepository(RajoDbContext context) : IUserRepository
{
    public async Task<List<User>> GetAllUsersAsync()
    {
        return await context.Users
            .Include(u => u.UserAddresses)
            .ThenInclude(ua => ua.Address)
            .Include(u => u.Role)
            .Include(u => u.ContactInfos)
            .ToListAsync();
    }

    public async Task<User?> GetUserAsync(int id)
    {
        return await context.Users
            .Include(u => u.UserAddresses)
            .ThenInclude(ua => ua.Address)
            .Include(u => u.Role)
            .Include(u => u.ContactInfos)
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User?> GetUserByUserNameAsync(string userName)
    {
        return await context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.UserName == userName);
    }

    public async Task RemoveUserAsync(int id)
    {
        User? user = await GetUserAsync(id);
        if (user != null)
        {
            context.Remove(user);
            await context.SaveChangesAsync();
        }
    }

    public async Task UpdateAsync(User user)
    {
        context.Update(user);
        try
        {
            await context.SaveChangesAsync();
        }
        catch
        {

        }
    }
}
