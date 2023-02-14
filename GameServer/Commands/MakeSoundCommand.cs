namespace GameServer.Commands
{
    public class MakeSoundCommand : ICommand
    {
        public string Name { get; set; } = "Make sound";
        public void Execute()
        {
            Console.WriteLine(Name + " placeholder");
        }
    }
}
