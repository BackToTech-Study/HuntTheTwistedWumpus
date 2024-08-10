using GameServer.Caverns;
using GameServer.Connection;
using GameServer.Players;

namespace GameServer
{
    public class GameManager
    {
        private static GameManager _instance;
        private List<IRoom> _rooms;
        private Player _player;

        public static GameManager GetInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameManager();
                    _instance.InitGameManager();
                }
                return _instance;
            }
        }

        public void InitGameManager()
        {
            InitRooms();
            ConnectRooms();

            IConnection connection = null;
            
            _player = new Player(_rooms.First());
        }

        public Player GetPlayer() { return _player; }
        public IRoom? GetRoom(string roomName)
        {
            foreach (IRoom room in _rooms)
            {
                if (room.Name == roomName) 
                    return room;
            }

            return null;
        }

        private void ConnectRooms()
        {
            // For the moment all rooms are connected
            for (int currentRoomIndex = 0; currentRoomIndex < _rooms.Count; ++currentRoomIndex)
            {
                for (int roomToConnectIndex = 0; roomToConnectIndex < _rooms.Count; roomToConnectIndex++)
                {
                    if (_rooms[currentRoomIndex] != _rooms[roomToConnectIndex])
                    {
                        _rooms[currentRoomIndex].AddAdjacentRoom(_rooms[roomToConnectIndex]);
                    }
                }
            }
        }

        private void InitRooms()
        {
            _rooms = new List<IRoom>();
            _rooms.Add(new Room("Room 1"));
            _rooms.Add(new Room("Room 2"));
            _rooms.Add(new Room("Room 3"));
        }
    }
}
