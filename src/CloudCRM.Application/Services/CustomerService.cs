using CloudCRM.Application.Interfaces.Repositories;
using CloudCRM.Application.Interfaces.Services;
using CloudCRM.Core.Entities;

namespace CloudCRM.Application.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<List<Customer>> GetAllCustomersAsync()
    {
        return await _customerRepository.GetAllAsync();
    }

    public async Task<Customer?> GetCustomerByIdAsync(int id)
    {
        return await _customerRepository.GetByIdAsync(id);
    }

    public async Task CreateCustomerAsync(Customer customer)
    {
        await _customerRepository.AddAsync(customer);
        await _customerRepository.SaveChangesAsync();
        // We'll improve this later
        // when we introduce Unit of Work.
    }

    public async Task UpdateCustomerAsync(Customer customer)
    {
        _customerRepository.Update(customer);
        await _customerRepository.SaveChangesAsync();

        await Task.CompletedTask;
    }

    public async Task DeleteCustomerAsync(int id)
    {
        var customer = await _customerRepository.GetByIdAsync(id);

        if (customer is null)
            return;

        _customerRepository.Delete(customer);
        await _customerRepository.SaveChangesAsync();
    }
}