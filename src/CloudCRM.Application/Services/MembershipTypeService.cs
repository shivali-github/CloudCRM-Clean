using CloudCRM.Application.Interfaces.Repositories;
using CloudCRM.Application.Interfaces.Services;
using CloudCRM.Core.Entities;

namespace CloudCRM.Application.Services;

public class MembershipTypeService : IMembershipTypeService
{
    private readonly IMembershipTypeRepository _membershipTypeRepository;

    public MembershipTypeService(IMembershipTypeRepository membershipTypeRepository)
    {
        _membershipTypeRepository = membershipTypeRepository;
    }

    public async Task<List<MembershipType>> GetAllMembershipTypesAsync()
    {
        return await _membershipTypeRepository.GetAllAsync();
    }

    public async Task<MembershipType?> GetMembershipTypeByIdAsync(int id)
    {
        return await _membershipTypeRepository.GetByIdAsync(id);
    }

    public async Task AddMembershipTypeAsync(MembershipType membershipType)
    {
        await _membershipTypeRepository.AddAsync(membershipType);
        await _membershipTypeRepository.SaveChangesAsync();
    }

    public async Task UpdateMembershipTypeAsync(MembershipType membershipType)
    {
        _membershipTypeRepository.Update(membershipType);
        await _membershipTypeRepository.SaveChangesAsync();
    }

    public async Task DeleteMembershipTypeAsync(int id)
    {
        var membershipType = await _membershipTypeRepository.GetByIdAsync(id);

        if (membershipType == null)
        {
            return;
        }

        _membershipTypeRepository.Delete(membershipType);
        await _membershipTypeRepository.SaveChangesAsync();
    }
}   