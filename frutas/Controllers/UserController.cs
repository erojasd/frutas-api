using FrutasApi.Dtos.Users;
using FrutasApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FrutasApi.Controllers
{

    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public UserController(IUserService userService, IConfiguration configuration)
        {
            _userService=userService;
            _configuration=configuration;
        }
        [Authorize]
        [HttpPost("create")]
        public IActionResult Create(CreateUserDto input)
        {
            return Ok(_userService.Create(input));
        }

        [Authorize]
        [HttpGet("list")]
        public IActionResult List()
        {
            return Ok(_userService.GetAll());
        }

        /// <summary>
        /// Genera el token de autenticación
        /// </summary
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserLoginDto input)
        {
            // Leemos el secret_key desde nuestro appseting
            var secretKey = _configuration.GetValue<string>("SecretKey");
            var key = Encoding.ASCII.GetBytes(secretKey);
            if (!_userService.CheckUserExists(input.Name))
                return BadRequest("Usuario o contraseña incorrecta");
            var response = _userService.Login(input.Name, input.Password);
            if (!response.IsAuthenticated)
                return BadRequest("Usuario o contraseña incorrecta");
            // Creamos los claims (pertenencias, características) del usuario
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, response.Name)
             };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                // ttime exp: 10 minutos
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(tokenHandler.WriteToken(createdToken));
        }

    }
}
