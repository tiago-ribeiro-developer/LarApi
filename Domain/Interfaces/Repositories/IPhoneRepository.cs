using Domain.Common;
using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IPhoneRepository : IRepository<Phone>
{
    Task AddAsync(Phone phone);
    Task UpdateAsync(Phone phone);
    Task<Phone?> GetByIdAsync(int id);
    Task<Phone?> GetByNumberAndPersonAsync(string number, Person person);
    Task<List<Phone>?> GetAll(Person person);
    Task DeleteAsync(int id);
}