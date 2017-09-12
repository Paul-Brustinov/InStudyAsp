using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Common
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int Id);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        void AddOrUpdate(T entity);
        void Delete(T entity);

        void Save();
    }
}
