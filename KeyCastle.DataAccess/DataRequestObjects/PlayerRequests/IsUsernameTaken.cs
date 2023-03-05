using KeyCastle.DapperPort.Abstraction;

namespace KeyCastle.DataAccess.DataRequestObjects.PlayerRequests
{
    internal class IsUsernameTaken : IDapperRequest<bool>
    {
        public IsUsernameTaken(string username) => Username = username;

        public string Username { get; set; }

        public object? GetParameters() => new { Username };

        public string GetSql() => "SELECT CASE WHEN EXISTS ( SELECT * FROM Player WHERE Username = @Username ) THEN 1 ELSE 0 END";
    }
}
