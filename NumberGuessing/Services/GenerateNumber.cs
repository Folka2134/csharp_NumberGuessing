namespace NumberGuessing.Services
{
    public class GenerateNumber : IGenerateNumber
    {
        private readonly Random _random = new();

        public int Generate(int max)
        {
            return _random.Next(1, max);
        }
    }
}