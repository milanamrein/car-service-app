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
    /// Reservation Type Repository
    /// </summary>
    public class ReservationTypeRepository : Repository<ReservationType, ReservationTypeDTO>, IReservationTypeRepository
    {
        public ReservationTypeRepository(CarServiceContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }
    }
}
