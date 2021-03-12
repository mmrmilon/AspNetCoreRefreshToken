using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected DatabaseContext context;
        protected DbSet<TEntity> table;

        public Repository(DatabaseContext context)
        {
            this.context = context;
            table = context.Set<TEntity>();
        }
        
        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = table;
            
            if (filter != null)
                query = query.Where(filter);
            
            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
                return orderBy(query).ToList();
            else
                return query.ToList();
        }

        public TEntity GetById(object id)
        {
            return table.Find(id);
        }

        public long Insert(TEntity entity)
        {
            table.Add(entity);
            return entity.Id;
        }

        public void InsertRange(IEnumerable<TEntity> entities)
        {
            table.AddRange(entities);
        }

        public void Update(TEntity entity)
        {
            table.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            //foreach (var entity in entities)
            //{
            //    this.Update(entity);
            //}
            table.UpdateRange(entities);
        }

        public void Delete(object id)
        {
            TEntity data = table.Find(id);
            this.Delete(data);
        }

        public void Delete(TEntity entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                table.Attach(entity);
            }

            table.Remove(entity);
        }
    }
}
