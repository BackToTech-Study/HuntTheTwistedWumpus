namespace ConsoleClient.Commands
{
    public class WalkToCommand: ICommand
    {
        public string Name { get; set; } = "Walk";
        public void Execute()
        {
            Console.WriteLine(Name + " to cave placeholder");
        }
    }
}
