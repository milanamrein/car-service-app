using CarService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Service.Repositories
{
    /// <summary>
    /// WorksheetMaterial Repository Interface
    /// </summary>
    public interface IWorksheetMaterialRepository : IRepository<WorksheetMaterial, WorksheetMaterialDTO>
    {
    }
}
