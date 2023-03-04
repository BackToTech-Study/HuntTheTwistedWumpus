namespace GameServer.Commands
{
    using GameServer.Sound;
    using GameServer.Room;
    public class MakeSoundCommand : ICommand
    {
        public string Name { get; set; } = "Make sound";
        private Sound _sound;
        private IRoom _room;
        private static bool _hasPropagated;

        public MakeSoundCommand()
        {
        }

        public MakeSoundCommand(Sound sound, IRoom room)
        {
            _sound = sound;
            _room = room;
        }

        public void PropagateSound(IRoom room, Sound sound)
        {
            if (_hasPropagated == true)
            {
                return;
            }

            room.ReceiveSound(sound);

            List<IRoom> adjacentRooms = room.GetConnectedRooms();

            if (sound.PropagationDistance > 0)
            {
                adjacentRooms.ForEach(adjacentRoom => adjacentRoom.ReceiveSound(sound));
            }

            _hasPropagated = true;
        }

        public void Execute()
        {
            PropagateSound(_room, _sound);
        }
    }
}
