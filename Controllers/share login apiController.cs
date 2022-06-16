using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using share_login_api.Models;
using share_login_api.Helpers;
using Microsoft.AspNetCore.Http;

namespace share_login_api.Controllers
{
   [Route(template:"api")]
   [ApiController]
    public class share_login_apiController : Controller
    {
        private readonly IUserRepository _repository;
        private readonly JwtServices _jwtservice;

        public object Httponly { get; private set; }

        public share_login_apiController(IUserRepository repository, JwtServices jwtservice)
        {
            _repository = repository;
            _jwtservice = jwtservice;
        }

        [HttpPost(template:"register")]
        public IActionResult Register(RegisterDto dto)
        {
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password) 
            };
            return Created("success", _repository.Create(user));
        }

        [HttpPost(template: "login")]
        public IActionResult Login(LoginDto dto)
        {
            var user = _repository.GetByEmail(dto.Email);

            if (user == null)
                return BadRequest(new { message = "wrong email" });

            if(!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
                return BadRequest(new { message = "wrong password" });


            var jwt = _jwtservice.Generate(user.Id);

            Response.Cookies.Append("jwt", jwt, new CookieOptions { HttpOnly = true });
            
            return Ok(new { jwt });
        }

        [HttpGet(template: "user")]
        public IActionResult User()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtservice.Verify(jwt);

                int userId = int.Parse(token.Issuer);

                var user = _repository.GetById(userId);

                return Ok(user);
            }
            catch (Exception) {
                return Unauthorized();
            }
        }
        [HttpPost(template: "logout")]
        public IActionResult Logout() 
        {
            Response.Cookies.Delete("jwt");
            return Ok();
        
        }
    }
}
