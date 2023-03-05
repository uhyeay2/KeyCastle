using KeyCastle.DapperPort.Abstraction;
using KeyCastle.DapperPort.DependencyInjection;

namespace KeyCastle.DataAccess.Tests.TestHelpers
{
    public abstract class InlineSqlTest
    {
        protected IHandleInlineSql _sqlHandler = ServiceInjection.NewSqlHandler(Hidden.TestDbConnectionString);
    }
}
