namespace Domain.Common;

public interface IRepository<T> : IDisposable where T : IAggregateRoot
{
}