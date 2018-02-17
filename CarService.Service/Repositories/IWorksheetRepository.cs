using CarService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Service.Repositories
{
    /// <summary>
    /// Worksheet Repository Interface
    /// </summary>
    public interface IWorksheetRepository : IRepository<Worksheet, WorksheetDTO>
    {
        /// <summary>
        /// Gets a <see cref="WorksheetDTO"/> object
        /// </summary>
        /// <param name="id">The worksheet's ID</param>
        /// <returns>The worksheet</returns>
        WorksheetDTO GetWorksheet(int id);
    }
}
