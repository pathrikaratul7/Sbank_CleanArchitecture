using Microsoft.AspNetCore.Mvc;
using SbankAPI.Application.Dto;
using SbankAPI.Application.Interface;

namespace SbankAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<UserResponseDTO>> AddUser(
            CreateUserDto createUserDto, 
            CancellationToken cancellationToken)
        {
            var result = await _service.AddUserAsynch(createUserDto, cancellationToken);
            return CreatedAtAction(nameof(AddUser), result);
        }
    }
}
