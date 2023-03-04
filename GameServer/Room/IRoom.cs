namespace GameServer.Room
{
    using GameServer.Sound;
    public interface IRoom
    {
        string Name { get; set; }
        Sound Sound { get; set; }
        public void AddAdjacentRoom(IRoom room);
        public List<IRoom> GetConnectedRooms();
        public void ReceiveSound(Sound sound);

    }
}
