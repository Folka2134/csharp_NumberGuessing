using Moq;
using NumberGuessing.Controllers;
using NumberGuessing.Services;
using NumberGuessing.Views;

namespace NumberGuessing.Tests
{
    public class GameControllerTests
    {
        [Fact]
        public void GameDisplaysLossMessageWhenPlayerRunsOutOfLives()
        {
            // Arrange
            var mockView = GameControllerTestsHelpers.GetMockView();
            var mockGenerateNumber = GameControllerTestsHelpers.CreateMockGenerateNumber(5);

            // Simulate user guesses
            mockView.SetupSequence(x => x.UserInput())
                .Returns("8") // First game
                .Returns("2") // Second game
                .Returns("3"); // Third game

            // Initialize game
            var controller = new GameController(mockView.Object, mockGenerateNumber.Object);

            // Act
            controller.Run();

            // Assert you ran out of lives
            mockView.Verify(x => x.DisplayMessage(GameMessages.OutOfLives), Times.Once);
            mockView.Verify(x => x.DisplayMessage("The number was: 5"), Times.Once);
        }

        [Fact]
        public void GameDisplaysVictoryMessageWhenPlayerGuessesCorrectly()
        {
            var mockView = GameControllerTestsHelpers.GetMockView();
            var mockGenerateNumber = GameControllerTestsHelpers.CreateMockGenerateNumber(5);

            // Simulate user guesses
            mockView.SetupSequence(x => x.UserInput())
                .Returns("1")
                .Returns("5");

            var controller = new GameController(mockView.Object, mockGenerateNumber.Object);

            controller.Run();

            mockView.Verify(x => x.DisplayMessage(GameMessages.Victory));
        }

        [Fact]
        public void GameStopsWhenPlayerInputsQuit()
        {
            var mockView = GameControllerTestsHelpers.GetMockView();
            var mockGenerateNumber = GameControllerTestsHelpers.CreateMockGenerateNumber(5);

            // Simulate user guesses
            mockView.SetupSequence(x => x.UserInput())
                .Returns("quit");

            var controller = new GameController(mockView.Object, mockGenerateNumber.Object);

            controller.Run();

            mockView.Verify(x => x.DisplayMessage(GameMessages.Exiting));
        }
        [Fact]
        public void GameDisplaysInvalidInputWhenPlayerDoesNotGuessANumber()
        {
            // Arrange
            var mockView = GameControllerTestsHelpers.GetMockView();
            var mockGenerateNumber = GameControllerTestsHelpers.CreateMockGenerateNumber(5);

            // Simulate invalid input followed by valid input
            mockView.SetupSequence(x => x.UserInput())
                .Returns("invalid") // Invalid input
                .Returns("5");      // Valid input to end the test

            var controller = new GameController(mockView.Object, mockGenerateNumber.Object);

            // Act
            controller.Run();

            // Assert
            mockView.Verify(x => x.DisplayMessage(GameMessages.InvalidInput), Times.Once);
        }
    }

}

