using GameServer.Caverns;

namespace GameServer.Players.PlayerStates
{
    public interface IState
    {
        public void WalkToRoom(Player player, IRoom room);
    }
}
