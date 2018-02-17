using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using AutoMapper;
using CarService.Service.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using CarService.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Collections.Generic;

namespace CarService.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/users")]
    public class UsersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthRepository _authRepository;
        private readonly ILogger<UsersController> _logger;

        public UsersController(
            IUnitOfWork unitOfWork,
            IAuthRepository authRepository,
            ILogger<UsersController> logger)
        {            
            _unitOfWork = unitOfWork;
            _authRepository = authRepository;
            _logger = logger;
        }

        // GET: api/users
        [Authorize]
        [HttpGet("{role}")]
        public async Task<IActionResult> GetUsers([FromRoute] string role)
        {
            try
            {

                if (!await _authRepository.IsRoleExistsAsync(role))
                    return BadRequest("Role does not exist!");

                return Ok(_unitOfWork.Users.Mapper
                    .Map<IEnumerable<UserDTO>>(_authRepository.GetAllUsersInRole(_unitOfWork.Users.GetAllUserEntities(), role)));

            }
            catch (Exception ex)
            {
                _logger.LogError($"Unexpected error while getting user: {ex.Message}");
                return StatusCode(500, $"An unexpected error has occurred: {ex.Message}");
            }
        }

        // GET: api/users/5
        [Authorize]
        [HttpGet("{role}/{id}")]
        public IActionResult GetUser([FromRoute] string role, [FromRoute] string id)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                UserDTO userDTO = _unitOfWork.Users.Mapper.Map<UserDTO>(_unitOfWork.Users.GetUser(id));

                if (userDTO == null)
                {
                    return NotFound("User cannot be found!");
                }

                return Ok(userDTO);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Unexpected error while getting user: {ex.Message}");
                return StatusCode(500, $"An unexpected error has occurred: {ex.Message}");
            }
        }

        // GET: api/users/Partner/login/james_foo/123456
        [AllowAnonymous]
        [HttpGet("{role}/login/{username}/{password}")]
        public async Task<IActionResult> GetLoginUser([FromRoute] string role, [FromRoute] string username, [FromRoute] string password)

        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                bool isUserValid = await _authRepository.ValidateUserAsync(username, password, role);

                if (!isUserValid)
                    return Unauthorized();

                User user = await _authRepository.GetUserAsync(username);

                return Ok(new UserDTO
                {
                    Id = user.Id,
                    Token = new JwtSecurityTokenHandler()
                        .WriteToken(await _authRepository.CreateSecurityTokenAsync(user))
                });

            }
            catch (Exception ex)
            {
                _logger.LogError($"Unexpected error while logging user in: {ex.Message}");
                return StatusCode(500, $"An unexpected error has occurred: {ex.Message}");
            }

        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> PostRegisterUser([FromBody] RegisterUserDTO newUser)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                IdentityResult result = await _authRepository.CreateUserAsync(newUser);
                if (!result.Succeeded)
                    return BadRequest(result.Errors);

                await _authRepository.CreateRoleAsync(newUser.Role);
                User user = await _authRepository.GetUserAsync(newUser.Username);
                await _authRepository.AddUserToRoleAsync(user, newUser.Role);

                return Ok(result);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Unexpected error while creating user: {ex.Message}");
                return StatusCode(500, $"An unexpected error has occurred: {ex.Message}");
            }
        }

        // GET: api/users/isexists/james_foo
        [AllowAnonymous]
        [HttpGet("isexists/{username}")]
        public IActionResult IsUsernameExists(string username)
        {
            try
            {

                return _unitOfWork.Users.Any(user => user.UserName.Equals(username)) ? Ok(true) : Ok(false);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Unexpected error while searching user: {ex.Message}");
                return StatusCode(500, $"An unexpected error has occurred: {ex.Message}");
            }
        }
    }
}