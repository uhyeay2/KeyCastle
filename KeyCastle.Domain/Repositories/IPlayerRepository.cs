using KeyCastle.Domain.Models;

namespace KeyCastle.Domain.Repositories
{
    public interface IPlayerRepository
    {
        public Task<int> InsertPlayerAsync(Guid guid, string username);

        public Task<IEnumerable<Player>> GetAllPlayersAsync();

        public Task<Player> GetPlayerAsync(string username);

        public Task<Player> GetPlayerAsync(Guid guid);

        public Task<bool> IsUserNameTakenAsync(string username);

        public Task<int> DeletePlayerAsync(Guid guid);
    }
}
