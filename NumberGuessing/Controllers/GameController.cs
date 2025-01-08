using NumberGuessing.Services;
using NumberGuessing.Views;

namespace NumberGuessing.Controllers
{
    public class GameController
    {
        private int lives;
        private readonly IConsoleView _view;
        private readonly IGenerateNumber _generator;

        public GameController(IConsoleView view, IGenerateNumber generator)
        {
            lives = 3;
            _view = view;
            _generator = generator;
        }

        public void Run()
        {
            _view.DisplayMessage("Welcome to Number guessing!");
            Console.WriteLine();
            _view.DisplayMessage("Set a maximum number: ");
            int max = int.Parse(_view.SetMaxNumber());
            int randomNumber = _generator.Generate(max);

            while (true)
            {
                if (lives == 0)
                {
                    Console.WriteLine();
                    _view.DisplayMessage("You ran out of lives!");
                    _view.DisplayMessage($"The number was: {randomNumber}");
                    break;
                }

                Console.WriteLine();
                _view.DisplayMessage("Guess or Quit");
                var input = _view.UserInput();
                if (input.ToLower() == "quit")
                {
                    _view.DisplayMessage("Exiting game...");
                    break;
                }

                var guess = int.Parse(input);
                if (guess > randomNumber)
                {
                    _view.DisplayMessage("Too high!");
                    lives--;
                }
                else if (guess < randomNumber)
                {
                    _view.DisplayMessage("Too low!");
                    lives--;
                }
                else
                {
                    _view.DisplayMessage("You got it!");
                    break;
                }
            }
        }
    }
}