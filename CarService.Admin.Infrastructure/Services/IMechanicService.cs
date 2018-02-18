using CarService.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarService.Admin.Infrastructure.Services
{
    /// <summary>
    /// Service interface for mechanics
    /// </summary>
    public interface IMechanicService
    {
        /// <summary>
        /// Gets a mechanic
        /// </summary>
        /// <param name="argId">The mechanic's ID</param>
        /// <param name="argToken">The mechanic's token</param>
        /// <returns>Mechanic data</returns>
        Task<UserDTO> GetMechanicAsync(string argId, string argToken);
    }
}
