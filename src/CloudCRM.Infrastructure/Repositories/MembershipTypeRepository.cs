using CloudCRM.Application.Interfaces.Repositories;
using CloudCRM.Core.Entities;
using CloudCRM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CloudCRM.Infrastructure.Repositories;

public class MembershipTypeRepository : IMembershipTypeRepository
{
    private readonly ApplicationDbContext _context;

    public MembershipTypeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<MembershipType>> GetAllAsync()
    {
        return await _context.MembershipTypes.ToListAsync();
    }

    public async Task<MembershipType?> GetByIdAsync(int id)
    {
        return await _context.MembershipTypes
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task AddAsync(MembershipType membershipType)
    {
        await _context.MembershipTypes.AddAsync(membershipType);
    }

    public void Update(MembershipType membershipType)
    {
        _context.MembershipTypes.Update(membershipType);
    }

    public void Delete(MembershipType membershipType)
    {
        _context.MembershipTypes.Remove(membershipType);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}