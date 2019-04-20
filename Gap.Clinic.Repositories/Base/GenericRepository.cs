namespace Gap.Clinic.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Persistence;
    using Services;
    using Microsoft.EntityFrameworkCore;

    public class GenericRepository<T>
        where T : class
    {
        #region Constructor
        public GenericRepository(ClinicContext context)
        {
            _context = context;
        }
        #endregion

        #region Propiedades
        protected DbContext _context;
        #endregion

        #region Métodos publicos
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsEnumerable();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public IEnumerable<T> GetAll(string include)
        {
            IQueryable<T> query = _context.Set<T>();
            return Include(query, include).AsEnumerable();
        }

        public async Task<List<T>> GetAllAsync(string include)
        {
            IQueryable<T> query = _context.Set<T>();
            return await Include(query, include).ToListAsync();
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> function)
        {
            return _context.Set<T>().Where(function).AsEnumerable();
        }

        public async Task<List<T>> FindByAsync(Expression<Func<T, bool>> function)
        {
            return await _context.Set<T>().Where(function).ToListAsync();
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> function, string include)
        {
            IQueryable<T> query = _context.Set<T>().Where(function);
            return Include(query, include).AsEnumerable();
        }

        public async Task<List<T>> FindByAsync(Expression<Func<T, bool>> function, string include)
        {
            IQueryable<T> query = _context.Set<T>().Where(function);
            return await Include(query, include).ToListAsync();
        }

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Set<T>().Remove(entity);
        }

        public void Edit(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        #endregion

        #region Métodos privados

        private IQueryable<T> Include(IQueryable<T> query, string include)
        {
            foreach (string property in include.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(property);
            }
            return query;
        }
        #endregion
    }
}
