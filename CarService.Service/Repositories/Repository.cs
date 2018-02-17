using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    /// Generic Repository Class
    /// </summary>
    public class Repository<TEntity, TEntityDTO> : IRepository<TEntity, TEntityDTO>
        where TEntity : class
        where TEntityDTO : class
    {
        protected readonly DbContext Context;        

        public Repository(DbContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        /// <summary>
        /// AutoMapper property
        /// </summary>
        public IMapper Mapper { get; set; }

        public IEnumerable<TEntityDTO> GetAll()
        {
            return this.Mapper.Map<IEnumerable<TEntityDTO>>(this.Context.Set<TEntity>().ToList<TEntity>());
        }

        public TEntity Get(object id)
        {            
            return this.Context.Set<TEntity>().Find(id);
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return this.Context.Set<TEntity>().Any(predicate);
        }

        public TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            return this.Context.Set<TEntity>().Where(predicate).FirstOrDefault();
        }

        public TEntity Add(TEntityDTO entityDTO)
        {
            TEntity entity = Mapper.Map<TEntity>(entityDTO);
            this.Context.Set<TEntity>().Add(entity);

            return entity;
        }

        public void Remove(TEntity entity)
        {
            this.Context.Set<TEntity>().Remove(entity);
        }        
    }
}
