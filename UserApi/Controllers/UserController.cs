using Microsoft.AspNetCore.Mvc;
using UserApi.Data.Dtos;

namespace UserApi.Controllers
{

    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult CreateUser(CreateUserDto userDto)
        {
            // Here you would typically add code to save the user to a database
            _logger.LogInformation("User created: {Name}, {BirthDate}", userDto.Username, userDto.BirthDate);
            return Ok(new { Message = "User created successfully", User = userDto });
        }

    }
}
