using KeyCastle.DataAccess.Abstraction.BaseDapperRequests;

namespace KeyCastle.DataAccess.DataRequestObjects.PlayerRequests
{
    internal class DeletePlayer : GuidRequest
    {
        public DeletePlayer(Guid guid) : base(guid) { }

        public override string GetSql() => "DELETE FROM Player WHERE Guid = @Guid";
    }
}
