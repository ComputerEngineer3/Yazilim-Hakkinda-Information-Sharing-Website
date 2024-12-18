﻿using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        Context context = new Context();
        DbSet<T> _object;

        public GenericRepository()
        {
            _object = context.Set<T>();
        }

        public void Add(T t)
        {
            var addedEntity = context.Entry(t);
            addedEntity.State = EntityState.Added;
            //_object.Add(t);
            context.SaveChanges();
        }

        public void Delete(T t)
        {
            var deletedEntity = context.Entry(t);
            deletedEntity.State = EntityState.Deleted;
            //_object.Remove(t);
            context.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public void Update(T t)
        {
            var updatedEntity = context.Entry(t);
            updatedEntity.State = EntityState.Modified;

            

            context.SaveChanges();
        }
    }
}
