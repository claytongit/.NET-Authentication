using systemLogin.Models;
using systemLogin.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace systemLogin.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;

        public UserController(UserService userService)
        {
            _service = userService;
        }

        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public ActionResult<UserModel> Post(UserModel user)
        {
            _service.Post(user);
            return user;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Get([FromBody]UserModel model)
        {
            var user = _service.Get(model.password, model.password);

            if(user == null)
            {
                return NotFound(new { message = "Usuario ou senha invalida" });
            }

            var token = TokenService.GenerateToken(user);

            return new { user = user, token = token };   
        }

        [HttpGet]
        [Route("")]
        [Authorize]
        public List<UserModel> Get()
        {
            return _service.Get();
        }

    }
}