using CarService.DTO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Service.Repositories
{
    /// <summary>
    /// Authentication Repository Interface
    /// </summary>
    public interface IAuthRepository
    {
        /// <summary>
        /// Gets a user from the database
        /// </summary>
        /// <param name="username">The user's username</param>
        /// <returns>The user</returns>
        Task<User> GetUserAsync(string username);

        /// <summary>
        /// Gets all users in a specific role
        /// </summary>
        /// <param name="users">The users</param>
        /// <param name="role">The role</param>
        /// <returns>The users in the role</returns>
        IEnumerable<User> GetAllUsersInRole(IEnumerable<User> users, string role);

        /// <summary>
        /// Validates a user's credentials in a specific role
        /// </summary>
        /// <param name="username">The username</param>
        /// <param name="password">The password</param>
        /// <param name="role">The role</param>
        /// <returns>Whether the user credentials are valid or not</returns>
        Task<bool> ValidateUserAsync(string username, string password, string role);

        /// <summary>
        /// Checks if the given role
        /// is exists
        /// </summary>
        /// <param name="role">The given role</param>
        /// <returns>Whether the given role is exists or not</returns>
        Task<bool> IsRoleExistsAsync(string role);

        /// <summary>
        /// Creates a JWT Security Token from a User model object
        /// </summary>
        /// <param name="user">The user</param>
        /// <returns>The security token</returns>
        Task<JwtSecurityToken> CreateSecurityTokenAsync(User user);

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="registerUserDTO">The new user's credentials</param>
        /// <returns>The creation result</returns>
        Task<IdentityResult> CreateUserAsync(RegisterUserDTO registerUserDTO);

        /// <summary>
        /// Creates a new role if it
        /// doesn't exist already
        /// </summary>
        /// <param name="role"></param>
        Task CreateRoleAsync(string role);

        /// <summary>
        /// Adds a user to a specific role
        /// </summary>
        /// <param name="user">The user</param>
        /// <param name="role">The role</param>
        Task AddUserToRoleAsync(User user, string role);
    }
}
