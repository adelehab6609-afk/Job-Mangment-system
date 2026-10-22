using Job_Recruitment_Management_System.Data;
using Microsoft.EntityFrameworkCore;

namespace Job_Recruitment_Management_System.GenericRepo
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        public readonly AppDbContext _context;
        
        public GenericRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T item)
        {
            await _context.Set<T>().AddAsync(item);
        }

        public async Task DeleteAsync(T item)
        {
             _context.Remove(item);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T item)
        {
             _context.Set<T>().Update(item);
        }
    }
}
