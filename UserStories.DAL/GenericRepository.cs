using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace UserStories.DAL
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {
        readonly DbContext _context;

        public GenericRepository(DbContext context)
        {
            _context = context;
        }

        public IQueryable<T> Get
        {
            get { return _context.Set<T>(); }
        }

        public IQueryable<T> GetIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public T Find(object[] keyValues)
        {
            return _context.Set<T>().Find(keyValues);
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();

        }

        public void Update(T entity)
        {
            var entry = _context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                _context.Set<T>().Attach(entity);
                entry = _context.Entry(entity);
            }
            entry.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void AddOrUpdate(T entity)
        {
            //uses DbContextExtensions to check value of primary key
            _context.AddOrUpdate(entity);
            _context.SaveChanges();
        }

        public void Delete(object[] keyValues)
        {
            var stub = _context.Load<T>(keyValues);
            _context.Set<T>().Remove(stub);
            _context.SaveChanges();
        }
    }
}
