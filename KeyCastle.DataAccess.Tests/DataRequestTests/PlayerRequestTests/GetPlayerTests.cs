namespace KeyCastle.DataAccess.Tests.DataRequestTests.PlayerRequestTests
{
    public class GetPlayerTests : InlineSqlTest
    {
        [Fact]
        public async Task GetPlayer_Given_NoPlayerExists_Should_ReturnNull()
        {
            var playerById = await SqlHandler.FetchAsync(new GetPlayer(-1));
            var playerByGuid = await SqlHandler.FetchAsync(new GetPlayer(TestGuid));
            var playerByUserName = await SqlHandler.FetchAsync(new GetPlayer("NoPlayerWithThisUserName"));

            Assert.Multiple(() =>
            {
                Assert.Null(playerById);
                Assert.Null(playerByGuid);
                Assert.Null(playerByUserName); 
            });
        }

        [Fact]
        public async Task GetPlayer_Given_Guid_Should_ReturnPlayer()
        {
            var insertedPlayer = new InsertPlayer(TestGuid, "GetPlayerByGuidFetchsPlayer");

            await SqlHandler.ExecuteAsync(insertedPlayer);

            var player = await SqlHandler.FetchAsync(new GetPlayer(TestGuid));

            await SqlHandler.ExecuteAsync(new DeletePlayer(TestGuid));

            Assert.Multiple(() =>
            {
                Assert.NotNull(player);

                Assert.Equal(insertedPlayer.UserName, player.UserName);
                Assert.Equal(insertedPlayer.Guid, player.Guid);
            });
        }

        [Fact]
        public async Task GetPlayer_Given_UserName_Should_ReturnPlayer()
        {
            var insertedPlayer = new InsertPlayer(TestGuid, "GetPlayerByUserNameFetchsPlayer");

            await SqlHandler.ExecuteAsync(insertedPlayer);

            var player = await SqlHandler.FetchAsync(new GetPlayer(insertedPlayer.UserName));

            await SqlHandler.ExecuteAsync(new DeletePlayer(TestGuid));

            Assert.Multiple(() =>
            {
                Assert.NotNull(player);

                Assert.Equal(insertedPlayer.UserName, player.UserName);
                Assert.Equal(insertedPlayer.Guid, player.Guid);
            });
        }

        [Fact]
        public async Task GetPlayer_Given_Id_Should_ReturnPlayer()
        {
            var insertedPlayer = new InsertPlayer(TestGuid, "GetPlayerByIdFetchsPlayer");

            await SqlHandler.ExecuteAsync(insertedPlayer);

            var playerDTO = await SqlHandler.FetchAsync(new GetPlayer(TestGuid));

            var playerById = await SqlHandler.FetchAsync(new GetPlayer(playerDTO.Id));

            await SqlHandler.ExecuteAsync(new DeletePlayer(TestGuid));

            Assert.Multiple(() =>
            {
                Assert.NotNull(playerById);

                Assert.Equal(insertedPlayer.UserName, playerById.UserName);
                Assert.Equal(insertedPlayer.Guid, playerById.Guid);
            });
        }
    }
}
