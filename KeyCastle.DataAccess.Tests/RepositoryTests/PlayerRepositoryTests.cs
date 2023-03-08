
using KeyCastle.DapperPort.Abstraction;
using KeyCastle.DataAccess.DataTransferObjects;
using KeyCastle.DataAccess.ModelBuilders;
using KeyCastle.DataAccess.Repositories;
using KeyCastle.Domain.Repositories;
using Moq;

namespace KeyCastle.DataAccess.Tests.RepositoryTests
{
    public class PlayerRepositoryTests
    {
        private readonly IPlayerRepository _playerRepository;

        private readonly Mock<IHandleInlineSql> _mockSqlHandler;

        public PlayerRepositoryTests()
        {

            _mockSqlHandler = new();
            _playerRepository = new PlayerRepository(_mockSqlHandler.Object, new PlayerModelBuilder());
        }

        [Fact]
        public async Task GetAllPlayers_Given_NoResultsFound_Should_ReturnEmptyCollection()
        {
            _mockSqlHandler.Setup(_ => _.FetchListAsync(It.IsAny<GetAllPlayers>())).Returns(Task.FromResult(Enumerable.Empty<PlayerDTO>()));

            var result = await _playerRepository.GetAllPlayersAsync();

            Assert.Empty(result);
        }

        [Fact]
        public async Task GetPlayerByUsername_Given_NullFromSqlHandler_Should_ReturnNull()
        {
            _mockSqlHandler.Setup(_ => _.FetchAsync(It.IsAny<GetPlayer>())).Returns(Task.FromResult((PlayerDTO)null!));

            var result = await _playerRepository.GetPlayerAsync("byUsername");

            Assert.Null(result);
        }

        [Fact]
        public async Task GetPlayerByGuid_Given_NullFromSqlHandler_Should_ReturnNull()
        {
            _mockSqlHandler.Setup(_ => _.FetchAsync(It.IsAny<GetPlayer>())).Returns(Task.FromResult((PlayerDTO)null!));

            var result = await _playerRepository.GetPlayerAsync(Guid.NewGuid());

            Assert.Null(result);
        }
    }
}
