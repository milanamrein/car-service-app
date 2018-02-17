using AutoMapper;
using CarService.DTO;
using CarService.Service.TypeConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Service
{
    /// <summary>
    /// AutoMapper Profile Class
    /// </summary>
    public class CarServiceProfile : Profile
    {
        public CarServiceProfile()
        {
            CreateMap<User, UserDTO>().ConvertUsing<UserDTOTypeConverter>();

            CreateMap<ReservationTypeDTO, ReservationType>().ReverseMap();
            CreateMap<MaterialDTO, Material>().ReverseMap();

            CreateMap<Reservation, ReservationDTO>().ConvertUsing<ReservationDTOTypeConverter>();
            CreateMap<ReservationDTO, Reservation>()
                .ForMember(res => res.Time, opt => opt.MapFrom(dto => dto.Time.ToLocalTime()))
                .ForMember(res => res.Mechanic, opt => opt.Ignore())
                .ForMember(res => res.Partner, opt => opt.Ignore())
                .ForMember(res => res.Type, opt => opt.Ignore())
                .ForMember(res => res.Worksheet, opt => opt.Ignore())
                .ForMember(res => res.MechanicId, opt => opt.MapFrom(dto => dto.Mechanic.Id))
                .ForMember(res => res.PartnerId, opt => opt.MapFrom(dto => dto.Partner.Id))
                .ForMember(res => res.TypeId, opt => opt.MapFrom(dto => dto.Type.Id));

            CreateMap<Worksheet, WorksheetDTO>().ConvertUsing<WorksheetDTOTypeConverter>();
            CreateMap<WorksheetDTO, Worksheet>()
                .ForMember(ws => ws.Mechanic, opt => opt.Ignore())
                .ForMember(ws => ws.Partner, opt => opt.Ignore())
                .ForMember(ws => ws.Reservation, opt => opt.Ignore())
                .ForMember(ws => ws.PartnerId, opt => opt.MapFrom(dto => dto.Partner.Id))
                .ForMember(ws => ws.MechanicId, opt => opt.MapFrom(dto => dto.Mechanic.Id))
                .ForMember(ws => ws.ReservationId, opt => opt.MapFrom(dto => dto.Reservation.Id))
                .ForMember(ws => ws.WorksheetMaterials, opt => opt.MapFrom(dto => dto.Materials
                .Select(mat => new WorksheetMaterial
                {
                    MaterialId = mat.Id,
                    Quantity = mat.Quantity
                }).ToList<WorksheetMaterial>()));
        }
    }
}
