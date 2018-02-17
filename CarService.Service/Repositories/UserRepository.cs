using CarService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace CarService.Service.Repositories
{
    /// <summary>
    /// User Repository
    /// </summary>
    public class UserRepository : Repository<User, UserDTO>, IUserRepository
    {
        public UserRepository(CarServiceContext context, IMapper mapper)
            : base(context, mapper)
        {            
        }

        public CarServiceContext CarServiceContext => this.Context as CarServiceContext;

        /// <summary>
        /// Gets a <see cref="User"/> user
        /// </summary>
        /// <param name="id">The user's ID</param>
        /// <returns>The user</returns>
        public User GetUser(string id)
        {
            return this.GetAllUserEntities()
                .Where(user => user.Id == id)
                .SingleOrDefault<User>();
        }

        /// <summary>
        /// Gets all the <see cref="User"/> entities
        /// </summary>
        public IEnumerable<User> GetAllUserEntities()
        {
            return this.CarServiceContext.Users
                .Include(user => user.PartnerReservations)
                    .ThenInclude(res => res.Type)
                .Include(user => user.MechanicReservations)
                    .ThenInclude(res => res.Type)
                .Include(user => user.PartnerWorksheets)
                    .ThenInclude(ws => ws.WorksheetMaterials)
                        .ThenInclude(wm => wm.Material)
                .Include(user => user.MechanicWorksheets)
                    .ThenInclude(ws => ws.WorksheetMaterials)
                        .ThenInclude(wm => wm.Material)
                .ToList<User>();
        }
    }
}
