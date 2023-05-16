using Exam.Core;

namespace Exam.Application;

public interface IUserService
{
    Task<UserDto> GetByIdAsync(long id, CancellationToken token);
    Task CreateAsync(UserDto userDto, CancellationToken token);
    Task UpdateAsync(UserDto userDto, CancellationToken token);
    Task<IEnumerable<UserDto>> GetAllAsync(CancellationToken token);
}