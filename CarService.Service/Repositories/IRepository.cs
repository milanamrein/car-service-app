using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CarService.Service.Repositories
{
    /// <summary>
    /// Generic Repository Interface
    /// </summary>
    public interface IRepository<TEntity, TEntityDTO> 
        where TEntity : class 
        where TEntityDTO : class
    {
        /// <summary>
        /// AutoMapper property
        /// </summary>
        IMapper Mapper { get; set; }

        IEnumerable<TEntityDTO> GetAll();
        TEntity Get(object id);
        bool Any(Expression<Func<TEntity, bool>> predicate);
        TEntity Find(Expression<Func<TEntity, bool>> predicate);

        TEntity Add(TEntityDTO entityDTO);
        void Remove(TEntity entity);
    }
}
