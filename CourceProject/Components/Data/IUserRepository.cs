using CourceProject.Components.Models;

namespace CourceProject.Components.Data
{
    public interface IUserRepository
    {
        public Task AddUser(User user);
        public Task UpdateUser(User user);
        public Task<IReadOnlyCollection<User>> GetUsers();
        public Task<User?> GetUserById(int id);

    }
}