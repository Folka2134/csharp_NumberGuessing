using NumberGuessing.Controllers;
using NumberGuessing.Services;
using NumberGuessing.Views;

namespace NumberGuessing
{
    class Program
    {
        static void Main(string[] args)
        {
            IConsoleView view = new ConsoleView();
            IGenerateNumber generator = new GenerateNumber();
            var game = new GameController(view, generator);
            game.Run();
        }
    }
}