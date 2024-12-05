using Dapper;
using Domain.Dto;
using Domain.Entities;
using Infrastructure.Data;
using Domain.Interfaces.Repositories;

namespace Infrastructure.Repositories;

public class PersonRepository : IPersonRepository
{
    protected readonly LarContext _context;

    public PersonRepository(LarContext context)
    {
        _context = context;
    }
    
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public async Task AddAsync(Person person)
    {
        string sql = @"
        
            INSERT INTO Persons (name, document, dateofbirth, active)
            VALUES (@name, @document, @dateofbirth, @active);

        ";

        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, PersonDto.Factory.Create(person));    
    }

    public async Task UpdateAsync(Person person)
    {
        string sql = @"
        
            UPDATE Persons
            SET name = @name, document = @document, dateofbirth = @dateofbirth
            WHERE Id = @id;

        ";
        
        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, PersonDto.Factory.Update(person));
        
    }

    public async Task<Person?> GetByIdAsync(int id)
    {
        string sql = @"
        
            SELECT * FROM Persons WHERE Id = @id AND active = true;

        ";
        
        using var connection = _context.CreateConnection();
        var result = await connection.QueryFirstOrDefaultAsync<PersonDto?>(sql, new { id });
        if (result == null)
            return null;
        return Person.Factory.Create(result);
        
    }

    public async Task<List<Person>?> GetAll()
    {
        string sql = @"
        
            SELECT pe.id, pe.name,pe.active, pe.dateofbirth, pe.document, STRING_AGG(INITCAP(ph.number), ',') AS phones

            FROM persons pe
            LEFT JOIN phones ph on pe.id = ph.personid
            WHERE pe.active = true

            GROUP BY
                pe.id,
                pe.name
            ORDER BY pe.name ASC;

        ";
        
        using var connection = _context.CreateConnection();
        var result = (await connection.QueryAsync<PersonDto>(sql)).ToList();
        if (result == null)
            return null;
        return result.Select(Person.Factory.Create).ToList();
    }

    public async Task DeleteAsync(int id)
    {
        string sql = @"
        
            UPDATE Persons
            SET active = false
            WHERE Id = @id;

        ";
        
        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, PersonDto.Factory.Delete(id));
    }
}