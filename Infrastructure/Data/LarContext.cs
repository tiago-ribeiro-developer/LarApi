using Microsoft.Extensions.Options;
using Npgsql;
using System.Data;
using Domain.Common;

namespace Infrastructure.Data;

public class LarContext
{
    private DbSettings _dbSettings;

    public LarContext(IOptions<DbSettings> dbSettings)
    {
        _dbSettings = dbSettings.Value;
    }

    public IDbConnection CreateConnection()
    {
        var connectionString = _dbSettings.GetConnectionString();
        return new NpgsqlConnection(connectionString);
    }
}