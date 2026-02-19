using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserApi.Data.Dtos;
using UserApi.Models;
using UserApi.Services;

namespace UserApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class UserController : ControllerBase
{   
    private UserService _userService;

    public UserController(UserService registerService)
    {
        _userService = registerService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> CreateUser(CreateUserDto userDto)
    {
        await _userService.Register(userDto);
        return Ok(new { Message = "User created successfully", User = userDto });

    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUserDto dto)
    {
        var token = await _userService.Login(dto);
        return Ok(token);

    }
}
