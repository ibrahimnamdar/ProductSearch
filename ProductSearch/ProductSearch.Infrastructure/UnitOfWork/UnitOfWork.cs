namespace ProductSearch.Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ProductSearchDbContext _productSearchDbContext;

    public UnitOfWork(ProductSearchDbContext productSearchDbContext)
    {
        _productSearchDbContext = productSearchDbContext;
    }

    public int Complete()
    {
        return _productSearchDbContext.SaveChanges();
    }

    public async Task<int> CompleteAsync()
    {
        return await _productSearchDbContext.SaveChangesAsync();
    }
}