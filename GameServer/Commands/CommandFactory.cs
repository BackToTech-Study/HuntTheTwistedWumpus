

using GameServer.Room;


namespace GameServer.Commands
{
    using GameServer.Sound;
    public class CommandFactory
    {

        public ICommand CreateCommand<T>() where T : ICommand, new()
        {
            return new T();
        }

        public ICommand CreateCommand<T, U, V>(U arg1, V arg2) where T : ICommand
        {
            object[] constructorArgs = new object[] { arg1, arg2 };
            return (T)Activator.CreateInstance(typeof(T), constructorArgs);
        }
    }
}

