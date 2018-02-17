using CarService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Service.Repositories
{
    /// <summary>
    /// User Repository Interface
    /// </summary>
    public interface IUserRepository : IRepository<User, UserDTO>
    {
        /// <summary>
        /// Gets all the <see cref="User"/> entities
        /// </summary>
        IEnumerable<User> GetAllUserEntities();

        /// <summary>
        /// Gets a <see cref="User"/> user
        /// </summary>
        /// <param name="id">The user's ID</param>
        /// <returns>The user</returns>
        User GetUser(string id);
    }
}
