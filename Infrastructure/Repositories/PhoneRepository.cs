using Dapper;
using Domain.Dto;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class PhoneRepository : IPhoneRepository
{
    protected readonly LarContext _context;

    public PhoneRepository(LarContext context)
    {
        _context = context;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public async Task AddAsync(Phone phone)
    {
        string sql = @"
        
            INSERT INTO Phones (Type, Number, PersonId)
            VALUES (@type, @number, @personId);

        ";
        
        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, PhoneDto.Factory.Create(phone)); 
        
    }

    public async Task UpdateAsync(Phone phone)
    {
        string sql = @"
        
            UPDATE Phones
            SET number = @number, type = @type
            WHERE Id = @id;


        ";
        
        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, PhoneDto.Factory.Update(phone));
        
    }

    public async Task<Phone?> GetByIdAsync(int id)
    {
        string sql = @"
        
            SELECT * FROM Phones WHERE id = @id;

        ";
        
        using var connection = _context.CreateConnection();
        var result = await connection.QueryFirstOrDefaultAsync<PhoneDto?>(sql, new { id });
        if (result == null)
            return null;
        return Phone.Factory.Create(result);
    }
    
    public async Task<Phone?> GetByNumberAndPersonAsync(string number, Person person)
    {
        string sql = @"
        
            SELECT * FROM Phones WHERE PersonId = @id AND number = @number;

        ";
        
        using var connection = _context.CreateConnection();
        var result = await connection.QueryFirstOrDefaultAsync<PhoneDto?>(sql, new { id = person.Id, number });
        if (result == null)
            return null;
        return Phone.Factory.Create(result);
    }

    public async Task<List<Phone>?> GetAll(Person person)
    {
        string sql = @"
        
            SELECT * FROM Phones WHERE PersonId = @id;

        ";
        
        using var connection = _context.CreateConnection();
        var result = (await connection.QueryAsync<PhoneDto>(sql, new { id = person.Id })).ToList();
        if (result == null)
            return null;
        return result.Select(Phone.Factory.Create).ToList();
        
    }

    public async Task DeleteAsync(int id)
    {
        string sql = @"
        
            DELETE FROM Phones WHERE Id = @id;

        ";
        
        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, PhoneDto.Factory.Delete(id));
        
    }
}