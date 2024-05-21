using Microsoft.AspNetCore.Mvc;
using Pharmacy.Application.Services;
using Pharmacy.Contracts;
using PharmacyStore.Core.Models;

namespace Pharmacy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService userService)
        {
            _usersService = userService;

        }

        [HttpPost]
        public async Task<ActionResult<string>> GetUserToken([FromBody] UserRequest request)
        {
            var user = new User(
                Guid.NewGuid(),
                request.Login,
                request.Password);
            var token = await _usersService.Login(user);

            HttpContext.Response.Cookies.Append("cookie", token);

            var tok = new Tok();
            tok.Token = token;
            tok.Id = 1;

            return Ok(tok);
        }

        [HttpPost("reg")]
        public async Task<ActionResult<Guid>> Register([FromBody] RegisterRequest request)
        {
            var user = new User(
                Guid.NewGuid(),
                request.Login,
                request.Password);

            await _usersService.Register(user);
            return Ok(user.Login);
        }
    }
    public class Tok
    {
        public int Id { get; set; }
        public string Token { get; set; }
    }
}
