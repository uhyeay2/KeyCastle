using KeyCastle.DataAccess.Abstraction.ModelBuilding;
using KeyCastle.Domain.Models;

namespace KeyCastle.DataAccess.ModelBuilders
{
    internal class PlayerModelBuilder : IModelBuilder<PlayerDTO, Player>
    {
        public Player Build(PlayerDTO input)
        {
            return input == null ?  default! : new Player(input.Guid, input.UserName, input.CreatedAtDateUTC);
        }
    }
}
