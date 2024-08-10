using GameServer.Caverns;
using GameServer.Commands;

namespace GameServer.Players.PlayerStates
{
    public class AliveActiveState : IState
    {
        public void WalkToRoom(Player player, IRoom room)
        {
            if (player == null || room == null)
                throw new ArgumentNullException("Player or room shouldn't be null");

            WalkToCommand walkToCommand = new WalkToCommand(room);
            walkToCommand.Execute(player);
        }
    }
}
