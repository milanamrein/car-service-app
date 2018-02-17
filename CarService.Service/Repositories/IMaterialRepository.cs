using CarService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Service.Repositories
{
    /// <summary>
    /// Material Repository Interface
    /// </summary>
    public interface IMaterialRepository : IRepository<Material, MaterialDTO>
    {
    }
}
