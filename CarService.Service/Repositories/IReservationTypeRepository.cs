using CarService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Service.Repositories
{
    /// <summary>
    /// Reservation Types Repository Interface
    /// </summary>
    public interface IReservationTypeRepository : IRepository<ReservationType, ReservationTypeDTO>
    {
    }
}
