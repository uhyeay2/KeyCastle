using KeyCastle.DapperPort.Abstraction;

namespace KeyCastle.DataAccess.Abstraction.BaseDapperRequests
{
    internal abstract class ParameterlessRequest : IDapperRequest
    {
        public object? GetParameters() => null;

        public abstract string GetSql();
    }

    internal abstract class ParameterlessRequest<TOutput> : ParameterlessRequest, IDapperRequest<TOutput> { }
}
