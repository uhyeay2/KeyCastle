using KeyCastle.DapperPort.Abstraction;
using KeyCastle.DataAccess.DataTransferObjects;

namespace KeyCastle.DataAccess.DataRequestObjects.PlayerRequests
{
    internal class GetPlayer : IDapperRequest<PlayerDTO>
    {
        #region Constructors

        public GetPlayer(int id) => Id = id;

        public GetPlayer(string userName) => UserName = userName;

        public GetPlayer(Guid guid) => Guid = guid;

        #endregion

        #region Field Searchable By

        public readonly string? UserName;

        public readonly Guid? Guid;

        public readonly int? Id;

        #endregion

        #region IDapperRequest Obligations

        public object? GetParameters() => new {Guid, UserName, Id};

        public string GetSql() => "SELECT * FROM Player WHERE (Guid = @Guid AND @Id IS NULL AND @UserName IS NULL ) " +
                                                          "OR (Id = @Id AND @Guid IS NULL AND @UserName IS NULL ) " +
                                                          "OR (UserName = @UserName AND @Guid is NULL AND @Id IS NULL)";
        #endregion
    }
}
