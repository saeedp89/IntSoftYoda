using System.Threading;
using System.Threading.Tasks;
using Exam.Application;
using Microsoft.AspNetCore.Mvc;

namespace Exam.API.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class UserController : ControllerBase
{
    private IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<ApiResult> CreateAsync([FromBody] UserDto userDto, CancellationToken cancellationToken)
    {
        await _userService.CreateAsync(userDto, cancellationToken);
        return ApiResult.Created(userDto.ToUser());
    }

    [HttpPut("{id:long}")]
    public async Task<ApiResult> UpdateAsync(UserDto dto, CancellationToken cancellationToken)
    {
        await _userService.UpdateAsync(dto, cancellationToken);
        return ApiResult.Updated(dto.ToUser());
    }

    [HttpGet("{id:long}")]
    public async Task<ApiResult> Get(long id, CancellationToken ct)
    {
        var user = await _userService.GetByIdAsync(id, ct);
        return user.Id == 0 ? ApiResult.NotFound() : ApiResult.OK(user);
    }

    [HttpGet]
    public async Task<ApiResult> List(CancellationToken ct)
    {
        var users = await _userService.GetAllAsync(ct);
        return ApiResult.OK(users.Count());
    }
}