using CourceProject.Components.Models;

namespace CourceProject.Components.Data
{
    public interface IConfidantRepository
    {
        public Task AddConfidant(Confidant confidant);
        public Task UpdateConfidant(Confidant confidant);
        public Task<IReadOnlyCollection<Confidant>> GetConfidants();
        public void Delete(Confidant confidant) { }
    }
}
