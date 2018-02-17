using CarService.Admin.Infrastructure.Helpers;
using CarService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Admin.Infrastructure.Services
{
    /// <summary>
    /// Authentication Persistence Service Interface
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Checks if the given username has already exists
        /// </summary>
        /// <param name="argUsername">The username input</param>
        /// <returns>Whether the username has already exists or not</returns>
        Task<bool> IsUsernameExistsAsync(string argUsername);

        /// <summary>
        /// Logs a user in
        /// </summary>
        /// <param name="argRole">The user's role</param>
        /// <param name="argUsername">The username</param>
        /// <param name="argPassword">The password</param>
        /// <returns>The user's JWT</returns>
        Task<UserDTO> LoginAsync(string argRole, string argUsername, SecureString argPassword);

        /// <summary>
        /// Registers a new mechanic
        /// </summary>
        /// <param name="registerMechanic">The new user's properties</param>
        /// <returns>The result of the registration</returns>
        Task<RegistrationResult> RegisterAsync(RegisterUserDTO registerMechanic);
    }
}
