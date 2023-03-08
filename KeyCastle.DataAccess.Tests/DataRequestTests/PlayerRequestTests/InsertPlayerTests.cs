using System.Data.SqlClient;

namespace KeyCastle.DataAccess.Tests.DataRequestTests.PlayerRequestTests
{
    public class InsertPlayerTests : InlineSqlTest
    {
        [Fact]
        public async Task InsertPlayer_Given_PlayerIsInserted_Should_ReturnOne()
        {
            var rowsAffected = await SqlHandler.ExecuteAsync(new InsertPlayer(TestGuid, "InsertReturnsOne"));

            await SqlHandler.ExecuteAsync(new DeletePlayer(TestGuid));

            Assert.Equal(1, rowsAffected);
        }

        [Fact]
        public async Task InsertPlayer_Given_UserNameIsAlreadyTaken_Should_ThrowSqlException()
        {
            var insertRequest = new InsertPlayer(TestGuid, "NonUniqueUserNameThrowsException");

            await SqlHandler.ExecuteAsync(insertRequest);

            var exception = await Record.ExceptionAsync(async () => await SqlHandler.ExecuteAsync(insertRequest));

            await SqlHandler.ExecuteAsync(new DeletePlayer(TestGuid));

            Assert.IsType<SqlException>(exception);
        }

        [Fact]
        public async Task InsertPlayer_Given_PlayerIsInserted_Should_InsertCorrectValues()
        {
            var insertRequest = new InsertPlayer(TestGuid, "InsertPlayerCorrectUsername");

            await SqlHandler.ExecuteAsync(insertRequest);

            var player = await SqlHandler.FetchAsync(new GetPlayer(TestGuid));

            await SqlHandler.ExecuteAsync(new DeletePlayer(TestGuid));

            Assert.Multiple(() =>
            {
                Assert.NotNull(player);

                Assert.Equal(insertRequest.Guid, player.Guid);
                Assert.Equal(insertRequest.UserName, player.UserName);
            });
        }
    }
}
