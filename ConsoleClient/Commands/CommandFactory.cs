namespace ConsoleClient.Commands
{
    public class CommandFactory
    {
        public ICommand CreateCommand<T>() where T : ICommand, new()
        {
            return new T();
        }
    }
}
