using KeyCastle.DataAccess.Abstraction.BaseDapperRequests;

namespace KeyCastle.DataAccess.DataRequestObjects.PlayerRequests
{
    internal class InsertPlayer : GuidRequest
    {
        public InsertPlayer(Guid guid, string userName) : base(guid) => UserName = userName;

        public string UserName { get; set; }

        public override object? GetParameters() => new { Guid, UserName };

        public override string GetSql() => "INSERT INTO Player (Guid, Username) VALUES (@Guid, @Username)";
    }
}
