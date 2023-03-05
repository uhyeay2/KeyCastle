using KeyCastle.DapperPort.Abstraction;

namespace KeyCastle.DataAccess.Abstraction.BaseDapperRequests
{
    internal abstract class GuidRequest : IDapperRequest
    {
        public GuidRequest(Guid guid) => Guid = guid;

        public Guid Guid { get; set; }

        public virtual object? GetParameters() => new {Guid };

        public abstract string GetSql();
    }

    internal abstract class GuidRequest<TOutput> : GuidRequest, IDapperRequest<TOutput>
    {
        protected GuidRequest(Guid guid) : base(guid) { }
    }
}
