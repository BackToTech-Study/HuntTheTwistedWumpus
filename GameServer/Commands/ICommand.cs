namespace GameServer.Commands
{
    public interface ICommand
    {
        void Execute(object executor);
    }
}
