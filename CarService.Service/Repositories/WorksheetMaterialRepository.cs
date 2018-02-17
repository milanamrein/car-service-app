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
    /// WorksheetMaterial Repository
    /// </summary>
    public class WorksheetMaterialRepository : Repository<WorksheetMaterial, WorksheetMaterialDTO>, IWorksheetMaterialRepository
    {
        public WorksheetMaterialRepository(CarServiceContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }
    }
}
