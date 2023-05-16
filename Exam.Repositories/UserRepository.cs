using Exam.Core;
using Microsoft.EntityFrameworkCore;

namespace Exam.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ExamDbContext _context;

    public UserRepository(ExamDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(User user, CancellationToken ct)
    {
        await _context.Set<User>().AddAsync(user, ct);
    }

    public void Update(User user, CancellationToken ct)
    {
        _context.Set<User>().Update(user);
    }

    public async Task<User?> GetByIdAsync(long id, CancellationToken ct)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Users.ToListAsync(cancellationToken);
    }
}