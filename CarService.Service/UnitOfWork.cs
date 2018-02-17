using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarService.Service.Repositories;
using AutoMapper;

namespace CarService.Service
{
    /// <summary>
    /// Unit Of Work
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CarServiceContext _context;

        public UnitOfWork(CarServiceContext context, IMapper mapper)
        {
            _context = context;
            this.Users = new UserRepository(context, mapper);
            this.Reservations = new ReservationRepository(context, mapper);
            this.Worksheets = new WorksheetRepository(context, mapper);
            this.ReservationTypes = new ReservationTypeRepository(context, mapper);
            this.Materials = new MaterialRepository(context, mapper);
            this.WorksheetMaterials = new WorksheetMaterialRepository(context, mapper);
        }

        public IUserRepository Users { get; private set; }

        public IReservationRepository Reservations { get; private set; }

        public IWorksheetRepository Worksheets {get; private set; }

        public IReservationTypeRepository ReservationTypes { get; private set; }

        public IMaterialRepository Materials { get; private set; }

        public IWorksheetMaterialRepository WorksheetMaterials { get; private set; }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
