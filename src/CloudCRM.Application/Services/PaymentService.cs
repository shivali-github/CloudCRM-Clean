using CloudCRM.Application.Interfaces.Repositories;
using CloudCRM.Application.Interfaces.Services;
using CloudCRM.Core.Entities;

namespace CloudCRM.Application.Services;

public class PaymentService : IPaymentService
{
    private readonly IPaymentRepository _paymentRepository;

    public PaymentService(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    public async Task<List<Payment>> GetAllPaymentsAsync()
    {
        return await _paymentRepository.GetAllAsync();
    }

    public async Task<Payment?> GetPaymentByIdAsync(int id)
    {
        return await _paymentRepository.GetByIdAsync(id);
    }

    public async Task AddPaymentAsync(Payment payment)
    {
        await _paymentRepository.AddAsync(payment);

        await _paymentRepository.SaveChangesAsync();
    }

    public async Task UpdatePaymentAsync(Payment payment)
    {
        _paymentRepository.Update(payment);

        await _paymentRepository.SaveChangesAsync();
    }

    public async Task DeletePaymentAsync(int id)
    {
        var payment =
            await _paymentRepository.GetByIdAsync(id);

        if (payment == null)
            return;

        _paymentRepository.Delete(payment);

        await _paymentRepository.SaveChangesAsync();
    }
}