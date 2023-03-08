using KeyCastle.DapperPort.Abstraction;
using KeyCastle.DapperPort.DependencyInjection;

namespace KeyCastle.DataAccess.Tests.TestHelpers
{
    public abstract class InlineSqlTest
    {
        protected IHandleInlineSql SqlHandler = ServiceInjection.NewSqlHandler(Hidden.TestDbConnectionString);

        protected Guid TestGuid = Guid.NewGuid();
    }
}
