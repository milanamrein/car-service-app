using CarService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace CarService.Service.Repositories
{
    /// <summary>
    /// Reservation Repository Interface
    /// </summary>
    public interface IReservationRepository : IRepository<Reservation, ReservationDTO>
    {
        /// <summary>
        /// Gets a <see cref="ReservationDTO"/> reservation
        /// </summary>
        /// <param name="id">The reservation's ID</param>
        /// <returns>The reservation</returns>
        ReservationDTO GetReservation(int id);
    }
}
