using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace EFCore.Repositories;

public class UserRepository(RajoDbContext context) : IUserRepository
{
    public async Task<User?> GetUserByUserNameAsync(string userName)
    {
        return await context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.UserName == userName);
    }
}
