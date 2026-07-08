using CloudCRM.Core.Entities;

namespace CloudCRM.Application.Interfaces.Services;

public interface IMembershipTypeService
{
    Task<List<MembershipType>> GetAllMembershipTypesAsync();

    Task<MembershipType?> GetMembershipTypeByIdAsync(int id);

    Task AddMembershipTypeAsync(MembershipType membershipType);

    Task UpdateMembershipTypeAsync(MembershipType membershipType);

    Task DeleteMembershipTypeAsync(int id);
}