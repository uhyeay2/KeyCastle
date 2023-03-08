namespace KeyCastle.DataAccess.DataRequestObjects.PlayerRequests
{
    internal class GetAllPlayers : ParameterlessRequest<PlayerDTO>
    {
        public override string GetSql() => "SELECT * FROM Player";
    }
}
