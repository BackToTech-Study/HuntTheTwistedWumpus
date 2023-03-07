using GameServer.Commands;
using GameServer.Messages;

namespace GameServer.Caverns
{
    public class Room : IRoom, ISoundSensible
    {
        public List<IRoom> _connectedRooms;
        public string Name { get; set; }

        private readonly List<ISoundSensible> _soundSensibleObjects = new List<ISoundSensible>();
        public List<ISoundSensible> SoundSensibleObjects { get { return _soundSensibleObjects; } }

        public Room(string name)
        {
            _connectedRooms = new List<IRoom>();
            Name = name;
        }

        public void AddAdjacentRoom(IRoom adjacentRoom)
        {
            _connectedRooms.Add(adjacentRoom);
        }

        public IReadOnlyList<IRoom> GetConnectedRooms()
        {
            return _connectedRooms.AsReadOnly();
        }

        public void ReceiveSound(Sound sound)
        {
            var makeSoundCommand = new MakeSoundCommand(sound);
            ExecuteCommand(makeSoundCommand);
        }

        public void ExecuteCommand(ICommand command)
        {
            command.Execute(this);
        }
    }
}
