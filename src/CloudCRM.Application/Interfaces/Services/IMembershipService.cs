using CloudCRM.Core.Entities;

namespace CloudCRM.Application.Interfaces.Services;

public interface IMembershipService
{
    Task<List<Membership>> GetAllMembershipsAsync();
    Task<Membership?> GetMembershipByIdAsync(int id);
    Task AddMembershipAsync(Membership membership);
    Task UpdateMembershipAsync(Membership membership);
    Task DeleteMembershipAsync(int id);

}