namespace GameServer.Caverns
{
    using GameServer.Commands;
    using GameServer.Messages;
    using GameServer.Players;
    public interface IRoom
    {
        string Name { get; set; }
        public List<ISoundSensible> SoundSensibleObjects { get; }
        public List<Player> Players { get; }

        public void AddAdjacentRoom(IRoom room);
        public IReadOnlyList<IRoom> GetConnectedRooms();
        public void ReceiveSound(Sound sound);
        public void ExecuteCommand(ICommand command);

        public IReadOnlyList<Player> GetPlayers(); 
        public void ReceivePlayer(Player player);
        public void RemovePlayer(Player player);
        public void WhisperPlayer(Player player);
    }
}
