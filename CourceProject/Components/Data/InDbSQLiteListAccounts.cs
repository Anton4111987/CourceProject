using CourceProject.Components.Models;
using Microsoft.EntityFrameworkCore;

namespace CourceProject.Components.Data
{
    public class InDbSQLiteListAccounts : IAccountRepository
    {
        private readonly AppDbContext _context;

        public InDbSQLiteListAccounts(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task AddAccount(Account account)
        {
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAccount(Account account)
        {
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<Account>> GetAccounts()
        {
            var list = await _context.Accounts.ToListAsync();
            return list.AsReadOnly();
        }
        public async Task<Account?> GetAccountById(int id)
        {
            return await _context.Accounts.FindAsync(id);
        }
    }
}
