using GameServer.Caverns;
using GameServer.Messages;
namespace GameServer.Commands
{
    public class MakeSoundCommand : ICommand
    {
        public const string Name = "Make sound";
        private Sound _sound;

        public MakeSoundCommand(Sound sound)
        {
            _sound = sound;
        }

        private void PropagateSound(IRoom? room, Sound sound)
        {
            if (null == room || 0 >= sound.PropagationDistance)
            {
                return;
            }

            room.SoundSensibleObjects.ForEach(soundSensibleObject => soundSensibleObject.ReceiveSound(sound));
            sound.PropagationDistance--;

            var adjacentRooms = room.GetConnectedRooms();

            foreach (var adjacentRoom in adjacentRooms)
            {
                var newSound = new Sound(sound.PropagationDistance, sound.Name);
                adjacentRoom.ReceiveSound(newSound);
            }
        }

        public void Execute(object room)
        {
            PropagateSound((room as IRoom), _sound);
        }
    }
}
