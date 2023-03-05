using KeyCastle.DapperPort.Abstraction;

namespace KeyCastle.DataAccess.Abstraction.Repositories
{
    internal abstract class SqlHandlerRepository
    {
        protected readonly IHandleInlineSql _sqlHandler;

        protected SqlHandlerRepository(IHandleInlineSql sqlHandler) => _sqlHandler = sqlHandler;
    }
}
