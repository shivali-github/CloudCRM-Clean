using CloudCRM.Core.Entities;

namespace CloudCRM.Application.Interfaces.Repositories;

public interface IPaymentRepository
{
    Task<List<Payment>> GetAllAsync();

    Task<Payment?> GetByIdAsync(int id);

    Task AddAsync(Payment payment);

    void Update(Payment payment);

    void Delete(Payment payment);

    Task SaveChangesAsync();
}