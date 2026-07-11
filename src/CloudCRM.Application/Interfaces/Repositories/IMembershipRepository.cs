using CloudCRM.Core.Entities;

namespace CloudCRM.Application.Interfaces.Repositories;

public interface IMembershipRepository
{
    Task<List<Membership>> GetAllAsync();
    Task<Membership?> GetByIdAsync(int id);
    Task AddAsync(Membership membership);
    void Update(Membership membership);
    void Delete(Membership membership);
    Task SaveChangesAsync();

}