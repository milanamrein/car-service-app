using AutoMapper;
using CarService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Service.TypeConverters
{
    /// <summary>
    /// AutoMapper TypeConverter class for <see cref="WorksheetDTO"/> objects
    /// </summary>
    public class WorksheetDTOTypeConverter : ITypeConverter<Worksheet, WorksheetDTO>
    {
        public WorksheetDTO Convert(Worksheet source, WorksheetDTO destination, ResolutionContext context)
        {
            return new WorksheetDTO
            {
                Id = source.Id,
                Partner = new UserDTO
                {
                    Id = source.Partner.Id,
                    FullName = source.Partner.Name,
                    Address = source.Partner.Address
                },
                Mechanic = new UserDTO
                {
                    Id = source.Mechanic.Id,
                    FullName = source.Mechanic.Name
                },
                Reservation = new ReservationDTO
                {
                    Id = source.Reservation.Id,
                    Time = source.Reservation.Time,
                    Type = new ReservationTypeDTO
                    {
                        Id = source.Reservation.Type.Id,
                        Name = source.Reservation.Type.Name
                    },
                    Comment = source.Reservation.Comment ?? string.Empty
                },
                Materials = source.WorksheetMaterials
                        .Select(wm => new MaterialDTO
                        {
                            Id = wm.Material.Id,
                            Name = wm.Material.Name,
                            Price = wm.Material.Price,
                            Quantity = wm.Quantity
                        }).ToList<MaterialDTO>()
            };
        }
    }
}
