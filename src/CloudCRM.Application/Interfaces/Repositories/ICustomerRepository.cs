using CloudCRM.Core.Entities;

namespace CloudCRM.Application.Interfaces.Repositories;

public interface ICustomerRepository
{
    Task<List<Customer>> GetAllAsync();

    Task<Customer?> GetByIdAsync(int id);

    Task AddAsync(Customer customer);

    void Update(Customer customer);

    void Delete(Customer customer);

    Task SaveChangesAsync();
}