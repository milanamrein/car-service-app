using CarService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace CarService.Service.Repositories
{
    /// <summary>
    /// Reservation Repository
    /// </summary>
    public class ReservationRepository : Repository<Reservation, ReservationDTO>, IReservationRepository
    {
        public ReservationRepository(CarServiceContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }

        public CarServiceContext CarServiceContext => this.Context as CarServiceContext;

        /// <summary>
        /// Gets a <see cref="ReservationDTO"/> reservation
        /// </summary>
        /// <param name="id">The reservation's ID</param>
        /// <returns>The reservation</returns>
        public ReservationDTO GetReservation(int id)
        {
            Reservation reservation = this.CarServiceContext.Reservations
                .Include(res => res.Mechanic)
                .Include(res => res.Partner)
                .Include(res => res.Type)
                .Include(res => res.Worksheet)
                .Where(res => res.Id == id)
                .SingleOrDefault<Reservation>();

            return this.Mapper.Map<ReservationDTO>(reservation);
        }
    }
}
