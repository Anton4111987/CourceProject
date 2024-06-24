using CourceProject.Components.Models;

namespace CourceProject.Components.Data
{
    public interface IUserRepository
    {
        /// <summary>
        /// Метод добавления пользователя (асинхронный)
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task AddUser(User user);

        /// <summary>
        /// Метод обновление данных пользователя (асинхронный)
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task UpdateUser(User user);

        /// <summary>
        /// Метод получения всех пользователей (асинхронный)
        /// </summary>
        /// <returns></returns>
        public Task<IReadOnlyCollection<User>> GetUsers();

        /// <summary>
        /// Метод получения пользователя по ID (асинхронный)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<User?> GetUserById(int id);

        /// <summary>
        /// Метод удаления пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task DeleteUser(User user);

    }
}