using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarService.Admin.Infrastructure.Helpers;
using CarService.DTO;
using System.Security;
using System.Net.Http;
using System.Net;
using System.Collections.ObjectModel;

namespace CarService.Admin.Infrastructure.Services
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public class AuthService : IAuthService
    {
        /// <summary>
        /// Base Service
        /// </summary>
        private readonly ICarService _carService;

        public AuthService(ICarService carService)
        {
            _carService = carService;
        }

        /// <summary>
        /// Checks if a user already exists
        /// with this username
        /// <param name="argUsername">The username</param>
        /// <returns>Whether the user already exists or not</returns>
        public async Task<bool> IsUsernameExistsAsync(string argUsername)
        {
            try
            {

                return await _carService.GetAsync<bool>(_carService.Client.BaseAddress + $"users/isexists/{argUsername}");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Logs a user in
        /// </summary>
        /// <param name="argRole">The user's role</param>
        /// <param name="argUsername">The username</param>
        /// <param name="argPassword">The password</param>
        /// <returns>The user's JWT</returns>
        public async Task<UserDTO> LoginAsync(string argRole, string argUsername, SecureString argPassword)
        {
            try
            {

                HttpResponseMessage response = await _carService.Client
                    .GetAsync(_carService.Client.BaseAddress +
                        $"users/{argRole}/login/{argUsername}/{PasswordHelpers.ConvertToUnsecureString(argPassword)}");
                if (!response.IsSuccessStatusCode)
                {
                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.Unauthorized:
                            throw new Exception("Invalid username or password!");
                        default:
                            throw new Exception(await response.Content.ReadAsAsync<string>());
                    }
                }

                return await response.Content.ReadAsAsync<UserDTO>();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Registers a new user
        /// </summary>
        /// <param name="argNewUser">The new user's credentials</param>
        /// <returns>The registration result</returns>
        public async Task<RegistrationResult> RegisterAsync(RegisterUserDTO argNewUser)
        {
            try
            {

                Error errors = new Error
                {
                    ModelState = new Dictionary<string, List<string>>()
                };
                RegistrationResult result = new RegistrationResult
                {
                    Messages = new ObservableCollection<string>()
                };

                if (argNewUser.Username != string.Empty)
                {
                    // checks if the given username already exists
                    // if it does, the registration was not successful, and add an error message
                    bool isUsernameExists = await this.IsUsernameExistsAsync(argNewUser.Username);
                    if (isUsernameExists)
                        errors.ModelState.Add("UsernameExists", new List<string>() { "This username already exists!" });
                }

                // checks if the password has a valid format
                if (!PasswordHelpers.IsPasswordValid(argNewUser.Password))
                    errors.ModelState.Add("InvalidPasswordFormat", new List<string>()
                    {
                        "Password is invalid!",
                        "The password cannot contain any whitespaces!",
                        "The password must contain at least one uppercase character!",
                        "The password must contain at least one non-alphanumeric character!",
                        "The password must contain at least one digit!",
                        "The password must contain at least a '-' or a '_' character!"
                    });

                // gets the response of the registration process
                HttpResponseMessage response =
                    await _carService.Client
                        .PostAsJsonAsync<RegisterUserDTO>(_carService.Client.BaseAddress + "users", argNewUser);

                // if it was successful, and the username does not exist in the database already,
                // then the registration was successful
                if (response.IsSuccessStatusCode && errors.ModelState.Count == 0)
                {
                    result.RegistrationWasSuccessful = true;
                    result.Messages.Add("Registration was successful! You can sign in now!");
                }
                else
                {
                    // else it wasn't
                    result.RegistrationWasSuccessful = false;

                    // if the request wasn't successful
                    if (!response.IsSuccessStatusCode)
                    {
                        // add the response errors to the errors object   
                        Dictionary<string, List<string>> responseErrors =
                            await response.Content.ReadAsAsync<Dictionary<string, List<string>>>();
                        foreach (KeyValuePair<string, List<string>> error in responseErrors)
                        {
                            errors.ModelState.Add(error.Key, error.Value);
                        }
                    }

                    // get the error messages
                    foreach (List<string> errorList in errors.ModelState.Values)
                    {
                        foreach (string error in errorList)
                        {
                            result.Messages.Add(error);
                        }
                    }
                }

                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
