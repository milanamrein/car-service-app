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
    /// Material Repository
    /// </summary>
    public class MaterialRepository : Repository<Material, MaterialDTO>, IMaterialRepository
    {
        public MaterialRepository(CarServiceContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }
    }
}
