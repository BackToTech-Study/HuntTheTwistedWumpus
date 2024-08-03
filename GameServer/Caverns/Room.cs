using GameServer.Commands;
using GameServer.Messages;
using GameServer.Players;

namespace GameServer.Caverns
{
    public class Room : IRoom, ISoundSensible
    {
        public List<IRoom> _connectedRooms;
        public string Name { get; set; }
        private readonly List<ISoundSensible> _soundSensibleObjects = new List<ISoundSensible>();

        public List<ISoundSensible> SoundSensibleObjects => _soundSensibleObjects;

        private readonly List<Player> _players = new List<Player>();
        public List<Player> Players => _players;

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

        public IReadOnlyList<Player> GetPlayers()
        {
            return _players.AsReadOnly();
        }

        public void ReceivePlayer(Player player)
        {
            _players.Add(player);
        }

        public void RemovePlayer(Player player)
        {
            _players.Remove(player);
        }

        public void WhisperPlayer(Player player)
        {
            // TODO_BOGI forgot the use case of this function
        }
    }
}
