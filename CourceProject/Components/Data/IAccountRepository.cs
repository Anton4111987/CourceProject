using CourceProject.Components.Models;

namespace CourceProject.Components.Data
{
    public interface IAccountRepository
    {
        /// <summary>
        /// Метод добавления аккаунта (асинхронный)
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public Task AddAccount(Account account);

        /// <summary>
        /// Метод обновления аккаунта (асинхронный)
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public Task UpdateAccount(Account account);

        /// <summary>
        /// Метод Получения всех аккаунтов (асинхронный)
        /// </summary>
        /// <returns></returns>
        public Task<IReadOnlyCollection<Account>> GetAccounts();

        /// <summary>
        /// Метод Получения всех аккаунтов по ID (асинхронный)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Account?> GetAccountById(int id);

        /// <summary>
        /// Метод удаления аккаунта
        /// </summary>
        /// <param name="account"></param>
        public void Delete(Account account) { }
    }
}
