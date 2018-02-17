using CarService.Service.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Service
{
    /// <summary>
    /// Unit Of Work Interface
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {        
        IUserRepository Users { get; }
        IReservationRepository Reservations { get; }
        IWorksheetRepository Worksheets { get; }
        IReservationTypeRepository ReservationTypes { get; }
        IMaterialRepository Materials { get; }
        IWorksheetMaterialRepository WorksheetMaterials { get; }
        Task<int> Complete();
    }
}
