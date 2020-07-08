using ITI.Achitecture.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Architecture.Repositories
{
    public class Generic<T> where T : BaseModel
    {
        private DbSet<T> dbSet;
        public EnitiesContext Context { get; set; }

        public Generic(EnitiesContext context)
        {
            Context = context;
            dbSet = Context.Set<T>();
        }

        public T Add(T T)
        {
            return dbSet.Add(T);
        }
        public T Update(T T)
        {
            if (!dbSet.Local.Any(i => i.ID == T.ID))
                dbSet.Attach(T);
            Context.Entry(T).State = EntityState.Modified;
            return T;
        }
        public void Remove(T T)
        {
            dbSet.Remove(T);
        }
        public T GetByID(int id)
        {
            return dbSet.FirstOrDefault(i => i.ID == id);
        }
        public IEnumerable<T> GetAll()
        {
            return dbSet;
        }
        public IEnumerable<T> Get(Expression<Func<T, bool>> filter)
        {
            return dbSet.Where(filter);
        }
    }
}
