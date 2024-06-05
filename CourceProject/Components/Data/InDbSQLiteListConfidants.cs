using CourceProject.Components.Models;
using Microsoft.EntityFrameworkCore;

namespace CourceProject.Components.Data
{
    public class InDbSQLiteListConfidants: IConfidantRepository
    {
        private readonly AppDbContext _context;

        public InDbSQLiteListConfidants(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task AddConfidant(Confidant confidant)
        {
            await _context.Confidants.AddAsync(confidant);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateConfidant(Confidant confidant)
        {
            _context.Confidants.Update(confidant);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<Confidant>> GetConfidants()
        {
            var list = await _context.Confidants.ToListAsync();
            return list.AsReadOnly();
        }

        public void Delete(Confidant confidant)
        {
            _context.Confidants.Remove(confidant);
            _context.SaveChanges();
        }

    }
}
