using System.Data;

namespace KeyCastle.DapperPort.Abstraction
{
    public interface IDbConnectionFactory
    {
        public IDbConnection NewConnection();
    }
}
