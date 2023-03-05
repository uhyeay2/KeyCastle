namespace KeyCastle.Domain.Models
{
    public class Player
    {
        public Player(Guid guid, string userName, DateTime createdAtDateUTC)
        {
            Guid = guid;
            UserName = userName;
            CreatedAtDateUTC = createdAtDateUTC;
        }

        public Guid Guid { get; set; }

        public string UserName { get; set; }

        public DateTime CreatedAtDateUTC { get; set; }
    }
}
