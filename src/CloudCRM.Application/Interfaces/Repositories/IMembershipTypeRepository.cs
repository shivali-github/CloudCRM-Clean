using CloudCRM.Core.Entities;

namespace CloudCRM.Application.Interfaces.Repositories;

public interface IMembershipTypeRepository
{
    Task<List<MembershipType>> GetAllAsync();

    Task<MembershipType?> GetByIdAsync(int id);

    Task AddAsync(MembershipType membershipType);

    void Update(MembershipType membershipType);

    void Delete(MembershipType membershipType);

    Task SaveChangesAsync();
}