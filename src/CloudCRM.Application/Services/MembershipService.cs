using CloudCRM.Application.Interfaces.Repositories;
using CloudCRM.Application.Interfaces.Services;
using CloudCRM.Core.Entities;

namespace CloudCRM.Application.Services;

public class MembershipService : IMembershipService
{
    private readonly IMembershipRepository _membershipRepository;

    public MembershipService(IMembershipRepository membershipRepository)
    {
        _membershipRepository = membershipRepository;
    }

    public async Task<List<Membership>> GetAllMembershipsAsync()
    {
        return await _membershipRepository.GetAllAsync();
    }

    public async Task<Membership?> GetMembershipByIdAsync(int id)
    {
        return await _membershipRepository.GetByIdAsync(id);
    }

    public async Task AddMembershipAsync(Membership membership)
    {
        await _membershipRepository.AddAsync(membership);
        await _membershipRepository.SaveChangesAsync();
    }

    public async Task UpdateMembershipAsync(Membership membership)
    {
        _membershipRepository.Update(membership);
        await _membershipRepository.SaveChangesAsync();
    }

    public async Task DeleteMembershipAsync(int id)
    {
        var membership = await _membershipRepository.GetByIdAsync(id);

        if (membership == null)
            return;

        _membershipRepository.Delete(membership);
        await _membershipRepository.SaveChangesAsync();
    }
}