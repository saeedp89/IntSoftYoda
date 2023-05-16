namespace Exam.Core;

public interface IUserRepository
{
    Task CreateAsync(User user,CancellationToken ct);
    void Update(User user,CancellationToken ct);
    Task<User?> GetByIdAsync(long id,CancellationToken ct);
    Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken);
}