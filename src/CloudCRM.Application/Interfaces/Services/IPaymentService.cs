using CloudCRM.Core.Entities;

namespace CloudCRM.Application.Interfaces.Services;

public interface IPaymentService
{
    Task<List<Payment>> GetAllPaymentsAsync();

    Task<Payment?> GetPaymentByIdAsync(int id);

    Task AddPaymentAsync(Payment payment);

    Task UpdatePaymentAsync(Payment payment);

    Task DeletePaymentAsync(int id);
}