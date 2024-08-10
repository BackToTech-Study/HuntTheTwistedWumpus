using GameServer.Caverns;
using GameServer.Players;

namespace GameServer.Commands
{
    public class WalkToCommand : ICommand
    {
        public string Name = "Walk to ";
        private IRoom _room;

        public WalkToCommand(IRoom room)
        {
            _room = room;
            Name += _room.Name;
        }

        private void MovePlayerToRoom(Player? player)
        {
            if (player == null)
                return;

            player.SetCurrentRoom(_room);
        }

        public void Execute(object player)
        {
            MovePlayerToRoom((player as Player));
        }
    }
}
