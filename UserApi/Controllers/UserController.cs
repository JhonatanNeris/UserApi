using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserApi.Data.Dtos;
using UserApi.Models;

namespace UserApi.Controllers
{

    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        private IMapper _mapper;
        private UserManager<User> _userManager;

        public UserController(ILogger<UserController> logger, IMapper mapper, UserManager<User> userManager)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto userDto)
        {
            // Here you would typically add code to save the user to a database
            _logger.LogInformation("User created: {Name}, {BirthDate}", userDto.Username, userDto.BirthDate);

            User user = _mapper.Map<User>(userDto);

            IdentityResult result = await _userManager.CreateAsync(user, userDto.Password);

            if (result.Succeeded)
            {
                return Ok(new { Message = "User created successfully", User = userDto });
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }
    }
}
