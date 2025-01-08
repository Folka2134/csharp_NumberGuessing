namespace NumberGuessing.Views
{
    public class ConsoleView : IConsoleView
    {
        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public string UserInput()
        {
            return Console.ReadLine();
        }
    }
}