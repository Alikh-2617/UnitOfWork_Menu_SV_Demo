using DAL.AppDbContext;
using DAL.Doman.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementation
{
    public class GenericService<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;

        public GenericService(ApplicationDbContext context)
        {
            _context = context;   
        }

        public void Delete(T entiry) =>  _context.Set<T>().Remove(entiry);

        public async Task<T?> Find(Guid id) => await _context.Set<T>().FindAsync(id);

        public async Task<IEnumerable<T>> GetAll() =>await _context.Set<T>().ToListAsync();

        public async Task insert(T entity)=> await _context.Set<T>().AddAsync(entity);

        public void Update(T entity) =>  _context.Set<T>().Entry(entity).State = EntityState.Modified;
        
    }
}
