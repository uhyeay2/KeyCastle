using KeyCastle.DapperPort.Abstraction;

namespace KeyCastle.DapperPort.Implementation
{
    internal abstract class DapperHandler
    {
        protected readonly IDbConnectionFactory _connectionFactory;

        public DapperHandler(IDbConnectionFactory connectionFactory) => _connectionFactory = connectionFactory;
    }
}
