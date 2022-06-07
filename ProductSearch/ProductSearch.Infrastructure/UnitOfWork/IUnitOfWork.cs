namespace ProductSearch.Infrastructure.UnitOfWork;

public interface IUnitOfWork
{
    int Complete();
    Task<int> CompleteAsync();
}