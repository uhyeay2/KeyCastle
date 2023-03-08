namespace KeyCastle.DataAccess.Tests.DataRequestTests.PlayerRequestTests
{
    public class GetAllPlayerTests : InlineSqlTest
    {
        [Fact]
        public async Task GetAllPlayers_Should_ReturnAllPlayers()
        {
            var playerGuids = new[] { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };

            foreach (var guid in playerGuids)
            {
                await SqlHandler.ExecuteAsync(new InsertPlayer(guid, guid.ToString()));
            }

            var players = await SqlHandler.FetchListAsync(new GetAllPlayers());

            foreach (var guid in playerGuids)
            {
                await SqlHandler.ExecuteAsync(new DeletePlayer(guid));
            }

            Assert.All(playerGuids, x => players.Select(_ => _.Guid).Contains(x));
        }
    }
}
