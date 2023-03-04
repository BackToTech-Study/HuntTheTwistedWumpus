namespace GameServer.Caverns
{
    using GameServer.Commands;
    using GameServer.Messages;
    public interface IRoom
    {
        string Name { get; set; }
        public List<ISoundSensible> SoundSensibleObjects { get; }
        public void AddAdjacentRoom(IRoom room);
        public IReadOnlyList<IRoom> GetConnectedRooms();
        public void ReceiveSound(Sound sound);
        public void ExecuteCommand(ICommand command);
    }
}
