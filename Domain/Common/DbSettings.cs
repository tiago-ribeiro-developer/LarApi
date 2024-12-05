namespace Domain.Common;

public class DbSettings
{
    public string? Host { get; set; }
    public string? Database { get; set; }
    public string? User { get; set; }
    public string? Pass { get; set; }

    public string? GetConnectionString()
    {
        return $"Host={Host}; Database={Database}; Username={User}; Password={Pass};";
    }
}