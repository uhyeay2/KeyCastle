namespace KeyCastle.DataAccess.Tests.DataRequestTests.PlayerRequestTests
{
    public class IsUserNameTakenTests : InlineSqlTest
    {
        [Fact]
        public async Task IsUserNameTake_Given_UserNameNotTaken_Should_ReturnFalse()
        {
            var exists = await SqlHandler.FetchAsync(new IsUsernameTaken("UserNameNotTakenReturnsFalse"));

            Assert.False(exists);
        }

        [Fact]
        public async Task IsUserNameTake_Given_UserNameIsTaken_Should_ReturnTrue()
        {
            var userName = "UserNameTakenReturnsTrue";

            await SqlHandler.ExecuteAsync(new InsertPlayer(TestGuid, userName));

            var exists = await SqlHandler.FetchAsync(new IsUsernameTaken(userName));

            await SqlHandler.ExecuteAsync(new DeletePlayer(TestGuid));

            Assert.True(exists);
        }
    }
}
