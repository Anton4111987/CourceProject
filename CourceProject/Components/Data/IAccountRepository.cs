using CourceProject.Components.Models;

namespace CourceProject.Components.Data
{
    public interface IAccountRepository
    {
        public Task AddAccount(Account account);
        public Task UpdateAccount(Account account);
        public Task<IReadOnlyCollection<Account>> GetAccounts();
        public Task<Account?> GetAccountById(int id);
        public void Delete(Account account) { }
    }
}
