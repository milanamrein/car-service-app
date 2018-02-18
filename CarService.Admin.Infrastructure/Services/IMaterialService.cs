using CarService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Admin.Infrastructure.Services
{
    /// <summary>
    /// Service interface for materials
    /// </summary>
    public interface IMaterialService
    {
        /// <summary>
        /// Gets all the materials
        /// </summary>
        /// <param name="argToken">The user's token</param>
        /// <returns>All the materials</returns>
        Task<List<MaterialDTO>> GetMaterialsAsync(string argToken);
    }
}
