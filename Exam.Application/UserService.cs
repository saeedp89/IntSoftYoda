using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Core;

namespace Exam.Application
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserDto> GetByIdAsync(long id, CancellationToken token)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id, token);
            return user == null ? new UserDto() : user.ToDto();
        }

        public async Task CreateAsync(UserDto userDto, CancellationToken token)
        {
            var user = userDto.ToUser();
            await _unitOfWork.Users.CreateAsync(user, token);
            await _unitOfWork.SaveChangesAsync(token);
        }

        public async Task UpdateAsync(UserDto userDto, CancellationToken token)
        {
            _unitOfWork.Users.Update(userDto.ToUser(), token);
            await _unitOfWork.SaveChangesAsync(token);
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync(CancellationToken token)
        {
            var users= await _unitOfWork.Users.GetAllAsync(token);
            return users.ToDto();
        }
    }
}