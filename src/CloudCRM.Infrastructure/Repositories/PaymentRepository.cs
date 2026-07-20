using CloudCRM.Application.Interfaces.Repositories;
using CloudCRM.Core.Entities;
using CloudCRM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CloudCRM.Infrastructure.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly ApplicationDbContext _context;

    public PaymentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Payment>> GetAllAsync()
    {
        return await _context.Payments
            .Include(p => p.Membership)
            .ThenInclude(m => m.Customer)
            .ToListAsync();
    }

    public async Task<Payment?> GetByIdAsync(int id)
    {
        return await _context.Payments
            .Include(p => p.Membership)
            .ThenInclude(m => m.Customer)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task AddAsync(Payment payment)
    {
        await _context.Payments.AddAsync(payment);
    }

    public void Update(Payment payment)
    {
        _context.Payments.Update(payment);
    }

    public void Delete(Payment payment)
    {
        _context.Payments.Remove(payment);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}