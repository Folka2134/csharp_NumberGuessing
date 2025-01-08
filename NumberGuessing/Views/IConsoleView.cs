namespace NumberGuessing.Views
{
    public interface IConsoleView
    {
        void DisplayMessage(string message);
        string UserInput();
        string SetMaxNumber();
    }
}