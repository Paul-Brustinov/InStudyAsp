using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqKit;

namespace Repo.Common
{
    public abstract class GenericRepository<T> : IGenericRepository<T>
       where T : class
    {
        protected DbContext _entities;
        protected readonly IDbSet<T> _dbset;

        public GenericRepository(DbContext context)
        {
            _entities = context;
            _dbset = context.Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {

            return _dbset.AsEnumerable<T>();
        }

        public IEnumerable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> query = _dbset.AsExpandable().Where(predicate).AsEnumerable();
            return query;
        }

        public virtual T Get(int id)
        {
            return _dbset.Find(id);
        }

        public virtual void AddOrUpdate(T entity)
        {
            _dbset.AddOrUpdate(entity);
            //_entities.SaveChanges();
        }

        public virtual void Delete(T entity)
        {

            _dbset.Remove(entity);
            //_entities.SaveChanges();
        }

        public virtual void Save()
        {
            _entities.SaveChanges();
        }
    }
}
