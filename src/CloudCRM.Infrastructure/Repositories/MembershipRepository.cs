using CloudCRM.Application.Interfaces.Repositories;
using CloudCRM.Core.Entities;
using CloudCRM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CloudCRM.Infrastructure.Repositories;

public class MembershipRepository : IMembershipRepository
{
    private readonly ApplicationDbContext _context;

    public MembershipRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Membership>> GetAllAsync()
    {
        return await _context.Memberships
            .Include(m => m.Customer)
            .Include(m => m.MembershipType)
            .ToListAsync();
    }

   public async Task<Membership?> GetByIdAsync(int id)
    {
        return await _context.Memberships
            .Include(m => m.Customer)
            .Include(m => m.MembershipType)
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task AddAsync(Membership membership)
    {
        await _context.Memberships.AddAsync(membership);
    }

    public void Update(Membership membership)
    {
        _context.Memberships.Update(membership);
    }

    public void Delete(Membership membership)
    {
        _context.Memberships.Remove(membership);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}