using ConsoleClient.Connection;

namespace ConsoleClient.Commands
{
    public class WalkToCommand: ICommand
    {
        private string Name { get; set; } = "";

        public WalkToCommand(string name)
        {
            Name = name;
        }

        public void Execute()
        {
            Console.WriteLine(Name);
        }
    }
}
