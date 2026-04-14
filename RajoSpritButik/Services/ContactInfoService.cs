using Entities.Models;
using Services.Interfaces;

namespace Services;

public class ContactInfoService(IContactInfoRepository contactInfoRepository) : IContactInfoService
{
    public async Task<List<ContactInfo>> GetUserContactInfosAsync(int id)
    {
        return await contactInfoRepository.GetUserContactInfosAsync(id);
    }
}
