using CarService.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Service.Repositories
{
    /// <summary>
    /// Authentication repository
    /// </summary>
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configurationRoot;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthRepository(
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configurationRoot,
            IPasswordHasher<User> passwordHasher)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configurationRoot = configurationRoot;
            _passwordHasher = passwordHasher;
        }       

        /// <summary>
        /// Gets a user from the database
        /// </summary>
        /// <param name="username">The user's username</param>
        /// <returns>The user</returns>
        public async Task<User> GetUserAsync(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }

        /// <summary>
        /// Gets all users in a specific role
        /// </summary>
        /// <param name="users">The users</param>
        /// <param name="role">The role</param>
        /// <returns>The users in the role</returns>
        public IEnumerable<User> GetAllUsersInRole(IEnumerable<User> users, string role)
        {
            IEnumerable<User> allUsersInRole = users.Where(user => _userManager.IsInRoleAsync(user, role).Result)
                .Select(user => user).ToList<User>();

            return allUsersInRole;
        }

        /// <summary>
        /// Validates a user's credentials in a specific role
        /// </summary>
        /// <param name="username">The username</param>
        /// <param name="password">The password</param>
        /// <param name="role">The role</param>
        /// <returns>Whether the user credentials are valid or not</returns>
        public async Task<bool> ValidateUserAsync(string username, string password, string role)
        {
            User user = await this.GetUserAsync(username);
            if (user == null)
                return false;

            // return whether the given password matches the existing user's password
            // and whether the user has that specific role
            return (_passwordHasher
                        .VerifyHashedPassword(user, user.PasswordHash, password)
                            == PasswordVerificationResult.Success
                    && await _userManager.IsInRoleAsync(user, role));
        }

        /// <summary>
        /// Checks if the given role
        /// is exists
        /// </summary>
        /// <param name="role">The given role</param>
        /// <returns>Whether the given role is exists or not</returns>
        public async Task<bool> IsRoleExistsAsync(string role)
        {
            return await _roleManager.RoleExistsAsync(role);
        }

        /// <summary>
        /// Creates a JWT Security Token from a User model object
        /// </summary>
        /// <param name="user">The user</param>
        /// <returns>The security token</returns>
        public async Task<JwtSecurityToken> CreateSecurityTokenAsync(User user)
        {
            // get user claims
            var userClaims = await _userManager.GetClaimsAsync(user);
            string role = _userManager.GetRolesAsync(user).Result.FirstOrDefault();
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName), // subject of the JWT - the user
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // generating JWT ID
                new Claim("Id", user.Id), // the user's ID
                new Claim("Username", user.UserName), // the user's username
                new Claim("FullName", user.Name), // the user's full name
                new Claim("Address", role.Equals("Partner") ? user.Address : string.Empty), // the user's address
                new Claim(ClaimTypes.Role, role) // the user's role
            }.Union(userClaims);

            // creating security key
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configurationRoot["JwtSecurityToken:Key"])); // key is defined in appsettings.json
            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            // creating security token
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: _configurationRoot["JwtSecurityToken:Issuer"],
                audience: _configurationRoot["JwtSecurityToken:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: signingCredentials
            );

            return jwtSecurityToken;
        }

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="registerUserDTO">The new user's credentials</param>
        /// <returns>The creation result</returns>
        public async Task<IdentityResult> CreateUserAsync(RegisterUserDTO registerUserDTO)
        {
            User user = new User
            {
                UserName = registerUserDTO.Username,
                Name = registerUserDTO.FirstName + " " + registerUserDTO.LastName,
                PhoneNumber = registerUserDTO.PhoneNumber ?? string.Empty,
                Address = (registerUserDTO.Street != null 
                    && registerUserDTO.City != null 
                    && registerUserDTO.ZipCode != null
                    && registerUserDTO.Country != null) ?
                    registerUserDTO.Street + ", " 
                    + registerUserDTO.City + ", " 
                    + registerUserDTO.ZipCode + ", " + registerUserDTO.Country : string.Empty
            };

            return await _userManager.CreateAsync(user, registerUserDTO.Password);
        }

        /// <summary>
        /// Creates a new role if it
        /// doesn't exist already
        /// </summary>
        /// <param name="role"></param>
        public async Task CreateRoleAsync(string role)
        {
            if (!await this.IsRoleExistsAsync(role))
            {
                IdentityRole identityRole = new IdentityRole { Name = role };
                await _roleManager.CreateAsync(identityRole);
            }
        }

        /// <summary>
        /// Adds a user to a specific role
        /// </summary>
        /// <param name="user">The user</param>
        /// <param name="role">The role</param>
        public async Task AddUserToRoleAsync(User user, string role)
        {            
            await _userManager.AddToRoleAsync(user, role);
        }        
    }
}
