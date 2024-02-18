using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using System.Linq;
using CourceProject.Components.Models;

namespace CourceProject.Components.Data
{
    public class InDbSQLiteListUsers : IUserRepository
    {
        private readonly AppDbContext _context;


        public InDbSQLiteListUsers(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUser(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<User>> GetUsers()
        {
            var list = await _context.Users.ToListAsync();
            return list.AsReadOnly();
        }
        public async Task<User?> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User?> GetUserByNameAndPasswordAsync(string Name, string Password)
        {
            return await _context.Users.FindAsync(Name, Password);
        }

    }

}
