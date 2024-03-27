﻿using System.Linq.Expressions;

namespace PrjBlocoSistemaWeb.Repository
{
    public abstract class RepositoryBase<T> where T : class, new()
    {
        protected PrjBlocoSistemaWebContext Context { get; set; }

        public RepositoryBase(PrjBlocoSistemaWebContext context)
        {
            Context = context;
        }

        public void Save(T entity)
        {
            this.Context.Add(entity);
            this.Context.SaveChanges();
        }

        public void Update(T entity)
        {
            this.Context.Update(entity);
            this.Context.SaveChanges();
        }
        public void Delete(T entity)
        {
            this.Context.Remove(entity);
            this.Context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return this.Context.Set<T>().ToList();
        }

        public T GetById(Guid id)
        {
            return this.Context.Set<T>().Find(id);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return this.Context.Set<T>().Where(expression);
        }

        public bool Exists(Expression<Func<T, bool>> expression)
        {
            return this.Find(expression).Any();
        }
    }
}
