using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace EFCore.Repositories;

public class ContactInfoRepository(RajoDbContext context) : IContactInfoRepository
{
    public async Task<List<ContactInfo>> GetUserContactInfosAsync(int id)
    {
        return await context.ContactInfos
            .Where(ci => ci.UserId == id)
            .Include(ci => ci.ContactType)
            .ToListAsync();
    }
}
