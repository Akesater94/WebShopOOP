using Entities.Models;

namespace Services.Interfaces;

public interface IContactInfoService
{
    Task<List<ContactInfo>> GetUserContactInfosAsync(int id);
}
