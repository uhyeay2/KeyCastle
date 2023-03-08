namespace KeyCastle.DataAccess.Tests.DataRequestTests.PlayerRequestTests
{
    public class DeletePlayerTests : InlineSqlTest
    {
        [Fact]
        public async Task DeletePlayer_Given_NoPlayerExists_Should_ReturnZero()
        {
            var rowsAffected = await SqlHandler.ExecuteAsync(new DeletePlayer(TestGuid));

            Assert.Equal(0, rowsAffected);
        }

        [Fact]
        public async Task DeletePlayer_Given_PlayerIsDeleted_Should_ReturnOne()
        {
            await SqlHandler.ExecuteAsync(new InsertPlayer(TestGuid, "DeletingPlayerReturnsOne"));

            var rowsAffected = await SqlHandler.ExecuteAsync(new DeletePlayer(TestGuid));

            Assert.Equal(1, rowsAffected);
        }
    }
}
