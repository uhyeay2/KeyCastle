using KeyCastle.DataAccess.Abstraction.ModelBuilding;
using KeyCastle.DataAccess.Abstraction.Repositories;
using KeyCastle.DataAccess.DataRequestObjects.PlayerRequests;
using KeyCastle.Domain.Models;
using KeyCastle.Domain.Repositories;

namespace KeyCastle.DataAccess.Repositories
{
    internal class PlayerRepository : SqlHandlerRepository, IPlayerRepository
    {
        private readonly IModelBuilder<PlayerDTO, Player> _modelBuilder;

        public PlayerRepository(IHandleInlineSql sqlHandler, IModelBuilder<PlayerDTO, Player> modelBuilder) : base(sqlHandler) => _modelBuilder = modelBuilder;

        public async Task<int> DeletePlayerAsync(Guid guid) => await _sqlHandler.ExecuteAsync(new DeletePlayer(guid));

        public async Task<IEnumerable<Player>> GetAllPlayersAsync()
        {
            var players = await _sqlHandler.FetchListAsync(new GetAllPlayers());

            return players.Any() ? players.Select(_modelBuilder.Build) : Enumerable.Empty<Player>();
        }

        public async Task<Player> GetPlayerAsync(string username) => _modelBuilder.Build(await _sqlHandler.FetchAsync(new GetPlayer(username)));

        public async Task<Player> GetPlayerAsync(Guid guid) => _modelBuilder.Build(await _sqlHandler.FetchAsync(new GetPlayer(guid)));

        public async Task<int> InsertPlayerAsync(Guid guid, string username)
        {
            if(await IsUserNameTakenAsync(username))
            {
                return -1;
            }

            return await _sqlHandler.ExecuteAsync(new InsertPlayer(guid, username));
        }

        public async Task<bool> IsUserNameTakenAsync(string username) => await _sqlHandler.FetchAsync(new IsUsernameTaken(username));
    }
}
