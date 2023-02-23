namespace GameServer.Room
{
    public interface IRoom
    {
        string Name { get; set; }
        public void AddAdjacentRoom(IRoom room);
        public List<IRoom> GetConnectedRooms();

    }
}
