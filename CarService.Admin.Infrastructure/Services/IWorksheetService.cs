using CarService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Admin.Infrastructure.Services
{
    /// <summary>
    /// Service interface for worksheets
    /// </summary>
    public interface IWorksheetService
    {
        /// <summary>
        /// Creates a new worksheet
        /// </summary>
        /// <param name="worksheetDTO">The new worksheet</param>
        /// <param name="argToken">The user's token</param>
        /// <returns>The created worksheet's ID</returns>
        Task<int> CreateWorksheetAsync(WorksheetDTO worksheetDTO, string argToken);
    }
}
