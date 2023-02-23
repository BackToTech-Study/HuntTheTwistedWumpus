namespace GameServer.Room
{
    public class Room : IRoom
    {
        public Dictionary<IRoom, List<IRoom>> _connectedRooms;
        public string Name { get; set; }

        public Room(string name)
        {
            _connectedRooms = new Dictionary<IRoom, List<IRoom>>();
            Name = name;
        }

        public void AddAdjacentRoom(IRoom adjacentRoom)
        {
            if (!_connectedRooms.ContainsKey(this))
            {
                _connectedRooms[this] = new List<IRoom>();
            }

            _connectedRooms[this].Add(adjacentRoom);
        }

        public List<IRoom> GetConnectedRooms()
        {
            return _connectedRooms[this];
        }
    }
}
