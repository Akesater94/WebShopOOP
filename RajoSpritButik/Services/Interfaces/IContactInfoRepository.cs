using Entities.Models;

namespace Services.Interfaces;

public interface IContactInfoRepository
{
    Task<List<ContactInfo>> GetUserContactInfosAsync(int id);
}
