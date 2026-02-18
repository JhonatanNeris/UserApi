using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserApi.Data.Dtos;
using UserApi.Models;
using UserApi.Services;

namespace UserApi.Controllers
{

    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase
    {   
        private RegisterService _registerService;

        public UserController(RegisterService registerService)
        {
            _registerService = registerService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto userDto)
        {
            await _registerService.Register(userDto);
            return Ok(new { Message = "User created successfully", User = userDto });

        }
    }
}
