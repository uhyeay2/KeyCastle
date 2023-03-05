namespace KeyCastle.DataAccess.DataTransferObjects
{
    internal class PlayerDTO
    {
        public int Id { get; set; }

        public Guid Guid { get; set; }

        public string UserName { get; set; } = null!;

        public DateTime CreatedAtDateUTC { get; set; }
    }
}
