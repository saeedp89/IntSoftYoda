using Exam.Application;
using Exam.Core;

public static class UserExtensions
{
    public static User ToUser(this UserDto dto)
    {
        return new User()
        {
            Id = dto.Id,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            NationalCode = dto.NationalCode,
            PhoneNumber = dto.PhoneNumber
        };
    }

    public static UserDto ToDto(this User user)
    {
        return new UserDto()
        {
            Id = user.Id,
            LastName = user.LastName,
            FirstName = user.FirstName,
            NationalCode = user.NationalCode,
            PhoneNumber = user.PhoneNumber
        };
    }

    public static IEnumerable<User> ToUser(this IEnumerable<UserDto> dtos)
        => dtos.Select(ToUser);

    public static IEnumerable<UserDto> ToDto(this IEnumerable<User> users)
        => users.Select(ToDto);
}