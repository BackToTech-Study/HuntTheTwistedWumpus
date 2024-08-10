using GameServer.Caverns;
using GameServer.Connection;
using GameServer.Players.PlayerStates;

namespace GameServer.Players
{
    public class Player
    {
        private IConnection? _connection;
        private IRoom? _currentRoom;
        private IState? _state;

        public Player()
        {
            _connection = null;
            _currentRoom = null;
            _state = null;
        }
        public Player(IRoom room)
        {
            _currentRoom = room;
            _state = new AliveActiveState();
        }

        public IRoom GetCurrentRoom() 
        {
            if (_currentRoom == null)
                throw new ArgumentNullException(nameof(_currentRoom), "Room cannot be null");

            return  _currentRoom;
        }

        public void SetCurrentRoom(IRoom room)
        {
            if (room == null)       
                throw new ArgumentNullException(nameof(room), "Room cannot be null");

            _currentRoom = room;
        }

        public void WalkToRoom(IRoom room)
        {
            if (room == null || _state == null)
                throw new ArgumentNullException(nameof(room), "Room cannot be null");

            _state.WalkToRoom(this, room);
        }

        public IState GetState()
        {
            if (_state == null)
                throw new ArgumentNullException(nameof(_currentRoom), "Room cannot be null");

            return _state;
        }
        public void SetPlayerState(IState state)
        {
            if (state == null)
                throw new ArgumentNullException(nameof(state), "Room cannot be null");

            _state = state;
        }
    }
}
