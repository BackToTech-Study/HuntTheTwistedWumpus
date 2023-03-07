namespace GameServer.Commands
{
    public class CommandFactory
    {

        public ICommand CreateCommand<T>() where T : ICommand, new()
        {
            return new T();
        }

        public ICommand CreateCommand<T, U>(U arg1) where T : ICommand
        {
            object[] constructorArgs = new object[] { arg1 };
            return (T)Activator.CreateInstance(typeof(T), constructorArgs);
        }
    }
}

