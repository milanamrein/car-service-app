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
    /// Worksheet Repository
    /// </summary>
    public class WorksheetRepository : Repository<Worksheet, WorksheetDTO>, IWorksheetRepository
    {
        public WorksheetRepository(CarServiceContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }

        public CarServiceContext CarServiceContext => this.Context as CarServiceContext;

        /// <summary>
        /// Gets a <see cref="WorksheetDTO"/> object
        /// </summary>
        /// <param name="id">The worksheet's ID</param>
        /// <returns>The worksheet</returns>
        public WorksheetDTO GetWorksheet(int id)
        {
            Worksheet worksheet = this.CarServiceContext.Worksheets
                .Include(ws => ws.WorksheetMaterials)
                    .ThenInclude(wm => wm.Material)
                .Include(ws => ws.Partner)
                .Include(ws => ws.Mechanic)
                .Include(ws => ws.Reservation)
                    .ThenInclude(res => res.Type)
                .Where(ws => ws.Id == id)  
                .SingleOrDefault<Worksheet>();

            return this.Mapper.Map<WorksheetDTO>(worksheet);
        }
    }
}
