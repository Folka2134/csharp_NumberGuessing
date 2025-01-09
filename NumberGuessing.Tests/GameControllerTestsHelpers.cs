using Moq;
using NumberGuessing.Services;
using NumberGuessing.Views;

public static class GameControllerTestsHelpers
{
    public static Mock<IConsoleView> GetMockView()
    {
        var mock = new Mock<IConsoleView>();
        // Simulate the user entering 10
        mock.SetupSequence(x => x.SetMaxNumber()).Returns("10");
        return mock;
    }

    public static Mock<IGenerateNumber> CreateMockGenerateNumber(int number)
    {
        var mock = new Mock<IGenerateNumber>();
        // Simulate number generation
        mock.Setup(x => x.Generate(It.IsAny<int>())).Returns(number);
        return mock;
    }
}