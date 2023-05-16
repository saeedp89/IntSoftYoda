using Exam.Core;

namespace Exam.Repositories;

public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(ExamDbContext dbContext, IUserRepository users)
    {
        _dbContext = dbContext;
        Users = users;
    }

    public IUserRepository Users { get; }
    private readonly ExamDbContext _dbContext;

    public Task<int> SaveChangesAsync(CancellationToken cancellation)
    {
        return _dbContext.SaveChangesAsync(cancellation);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _dbContext.Dispose();
        }
    }
}