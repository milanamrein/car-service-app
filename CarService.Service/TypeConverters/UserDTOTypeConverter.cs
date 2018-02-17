using AutoMapper;
using CarService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Service.TypeConverters
{
    /// <summary>
    /// AutoMapper TypeConverter class for <see cref="UserDTO"/> objects
    /// </summary>
    public class UserDTOTypeConverter : ITypeConverter<User, UserDTO>
    {
        public UserDTO Convert(User source, UserDTO destination, ResolutionContext context)
        {
            return new UserDTO
            {
                Id = source.Id,
                FullName = source.Name,
                Username = source.UserName,
                Address = source.Address ?? string.Empty,
                PartnerReservations = source.PartnerReservations
                    .Where(res => res.Time >= DateTime.Now)
                    .Select(res => new ReservationDTO
                    {
                        Id = res.Id,
                        Time = res.Time,
                        Partner = new UserDTO
                        {
                            Id = res.Partner.Id,
                            FullName = res.Partner.Name,
                            Username = res.Partner.UserName,
                            Address = res.Partner.Address
                        },
                        Mechanic = new UserDTO
                        {
                            Id = res.Mechanic.Id,
                            FullName = res.Mechanic.Name,
                            Username = res.Mechanic.UserName,
                        },
                        Worksheet = (res.Worksheet != null) ? new WorksheetDTO
                        {
                            Id = res.Worksheet.Id
                        } : new WorksheetDTO(),
                        Type = new ReservationTypeDTO
                        {
                            Id = res.Type.Id,
                            Name = res.Type.Name
                        },
                        Comment = res.Comment ?? string.Empty
                    }).OrderBy(res => res.Time).ToList<ReservationDTO>(),
                MechanicReservations = source.MechanicReservations
                    .Where(res => res.Time >= DateTime.Now)
                    .Select(res => new ReservationDTO
                    {
                        Id = res.Id,
                        Time = res.Time,
                        Partner = new UserDTO
                        {
                            Id = res.Partner.Id,
                            FullName = res.Partner.Name,
                            Username = res.Partner.UserName,
                            Address = res.Partner.Address
                        },
                        Mechanic = new UserDTO
                        {
                            Id = res.Mechanic.Id,
                            FullName = res.Mechanic.Name,
                            Username = res.Mechanic.UserName,
                        },
                        Worksheet = (res.Worksheet != null) ? new WorksheetDTO
                        {
                            Id = res.Worksheet.Id
                        } : new WorksheetDTO(),
                        Type = new ReservationTypeDTO
                        {
                            Id = res.Type.Id,
                            Name = res.Type.Name
                        },
                        Comment = res.Comment ?? string.Empty
                    }).OrderBy(res => res.Time).ToList<ReservationDTO>(),
                PartnerWorksheets = source.PartnerWorksheets.Select(ws => new WorksheetDTO
                {
                    Id = ws.Id,
                    Partner = new UserDTO
                    {
                        Id = ws.Partner.Id,
                        FullName = ws.Partner.Name,
                        Username = ws.Partner.UserName,
                        Address = ws.Partner.Address
                    },
                    Mechanic = new UserDTO
                    {
                        Id = ws.Mechanic.Id,
                        FullName = ws.Mechanic.Name,
                        Username = ws.Mechanic.UserName,
                    },
                    Reservation = new ReservationDTO
                    {
                        Id = ws.Reservation.Id,
                        Time = ws.Reservation.Time,
                        Type = new ReservationTypeDTO
                        {
                            Id = ws.Reservation.Type.Id,
                            Name = ws.Reservation.Type.Name
                        },
                        Comment = ws.Reservation.Comment ?? string.Empty
                    },
                    Materials = ws.WorksheetMaterials.Select(wm => new MaterialDTO
                    {
                        Id = wm.Material.Id,
                        Name = wm.Material.Name,
                        Price = wm.Material.Price,
                        Quantity = wm.Quantity
                    }).ToList<MaterialDTO>()
                }).OrderBy(ws => ws.Reservation.Time).ToList<WorksheetDTO>(),
                MechanicWorksheets = source.MechanicWorksheets.Select(ws => new WorksheetDTO
                {
                    Id = ws.Id,
                    Partner = new UserDTO
                    {
                        Id = ws.Partner.Id,
                        FullName = ws.Partner.Name,
                        Username = ws.Partner.UserName,
                        Address = ws.Partner.Address
                    },
                    Mechanic = new UserDTO
                    {
                        Id = ws.Mechanic.Id,
                        FullName = ws.Mechanic.Name,
                        Username = ws.Mechanic.UserName,
                    },
                    Reservation = new ReservationDTO
                    {
                        Id = ws.Reservation.Id,
                        Time = ws.Reservation.Time,
                        Type = new ReservationTypeDTO
                        {
                            Id = ws.Reservation.Type.Id,
                            Name = ws.Reservation.Type.Name
                        },
                        Comment = ws.Reservation.Comment ?? string.Empty
                    },
                    Materials = ws.WorksheetMaterials.Select(wm => new MaterialDTO
                    {
                        Id = wm.Material.Id,
                        Name = wm.Material.Name,
                        Price = wm.Material.Price,
                        Quantity = wm.Quantity
                    }).ToList<MaterialDTO>()
                }).OrderByDescending(ws => ws.Reservation.Time).ToList<WorksheetDTO>()
            };
        }
    }
}
