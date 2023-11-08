using Microsoft.EntityFrameworkCore;
using Movie_Ticket_Web_API.Context;

namespace Movie_Ticket_Web_API.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ApplicationDbContext _context = null;
        protected DbSet<T> table = null;
        public GenericRepository(ApplicationDbContext context)
        {
            this._context = context;
            table = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await table.ToListAsync();
        }

        
        public async Task<T> GetById(object id)
        {
            return await table.FindAsync(id);
        }
        public async Task CreateAsync(T obj)
        {
            await table.AddAsync(obj);
        }
        public async Task UpdateAsync(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public async Task DeleteAsync(object id)
        {
            T existing = await table.FindAsync(id);
            table.Remove(existing);
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
