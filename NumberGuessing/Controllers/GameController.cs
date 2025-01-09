using NumberGuessing.Services;
using NumberGuessing.Views;

namespace NumberGuessing.Controllers
{
    public static class GameMessages
    {
        public const string Welcome = "You ran out of lives!";
        public const string OutOfLives = "You ran out of lives!";
        public const string CorrectNumber = "The number was: {0}";
        public const string Victory = "You got it!";
        public const string Exiting = "Exiting game...";
        public const string InvalidInput = "Invalid input! Please enter a number.";
    }

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
                    _view.DisplayMessage(GameMessages.OutOfLives);
                    _view.DisplayMessage(string.Format(GameMessages.CorrectNumber, randomNumber));
                    break;
                }

                Console.WriteLine();
                _view.DisplayMessage("Guess or Quit");
                var input = _view.UserInput();
                if (input.ToLower() == "quit")
                {
                    _view.DisplayMessage(GameMessages.Exiting);
                    break;
                }

                try
                {
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
                        _view.DisplayMessage(GameMessages.Victory);
                        break;
                    }
                }
                catch (FormatException)
                {
                    _view.DisplayMessage(GameMessages.InvalidInput);
                }
            }
        }
    }
}