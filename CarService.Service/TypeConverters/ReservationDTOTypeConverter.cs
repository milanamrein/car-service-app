using AutoMapper;
using CarService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Service.TypeConverters
{
    /// <summary>
    /// AutoMapper TypeConverter class for <see cref="ReservationDTO"/> objects
    /// </summary>
    public class ReservationDTOTypeConverter : ITypeConverter<Reservation, ReservationDTO>
    {
        public ReservationDTO Convert(Reservation source, ReservationDTO destination, ResolutionContext context)
        {
            return new ReservationDTO
            {
                Id = source.Id,
                Time = source.Time,
                Comment = source.Comment ?? string.Empty,
                Partner = new UserDTO
                {
                    Id = source.Partner.Id,
                    FullName = source.Partner.Name
                },
                Mechanic = new UserDTO
                {
                    Id = source.Mechanic.Id,
                    FullName = source.Mechanic.Name
                },
                Type = new ReservationTypeDTO
                {
                    Id = source.Type.Id,
                    Name = source.Type.Name
                },
                Worksheet = source.Worksheet != null ? new WorksheetDTO
                {
                    Id = source.Worksheet.Id
                } : new WorksheetDTO()
            };
        }
    }
}
