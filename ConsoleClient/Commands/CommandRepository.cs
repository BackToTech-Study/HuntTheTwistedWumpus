namespace ConsoleClient.Commands
{
    public class CommandRepository
    {
        List<ICommand> commands;
        public CommandRepository()
        {
            commands = new List<ICommand>();
        }

        public void Add(ICommand command)
        {
            commands.Add(command);
        }

        public List<ICommand> GetAllCommands()
        {
            return commands;
        }
    }
}
