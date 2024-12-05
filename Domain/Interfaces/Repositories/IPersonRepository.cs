using Domain.Common;
using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IPersonRepository : IRepository<Person>
{
    Task AddAsync(Person person);
    Task UpdateAsync(Person person);
    Task<Person?> GetByIdAsync(int id);
    Task<List<Person>?> GetAll();
    Task DeleteAsync(int id);
}